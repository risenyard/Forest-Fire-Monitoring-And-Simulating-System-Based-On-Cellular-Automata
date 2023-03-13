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
    public partial class RasterInf : Form
    {
        public RasterInf(DataTable FT)
        {
            InitializeComponent();
            this.dataGridView1.DataSource = FT;
        }

    }
}
