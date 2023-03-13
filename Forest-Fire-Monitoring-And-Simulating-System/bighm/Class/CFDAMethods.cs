using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bighm.Class
{
    class CFDAMethods
    {
        #region CFDA主算法
        public double[,] CFDA_double(double[,] back_ground, double[,] ch2, double[,] ch3, double[,] ch4, double[,] ch5)
        {
            //初始化
            int row = ch2.GetLength(0);
            int col = ch2.GetLength(1);
            var CFDA_Matrix = DenseMatrix.OfArray(ch2);

            //导入所有读取的数据
            List<double[,]> Inputdata = new List<double[,]>();
            Inputdata.Add(ch2);
            Inputdata.Add(ch3);
            Inputdata.Add(ch4);
            Inputdata.Add(ch5);

            //初始化一个新的矩阵，用来记录结果
            DenseMatrix CFDA_result = new DenseMatrix(row, col);
            long c1 = 0;long c2 = 0;long c3 = 0, c4 = 0, c5 = 0, c6 = 0, c7 = 0, c8 = 0, c9 = 0; ;

            if (WhetherSameSize(Inputdata))//判断数据是否是相同的大小
            {
                for (int i = 0; i < row ; i++)
                {
                    for (int j = 0; j < col; j++)
                    {
                        c9++;
                        if (back_ground[i, j] == 1)//判断是否在行政区内
                        {
                            c8++;
                            if (ch3[i, j] > 3000)//火灾监测的3B波段需温度较高
                            {
                                if (ch3[i, j] - ch4[i, j] <= 140)
                                {
                                    CFDA_result[i, j] = 0;//认为是地物热背景
                                    c6++;
                                }
                                else 
                                {
                                    if (ch4[i, j] <= 2600)
                                    {
                                        CFDA_result[i, j] = 0;//认为是高云
                                        c5++;
                                    }
                                    else
                                    {
                                        if(ch2[i,j] >= 2000)
                                        {
                                            CFDA_result[i, j] = 0;//认为是高反射率地物
                                            c4++;
                                        }
                                        else
                                        {
                                            if((ch4[i,j]-ch5[i,j]>=41) & (ch3[i, j] - ch4[i, j] < 190))
                                            {
                                                CFDA_result[i, j] = 0;//认为是薄卷云和高反射率地物共同作用的结果
                                                c3++;
                                            }
                                            else
                                            {
                                                CFDA_result[i, j] = 1;//认为是真火点
                                                c7++;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                CFDA_result[i, j] = 0;//当温度不是过高则不是火点
                                c2++;
                        
                            }
                        }
                        else
                        {
                            CFDA_result[i, j] = 0;//当不在行政区内，则不认为是火点
                            c1++;
                        }
                    }
                }
            }
            else
            {
                ShowAllSize(Inputdata);
                return null;
            }
            double[,] CFDA_Result = CFDA_result.ToArray();
            return CFDA_Result;
        }

        #endregion

        #region 一些辅助方法函数
        public void ShowAllSize(List<double[,]> Inputdata)
        {
            string text = "错误:+";
            for (int i = 0; i < Inputdata.Count; i++)
            {
                text = text + "\ndouble[,] Inputdata [" + i.ToString() + "]:  " + Inputdata[i].GetLength(0).ToString() + "*" + Inputdata[i].GetLength(1).ToString();
            }
            text = text + "\n请输入相同大小的数据!";
            MessageBox.Show(text, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool WhetherSameSize(List<double[,]> Inputdata)
        {
            bool result = true;
            int row = Inputdata[0].GetLength(0);//获取行数
            int col = Inputdata[0].GetLength(1);//获取列数
            for (int i = 0; i < Inputdata.Count; i++)
            {
                if (!(Inputdata[i].GetLength(0) == row && Inputdata[i].GetLength(1) == col))
                {
                    return false;
                }
            }
            return result;
        }
        #endregion
    }
}
