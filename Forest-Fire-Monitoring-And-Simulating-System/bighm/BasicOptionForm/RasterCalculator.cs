using bighm.Class;
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
    public partial class RasterCalculator : Form
    {
        public IRasterLayer outLayer;
        List<IRasterLayer> Layers=new List<IRasterLayer>();
        List<string> Variable;
        List<IGeoDataset> geodataset=new List<IGeoDataset>();
        int cursor;

        public RasterCalculator(AxMapControl mapcontrol)//构造函数
        {
            for (int i = 0; i < mapcontrol.LayerCount; i++)
            {
                ILayer layer = mapcontrol.get_Layer(i);
                if (layer is IRasterLayer)
                {
                    IRasterLayer newLayer = layer as IRasterLayer;
                    Layers.Add(newLayer);
                }
            }
            InitializeComponent();
            ConfirmValue.Enabled = false;
            button1.Enabled = false;
        }

        #region 构建语句



        private void btnAdd_Click(object sender, EventArgs e)//加号按钮
        {
            richTextBox1.Text += " " + "+"+" ";
        }

        private void btnMinus_Click(object sender, EventArgs e)//减号按钮
        {
            richTextBox1.Text += " " + "-" + " ";
        }

        private void btnMultiply_Click(object sender, EventArgs e)//乘号按钮
        {
            richTextBox1.Text += " " + "*" + " ";
        }

        private void btnDivide_Click(object sender, EventArgs e)//除号按钮
        {
            richTextBox1.Text += " " + "/" + " ";
        }

        private void btnParentheses_Click(object sender, EventArgs e)//圆括号按钮
        {
            richTextBox1.Text += " " + "()";
        }

        #endregion

        #region 处理集构建

        //确认公式
        private void ConfirmEquation_Click(object sender, EventArgs e)
        {
            //读取变量项
            bool flag = true;
            var pattern = new Regex(@"( [^\W_\d] ( [^\W] )* )",RegexOptions.IgnorePatternWhitespace);
            var input = richTextBox1.Text;
            Variable = new List<string>();
            foreach (Match m in pattern.Matches(input))
            {
                if (m.Groups[1].Value == "float")
                    continue;
                flag = true;
                foreach (string s in Variable)
                    if (m.Groups[1].Value == s)
                        flag = false;
                if (flag)
                {
                    Variable.Add(m.Groups[1].Value);
                }
            }
                
                
            //进行下一步操作
            if (Variable.Count>0)
            {
                cursor = 0;
                labelVariable.Text = Variable[0];
                ConfirmEquation.Enabled = false;
                ClearEquation.Enabled = false;
                button1.Enabled = true;
                ChoiceBand(listBoxLayer);               
            }

        }

        //所有变量对应
        private void button1_Click(object sender, EventArgs e)
        {
            if (cursor<Variable.Count)
            {
                IRasterBandCollection rb = (IRasterBandCollection)Layers[listBoxLayer.SelectedIndex].Raster;
                geodataset.Add(rb.Item(listBoxBand.SelectedIndex) as IGeoDataset);
                cursor++;
                if(cursor<Variable.Count)
                {
                    labelVariable.Text = Variable[cursor];
                }
            }
            if (cursor == Variable.Count)
            {
                button1.Enabled = false;
                ConfirmValue.Enabled = true;
            }
             
        }
        //清除公式
        private void btnClear_Click(object sender, EventArgs e) //清除查询条件
        {
            richTextBox1.Text = null;
        }

        //关闭窗口
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        //可选图层函数
        private void ChoiceBand(ListBox listbox)
        {
            for (int i = 0; i < Layers.Count; i++)
            {
                listBoxLayer.Items.Add(Layers[i].Name);
            }
            listbox.SelectedIndex = 0;
        }
        //可选波段函数
        private void listBoxLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBoxBand.Items.Clear();
            IRasterBandCollection rasterBandCollection = (IRasterBandCollection)Layers[listBoxLayer.SelectedIndex].Raster;
            for (int i = 0; i < rasterBandCollection.Count; i++)
            {
                listBoxBand.Items.Add(rasterBandCollection.Item(i).Bandname);
            }
            listBoxBand.SelectedIndex = 0;
        }

        #endregion

        #region 栅格计算器计算
        //确认计算
        private void ConfirmValue_Click(object sender, EventArgs e)
        {
            // 栅格计算器
            IMapAlgebraOp pRSalgebra = new RasterMapAlgebraOpClass();
            // 从波段集中获取单个波段，即该波段的矩阵GeoDataSet（Item的下标从0开始）
            for (int i = 0; i < geodataset.Count; i++)
            {
                pRSalgebra.BindRaster(geodataset[i],Variable[i]);
            }
            String strOut = richTextBox1.Text;
            for (int i = 0; i < Variable.Count; i++)
            {
                strOut = strOut.Replace(Variable[i], "[" + Variable[i] + "]");
            }
            try
            {
                // 执行
                IGeoDataset pOutGeo = pRSalgebra.Execute(strOut);
                IGeoDataset pGeo1 = RasterArray.ProNoDataRaster(pOutGeo);
                // 将矩阵GeoDataset转成栅格集
                IRasterBandCollection irbc = (IRasterBandCollection)pGeo1;
                IRasterDataset pRD = irbc.Item(0).RasterDataset;
                //rastDataset_savi = pRD;

                outLayer = new RasterLayerClass();
                outLayer.CreateFromRaster(pOutGeo as IRaster);
                this.DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show("输入情况出错");
            }
        }

        #endregion


    }

}

