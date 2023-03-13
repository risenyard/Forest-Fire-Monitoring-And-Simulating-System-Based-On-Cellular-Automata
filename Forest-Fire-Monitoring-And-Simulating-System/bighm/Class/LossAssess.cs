using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bighm.Class
{
    class LossAssess
    {
        //类别1：计算直接经济损失
        public double GetForestResourceLoss(double[,] lulc, int forest_index, double[,] fire, double L, double ForestPrice)
        {
            //lulc，评估范围的lulc数据
            //forrst_index，lulc数据，林地的编号
            //fire，火灾监测/火灾模拟结果
            //L,栅格边长（m）
            //ForestPrice，单位面积林产品、林副产品损失（m2）
            double area = GetIndexArea(lulc, forest_index, fire, L);
            return area * ForestPrice;
        }
        public double GetCropLoss(double[,] lulc,int crop_index,double[,] fire,double L,double CropPrice)
        {
            //lulc，评估范围的lulc数据
            //crop_index，lulc数据，耕地的编号
            //fire，火灾监测/火灾模拟结果(0~1)
            //L,栅格边长（m）
            //CropPrice，单位面积农作物价格（m2）
            double area= GetIndexArea(lulc, crop_index, fire,L);
            return area * CropPrice;
        }
        private  double GetIndexArea(double[,] lulc, int index, double[,] fire,double L)
        {
            double aera_count = 0;
            for (int i = 0; i < fire.GetLength(0); i++)
            {
                for (int j = 0; j < fire.GetLength(1); j++)
                {
                    if (lulc[i, j] == index && fire[i, j] > 0)
                    {
                        aera_count = aera_count + fire[i, j];
                    }
                }
            }
            return aera_count * L;
        }
       
        
        //类别2：计算间接经济损失
        public double GetEconomicLosss(int Fire_AffectDays, int Fire_AffectWorkers, double salary_perday)
        {
            //计算火灾对生产资料、生产环境的影响

            //Fire_AffectDays 火灾影响下停工时间（天）
            //Fire_AffectWorkers火灾影响到的工人数（人）
            //double salary_perday日均工资（元/人/天）

            return Fire_AffectDays * Fire_AffectWorkers * salary_perday;
        }
        public double GetEconomicSystemLosss(int Fire_AffectDays, double income_perday)
        {
            //计算火灾对林业产品市场体系、经济结构体系的影响，导致相关营业单位不能正常营业

            //Fire_AffectDays 火灾影响下停工时间（天）
            //income_perday日营业额（元/天）

            return Fire_AffectDays * income_perday;
        }
        public double GetEconomicProduceLosss(int Fire_AffectDays, int product_amount, double price_perproduct)
        {
            //计算火灾对林业生产单位林业产品生产的影响

            //Fire_AffectDays 火灾影响下停工时间（天）
            //product_amount每天可生产的产品数量（件/天）
            //double price_perproduct产品出厂价（元/件）

            return Fire_AffectDays * product_amount * price_perproduct;
        }
       
        
        //类别3：计算扑火救援、重建费用
        public double GetRescureCosts(double workersCosts, double toolsCosts, double transportationCosts,double othercosts)
        {
            //计算总损失费用
            return workersCosts + toolsCosts + transportationCosts+othercosts;
        }
        public double GetRescureCosts_Worker(int num_worker, double per_worker)
        {
            //计算扑火人员费用

            //num表示人数
            //per表示费用 元/人
            return num_worker * per_worker;
        }
        public double GetRescureCosts_Tools(int num_diantai, double per_diantai, int num_fengli, double per_fengli, int num_qitatool, double per_qitatool)
        {
            //计算扑火工具所需的费用
            // diantai，表示便携电台
            // fengli，表示风力灭火机
            // qitatool，表示其他工具
            //num表示人数
            //per表示费用 元/台
            return num_diantai *per_diantai+num_fengli* per_fengli+num_qitatool*per_qitatool;
        }
        public double GetRescureCosts_Transportation(int num_yunshu, double per_yunshu, int num_zhuangjia, double per_zhuangjia, int num_feiji, double per_feiji,int num_qita,double per_qita)
        {
            //计算救援交通所需的费用
            // yunshui运输车辆
            // zhuangjia装甲车辆
            // feiji飞机
            // qita其他车辆
            //num表示人数
            //per表示费用 元/台
            return num_yunshu *per_yunshu+num_zhuangjia*per_zhuangjia+ num_feiji*per_feiji+num_qita*per_qita;
        }

    }
}
