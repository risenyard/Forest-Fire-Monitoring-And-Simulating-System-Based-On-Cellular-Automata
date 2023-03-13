using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Controls;
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
    /// <summary>
    /// 选择样式的窗口
    /// </summary>
    public partial class SymbolChoice : Form
    {
        IStyleGalleryItem m_StyleGalleryItem;

        #region 基础功能
        public SymbolChoice()
        {
            InitializeComponent();
        }

        private void SymbolChoice_Load(object sender, EventArgs e)
        {
            //读取ESRI样式库
            string sInstall = ESRI.ArcGIS.RuntimeManager.ActiveRuntime.Path;
            axSymbologyControl1.LoadStyleFile(sInstall + "\\Styles\\ESRI.ServerStyle");
            textBox1.Enabled = false;
        }

        /// <summary>
        /// 获取样式
        /// </summary>
        public IStyleGalleryItem GetItem(ESRI.ArcGIS.Controls.esriSymbologyStyleClass styleClass)
        {
            m_StyleGalleryItem = null;
            button1.Enabled = false;
            axSymbologyControl1.StyleClass = styleClass;//读取传入样式
            axSymbologyControl1.GetStyleClass(styleClass).UnselectItem();
            Visible();
            this.ShowDialog();
            return m_StyleGalleryItem;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            m_StyleGalleryItem = null;
            this.Hide();
        }

        /// <summary>
        /// 抓取样式
        /// </summary>
        private void axSymbologyControl1_OnItemSelected(object sender, ESRI.ArcGIS.Controls.ISymbologyControlEvents_OnItemSelectedEvent e)
        {
            textBox1.Enabled = true;
            m_StyleGalleryItem = axSymbologyControl1.GetStyleClass(axSymbologyControl1.StyleClass).GetSelectedItem();
            ShowAttributes();
            button1.Enabled = true;
        }
        #endregion

        #region 展示格相关
        ///
        ///样式预览函数
        ///
        private void PreviewImage()

        {
            stdole.IPictureDisp picture = this.axSymbologyControl1.GetStyleClass(this.axSymbologyControl1.StyleClass).PreviewItem(m_StyleGalleryItem, this.ptbPreview.Width, this.ptbPreview.Height);
            System.Drawing.Image image = System.Drawing.Image.FromHbitmap(new System.IntPtr(picture.Handle));
            this.ptbPreview.Image = image;
        }


        ///
        ///设置不同情况的可见性
        ///
        private void Visible()
        {
            switch (this.axSymbologyControl1.StyleClass)
            {
                case esriSymbologyStyleClass.esriStyleClassMarkerSymbols:
                    this.lblAngle.Visible = true;
                    this.Angle.Visible = true;
                    this.textBox1.Visible = false;
                    this.Text.Visible = false;
                    break;

                case esriSymbologyStyleClass.esriStyleClassLineSymbols:
                    this.lblAngle.Visible = false;
                    this.Angle.Visible = false;
                    this.textBox1.Visible = false;
                    this.Text.Visible = false;
                    break;

                case esriSymbologyStyleClass.esriStyleClassFillSymbols:
                    this.lblAngle.Visible = false;
                    this.Angle.Visible = false;
                    this.textBox1.Visible = false;
                    this.Text.Visible = false;
                    break;

                case esriSymbologyStyleClass.esriStyleClassTextSymbols:
                    this.lblAngle.Visible = true;
                    this.Angle.Visible = true;
                    this.textBox1.Visible = true;
                    this.Text.Visible = true;
                    break;

                case esriSymbologyStyleClass.esriStyleClassNorthArrows:
                    this.lblAngle.Visible = false;
                    this.Angle.Visible = false;
                    this.textBox1.Visible = false;
                    this.Text.Visible = false;
                    break;

                case esriSymbologyStyleClass.esriStyleClassScaleBars:
                    this.lblAngle.Visible = false;
                    this.Angle.Visible = false;
                    this.textBox1.Visible = false;
                    this.Text.Visible = false;
                    break;


            }

        }

        ///
        ///符号性质展示函数
        ///
        private void ShowAttributes()
        {
            Color color;
            switch (this.axSymbologyControl1.StyleClass)
            {
                //点符号
                case esriSymbologyStyleClass.esriStyleClassMarkerSymbols:
                    color = this.ConvertIRgbColorToColor(((IMarkerSymbol)m_StyleGalleryItem.Item).Color as IRgbColor);
                    //设置点符号角度和大小初始值
                    this.lblAngle.Value = (decimal)((IMarkerSymbol)this.m_StyleGalleryItem.Item).Angle;
                    this.lblSize.Value = (decimal)((IMarkerSymbol)this.m_StyleGalleryItem.Item).Size;
                    break;
                //线符号
                case esriSymbologyStyleClass.esriStyleClassLineSymbols:
                    color = this.ConvertIRgbColorToColor(((ILineSymbol)m_StyleGalleryItem.Item).Color as IRgbColor);
                    //设置线宽初始值
                    this.lblSize.Value = (decimal)((ILineSymbol)this.m_StyleGalleryItem.Item).Width;
                    break;
                //面符号
                case esriSymbologyStyleClass.esriStyleClassFillSymbols:
                    color = this.ConvertIRgbColorToColor(((IFillSymbol)m_StyleGalleryItem.Item).Color as IRgbColor);
                    this.lblSize.Value= (decimal)((IFillSymbol)this.m_StyleGalleryItem.Item).Outline.Width;
                    break;
                //文字
                case esriSymbologyStyleClass.esriStyleClassTextSymbols:
                    color = this.ConvertIRgbColorToColor(((ITextSymbol)m_StyleGalleryItem.Item).Color as IRgbColor);
                    this.lblSize.Value = (decimal)((ITextSymbol)this.m_StyleGalleryItem.Item).Size;
                    this.lblAngle.Value = (decimal)((ITextSymbol)this.m_StyleGalleryItem.Item).Angle;
                    this.textBox1.Text = ((ITextSymbol)this.m_StyleGalleryItem.Item).Text;
                    break;
                //指南针
                case esriSymbologyStyleClass.esriStyleClassNorthArrows:
                    color = this.ConvertIRgbColorToColor(((INorthArrow)m_StyleGalleryItem.Item).Color as IRgbColor);
                    this.lblSize.Value = (decimal)((INorthArrow)this.m_StyleGalleryItem.Item).Size;
                    break;
                //比例尺
                case esriSymbologyStyleClass.esriStyleClassScaleBars:
                    color = this.ConvertIRgbColorToColor(((IScaleBar)m_StyleGalleryItem.Item).BarColor as IRgbColor);
                    this.lblSize.Value = (decimal)((IScaleBar)this.m_StyleGalleryItem.Item).BarHeight;
                    break;

                default:
                    color = this.ConvertIRgbColorToColor(CreateRGBColor(0, 0, 0));
                    break;

            }
            //设置按钮背景色
            this.btnColor.BackColor = color;
            //预览符号
            this.PreviewImage();
        }

        #endregion

        #region 属性修改触发事件

        private void lblSize_ValueChanged(object sender, EventArgs e)
        {
            switch (this.axSymbologyControl1.StyleClass)
            {
                //点符号
                case esriSymbologyStyleClass.esriStyleClassMarkerSymbols:
                    ((IMarkerSymbol)this.m_StyleGalleryItem.Item).Size = (double)this.lblSize.Value;
                    break;
                //线符号
                case esriSymbologyStyleClass.esriStyleClassLineSymbols:
                    ((ILineSymbol)this.m_StyleGalleryItem.Item).Width = (double)this.lblSize.Value;
                    break;
                //面符号
                case esriSymbologyStyleClass.esriStyleClassFillSymbols:
                    ((IFillSymbol)this.m_StyleGalleryItem.Item).Outline.Width = (double)this.lblSize.Value;
                    break;
                //文字
                case esriSymbologyStyleClass.esriStyleClassTextSymbols:
                    ((ITextSymbol)this.m_StyleGalleryItem.Item).Size = (double)this.lblSize.Value;
                    break;
                //指南针
                case esriSymbologyStyleClass.esriStyleClassNorthArrows:
                    ((INorthArrow)this.m_StyleGalleryItem.Item).Size = (double)this.lblSize.Value;
                    break;
                //比例尺
                case esriSymbologyStyleClass.esriStyleClassScaleBars:
                    ((IScaleBar)this.m_StyleGalleryItem.Item).BarHeight = (double)this.lblSize.Value;
                    break;

            }
            this.PreviewImage();
        }

        private void lblAngle_ValueChanged(object sender, EventArgs e)
        {
            switch (this.axSymbologyControl1.StyleClass)
            {
                //点符号
                case esriSymbologyStyleClass.esriStyleClassMarkerSymbols:
                    ((IMarkerSymbol)this.m_StyleGalleryItem.Item).Angle = (double)this.lblSize.Value;
                    break;
                //文字
                case esriSymbologyStyleClass.esriStyleClassTextSymbols:
                    ((ITextSymbol)this.m_StyleGalleryItem.Item).Angle = (double)this.lblSize.Value;
                    break;
            }
            this.PreviewImage();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ((ITextSymbol)this.m_StyleGalleryItem.Item).Text = this.textBox1.Text;
            this.PreviewImage();
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            //调用系统颜色对话框
            if (this.colorDialog1.ShowDialog() == DialogResult.OK)
            {
                //将颜色按钮的背景颜色设置为用户选定的颜色
                this.btnColor.BackColor = this.colorDialog1.Color;
                //设置符号颜色为用户选定的颜色
                switch (this.axSymbologyControl1.StyleClass)
                {
                    //点符号
                    case esriSymbologyStyleClass.esriStyleClassMarkerSymbols:
                        ((IMarkerSymbol)this.m_StyleGalleryItem.Item).Color = this.ConvertColorToIColor(this.colorDialog1.Color);
                        break;
                    //线符号
                    case esriSymbologyStyleClass.esriStyleClassLineSymbols:
                        ((ILineSymbol)this.m_StyleGalleryItem.Item).Color = this.ConvertColorToIColor(this.colorDialog1.Color);
                        break;
                    //面符号
                    case esriSymbologyStyleClass.esriStyleClassFillSymbols:
                        ((IFillSymbol)this.m_StyleGalleryItem.Item).Color = this.ConvertColorToIColor(this.colorDialog1.Color);
                        break;
                    //文字
                    case esriSymbologyStyleClass.esriStyleClassTextSymbols:
                        ((ITextSymbol)this.m_StyleGalleryItem.Item).Color = this.ConvertColorToIColor(this.colorDialog1.Color);
                        break;
                    //指南针
                    case esriSymbologyStyleClass.esriStyleClassNorthArrows:
                        ((INorthArrow)this.m_StyleGalleryItem.Item).Color = this.ConvertColorToIColor(this.colorDialog1.Color);
                        break;
                    //指南针
                    case esriSymbologyStyleClass.esriStyleClassScaleBars:
                        ((IScaleBar)this.m_StyleGalleryItem.Item).BarColor = this.ConvertColorToIColor(this.colorDialog1.Color);
                        break;
                }

                //更新符号预览

                this.PreviewImage();

            }
        }
        #endregion

        #region 颜色相关
        private IRgbColor CreateRGBColor(System.Byte myRed, System.Byte myGreen, System.Byte myBlue)
        {
            IRgbColor rgbColor = new RgbColorClass();
            rgbColor.Red = myRed;
            rgbColor.Green = myGreen;
            rgbColor.Blue = myBlue;
            rgbColor.UseWindowsDithering = true;
            return rgbColor;
        }

        /// <summary>
        /// 将.NET中的Color结构转换至于ArcGIS Engine中的IColor接口
        /// </summary>
        /// <param name="color">.NET中的System.Drawing.Color结构表示ARGB颜色</param>
        /// <returns>IColor</returns>
        public IColor ConvertColorToIColor(Color color)
        {
            IColor pColor = new RgbColorClass();
            pColor.RGB = color.B * 65536 + color.G * 256 + color.R;
            return pColor;
        }

        public Color ConvertIRgbColorToColor(IRgbColor pRgbColor)
        {
            return ColorTranslator.FromOle(pRgbColor.RGB);
        }
        #endregion

        private void Color_Click(object sender, EventArgs e)
        {

        }
    }

}
