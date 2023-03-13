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
using ESRI.ArcGIS.SpatialAnalyst;
using ESRI.ArcGIS.GeoAnalyst;

namespace bighm.BasicOptionForm
{
    public partial class SurfaceAnalysis2 : Form
    {
        public SurfaceAnalysis2(IHookHelper hookHelper)
        {
            InitializeComponent();
            m_hookHelper = hookHelper;
            m_activeView = m_hookHelper.ActiveView;
            m_map = m_hookHelper.FocusMap;
        }

        #region 需要的变量定义

        IHookHelper m_hookHelper = null;
        IActiveView m_activeView = null;
        IMap m_map = null;
        private object Missing = Type.Missing;
        private ISurfaceOp surfaceOp;//表面分析对象
        private IGeoDataset inGeodataset;//输入数据
        private IGeoDataset outGeodataset;//输出数据
        private esriGeoAnalysisSlopeEnum slopeEnum;//Slopes输出测量单位
        private ILayer Aspectresult;

        #endregion

        #region 输出结果

        public ILayer GetAspectresult()
        {
            return Aspectresult;
        }
        #endregion

        #region 设置输入栅格
        private void SurfaceAnalysis_Load(object sender, EventArgs e)
        {
            surfaceOp = new RasterSurfaceOpClass();
            RasinputAddItems();//导入combobox的字段
        }

        private void RasinputAddItems()
        {
            if (GetRasLayers() == null) return;
            IEnumLayer layers = GetRasLayers();
            layers.Reset();
            ILayer layer = layers.Next();
            while (layer != null)
            {
                if (layer is IRasterLayer)
                {
                    Rasinputcbb.Items.Add(layer.Name);
                }
                layer = layers.Next();
            }
            Rasinputcbb.SelectedIndex = 0;
        }
        private IEnumLayer GetRasLayers()
        {
            UID uid = new UIDClass();
            uid.Value = "{D02371C7-35F7-11D2-B1F2-00C04F8EDEFF}";// IRasterayer
            if (m_map.LayerCount != 0)
            {
                IEnumLayer layers = m_map.get_Layers(uid, true);
                return layers;
            }
            return null;
        }


        //通过图层名得到图层
        private ILayer getLayerFromName(string layerName)
        {
            ILayer layer;
            for (int i = 0; i < m_map.LayerCount; i++)
            {
                layer = m_map.get_Layer(i);
                if (layerName == layer.Name)
                    return layer;
            }
            return null;
        }
        private void Rasinputcbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ILayer layer = getLayerFromName(Rasinputcbb.SelectedItem.ToString());
                IRasterLayer rasterLayer = layer as IRasterLayer;

                IRaster raster = rasterLayer.Raster;
                inGeodataset = raster as IGeoDataset;
            }
            catch (Exception ex)
            {
                MessageBox.Show("选择图层不是栅格图层！");
            }
        }
        #endregion

        #region 计算坡向
        private void AspectCountbtn_Click(object sender, EventArgs e)
        {
            try
            {
                outGeodataset = surfaceOp.Aspect(inGeodataset);
                Aspectresult = ShowRasterResult(outGeodataset, "Aspect(坡向)");
                this.DialogResult = DialogResult.OK;
            }
            catch { }
        }
        #endregion

        #region 展示计算结果
        //显示栅格结果
        private ILayer ShowRasterResult(IGeoDataset geoDataset, string interType)
        {
            IRasterLayer rasterLayer = new RasterLayerClass();
            IRaster raster = new Raster();
            raster = (IRaster)geoDataset;
            rasterLayer.CreateFromRaster(raster);
            rasterLayer.Name = interType;
            return (ILayer)rasterLayer;
        }
        #endregion

    }
}

