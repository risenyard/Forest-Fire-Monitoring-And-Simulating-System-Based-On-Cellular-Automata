using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.SpatialAnalyst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bighm.Class
{
    static class RasterManage
    {
		public static IRasterLayer RasterClip(IRasterLayer pRasterLayer, IEnvelope clipGeo)
        {
			// IExtractionOp
			IExtractionOp extraction = new RasterExtractionOpClass();
			try
			{
			
				IGeoDataset geoDataset = extraction.Rectangle((IGeoDataset)pRasterLayer.Raster, clipGeo, true);
				IRaster raster = geoDataset as IRaster;
				if (raster != null)
				{
					IRasterLayer outLayer = new RasterLayerClass();
					outLayer.CreateFromRaster(raster);
					return outLayer;
				}
				else
                {
					MessageBox.Show("没有栅格值");
					return null;
                }
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
				return null;
			}
		}

    }
}
