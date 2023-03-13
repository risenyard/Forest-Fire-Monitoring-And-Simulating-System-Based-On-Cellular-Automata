using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bighm.Class
{
    public class CAMethods
    {
        //两个结果序列
        public double[] timeseries;
        public decimal[] fireseries;

        public double[,] FireCA_double(double[,] back_ground, double[,] FireMonitoringResult, double[,] Temperture, double[,] WindSpeedRank, double[,] Humidity, double[,] WindSpeed, double[,] dem, double WindDirection, double L, int Expected_Time)
        {
            //初始化
            int row = FireMonitoringResult.GetLength(0);
            int col = FireMonitoringResult.GetLength(1);
            var CA_Matrix = DenseMatrix.OfArray(FireMonitoringResult);

            //导入所有读取的数据
            List<double[,]> Inputdata = new List<double[,]>();
            Inputdata.Add(FireMonitoringResult);
            Inputdata.Add(Temperture);
            Inputdata.Add(WindSpeedRank);
            Inputdata.Add(Humidity);
            Inputdata.Add(dem);
            Inputdata.Add(WindSpeed);


            if (WhetherSameSize(Inputdata))//判断数据是否是相同的大小
            {
                if (WhetherBinaryData(FireMonitoringResult)) //判断是否为2值数据
                {
                    double[,] tempMonitor = new double[3, 3];
                    double[,] tempKal = new double[3, 3];
                    double[,] tempKw = new double[3, 3];
                    DenseMatrix AdjustRate = new DenseMatrix(3, 3);
                    double[,] tempKsAdjustSpreadRate = new double[3, 3];

                    //可更改参数
                    //double WindDirection = 0;//风向
                    //double L = 250;//空间分辨率（栅格边长）
                    //int Expected_Time = 10;//模拟时间

                    //计算初始蔓延速度，速度单位m/min
                    DenseMatrix InitialSpreadRate = GetInitialSpreadRate(Temperture, WindSpeedRank, Humidity);
                    //计算Ks可燃物配置格局更正系数
                    //DenseMatrix Ks_Matrix = GetKs(lulc,ndvi);
                    //计算Ks修正蔓延速度
                    //DenseMatrix KsAdjustSpreadRate = (DenseMatrix)InitialSpreadRate.PointwiseMultiply(Ks_Matrix);

                    //不进行kS修正
                    DenseMatrix SpreadRate = InitialSpreadRate;
                    //计算Kw修正cos
                    double[,] cos_double = GetCos(WindDirection);

                    int[] RightUp = GetRightUp(back_ground);
                    int[] LeftDown = GetLeftDown(back_ground);
                    Console.WriteLine(RightUp[1].ToString() + " + " + RightUp[0].ToString());
                    Console.WriteLine(LeftDown[1].ToString() + " + " + LeftDown[0].ToString());

                    //获取时间序列
                    int count = 0;
                    timeseries = new double[5];
                    fireseries = new decimal[5];
                    for (int i = 0; i < Expected_Time; i=i+Expected_Time/5)
                    {
                        timeseries[count] = i;
                        count++;
                    }

                    //开始循环
                    int countforfire = 0;//最终火势面积时间序号
                    decimal pointcount = 0;//火点数记录
                    for (int time = 0; time < Expected_Time; time++)
                    {
                        //初始化一个新的矩阵，用来记录time次循环的结果
                        //DenseMatrix CA_Matrix_refresh = DenseMatrix.Create(row, col, -99);
                        DenseMatrix CA_Matrix_refresh = new DenseMatrix(row, col);
                        for (int i = RightUp[0] + 1; i < LeftDown[0] - 1; i++)//行遍历
                        {
                            for (int j = RightUp[1] + 1; j < LeftDown[1] - 1; j++)//列遍历
                            {
                                if (back_ground[i, j] == 1)//判断是否在行政区内
                                {
                                    //SpreadRate[i,j]= 0.0299 * Temperture[i, j] + 0.0470 * WindSpeedRank[i, j] + 0.009 * Humidity[i, j] - 0.304;

                                    //计算3*3改进的 Kw kal
                                    tempKw = GetKwDouble(GetCA(WindSpeed, i, j), cos_double);
                                    tempKal = GetKalDouble(GetCA(dem, i, j), L);

                                    //计算3*3修正蔓延速度
                                    //AdjustRate = (DenseMatrix)(SpreadRate[i, j] * DenseMatrix.OfArray(tempKw).PointwiseMultiply(DenseMatrix.OfArray(tempKal)));
                                    //AdjustRate = DenseMatrix.OfArray(GetCA(SpreadRate.ToArray(), i, j));
                                    AdjustRate = (DenseMatrix)(SpreadRate[i, j] * DenseMatrix.OfArray(tempKw));
                                    AdjustRate = (DenseMatrix)AdjustRate.PointwiseMultiply(DenseMatrix.OfArray(tempKal));



                                    //计算3*3邻胞累积蔓延影响
                                    double AccumulateRate = GetNeiborCell_AccumulateRate(AdjustRate, GetCA(CA_Matrix.ToArray(), i, j));
                                    //计算3*3次邻胞累积蔓延影响
                                    double SecAccumulateRate = GetSecNeiborCell_AccumulateRate(AdjustRate, GetCA(CA_Matrix.ToArray(), i, j));

                                    //输出中心元胞速度
                                    Console.WriteLine(time.ToString() + "    " + i.ToString());
                                    Console.WriteLine(time.ToString() + "    " + j.ToString());
                                    Console.WriteLine("center:" + SpreadRate[i, j].ToString());
                                    Console.WriteLine("AccumulateRate:" + AccumulateRate.ToString());
                                    Console.WriteLine("SecAccumulateRate:" + SecAccumulateRate.ToString());

                                    //由于 CA_Matrix 里面的元胞都在同时发生变化，而不是以遍历行列的顺序进行
                                    //因此，在同一次遍历中的元胞，应当以未进行转换的矩阵为基础
                                    CA_Matrix_refresh[i, j] = CA_Matrix[i, j] + AccumulateRate / L + 0.785 * SecAccumulateRate / L;
                                    Console.WriteLine("CA_Matrix_refresh[i, j]:" + CA_Matrix_refresh[i, j].ToString());
                                    if (CA_Matrix_refresh[i, j] > 1)
                                    {
                                        CA_Matrix_refresh[i, j] = 1;
                                    }
                                    if (CA_Matrix_refresh[i, j] < 0)
                                    {
                                        CA_Matrix_refresh[i, j] = 0;
                                    }
                                    pointcount = pointcount + Convert.ToDecimal( CA_Matrix_refresh[i, j]);
                                }
                                else
                                {
                                    CA_Matrix_refresh[i, j] = 0;//当不在行政区内，则不进行转换
                                }
                            }
                        }
                        //将time次循环的结果更新到 CA_Matrix
                        CA_Matrix = CA_Matrix_refresh;
                        for (int series = 0; series < count; series++)
                        {
                            //获取火区序列
                            if (time==timeseries[series])
                            {
                                fireseries[countforfire] = pointcount;
                                countforfire++;
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Error: Nonbinary data!", "Error");
                    return null;
                }
            }
            else
            {
                ShowAllSize(Inputdata);
                return null;
            }

            double[,] CA_Result = CA_Matrix.ToArray();
            return CA_Result;
        }

        public int[] GetRightUp(double[,] background)
        {
            int row = background.GetLength(0);
            int col = background.GetLength(1);
            int[] righetup = new int[2];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (background[i, j] == 1)
                    {
                        righetup[0] = i;
                        righetup[1] = j;
                        return righetup;
                    }
                }
            }
            return righetup;
        }
        public int[] GetLeftDown(double[,] background)
        {
            int row = background.GetLength(0);
            int col = background.GetLength(1);
            int[] LeftDown = new int[2];
            for (int i = row - 1; i >= 0; i--)
            {
                for (int j = col - 1; j >= 0; j--)
                {
                    if (background[i, j] == 1)
                    {
                        LeftDown[0] = i;
                        LeftDown[1] = j;
                        return LeftDown;
                    }
                }
            }
            return LeftDown;
        }
        public double[,] GetCos(double WindDirection)
        {
            double[,] tempDouble = new double[3, 3];
            tempDouble[0, 0] = Math.Cos(Math.Abs(WindDirection - 135));
            tempDouble[0, 1] = Math.Cos(Math.Abs(WindDirection - 180));
            tempDouble[0, 2] = Math.Cos(Math.Abs(WindDirection - 225));
            tempDouble[1, 0] = Math.Cos(Math.Abs(WindDirection - 90));
            tempDouble[1, 1] = 0;
            tempDouble[1, 2] = Math.Cos(Math.Abs(WindDirection - 270));
            tempDouble[2, 0] = Math.Cos(Math.Abs(WindDirection - 45));
            tempDouble[2, 1] = Math.Cos(Math.Abs(WindDirection - 0));
            tempDouble[2, 2] = Math.Cos(Math.Abs(WindDirection - 315));
            return tempDouble;
        }

        public double[,] GetCA(double[,] doubleResult, int i, int j)
        {
            double[,] tempDouble = new double[3, 3];
            tempDouble[0, 0] = doubleResult[i-1, j-1];
            tempDouble[0, 1] = doubleResult[i-1, j];
            tempDouble[0, 2] = doubleResult[i-1, j+1];
            tempDouble[1, 0] = doubleResult[i, j-1];
            tempDouble[1, 1] = doubleResult[i, j];
            tempDouble[1, 2] = doubleResult[i, j+1];
            tempDouble[2, 0] = doubleResult[i+1, j-1];
            tempDouble[2, 1] = doubleResult[i+1, j];
            tempDouble[2, 2] = doubleResult[i+1, j+1];
            return tempDouble;
        }
        public bool WhetherBinaryData(double[,] MatrixResult)
        {
            //判断是否为01类型数据
            for (int i=0;i<MatrixResult.GetLength(0);i++)
            {
                for (int j = 0; j < MatrixResult.GetLength(1); j++)
                {
                    if(!(MatrixResult[i,j]==1 || MatrixResult[i, j] == 0|| MatrixResult[i, j] == -99))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public DenseMatrix GetInitialSpreadRate(double[,] Temperture,double[,] WindSpeedRank,double[,] Humidity)
        {          
            DenseMatrix TempertureMatrix = DenseMatrix.OfArray(Temperture);
            DenseMatrix WindSpeedMatrix = DenseMatrix.OfArray(WindSpeedRank);
            DenseMatrix HumidityMatrix = DenseMatrix.OfArray(Humidity);
            
            DenseMatrix InitialSpreadRate = (DenseMatrix)((0.0299 * TempertureMatrix) + (0.0470 * WindSpeedMatrix) + (0.009 * HumidityMatrix) - 0.304);
            return InitialSpreadRate;          
        }
        public bool WhetherSameSize(List<double[,]> Inputdata)
        {
            bool result = true;
            int row = Inputdata[0].GetLength(0);//获取行数
            int col = Inputdata[0].GetLength(1);//获取列数
            for(int i = 0; i < Inputdata.Count; i++)
            {
                if(!(Inputdata[i].GetLength(0)==row && Inputdata[i].GetLength(1) == col))
                {                   
                    return false;
                }
            }
            return result;
        }
        public void ShowAllSize(List<double[,]> Inputdata)
        {
            string text = "Error:+";
            for (int i = 0; i < Inputdata.Count; i++)
            {
                text = text + "\ndouble[,] Inputdata ["+i.ToString()+"]:  " + Inputdata[i].GetLength(0).ToString() + "*" + Inputdata[i].GetLength(1).ToString();
            }
            text = text + "\nPlease enter the same size of data!";
            MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public DenseMatrix GetKs(double[,] lulc,double[,] ndvi,List<double> index)
        {
            //int Forest_index,int Shrub_index,int Grass_index,int cropland_index
            DenseMatrix Ks_Matrix = null;
            //利用lulc数据限定范围
            //int[] ValueAsOne = { 20, 30, 40 };
            //double[,] Binarylulc = SetAsBinaryData(lulc, ValueAsOne);
            //数组转矩阵
            //DenseMatrix lulc_Matrix = DenseMatrix.OfArray(Binarylulc);
            //DenseMatrix ndvi_Matrix = DenseMatrix.OfArray(ndvi);
            //Ks 值代表可燃物的配置格局更正系数

            return Ks_Matrix;
        }
        public double[,] SetAsBinaryData(double[,] Matrix,int[] ValueAsOne)
        {
            int row = Matrix.GetLength(0);
            int col = Matrix.GetLength(1);
            int ValueCount = ValueAsOne.GetLength(0);
            double[,] BinaryData =new double[row, col];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    for(int k=0;k< ValueCount; k++)
                    {
                        if (Matrix[i, j] == ValueAsOne[k])
                        {
                            BinaryData[i, j] = 1;
                            break;
                        }                       
                    }
                }
            }
            return BinaryData;
        }
        public double[,] GetKwDouble(double[,] WindSpeed, double[,] cos_double)
        {
            double[,] tempDouble = new double[3, 3];
            tempDouble[0, 0] = GetKw(WindSpeed[0, 0] * cos_double[0, 0]);
            tempDouble[0, 1] = GetKw(WindSpeed[0, 1] * cos_double[0, 1]);
            tempDouble[0, 2] = GetKw(WindSpeed[0, 2] * cos_double[0, 2]);
            tempDouble[1, 0] = GetKw(WindSpeed[1, 0] * cos_double[1, 0]);
            tempDouble[1, 1] = 0;
            tempDouble[1, 2] = GetKw(WindSpeed[1, 2] * cos_double[1, 2]);
            tempDouble[2, 0] = GetKw(WindSpeed[2, 0] * cos_double[2, 0]);
            tempDouble[2, 1] = GetKw(WindSpeed[2, 1] * cos_double[1, 1]);
            tempDouble[2, 2] = GetKw(WindSpeed[2, 2] * cos_double[2, 2]);
            return tempDouble;
        }
        private double GetKw(double V)
        {
            //使用毛贤敏模型经典参数，计算Kw
            return Math.Exp(0.1783*V);
        }
        public double[,] GetKalDouble(double[,] dem,double L)
        {
            double[,] tempDouble = new double[3, 3];
            tempDouble[0, 0] = GetKal(dem[1, 1], dem[0, 0], Math.Sqrt(2) * L);
            tempDouble[0, 1] = GetKal(dem[1, 1], dem[0, 1], L);
            tempDouble[0, 2] = GetKal(dem[1, 1], dem[0, 2], Math.Sqrt(2) * L);
            tempDouble[1, 0] = GetKal(dem[1, 1], dem[0, 0], L);
            tempDouble[1, 1] = 1;
            tempDouble[1, 2] = GetKal(dem[1, 1], dem[0, 2], L);
            tempDouble[2, 0] = GetKal(dem[1, 1], dem[0, 0], Math.Sqrt(2) * L);
            tempDouble[2, 1] = GetKal(dem[1, 1], dem[0, 1], L);
            tempDouble[2, 2] = GetKal(dem[1, 1], dem[0, 2], Math.Sqrt(2) * L);
            return tempDouble;
        }
        private double GetKal(double dem_center,double dem_neibor,double L) 
        {
            double G = 0;
            if ((dem_neibor-dem_center)>=0)
            {
                G = 1;
            }
            double up_down = Math.Pow(-1, G);
            double tan_angle = Math.Abs((dem_neibor - dem_center) / L);
            double tan_pow = Math.Pow(tan_angle, 1.2);
            return Math.Exp(3.533 * up_down * tan_pow);
        }
        public double GetNeiborCell_AccumulateRate(DenseMatrix AdjustRate,double[,] MonitorFire)
        {
            double result = AdjustRate[0, 1] * MonitorFire[0, 1]
                          + AdjustRate[1, 0] * MonitorFire[1, 0]
                          + AdjustRate[1, 2] * MonitorFire[1, 2]
                          + AdjustRate[2, 1] * MonitorFire[2, 1];
            if (result < 0)
            {
                return 0;
            }
            return result;
        }
        public double GetSecNeiborCell_AccumulateRate(DenseMatrix AdjustRate, double[,] MonitorFire)
        {
            double result = AdjustRate[0, 0] * MonitorFire[0, 0]
                          + AdjustRate[0, 2] * MonitorFire[0, 2]
                          + AdjustRate[2, 0] * MonitorFire[2, 0]
                          + AdjustRate[2, 2] * MonitorFire[2, 2];
            if (result < 0)
            {
                return 0;
            }
            return result;
        }


    }
}
