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
    public partial class SelectLayer : Form
    {
        List<IRasterLayer> Layers=new List<IRasterLayer>();
        public List<IRasterLayer> outLayers = new List<IRasterLayer>();
        AxMapControl axmapcontrol;
        public SelectLayer(AxMapControl mapcontrol)//构造函数
        {
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
            InitializeComponent();

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

        //确认计算
        private void ConfirmValue_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBoxLayer.SelectedItems.Count; i++)
            {
                IRasterLayer layer = axmapcontrol.get_Layer(listBoxLayer.SelectedIndices[i]) as IRasterLayer;
                outLayers.Add(layer);
            }

            if (outLayers.Count>0)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("没有有效的裁剪结果！");
            }
        }
        #endregion



    }

}

