using bighm.Class;
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
    public partial class LossassessForm : Form
    {
        public LossassessForm()
        {
            InitializeComponent();
        }

        private void IndirLossbtn_Click(object sender, EventArgs e)
        {
            LossAssess lossAssess = new LossAssess();
            double Loss1 = lossAssess.GetEconomicLosss(Convert.ToInt32(Fire_AffectDays.Text),
                Convert.ToInt32(Fire_AffectWorkers.Text), Convert.ToInt32(salary_perday.Text));
            double Loss2 = lossAssess.GetEconomicSystemLosss(Convert.ToInt32(Fire_AffectDays.Text),
                Convert.ToInt32(income_perday.Text));
            double Loss3 = lossAssess.GetEconomicProduceLosss(Convert.ToInt32(Fire_AffectDays.Text),
                Convert.ToInt32(product_amount.Text), Convert.ToInt32(price_perproduct.Text));
            richTextBox1.Text = "火灾对生产资料、生产环境的影响为:\n" + Loss1.ToString() +"\n"+
                "火灾对林业产品市场体系、经济结构体系的影响为:\n" + Loss2.ToString() + "\n"+
                "火灾对林业生产单位林业产品生产的影响:\n" + Loss3.ToString();
        }

        private void Rebulidlossbtn_Click(object sender, EventArgs e)
        {
            LossAssess lossAssess = new LossAssess();
            double Loss1 = lossAssess.GetRescureCosts_Worker(Convert.ToInt32(num_worker.Text),
                Convert.ToInt32(per_worker.Text));
            double Loss2 = lossAssess.GetRescureCosts_Tools(Convert.ToInt32(num_diantai.Text),
                Convert.ToInt32(per_diantai.Text), Convert.ToInt32(num_fengli.Text), Convert.ToInt32(per_fengli.Text)
                , Convert.ToInt32(num_qitatool.Text), Convert.ToInt32(per_qitatool.Text));
            double Loss3 = lossAssess.GetRescureCosts_Transportation(Convert.ToInt32(num_yunshu.Text),
                Convert.ToInt32(per_yunshu.Text), Convert.ToInt32(num_zhuangjia.Text), Convert.ToInt32(per_zhuangjia.Text),
                Convert.ToInt32(num_feiji.Text), Convert.ToInt32(per_feiji.Text), Convert.ToInt32(num_qita.Text),
                 Convert.ToInt32(per_qita.Text));
            double Loss_sum = lossAssess.GetRescureCosts(Loss1, Loss2, Loss3, Convert.ToDouble(othercost.Text));
            richTextBox2.Text = "火灾扑火救援、重建的总费用为:\n" + Loss_sum.ToString() + "\n"+
              "扑火人员费用为:\n" +Loss1.ToString() + "\n" +
              "扑火工具所需的费用:\n" + Loss2.ToString() + "\n" +
             "救援交通所需的费用:\n" + Loss3.ToString();
        }
    }
}
