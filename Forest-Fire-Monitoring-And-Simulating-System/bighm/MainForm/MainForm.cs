using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Output;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.DataSourcesRaster;
using bighm.Class;
using bighm.BasicOptionForm;
using ESRI.ArcGIS.Geoprocessor;

namespace bighm
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        #region 初始窗口设置
        //弹出窗口
        private IToolbarMenu m_ToolbarMenu;
        //操作图层
        public ILayer HitLayer;
        //两个成图序列
        public double[] timeseries;
        public decimal[] fireseries;

        #region 加载窗体初始化
        private void MainForm_Load(object sender, EventArgs e)
        {
            //TOCControl设置
            axTOCControl1.LabelEdit = esriTOCControlEdit.esriTOCControlManual;

            //ToolBar工具设置
            axToolbarControl1.AddItem("esriControls.ControlsPageZoomInTool", -1, -1,
                true, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl1.AddItem("esriControls.ControlsPageZoomOutTool", -1, -1,
                false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl1.AddItem("esriControls.ControlsPagePanTool", -1, -1, false,
                0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl1.AddItem("esriControls.ControlsPageZoomWholePageCommand", -1,
                -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl1.AddItem("esriControls.ControlsMapZoomInTool", -1, -1, true,
                0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl1.AddItem("esriControls.ControlsMapZoomOutTool", -1, -1,
                false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl1.AddItem("esriControls.ControlsMapPanTool", -1, -1, false,
                0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl1.AddItem("esriControls.ControlsMapFullExtentCommand", -1, -
                1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl1.AddItem("esriControls.ControlsMapZoomToLastExtentBackCommand",
                -1, -1, false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl1.AddItem("esriControls.ControlsMapZoomToLastExtentForwardCommand", 
                -1, -1, false,0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl1.AddItem("esriControls.ControlsMapIdentifyTool", -1, -1,
                true, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl1.AddItem("esriControls.ControlsMapFindCommand", -1, -1,
                false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            axToolbarControl1.AddItem("esriControls.ControlsMapMeasureTool", -1, -1,
                false, 0, esriCommandStyles.esriCommandStyleIconOnly);
            ControlsGraphicElementToolbar command = new ControlsGraphicElementToolbar();
            axToolbarControl1.AddItem(command, -1, -1,
                true, 0, esriCommandStyles.esriCommandStyleIconOnly);

            //ToolBar设置并添加工具条盘
            IToolbarPalette toolbarPalette = new ToolbarPaletteClass();
            toolbarPalette.AddItem("esriControls.ControlsNewMarkerTool", -1, -1);
            toolbarPalette.AddItem("esriControls.ControlsNewLineTool", -1, -1);
            toolbarPalette.AddItem("esriControls.ControlsNewCircleTool", -1, -1);
            toolbarPalette.AddItem("esriControls.ControlsNewEllipseTool", -1, -1);
            toolbarPalette.AddItem("esriControls.ControlsNewRectangleTool", -1, -1);
            toolbarPalette.AddItem("esriControls.ControlsNewPolygonTool", -1, -1);
            axToolbarControl1.AddItem(toolbarPalette, 0, -1, false, 0,
                esriCommandStyles.esriCommandStyleIconOnly);
            
            //关联控件
            axTOCControl1.SetBuddyControl(axMapControl1);
            axToolbarControl1.SetBuddyControl(axMapControl1);

            //设置PageLayout图框

            double width, height;
            axPageLayoutControl1.Page.QuerySize(out width, out height);

            IEnvelope pEnvelop = new EnvelopeClass();
            pEnvelop.PutCoords(0, 0, width, height);
            pEnvelop.Expand(1, 1, true);

            IGraphicsContainer pGraphicsContainer = axPageLayoutControl1.ActiveView as IGraphicsContainer;
            IElement pElement = axPageLayoutControl1.FindElementByName("Layers");//获取PageLayout中的数据框元素
            pElement.Geometry = pEnvelop;
            axPageLayoutControl1.Refresh(esriViewDrawPhase.esriViewGraphics, null, null);

        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl2.SelectedIndex)
            {
                case 0:
                    axToolbarControl1.SetBuddyControl(axMapControl1);
                    break;
                case 1:
                    axToolbarControl1.SetBuddyControl(axPageLayoutControl1);
                    break;
            }
        }
        #endregion

        #region 同步两个窗口
        private void axMapControl1_OnExtentUpdated_1(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            copy(axMapControl1, axPageLayoutControl1);

        }

        private void axMapControl1_OnMapReplaced(object sender, IMapControlEvents2_OnMapReplacedEvent e)
        {
            copy(axMapControl1, axPageLayoutControl1);
        }

        private void copy(AxMapControl axMapControl1,AxPageLayoutControl axPageLayoutControl1)
        {
            IObjectCopy pobjectcopy = new ObjectCopyClass();
            object from = pobjectcopy.Copy(axMapControl1.Map);
            object to = axPageLayoutControl1.ActiveView.FocusMap;
            pobjectcopy.Overwrite(from, ref to);
            axPageLayoutControl1.ActiveView.Refresh();
        }
        #endregion


        #region 颜色相关
        //根据颜色值创建IRgbColor
        private IRgbColor CreateRGBColor(System.Byte myRed, System.Byte myGreen, System.Byte myBlue)
        {
            IRgbColor rgbColor = new RgbColorClass();
            rgbColor.Red = myRed;
            rgbColor.Green = myGreen;
            rgbColor.Blue = myBlue;
            rgbColor.UseWindowsDithering = true;
            return rgbColor;
        }


        #endregion

        #region 与TOCControl交互（以及右键菜单）
        private void axTOCControl1_OnMouseDown(object sender, ITOCControlEvents_OnMouseDownEvent e)
        {
            //TOCcontrol的所有要素声明
            esriTOCControlItem toccItem = esriTOCControlItem.esriTOCControlItemNone;
            ILayer iLayer = null;
            IBasicMap iBasicMap = null;
            object unk = null;
            object data = null;
            //if (e.button == 1)
            //{
            //    //判断鼠标定位地点
            //    axTOCControl1.HitTest(e.x, e.y, ref toccItem, ref iBasicMap, ref iLayer, ref unk, ref data);
            //    //定位到legend
            //    if (toccItem == esriTOCControlItem.esriTOCControlItemHeading)
            //    {
            //        if (iLayer is IRasterLayer)
            //        {
            //            HitLayer = iLayer;
            //            DataTable FT = FL_BuildTable(HitLayer as RasterLayer);
            //            RasterInformation newTable = new RasterInformation(HitLayer as RasterLayer, FT);
            //            newTable.ShowDialog();
            //            axMapControl1.Refresh();
            //            newTable.Dispose();
            //        }
            //    }

            //}
            if (e.button == 2)
            {
                axTOCControl1.HitTest(e.x, e.y, ref toccItem, ref iBasicMap, ref iLayer, ref unk, ref data);
                //判断鼠标单击的事件源是否为图层（也可能是数据框或空白）
                if (toccItem == esriTOCControlItem.esriTOCControlItemLayer)
                {
                    if (iLayer is IRasterLayer)
                    {
                        HitLayer = iLayer;
                        this.TOCcontextMenuStrip1.Show(axTOCControl1, e.x, e.y);
                    }
                }
            }

        }

        private void 删除图层ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < axMapControl1.LayerCount; i++)
            {
                if (axMapControl1.get_Layer(i) == HitLayer)
                {
                    axMapControl1.DeleteLayer(i);
                    copy(axMapControl1, axPageLayoutControl1);
                    axTOCControl1.Update();
                }
            }

        }

        private void 显示属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable FT = FL_BuildTable(HitLayer as RasterLayer);
            RasterInf newTable = new RasterInf(FT);
            newTable.ShowDialog();
            newTable.Dispose();
        }

        private void 渲染ToolStripMenuItem_Click(object sender, EventArgs e)
        {
                RasterRender newTable = new RasterRender(HitLayer as RasterLayer);
            newTable.ShowDialog();
            axMapControl1.Refresh();
            axTOCControl1.Update();
            copy(axMapControl1, axPageLayoutControl1);
            newTable.Dispose();
        }
        #endregion   

        #region 其他杂项
        //放大缩小窗口静止处理
        private void MainForm_ResizeBegin(object sender, EventArgs e)
        {
            //Suppress data redraw and draw bitmap instead.
            axMapControl1.SuppressResizeDrawing(true, 0);
            axPageLayoutControl1.SuppressResizeDrawing(true, 0);

        }
        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            //Stop bitmap draw and draw data.
            axMapControl1.SuppressResizeDrawing(false, 0);
            axPageLayoutControl1.SuppressResizeDrawing(false, 0);
            
        }

        ////设置PageLayout的弹出窗口
        //private void axPageLayoutControl1_OnMouseDown(object sender, IPageLayoutControlEvents_OnMouseDownEvent e)
        //{
        //    //Pop-up the ToolbarMenu
        //    if (e.button == 2)
        //    {
        //        m_ToolbarMenu.PopupMenu(e.x, e.y, axPageLayoutControl1.hWnd);
        //    }
        //}

        //控制TOCControl可编辑
        private void axTOCControl1_OnEndLabelEdit(object sender, ITOCControlEvents_OnEndLabelEditEvent e)
        {
            //If the new label is an empty string,prevent the edit
            if (e.newLabel.Trim() == "")
            {
                e.canEdit = false;
            }
        }
        #endregion


        #region 实时显示地理信息
        //显示鼠标点地理位置
        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {

            if (axMapControl1.LayerCount > 0)
            {
                //当前比例尺
                toolStripStatusLabel1.Text = "   1:" + ((long)axMapControl1.MapScale).ToString() + "  ";
                IProjectedCoordinateSystem pcs = this.axMapControl1.SpatialReference as IProjectedCoordinateSystem;
                //定义点
                double d1, n1, m1, L1, d2, n2, m2, L2;
                WKSPoint pt = new WKSPoint(); //不能用IPoint pt = new PointClass();因为后面的方法只支持WKSPoint
                pt.X = e.mapX;
                pt.Y = e.mapY;
                if (pt.X > 180 || pt.X < -180 || pt.Y > 180 || pt.Y < -180)
                    pcs.Inverse(1, ref pt); //将平面坐标转换为地理坐标                 
                d1 = pt.X / 1;//度的整数部分                 
                n1 = pt.X % 1;//度的小数部分                 
                m1 = (n1 * 60) / 1;//分                 
                L1 = ((n1 * 60) % 1) * 60;//秒                 
                d2 = pt.Y / 1;//纬度的整数部分                 
                n2 = pt.Y % 1;//度的小数部分                 
                m2 = (n2 * 60) / 1;//分  
                string m22;
                if (m2 < 10)
                    m22 = "0" + m2.ToString();
                else
                    m22 = m2.ToString();
                L2 = ((n2 * 60) % 1) * 60;//秒 
                try
                {
                    toolStripStatusLabel2.Text = d1.ToString().Remove(3) + "°" + m1.ToString().Remove(2) + " '" + L1.ToString().Remove(6) + "\"" + "E ";
                    toolStripStatusLabel3.Text = d2.ToString().Remove(2) + "°" + m22.Remove(2) + " '" + L2.ToString().Remove(6) + "\"" + "N ";
                }
                catch (Exception)
                {

                    toolStripStatusLabel2.Text = "0";
                    toolStripStatusLabel3.Text = "0";
                }
            }

        }
        #endregion

        #endregion

        #region 数据输入输出模块

        #region 读取栅格
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //打开栅格
            IRasterWorkspace workspace;
            IWorkspaceFactory wFactory = new RasterWorkspaceFactoryClass();
            //选定工作空间和文件
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "TIF文件(*.tif)|*.tif";
            of.Title = "读取TIF文件";
            of.Multiselect = true;
            if (of.ShowDialog() == DialogResult.OK)
            {
                string[] files = of.FileNames;
                foreach(string file in files)
                {
                    int index = file.LastIndexOf("\\");
                    string path = file.Substring(0, index);
                    string name = file.Substring(index + 1, file.Length - index - 1);
                    workspace = (IRasterWorkspace)wFactory.OpenFromFile(path, 0);
                    IRasterDataset rasterDS = workspace.OpenRasterDataset(name);

                    if (rasterDS != null)
                    {
                        //栅格波段数
                        IRasterBandCollection rasterBandCollection = rasterDS as IRasterBandCollection;
                        //栅格图层创建
                        IRasterDataset2 rasterDataset2 = rasterDS as IRasterDataset2;
                        IRaster raster = rasterDataset2.CreateFullRaster();
                        IRasterLayer pRasterLayer = new RasterLayer();
                        pRasterLayer.CreateFromRaster(raster);
                        //添加图层
                        axMapControl1.AddLayer(pRasterLayer);
                        axPageLayoutControl1.ActiveView.Refresh();
                        axMapControl1.Refresh();

                    }
                }
               
            }

        }

        #endregion

        #region 制图功能组
        private EnumMapSurroundType _enumMapSurType = EnumMapSurroundType.None;
        private IPoint m_MovePt = null;
        private IPoint m_PointPt = null;
        private INewEnvelopeFeedback pNewEnvelopeFeedback;
        private IStyleGalleryItem pStyleGalleryItem;

        #region 添加指北针
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            try
            { 
                _enumMapSurType = EnumMapSurroundType.NorthArrow;
                SymbolChoice SymbolChoicePanel = new SymbolChoice();
                IStyleGalleryItem styleGalleryItem = SymbolChoicePanel.GetItem(esriSymbologyStyleClass.esriStyleClassNorthArrows);
                if (styleGalleryItem == null) return;
                pStyleGalleryItem = styleGalleryItem;
                SymbolChoicePanel.Dispose();
                //mapSurroundFrame.MapSurround = (IMapSurround)markerNorthArrow;
            }
            catch (Exception ex)
            {
            }
        }
        private void addNorthArrow(IPageLayout pPageLayout, IEnvelope pEnv, IActiveView pActiveView)
        {
            IMap pMap = pActiveView.FocusMap;
            IGraphicsContainer pGraphicsContainer = pPageLayout as IGraphicsContainer;
            IMapFrame pMapFrame = pGraphicsContainer.FindFrame(pMap) as IMapFrame;
            if (pStyleGalleryItem == null) return;
            IMapSurroundFrame pMapSurroundFrame = new MapSurroundFrameClass();
            pMapSurroundFrame.MapFrame = pMapFrame;
            INorthArrow pNorthArrow = new MarkerNorthArrowClass();
            pNorthArrow = pStyleGalleryItem.Item as INorthArrow;
            //pNorthArrow.Size = pEnv.Width * 50;
            pMapSurroundFrame.MapSurround = (IMapSurround)pNorthArrow;//根据用户的选取，获取相应的MapSurround            
            IElement pElement = axPageLayoutControl1.FindElementByName("NorthArrows");//获取PageLayout中的指北针元素
            if (pElement != null)
            {
                pGraphicsContainer.DeleteElement(pElement);  //如果存在指北针，删除已经存在的指北针
            }
            IElementProperties pElePro = null;
            pElement = (IElement)pMapSurroundFrame;
            pElement.Geometry = (IGeometry)pEnv;
            pElePro = pElement as IElementProperties;
            pElePro.Name = "NorthArrows";
            pGraphicsContainer.AddElement(pElement, 0);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }
        #endregion

        #region 添加比例尺
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            _enumMapSurType = EnumMapSurroundType.ScaleBar;
            //设置MapSurroundFrame中比例尺的符号
            SymbolChoice SymbolChoicePanel = new SymbolChoice();
            IStyleGalleryItem styleGalleryItem = SymbolChoicePanel.GetItem(esriSymbologyStyleClass.esriStyleClassScaleBars);
            if (styleGalleryItem == null) return;
            pStyleGalleryItem = styleGalleryItem;
            SymbolChoicePanel.Dispose();
        }
        private void makeScaleBar(IActiveView pActiveView, IPageLayout pPageLayout, IEnvelope pEnv)
        {
            IMap pMap = pActiveView.FocusMap;
            IGraphicsContainer pGraphicsContainer = pPageLayout as IGraphicsContainer;
            IMapFrame pMapFrame = pGraphicsContainer.FindFrame(pMap) as IMapFrame;
            if (pStyleGalleryItem == null) return;
            IScaleBar markerSB = (IScaleBar)pStyleGalleryItem.Item;
            //markerSB.Division = 8;
            markerSB.Subdivisions = 3;
            markerSB.LabelFrequency = esriScaleBarFrequency.esriScaleBarMajorDivisions;
            ////设置比例尺文字符号
            //SymbolChoice SymbolChoicePanel2 = new SymbolChoice();
            //IStyleGalleryItem styleGalleryItem2 = SymbolChoicePanel2.GetItem(esriSymbologyStyleClass.esriStyleClassTextSymbols);
            //if (styleGalleryItem2 == null) return;
            //ITextSymbol markerText = (ITextSymbol)styleGalleryItem2.Item;
            //SymbolChoicePanel2.Dispose();
            //markerSB.LabelSymbol = markerText;
            //markerSB.UnitLabelSymbol = markerText;
            //添加到MapSurround
            IMapSurroundFrame pMapSurroundFrame = new MapSurroundFrameClass();
            pMapSurroundFrame.MapFrame = pMapFrame;
            pMapSurroundFrame.MapSurround = (IMapSurround)markerSB;
            //添加为Element
            IElement pElement = axPageLayoutControl1.FindElementByName("ScaleBar");
            if (pElement != null)
            {
                pGraphicsContainer.DeleteElement(pElement);  //删除已经存在的比例尺
            }
            IElementProperties pElePro = null;
            pElement = (IElement)pMapSurroundFrame;
            pElement.Geometry = (IGeometry)pEnv;
            pElePro = pElement as IElementProperties;
            pElePro.Name = "ScaleBar";
            pGraphicsContainer.AddElement(pElement, 0);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }

        #endregion

        #region 添加图例
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            try
            {
                _enumMapSurType = EnumMapSurroundType.Legend;
            }
            catch (Exception ex)
            {

            }
        }

        private void MakeLegend(IActiveView pActiveView, IPageLayout pPageLayout, IEnvelope pEnv)
        {
            UID pID = new UID();
            pID.Value = "esriCarto.Legend";
            IGraphicsContainer pGraphicsContainer = pPageLayout as IGraphicsContainer;
            IMapFrame pMapFrame = pGraphicsContainer.FindFrame(pActiveView.FocusMap) as IMapFrame;
            IMapSurroundFrame pMapSurroundFrame = pMapFrame.CreateSurroundFrame(pID, null);//根据唯一标示符，创建与之对应MapSurroundFrame
            IElement pDeletElement = axPageLayoutControl1.FindElementByName("Legend");//获取PageLayout中的图例元素
            if (pDeletElement != null)
            {
                pGraphicsContainer.DeleteElement(pDeletElement);  //如果已经存在图例，删除已经存在的图例
            }
            //设置MapSurroundFrame背景
            //ISymbolBackground pSymbolBackground = new SymbolBackgroundClass();
            //IFillSymbol pFillSymbol = new SimpleFillSymbolClass();
            //ILineSymbol pLineSymbol = new SimpleLineSymbolClass();
            //pLineSymbol.Color =CreateRGBColor(0, 0, 0);
            //pFillSymbol.Color =CreateRGBColor(240, 240, 240);
            //pLineSymbol.Color = m_OperatePageLayout.GetRgbColor(0, 0, 0);
            //pFillSymbol.Color = m_OperatePageLayout.GetRgbColor(240, 240, 240);
            //pFillSymbol.Outline = pLineSymbol;
            //pSymbolBackground.FillSymbol = pFillSymbol;
            //pMapSurroundFrame.Background = pSymbolBackground;
            //添加图例
            IElement pElement = pMapSurroundFrame as IElement;
            pElement.Geometry = pEnv as IGeometry;
            IMapSurround pMapSurround = pMapSurroundFrame.MapSurround;
            ILegend pLegend = pMapSurround as ILegend;
            pLegend.ClearItems();
            pLegend.Title = "图例";
            for (int i = 0; i < pActiveView.FocusMap.LayerCount; i++)
            {
                ILegendItem pLegendItem = new HorizontalLegendItemClass();
                pLegendItem.Layer = pActiveView.FocusMap.get_Layer(i);//获取添加图例关联图层             
                pLegendItem.ShowDescriptions = false;
                pLegendItem.Columns = 1;
                pLegendItem.ShowHeading = true;
                pLegendItem.ShowLabels = true;
                pLegend.AddItem(pLegendItem);//添加图例内容
            }
            pGraphicsContainer.AddElement(pElement, 0);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }
        #endregion

        #region 添加标题
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            try
            {
                _enumMapSurType = EnumMapSurroundType.Title;
                SymbolChoice SymbolChoicePanel = new SymbolChoice();
                IStyleGalleryItem styleGalleryItem = SymbolChoicePanel.GetItem(esriSymbologyStyleClass.esriStyleClassTextSymbols);
                if (styleGalleryItem == null) return;
                pStyleGalleryItem = styleGalleryItem;
                SymbolChoicePanel.Dispose();
            }
            catch (Exception ex)
            {
            }
        }

        private void MakeTitle(IPageLayout pPageLayout, IEnvelope pEnv, IActiveView pActiveView)
        {
            IMap pMap = pActiveView.FocusMap;
            IGraphicsContainer pGraphicsContainer = pPageLayout as IGraphicsContainer;
            IMapFrame pMapFrame = pGraphicsContainer.FindFrame(pMap) as IMapFrame;
            if (pStyleGalleryItem == null) return;
            IMapSurroundFrame pMapSurroundFrame = new MapSurroundFrameClass();
            pMapSurroundFrame.MapFrame = pMapFrame;
            ITextElement txtElement = new TextElementClass();
            ITextSymbol pTextSymbol = (ITextSymbol)pStyleGalleryItem.Item;//Text的符号样式
            txtElement.Text = pTextSymbol.Text;
            txtElement.Symbol = pTextSymbol;
            //pMapSurroundFrame.MapSurround = (IMapSurround)pTextSymbol;//根据用户的选取，获取相应的MapSurround            

            //IElementProperties pElePro = null;
            //pElement = (IElement)pMapSurroundFrame;
            //pElement.Geometry = (IGeometry)pEnv;
            //pElePro = pElement as IElementProperties;


            IElement pElement = txtElement as IElement;
            pElement.Geometry = (IGeometry)pEnv;
            pGraphicsContainer.AddElement(pElement, 0);
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        }
        #endregion

        #region 确定添加框架

        //通过OnMouseDown事件，产生矩形框的第一个点
        private void axPageLayoutControl1_OnMouseDown(object sender, IPageLayoutControlEvents_OnMouseDownEvent e)
        {
            try
            {
                if (_enumMapSurType != EnumMapSurroundType.None)
                {
                    IActiveView pActiveView = null;
                    pActiveView = axPageLayoutControl1.PageLayout as IActiveView;
                    m_PointPt = pActiveView.ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);
                    if (pNewEnvelopeFeedback == null)
                    {
                        pNewEnvelopeFeedback = new NewEnvelopeFeedbackClass();
                        pNewEnvelopeFeedback.Display = pActiveView.ScreenDisplay;
                        pNewEnvelopeFeedback.Start(m_PointPt);
                    }
                    else
                    {
                        pNewEnvelopeFeedback.MoveTo(m_PointPt);
                    }

                }
            }
            catch
            {
            }
        }
        private void axPageLayoutControl1_OnMouseMove(object sender, IPageLayoutControlEvents_OnMouseMoveEvent e)
        {
            try
            {
                if (_enumMapSurType != EnumMapSurroundType.None)
                {
                    if (pNewEnvelopeFeedback != null)
                    {
                        m_MovePt = (axPageLayoutControl1.PageLayout as IActiveView).ScreenDisplay.DisplayTransformation.ToMapPoint(e.x, e.y);
                        pNewEnvelopeFeedback.MoveTo(m_MovePt);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            //显示当前地理位置
            if (axPageLayoutControl1.ActiveView.FocusMap.LayerCount > 0)
            {
                //当前比例尺
                toolStripStatusLabel1.Text = "   1:" + ((long)axPageLayoutControl1.ActiveView.FocusMap.MapScale).ToString() + "  ";
                IProjectedCoordinateSystem pcs = this.axPageLayoutControl1.ActiveView.FocusMap.SpatialReference as IProjectedCoordinateSystem;
                //定义点
                IScreenDisplay screenDisplay = axMapControl1.ActiveView.ScreenDisplay;
                IDisplayTransformation displayTransformation = screenDisplay.DisplayTransformation;
                IPoint pt = new PointClass();
                pt = displayTransformation.ToMapPoint((System.Int32)e.x, (System.Int32)e.y);

                double d1, n1, m1, L1, d2, n2, m2, L2;
                WKSPoint pt2 = new WKSPoint(); //不能用IPoint pt = new PointClass();因为后面的方法只支持WKSPoint
                pt2.X = pt.X;
                pt2.Y = pt.Y;
                if (pt2.X > 180 || pt2.X < -180 || pt2.Y > 180 || pt2.Y < -180)
                    pcs.Inverse(1, ref pt2); //将平面坐标转换为地理坐标                 
                d1 = pt2.X / 1;//度的整数部分                 
                n1 = pt2.X % 1;//度的小数部分                 
                m1 = (n1 * 60) / 1;//分                 
                L1 = ((n1 * 60) % 1) * 60;//秒                 
                d2 = pt2.Y / 1;//纬度的整数部分                 
                n2 = pt2.Y % 1;//度的小数部分                 
                m2 = (n2 * 60) / 1;//分  
                string m22;
                if (m2 < 10)
                    m22 = "0" + m2.ToString();
                else
                    m22 = m2.ToString();
                L2 = ((n2 * 60) % 1) * 60;//秒 
                try
                {
                    toolStripStatusLabel2.Text = d1.ToString().Remove(3) + "°" + m1.ToString().Remove(2) + " '" + L1.ToString().Remove(6) + "\"" + "E ";
                    toolStripStatusLabel3.Text = d2.ToString().Remove(2) + "°" + m22.Remove(2) + " '" + L2.ToString().Remove(6) + "\"" + "N ";
                }
                catch (Exception)
                {
                    toolStripStatusLabel2.Text = "0";
                    toolStripStatusLabel3.Text = "0";
                }
            }

        }

        //通过OnMouseUp事件，产生矩形框的第一个点的对焦点，返回一个矩形，并将制图要素添加到该矩形中
        private void axPageLayoutControl1_OnMouseUp(object sender, IPageLayoutControlEvents_OnMouseUpEvent e)
        {
            if (_enumMapSurType != EnumMapSurroundType.None)
            {
                if (pNewEnvelopeFeedback != null)
                {
                    IActiveView pActiveView = null;
                    pActiveView = axPageLayoutControl1.PageLayout as IActiveView;
                    IEnvelope pEnvelope = pNewEnvelopeFeedback.Stop();
                    AddMapSurround(pActiveView, _enumMapSurType, pEnvelope);
                    pNewEnvelopeFeedback = null;
                    _enumMapSurType = EnumMapSurroundType.None;
                }
            }
        }

        /// 添加地图整饰要素
        private void AddMapSurround(IActiveView pAV, EnumMapSurroundType _enumMapSurroundType, IEnvelope pEnvelope)
        {
            try
            {
                switch (_enumMapSurroundType)
                {
                    case EnumMapSurroundType.NorthArrow:
                        addNorthArrow(axPageLayoutControl1.PageLayout, pEnvelope, pAV);
                        break;
                    case EnumMapSurroundType.ScaleBar:
                        makeScaleBar(pAV, axPageLayoutControl1.PageLayout, pEnvelope);
                        break;
                    case EnumMapSurroundType.Legend:
                        MakeLegend(pAV, axPageLayoutControl1.PageLayout, pEnvelope);
                        break;
                    case EnumMapSurroundType.Title:
                        MakeTitle(axPageLayoutControl1.PageLayout, pEnvelope,pAV);
                        break;
                }
            }
            catch (Exception ex)
            {
            }
        }




        #endregion

        #region 导出地图
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ExportMapToImage();
        }
        private void ExportMapToImage()
        {
            try
            {
                SaveFileDialog m_save = new SaveFileDialog();
                m_save.Filter = "jpeg图片(*.jpg)|*.jpg|tiff图片(*.tif)|*.tif|bmp图片(*.bmp)|*.bmp|emf图片(*.emf)|*.emf|png图片(*.png)|*.png|gif图片(*.gif)|*.gif";
                m_save.ShowDialog();
                string Outpath = m_save.FileName;
                if (Outpath != "")
                {
                    //分辨率
                    double resolution = axPageLayoutControl1.ActiveView.ScreenDisplay.DisplayTransformation.Resolution;
                    IExport m_export = null;
                    if (Outpath.EndsWith(".jpg"))
                    {
                        m_export = new ExportJPEG() as IExport;

                    }
                    else if (Outpath.EndsWith(".tig"))
                    {
                        m_export = new ExportTIFF() as IExport;

                    }
                    else if (Outpath.EndsWith(".bmp"))
                    {
                        m_export = new ExportBMP() as IExport;

                    }
                    else if (Outpath.EndsWith(".emf"))
                    {
                        m_export = new ExportEMF() as IExport;
                    }
                    else if (Outpath.EndsWith(".png"))
                    {
                        m_export = new ExportPNG() as IExport;
                    }
                    else if (Outpath.EndsWith(".gif"))
                    {
                        m_export = new ExportGIF() as IExport;
                    }
                    //设置输出的路径
                    m_export.ExportFileName = Outpath;
                    //设置输出的分辨率
                    m_export.Resolution = 300;
                    IActiveView activeView = this.axPageLayoutControl1.PageLayout as IActiveView;
                    tagRECT piexPound = activeView.ScreenDisplay.DisplayTransformation.get_DeviceFrame();
                    //设置输出的IEnvelope
                    IEnvelope m_envelope = new Envelope() as IEnvelope;
                    m_envelope.PutCoords(piexPound.left, piexPound.bottom, piexPound.right, piexPound.top);
                    m_export.PixelBounds = m_envelope;

                    ITrackCancel m_trackCancel = new CancelTracker();
                    //输出的方法
                    axPageLayoutControl1.ActiveView.Output(m_export.StartExporting(), (short)resolution, ref piexPound, activeView.Extent, m_trackCancel);
                    m_export.FinishExporting();
                }

            }
            catch (Exception Err)
            {
                MessageBox.Show(Err.Message, "输出图片", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        #endregion

        //#region 载入模板
        //private void UsingTemplate_Click(object sender, EventArgs e)
        //{
        //    frmTemplate fTemplate = new frmTemplate(axPageLayoutControl1);
        //    fTemplate.Show();
        //}
        //#endregion

        #endregion

        #endregion

        #region 构造栅格信息表

        private DataTable FL_BuildTable(RasterLayer layer)
        {
            //创建DataTable，以图层名命名
            DataTable Table = new DataTable(layer.Name);
            //获取图层的栅格信息
            IRaster raster = layer.Raster;         
            IGeoDataset geoDS = raster as IGeoDataset;
            IRasterProps rasterProps = (IRasterProps)raster;
            IRasterBandCollection rasterBandCollection = (IRasterBandCollection)raster;
            IRasterBand rasterBand = rasterBandCollection.Item(0);
            IRasterDataset rasterDS = rasterBand as IRasterDataset;
            //创建DataTable
            DataColumn namefield = new DataColumn();
            namefield.ColumnName = "属性";
            namefield.DataType = System.Type.GetType("System.String");
            DataColumn valuefield = new DataColumn();
            valuefield.ColumnName = "值";
            valuefield.DataType = System.Type.GetType("System.String");
            Table.Columns.Add(namefield);
            Table.Columns.Add(valuefield);

            //填充DataTable
            Table = AddRowValue(Table, "栅格行数和列数", rasterProps.Height + "," + rasterProps.Width);
            Table = AddRowValue(Table, "栅格单元宽度", rasterProps.MeanCellSize().X.ToString());
            Table = AddRowValue(Table, "栅格单元高度", rasterProps.MeanCellSize().Y.ToString());
            Table = AddRowValue(Table, "栅格文件类型", rasterDS.Format);
            Table = AddRowValue(Table, "波段数", rasterBandCollection.Count.ToString());
            Table = AddRowValue(Table, "像元类型", rasterProps.PixelType.ToString());
            Table = AddRowValue(Table, "缺损值", rasterProps.NoDataValue.ToString());
            Table = AddRowValue(Table, "压缩类型", rasterDS.CompressionType);
            Table = AddRowValue(Table, "文件路径", rasterDS.CompleteName);
            Table = AddRowValue(Table, "空间参考", geoDS.SpatialReference.Name);
            Table = AddRowValue(Table, "范围（顶部）",rasterProps.Extent.YMax.ToString());
            Table = AddRowValue(Table, "范围（底部）", rasterProps.Extent.YMin.ToString());
            Table = AddRowValue(Table, "范围（右部）", rasterProps.Extent.XMax.ToString());
            Table = AddRowValue(Table, "范围（左部）", rasterProps.Extent.XMin.ToString());
            for (int i = 0; i < rasterBandCollection.Count; i++)
            {
                int number = i + 1;
                IRasterBand rBand = rasterBandCollection.Item(i);
                IRasterStatistics sta = rBand.Statistics;               
                //bool hasStatistics;
                //rasterBand.HasStatistics(out hasStatistics);
                if (sta==null)
                {
                    //计算栅格统计值
                    rBand.ComputeStatsAndHist();
                }
                sta = rBand.Statistics;

                Table = AddRowValue(Table, "波段"+number+"名称", rasterBandCollection.Item(i).Bandname);
                Table = AddRowValue(Table, "波段" + number + "最大值,最小值和均值", sta.Maximum+","+ sta.Minimum+","+sta.Mean);
            }
            //返回表
            return Table;
        }

        private DataTable AddRowValue(DataTable Table,string name,string value)
        {
            DataRow dataRow = Table.NewRow();
            dataRow[0] = name;
            dataRow[1] = value;
            Table.Rows.Add(dataRow);
            return Table;
        }



        /////空值处理
        //private IGeoDataset Null2Number(IGeoDataset pRaster)
        //{
        //    //检查出为空的位置（null区位1，非null区为0）
        //    string isNullPath = System.IO.Path.Combine(Application.StartupPath, "isnull.tif");
        //    Geoprocessor gp = new Geoprocessor();    //初始化Geoprocessor
        //    gp.OverwriteOutput = true;                     //允许运算结果覆盖现有文件
        //    ESRI.ArcGIS.SpatialAnalystTools.IsNull isnullgp = new ESRI.ArcGIS.SpatialAnalystTools.IsNull();
        //    isnullgp.in_raster = pRaster;
        //    isnullgp.out_raster = isNullPath;
        //    gp.Execute(isnullgp, null);

        //    //将空（即是1）的设为0，其余设为原始值
        //    Geoprocessor gp1 = new Geoprocessor();
        //    gp1.OverwriteOutput = true;                   
        //    ESRI.ArcGIS.SpatialAnalystTools.Con congp = new ESRI.ArcGIS.SpatialAnalystTools.Con();
        //    congp.in_conditional_raster = isNullPath;
        //    congp.where_clause = "Value = 1";//value=1的地方即是查询出来的Null的地方
        //    congp.in_false_raster_or_constant = pRaster;
        //    congp.in_true_raster_or_constant =0;//将null改为0或其他值
        //    gp1.Execute(congp, null);
        //    return pRaster;
        //}

        #endregion

        #region 栅格分析模块


        //栅格裁剪
        private void clipRaster_Click(object sender, EventArgs e)
        {
            //裁剪框
            IGraphicsContainerSelect gcs = axMapControl1.Map as IGraphicsContainerSelect;
            if (gcs.ElementSelectionCount == 0)
            {
                MessageBox.Show("当前没有选择任何Element！请先选取。");
                return;
            }
            IElement el = gcs.SelectedElement(0);
            IEnvelope geo = el.Geometry.Envelope;
            //裁剪图层
            SelectLayer sl = new SelectLayer(axMapControl1);
            if (sl.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < sl.outLayers.Count; i++)
                {
                    IRasterLayer outLayer = RasterManage.RasterClip(sl.outLayers[i], geo);
                    outLayer.Name = sl.outLayers[i].Name + "[裁剪后]";
                    axMapControl1.AddLayer(outLayer);
                }
            }

        }

        //NDVI
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            NDVI cal = new NDVI(axMapControl1);
            if (cal.ShowDialog()==DialogResult.OK)
            {
                axMapControl1.AddLayer(cal.outLayer);
                axMapControl1.Refresh();
                copy(axMapControl1, axPageLayoutControl1);
                axTOCControl1.Update();
            }
            
        }

        //栅格计算器
        private void pictureBox8_Click(object sender, EventArgs e)
        {
            RasterCalculator cal = new RasterCalculator(axMapControl1);
            if (cal.ShowDialog() == DialogResult.OK)
            {
                axMapControl1.AddLayer(cal.outLayer);
                axMapControl1.Refresh();
                copy(axMapControl1, axPageLayoutControl1);
                axTOCControl1.Update();
            }
        }

        //计算坡度
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            axMapControl1.Map.ClearSelection();
            IHookHelper m_hookHelper = new HookHelperClass();
            m_hookHelper.Hook = this.axMapControl1.Object;
            if (m_hookHelper == null) return;
            if (m_hookHelper.FocusMap.LayerCount > 0)
            {
                try
                {
                    SurfaceAnalysis surfaceAnalysis = new SurfaceAnalysis(m_hookHelper);
                    surfaceAnalysis.ShowDialog(m_hookHelper as System.Windows.Forms.IWin32Window);
                    if (surfaceAnalysis.DialogResult==DialogResult.OK)
                    {
                        ILayer aspectLayer = surfaceAnalysis.GetSloperesult();
                        axMapControl1.AddLayer((ILayer)aspectLayer, 0);
                        axMapControl1.ActiveView.Refresh();
                        copy(axMapControl1, axPageLayoutControl1);
                        axTOCControl1.Update();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("计算出错！");
                }
            }
        }
        //计算坡向
        private void pictureBox10_Click(object sender, EventArgs e)
        {
            axMapControl1.Map.ClearSelection();
            IHookHelper m_hookHelper = new HookHelperClass();
            m_hookHelper.Hook = this.axMapControl1.Object;
            if (m_hookHelper == null) return;
            if (m_hookHelper.FocusMap.LayerCount > 0)
            {
                try
                {
                    SurfaceAnalysis2 surfaceAnalysis = new SurfaceAnalysis2(m_hookHelper);
                    surfaceAnalysis.ShowDialog(m_hookHelper as System.Windows.Forms.IWin32Window);
                    if (surfaceAnalysis.DialogResult == DialogResult.OK)
                    {
                        ILayer aspectLayer = surfaceAnalysis.GetAspectresult();
                        axMapControl1.AddLayer((ILayer)aspectLayer, 0);
                        axMapControl1.ActiveView.Refresh();
                        copy(axMapControl1, axPageLayoutControl1);
                        axTOCControl1.Update();
                    }
                       
                }
                catch (Exception ex)
                {
                    MessageBox.Show("计算出错！");
                }
            }
        }
        #endregion

        #region 林火模块

        //元胞自动机林火管理(CA)
        private void 林火管理_Click(object sender, EventArgs e)
        {
            CA cv = new CA(axMapControl1);
            if (cv.ShowDialog()==DialogResult.OK)
            {
                axMapControl1.AddLayer(cv.outLayers);
                timeseries = cv.timeseries;
                fireseries = cv.fireseries;
            }
            
        }

        //求取CFDA
        private void pictureBox11_Click(object sender, EventArgs e)
        {
            CFDA cv = new CFDA(axMapControl1);
            if (cv.ShowDialog() == DialogResult.OK)
            {
                axMapControl1.AddLayer(cv.outLayers);
            }
        }

        //可视化成图
        private void pictureBox12_Click(object sender, EventArgs e)
        {
            VisualForm newform = new VisualForm(timeseries, fireseries);
            newform.ShowDialog();
        }


        #endregion

        #region 程序版本信息
        //关于
        private void iconButton1_Click(object sender, EventArgs e)
        {
            string text = "程序简介：该程序基于栅格处理和元胞自动机算法进行林火检测与模拟;\n" +
                "版本更新情况：版本号 0.8 更新于2021/07/08;\n" +
                "本软件由奇妙森林的光颖传说小组全权开发，最终解释权归该小组所有，\n对于软件盗用保留追究及其他一切权利;";
            string caption = "关于软件";
            MessageBox.Show(text,caption);
        }

        #endregion

        #region 损失评估
        private void Lossassesspcb_Click(object sender, EventArgs e)
        {
            LossassessForm lossassessForm = new LossassessForm();
            lossassessForm.ShowDialog();
        }
        #endregion
    }
}
