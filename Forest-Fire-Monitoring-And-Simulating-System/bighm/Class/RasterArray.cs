using ESRI.ArcGIS.DataSourcesRaster;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.SpatialAnalyst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bighm.Class
{
    static class RasterArray
    {

        //栅格转数组
        public static System.Array RasterToArray(IGeoDataset pGD)
        {
            //, ref object novalue
            IRaster raster = pGD as IRaster;
            IRasterProps props = (IRasterProps)raster;
            //novalue = props.NoDataValue;
            IPnt pBlockSize = new PntClass();
            pBlockSize.SetCoords((double)props.Width, (double)props.Height);
            IRaster2 raster2 = (IRaster2)raster;
            IPixelBlock pixelBlock = raster2.CreateCursorEx(pBlockSize).PixelBlock;
            pBlockSize.SetCoords(0.0, 0.0);
            raster.Read(pBlockSize, pixelBlock);
            IPixelBlock3 block3 = (IPixelBlock3)pixelBlock;
            return (System.Array)block3.get_PixelData(0);
        }

        //根据数组新值构造栅格
        public static IGeoDataset AlterRasterArray(IGeoDataset pGeo, Array arr)
        {
            try
            {
                IRaster raster = pGeo as IRaster;
                IRasterProps props = (IRasterProps)raster;
                IPnt pBlockSize = new PntClass();
                pBlockSize.SetCoords((double)props.Width, (double)props.Height);
                IRaster2 raster2 = (IRaster2)raster;
                IPixelBlock pixelBlock = raster2.CreateCursorEx(pBlockSize).PixelBlock;
                pBlockSize.SetCoords(0.0, 0.0);
                raster.Read(pBlockSize, pixelBlock);
                pixelBlock.set_SafeArray(0, arr);

                //编辑raster，将更新的值写入raster中  
                IRasterEdit rasterEdit = raster as IRasterEdit;
                //左上点坐标  
                IPnt tlp = new Pnt();
                tlp.SetCoords(0, 0);
                rasterEdit.Write(tlp, pixelBlock);
                rasterEdit.Refresh();
                return pGeo;
            }

            catch(Exception ex)
            {
                MessageBox.Show("输入异常！");
                return null;
            }
           
        }

        //新建栅格
        public static IGeoDataset CopyGeoDataset(IGeoDataset pGeo)
        {
            IMapAlgebraOp pRSalgebra = new RasterMapAlgebraOpClass();
            pRSalgebra.BindRaster(pGeo, "Raster");
            String strOut = "[Raster]";
            IGeoDataset pOutGeo = pRSalgebra.Execute(strOut);
            return pOutGeo;
        }

        //背景值归0
        public static IGeoDataset ProNoDataRaster(IGeoDataset pGeoDataset)
        {
            IGeoDataset my_GeoDataset = pGeoDataset;
            //IRasterBandCollection pRBandCollection = my_GeoDataset as IRasterBandCollection;
            //IRasterBand pRBand = pRBandCollection.Item(0);
            IRasterProps pRasterprops = my_GeoDataset as IRasterProps;
            pRasterprops.NoDataValue = -99;
            //pRBand = pRasterprops as IRasterBand;
            //pRBand.ComputeStatsAndHist();
            //pRBandCollection = pRBand.RasterDataset as IRasterBandCollection;
            return pGeoDataset as IGeoDataset;
        }

    }
}
