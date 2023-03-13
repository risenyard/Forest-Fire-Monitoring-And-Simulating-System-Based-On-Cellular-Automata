using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using stdole;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bighm.BasicOptionForm
{
    public partial class RasterRender : Form
    {
        RasterLayer iLayer;
        ISymbologyStyleClass pSymbologyStyleClass;
        IRasterBandCollection rasterBandCollection;
        public RasterRender(RasterLayer iLayer)
        {
            InitializeComponent();
            InitSymbologyControl();
            InitColorRampCombobox();
            this.iLayer = iLayer;
            rasterBandCollection = (IRasterBandCollection)iLayer.Raster;
            //将栅格的各波段名字预设combobox中以供选择
            for (int i = 0; i < rasterBandCollection.Count; i++)
            {
                cb_band.Items.Add(rasterBandCollection.Item(i).Bandname);
                RBox.Items.Add(rasterBandCollection.Item(i).Bandname);
                GBox.Items.Add(rasterBandCollection.Item(i).Bandname);
                BBox.Items.Add(rasterBandCollection.Item(i).Bandname);
            }
            this.cb_band.SelectedIndex = 0;
            this.RBox.SelectedIndex = 0;
            this.GBox.SelectedIndex = 0;
            this.BBox.SelectedIndex = 0;
            this.cb_method.SelectedIndex = 0;
            this.numericUpDown1.Visible = false;

        }

        #region 色带设计

        // combobox重绘
        private void cb_colormap_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            e.Graphics.DrawImage(cb_colormap.Items[e.Index] as Image, e.Bounds);
        }

        // 初始化符号库
        private void InitSymbologyControl()
        {
            //读取ESRI样式库
            string sInstall = ESRI.ArcGIS.RuntimeManager.ActiveRuntime.Path;
            axSymbologyControl1.LoadStyleFile(sInstall + "\\Styles\\ESRI.ServerStyle");
            this.axSymbologyControl1.StyleClass = esriSymbologyStyleClass.esriStyleClassColorRamps;
            //色带另存
            this.pSymbologyStyleClass = axSymbologyControl1.GetStyleClass(esriSymbologyStyleClass.esriStyleClassColorRamps);
        }

        // 初始化色带下拉框
        private void InitColorRampCombobox()
        {
            this.cb_colormap.DrawMode = DrawMode.OwnerDrawFixed;
            this.cb_colormap.DropDownStyle = ComboBoxStyle.DropDownList;
            //绘制色带
            for (int i = 0; i < pSymbologyStyleClass.ItemCount; i++)
            {
                //从另存中读取色带
                IStyleGalleryItem pStyleGalleryItem = pSymbologyStyleClass.GetItem(i);
                IPictureDisp pPictureDisp = pSymbologyStyleClass.PreviewItem(pStyleGalleryItem, cb_colormap.Width, cb_colormap.Height);
                Image image = Image.FromHbitmap(new IntPtr(pPictureDisp.Handle));
                cb_colormap.Items.Add(image);
            }
            cb_colormap.SelectedIndex = 20;
        }

        private void cb_method_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_method.Text == "分级")
            {
                numericUpDown1.Visible = true;
            }
            else
            {
                this.numericUpDown1.Visible = false;
                cb_band.Enabled = true;
            }
                
        }
        #endregion

        #region 单波段栅格渲染

        //确定渲染模式
        private void SetRasterSymbol(IRasterLayer pRasterLayer)
        {
            //获取cb选择的色带序号，根据序号选择色带
            int symbol_index = cb_colormap.SelectedIndex;
            ISymbologyStyleClass symbologyStyleClass = axSymbologyControl1.GetStyleClass(esriSymbologyStyleClass.esriStyleClassColorRamps);
            IStyleGalleryItem mStyleGalleryItem = symbologyStyleClass.GetItem(symbol_index);
            IColorRamp colorramp_select = (IColorRamp)mStyleGalleryItem.Item;

            if (cb_method.Text == "拉伸")
            {
                RasterStretchRender(colorramp_select, pRasterLayer);
            }
            else if (cb_method.Text == "分级")
            {
                int cls_num = Convert.ToInt32(numericUpDown1.Value);
                RasterClassifyRender(colorramp_select, pRasterLayer, cls_num);
            }
            else if (cb_method.Text == "唯一值")
            {
                RasterUniqueRender(colorramp_select, pRasterLayer);
            }
         }



        //拉伸渲染
        private void RasterStretchRender(IColorRamp pColorRamp, IRasterLayer pRasterLayer)
        {
            //渲染器定义
            IRasterStretchColorRampRenderer pSRRender = new RasterStretchColorRampRendererClass();
            pSRRender.BandIndex = cb_band.SelectedIndex;
            IRasterRenderer pRRender = pSRRender as IRasterRenderer;

            //渲染器设置
            pRRender.Raster = pRasterLayer.Raster;
            pRRender.Update();
            pSRRender.ColorRamp = pColorRamp;

            //栅格渲染
            pRasterLayer.Renderer = pRRender;
        }

        //分级渲染
        private void RasterClassifyRender(IColorRamp pColorRamp, IRasterLayer pRasterLayer, int cls_num)
        {
            //渲染器定义
            IRasterClassifyColorRampRenderer pRCRender = new RasterClassifyColorRampRendererClass();
            IRasterRenderer pRRend = pRCRender as IRasterRenderer;

            IRaster pRaster = pRasterLayer.Raster;
            IRasterBandCollection pRBandCol = pRaster as IRasterBandCollection;
            IRasterBand pRBand = pRBandCol.Item(cb_band.SelectedIndex);
            if (pRBand.Histogram == null)
            {
                pRBand.ComputeStatsAndHist();
            }
            //渲染器设置
            pRRend.Raster = pRasterLayer.Raster;
            pRCRender.ClassCount = cls_num;
            pRRend.Update();
            //渲染映射
            double gap = pColorRamp.Size / (cls_num - 1);
            IFillSymbol fillSymbol = new SimpleFillSymbol() as IFillSymbol;
            for (int i = 0; i < pRCRender.ClassCount; i++)
            {
                int index;
                if (i < pRCRender.ClassCount - 1)
                {
                    index = Convert.ToInt32(i * gap);
                }
                else
                {
                    index = pColorRamp.Size - 1;
                }
                fillSymbol.Color = pColorRamp.get_Color(index);
                pRCRender.set_Symbol(i, fillSymbol as ISymbol);
                pRCRender.set_Label(i, pRCRender.get_Break(i).ToString("0.00") + "-" + pRCRender.get_Break(i + 1).ToString("0.00"));
            }
            //栅格渲染
            pRasterLayer.Renderer = pRRend;
        }

        //唯一值渲染
        private void RasterUniqueRender(IColorRamp pColorRamp, IRasterLayer pRasterLayer)
        {
            //渲染器定义
            IRasterUniqueValueRenderer pRURender = new RasterUniqueValueRendererClass();
            IRasterRenderer pRRend = pRURender as IRasterRenderer;

            //渲染器设置
            pRRend.Raster = pRasterLayer.Raster;
            pRRend.Update();

            IUniqueValues uniqueValues = new UniqueValuesClass();
            IRasterCalcUniqueValues calcUniqueValues = new RasterCalcUniqueValuesClass();

            try
            {
                calcUniqueValues.AddFromRaster(pRasterLayer.Raster, cb_band.SelectedIndex, uniqueValues);//计算第n通道的唯一值
                //渲染映射
                double gap = pColorRamp.Size / (uniqueValues.Count - 1);
                IFillSymbol fillSymbol = new SimpleFillSymbol() as IFillSymbol;
                for (int i = 0; i < uniqueValues.Count; i++)
                {
                    int index;
                    if (i < uniqueValues.Count - 1)
                    {
                        index = Convert.ToInt32(i * gap);
                    }
                    else
                    {
                        index = pColorRamp.Size - 1;
                    }
                    fillSymbol.Color = pColorRamp.get_Color(index);
                    pRURender.AddValue(0, i, uniqueValues.get_UniqueValue(i));
                    pRURender.set_Label(0, i, uniqueValues.get_UniqueValue(i).ToString());
                    pRURender.set_Symbol(0, i, fillSymbol as ISymbol);
                }
                //栅格渲染
                pRasterLayer.Renderer = pRRend;
            }
            catch(Exception ex)
            {
                MessageBox.Show("唯一值过多！");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SetRasterSymbol(iLayer);
            this.DialogResult = DialogResult.OK;
        }
        #endregion

        #region 多波段栅格渲染
        //RGB渲染
        private void button2_Click(object sender, EventArgs e)
        {
            //渲染器
            IRasterRGBRenderer2 RasterRGBRenderer2 = new RasterRGBRendererClass();
            IRasterRenderer rasterRenderer = RasterRGBRenderer2 as IRasterRenderer;
            rasterRenderer.Raster = iLayer.Raster;
            rasterRenderer.Update();
            //渲染
            RasterRGBRenderer2.RedBandIndex = RBox.SelectedIndex;
            RasterRGBRenderer2.GreenBandIndex = GBox.SelectedIndex;
            RasterRGBRenderer2.BlueBandIndex = BBox.SelectedIndex;
            rasterRenderer.Update();
            iLayer.Renderer = rasterRenderer;
            this.DialogResult = DialogResult.OK;
        }
        #endregion


    }
}
