using bighm.Class;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bighm.BasicOptionForm
{   
    public partial class CFDA : Form
    {
        List<IRasterLayer> Layers = new List<IRasterLayer>();
        List<ComboBox> cb_box ;
        public IRasterLayer outLayers;
        AxMapControl axmapcontrol;

        //初始化
        public CFDA(AxMapControl mapcontrol)
        {
            InitializeComponent();
            cb_box = new List<ComboBox>() { cb_background, cb_ch2, cb_ch3,cb_ch4, cb_ch5};
            axmapcontrol = mapcontrol;
            for (int i = 0; i < mapcontrol.LayerCount; i++)
            {
                ILayer layer = axmapcontrol.get_Layer(i);
                if (layer is IRasterLayer)
                {
                    IRasterLayer newLayer = layer as IRasterLayer;
                    Layers.Add(newLayer);
                }
            }
            foreach (ComboBox cb in cb_box)
                FillinItems(cb, Layers);
            
        }

        //填充选项函数
        private void FillinItems(ComboBox cb, List<IRasterLayer> Layers)
        {
            for (int i = 0; i < Layers.Count; i++)
            {
                cb.Items.Add(Layers[i].Name);
                cb.SelectedIndex = 0;
            }
        }

        //获取double数组
        private double[,] Raster2Double(IRasterLayer layer)
        {
            //摘除无效（为0）-转化为array
            IGeoDataset geodataset= layer.Raster as IGeoDataset;
            geodataset = RasterArray.ProNoDataRaster(geodataset);
            System.Array arr = RasterArray.RasterToArray(geodataset);

            // 获取double的array
            int x = arr.GetLength(0);
            int y = arr.GetLength(1);
            double[,] newarr = new double[x, y];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    // 这一点的像素值
                    double pixelvalue = Convert.ToDouble(arr.GetValue(i, j));
                    newarr[i, j] = Convert.ToDouble(pixelvalue);
                }
            }
            return newarr;
        }
        
        //返回图层
        private IRasterLayer outToLayer(IRasterLayer model,double[,] arr)
        {
            //拷贝新图层
            IGeoDataset modelset = model.Raster as IGeoDataset;
            IGeoDataset newset = RasterArray.CopyGeoDataset(modelset);
            newset = RasterArray.ProNoDataRaster(newset);
            // 转化double到float
            int x = arr.GetLength(0);
            int y = arr.GetLength(1);
            float[,] newarr = new float[x, y];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    // 这一点的像素值
                    float pixelvalue = Convert.ToSingle(arr.GetValue(i, j));
                    newarr[i, j] = (pixelvalue);
                }
            }
            // 让二维数组arr生成栅格数据(单波段、同类型）  
            IGeoDataset aod = RasterArray.AlterRasterArray(newset,newarr); //修改pGeo中的矩阵数组
            IRasterLayer outLayer = new RasterLayerClass();
            outLayer.CreateFromRaster(aod as IRaster);
            return outLayer;
        }

        //获取背景值
        private double[,] GetBackGround(double[,] arr)
        {
            // 获取double的array
            int x = arr.GetLength(0);
            int y = arr.GetLength(1);
            double[,] newarr = new double[x, y];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == -99)
                        newarr[i, j] = 0;
                    else
                        newarr[i, j] = 1;
                }
            }
            return newarr;
        }

        //开始运算
        private void iconButton1_Click(object sender, EventArgs e)
        {
            //转化为double数组
            List<double[,]> doubleteam = new List<double[,]>();
            foreach (ComboBox cb in cb_box)
            {
                double[,] newmat = Raster2Double(Layers[cb.SelectedIndex]);
                doubleteam.Add(newmat);
            }
            //获得背景值数组
            double[,] background = GetBackGround(doubleteam[0]);
            //元胞运算
            CFDAMethods calculateCFDA = new CFDAMethods();
            double[,] CFDAresult = calculateCFDA.CFDA_double(background, doubleteam[1], doubleteam[2], doubleteam[3], doubleteam[4]);
            //输出图层
            if (CFDAresult != null)
            {
                outLayers = outToLayer(Layers[Layers.Count - 1], CFDAresult);
                this.DialogResult = DialogResult.OK;
            }     
        }

    }
}
