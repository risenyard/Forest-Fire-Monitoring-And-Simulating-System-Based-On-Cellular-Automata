using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.SpatialAnalyst;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bighm.BasicOptionForm
{
    public partial class NDVI : Form
    {
        public IRasterLayer outLayer;
        List<IRasterLayer> Layers=new List<IRasterLayer>();

        public NDVI(AxMapControl mapcontrol)//构造函数
        {
            for (int i = 0; i < mapcontrol.LayerCount; i++)
            {
                ILayer layer = mapcontrol.get_Layer(i);
                if (layer is IRasterLayer)
                {
                    IRasterLayer newLayer = layer as IRasterLayer;
                    Layers.Add(newLayer);
                }
            }
            InitializeComponent();
            ConfirmValue.Enabled = false;

            for (int i = 0; i < Layers.Count; i++)
            {
                listBoxLayer.Items.Add(Layers[i].Name);
                listBoxLayer.SelectedIndex = 0;
            }
            
        }

        #region 求NDVI

        //关闭窗口
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //可选波段函数
        private void listBoxLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxBandNIR.Items.Clear();
            listBoxBandR.Items.Clear();
            IRasterBandCollection rasterBandCollection = (IRasterBandCollection)Layers[listBoxLayer.SelectedIndex].Raster;
            for (int i = 0; i < rasterBandCollection.Count; i++)
            {
                listBoxBandNIR.Items.Add(rasterBandCollection.Item(i).Bandname);
                listBoxBandR.Items.Add(rasterBandCollection.Item(i).Bandname);
            }
            listBoxBandNIR.SelectedIndex = 0;
            listBoxBandR.SelectedIndex = 0;
            ConfirmValue.Enabled = true;
        }

        //确认计算
        private void ConfirmValue_Click(object sender, EventArgs e)
        {
            // 栅格计算器
            IMapAlgebraOp pRSalgebra = new RasterMapAlgebraOpClass();
            // 从波段集中获取单个波段
            IRasterBandCollection rb = (IRasterBandCollection)Layers[listBoxLayer.SelectedIndex].Raster;
            IGeoDataset NIR = rb.Item(listBoxBandNIR.SelectedIndex) as IGeoDataset;
            IGeoDataset R = rb.Item(listBoxBandR.SelectedIndex) as IGeoDataset;
            pRSalgebra.BindRaster(NIR, "NIR");
            pRSalgebra.BindRaster(R, "R");
            String strOut = "float([NIR] - [R]) / ([NIR] + [R])";
            try
            {
                // 执行
                IGeoDataset pOutGeo = pRSalgebra.Execute(strOut);
                // 将矩阵GeoDataset转成栅格集
                IRasterBandCollection irbc = (IRasterBandCollection)pOutGeo;
                IRasterDataset pRD = irbc.Item(0).RasterDataset;
                //rastDataset_savi = pRD;

                outLayer = new RasterLayerClass();
                outLayer.CreateFromRaster(pOutGeo as IRaster);
                this.DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show("输入情况出错");
            }
        }
        #endregion



    }

}

