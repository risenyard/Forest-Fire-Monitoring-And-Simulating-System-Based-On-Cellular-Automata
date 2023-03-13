using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing.Imaging;
using bighm.Class;

namespace bighm.BasicOptionForm
{
    public partial class VisualForm : Form
    {
        public double[] x = { 521, 522, 523, 524, 525, 526, 527 } ;
        public decimal[] y = { 95, 30, 20, 23, 60, 87, 42 };
        public double[] timeseries;
        public decimal[] fireseries;
        public VisualForm(double[] timeseries,decimal[] fireseries)
        {
            InitializeComponent();
            this.timeseries = timeseries;
            this.fireseries = fireseries;
        }

        #region 导入数据
        private void Datainputbtn_Click(object sender, EventArgs e)
        {
            if(timeseries!=null&&fireseries!=null)
            {
                MessageBox.Show("导入成功");
                x = this.timeseries;
                y = this.fireseries;
            }
            else
            {
                MessageBox.Show("请进行元胞自动机模拟!");
            }
        }
        #endregion

        #region 绘制折线图
        private void SeriesDrawbtn_Click(object sender, EventArgs e)
        {
            UpdateSplinechart();
        }
        void UpdateSplinechart()
        {
            //将折线图的结果输出页设置为当前页
            this.tabControl1.SelectedTab = this.SplinePicpage;
            //判断制图要素是否完整
            if (SeriesX.Text == "" || SeriesY.Text == "" || SeriesName.Text == "" || PictureName.Text == "")
            {
                MessageBox.Show("请将制图要素填写完整！");
            }
            else
            {
                // 设置曲线的样式
                Series series = chart1.Series[0];
                series.Points.Clear();//重新输入系列点
                // 画样条曲线（Spline）
                series.ChartType = SeriesChartType.Spline;
                // 线宽
                series.BorderWidth = 2;
 
                // 设置系列的名称
                series.LegendText = SeriesName.Text;

                DataTable dataTable = new DataTable();
                DataColumn seriesX = new DataColumn(SeriesX.Text, Type.GetType("System.Double"));
                DataColumn seriesY = new DataColumn(SeriesY.Text, Type.GetType("System.Double"));
                if (SeriesX.Text != SeriesY.Text)
                {
                    dataTable.Columns.Add(seriesX);
                    dataTable.Columns.Add(seriesY);
                    for (int i = 0; i < x.Length; i++)
                    {
                        DataRow dr = dataTable.NewRow();
                        dr[SeriesX.Text] = x[i];
                        dr[SeriesY.Text] = y[i];
                        dataTable.Rows.Add(dr);
                        series.Points.AddXY(x[i], y[i]);
                    }

                    dataGridView1.DataSource = dataTable;
                    dataGridView1.Columns[SeriesX.Text].DefaultCellStyle.Format = "0.00"; //
                    dataGridView1.Columns[SeriesY.Text].DefaultCellStyle.Format = "0.00"; //设置其显示的小数位数
                    //*****对数据框外观的调整*****//
                    dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
                    //为了美观自动调整行高与列宽
                    dataGridView1.Font = new Font("Calibri", 7);
                    //设置不自动增加行
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.RowHeadersVisible = false;

                    // 设置显示范围
                    ChartArea chartArea = chart1.ChartAreas[0];
                    chartArea.AxisX.Minimum = x.Min();
                    chartArea.AxisX.Maximum = x.Max();
                    chartArea.AxisY.Minimum = (double)Math.Floor(y.Min());
                    chartArea.AxisY.Maximum = (double)Math.Ceiling(y.Max());

                    //设置横纵坐标轴的标题
                    chartArea.AxisX.Title = SeriesX.Text;
                    chartArea.AxisY.Title = SeriesY.Text;
                    chartArea.AxisY.TitleFont = new Font("微软雅黑", (int)Splinenumsize.Value);
                    chartArea.AxisX.TitleFont = new Font("微软雅黑", (int)Splinenumsize.Value);

                    this.chart1.Titles.Clear();
                    //添加图表的标题
                    this.chart1.Titles.Add(new System.Windows.Forms.DataVisualization.Charting.Title(PictureName.Text,
                        System.Windows.Forms.DataVisualization.Charting.Docking.Top));

                }
                else
                {
                    MessageBox.Show("横轴和纵轴的名称不能相同！");
                }
            }
        }
        private void Splinenumsize_Click(object sender, EventArgs e)
        {
            UpdateSplinechart();
        }
        #endregion

        #region 绘制柱状图

        List<ColumnChartItem> _items = new List<ColumnChartItem>();//绘制柱状图所需数据
        ColumnChart cc = new ColumnChart();
        void initValues()
        {
            if (PictureName.Text != "" || Xbarvalue.Text  !="" || Ybarvalue.Text != "")
            {
                //判断制图要素是否齐全

                //数据展示的代码和！折线图的完全一样！可以提取！！！
                DataTable dataTable = new DataTable();
                DataColumn seriesX = new DataColumn(Xbarvalue.Text, Type.GetType("System.Double"));
                DataColumn seriesY = new DataColumn(Ybarvalue.Text, Type.GetType("System.Double"));
                if (Xbarvalue.Text != Ybarvalue.Text)
                {
                    dataTable.Columns.Add(seriesX);
                    dataTable.Columns.Add(seriesY);
                    for (int i = 0; i < x.Length; i++)
                    {
                        DataRow dr = dataTable.NewRow();
                        dr[Xbarvalue.Text] = x[i];
                        dr[Ybarvalue.Text] = y[i];
                        dataTable.Rows.Add(dr);
                    }
                    dataGridView1.DataSource = dataTable;
                    //*****对数据框外观的调整*****//
                    dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
                    //为了美观自动调整行高与列宽
                    dataGridView1.Font = new Font("Calibri", 7);
                    //设置不自动增加行
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.RowHeadersVisible = false;
                }
                else
                {
                    MessageBox.Show("横纵坐标轴名称需不同！");
                }

                //设置柱状图的颜色表 
                //颜色表的长度需要和数据保持一致，这个需要依据CA跑出来的结果而定
                Color[] colorlist = new Color[]{ Color.PaleVioletRed, Color.PeachPuff, Color.PowderBlue
                 ,Color.DarkSeaGreen,Color.Plum,Color.Pink,Color.PapayaWhip};
                //添加3D柱状数据
                for (int i = 0; i < x.Length; i++)
                {
                    _items.Add(new ColumnChartItem(colorlist[i], x[i].ToString(), y[i]));
                }
                //制图内容的属性设置
                updateChart(cc);
            }
            else
            {
                MessageBox.Show("请输入完整的制图要素");
            }
        }

        private void Drawbarbtn_Click(object sender, EventArgs e)
        {
            //将折线图的结果输出页设置为当前页
            this.tabControl1.SelectedTab = this.Barpicpage;
            initValues();//导入数据
        }
        void BtnUpdateChartClick(object sender, EventArgs e)
        {
            updateChart(cc);//更新图表内容
        }
        void updateChart(ColumnChart cc)
        {
            //制图内容的属性设置
            cc.BackgroundColor = Color.White;
            cc.ShowGuideLines = chkShowGuideLines.Checked;
            cc.ValueFont = new Font("Calibri", 8);
            cc.DescriptionFont = new Font("Calibri", 8);
            cc.Width = Convert.ToInt32(350);
            cc.Height = Convert.ToInt32(250);
            cc.ColumnSpacing = Convert.ToInt32(0);
            cc.Margins = Convert.ToInt32(10);
            cc.Depth = Convert.ToInt32(20);
            cc.ValueFormat = "#0.00";
            cc.GuideLineFormat = "#0.00";
            cc.GuideLinesCount = Convert.ToInt32(6);
            cc.ShowDescriptions = chkShowDescriptions.Checked;
            cc.ShowValues = chkShowValues.Checked;
            cc.Xlabel = Xbarvalue.Text;
            cc.Ylabel = Ybarvalue.Text;
            cc.PictrueName = PictureName.Text;
            if(cc.Items.Count == 0)
            {
                 foreach (ColumnChartItem item in _items)
                    cc.Items.Add(item);
            }
            BarPictureout.Image = cc.GetChart();
        }
        private void Savebtn_Click(object sender, EventArgs e)
        {

            if(tabControl2.SelectedTab == tabPage4)
            {
                sfd.Title = "导出为png";
                sfd.Filter = "PNG文件(*.png)|*.png";
                if (sfd.ShowDialog() != DialogResult.OK)
                    return;
                BarPictureout.Image.Save(sfd.FileName, ImageFormat.Png);//保存柱状图
            }
            if (tabControl2.SelectedTab == SeriesDraw)
            {
                //折线图保存为png
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.Filter = "PNG文件(*.png)|*.png";
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    chart1.SaveImage(savefile.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
            if (tabControl2.SelectedTab == tabPage5)
            {
                //饼图保存为png
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.Filter = "PNG文件(*.png)|*.png";
                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    Piechart.SaveImage(savefile.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
            }

        }
        #endregion

        #region 绘制饼图
        private void Drawpiebtn_Click(object sender, EventArgs e)
        {
            UpdatePiechart();
        }
        void UpdatePiechart()
        {
            //将折线图的结果输出页设置为当前页
            this.tabControl1.SelectedTab = this.Piepage;

            //判断制图要素是否完整
            if (PictureName.Text == "")
            {
                MessageBox.Show("请填写图名！");
            }
            else
            {
                // 设置曲线的样式
                Series series = Piechart.Series[0];
                series.Points.Clear();//重新输入系列点
                // 画样条曲线（Spline）
                series.ChartType = SeriesChartType.Pie;
                // 线宽
                series.BorderWidth = 2;
                
                DataTable dataTable = new DataTable();
                DataColumn seriesX = new DataColumn("要素", Type.GetType("System.Double"));
                DataColumn seriesY = new DataColumn("要素值", Type.GetType("System.Double"));
                dataTable.Columns.Add(seriesX);
                dataTable.Columns.Add(seriesY);
                for (int i = 0; i < x.Length; i++)
                {
                    DataRow dr = dataTable.NewRow();
                    dr["要素"] = x[i];
                    dr["要素值"] = y[i];
                    dataTable.Rows.Add(dr);
                    series.Points.AddXY(x[i], y[i]);
                }

                dataGridView1.DataSource = dataTable;
                dataGridView1.Columns["要素"].DefaultCellStyle.Format = "0.00"; //
                dataGridView1.Columns["要素值"].DefaultCellStyle.Format = "0.00"; //设置其显示的小数位数
                //*****对数据框外观的调整*****//
                dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
                //为了美观自动调整行高与列宽
                dataGridView1.Font = new Font("Calibri", 7);
                //设置不自动增加行
                dataGridView1.AllowUserToAddRows = false;
                dataGridView1.RowHeadersVisible = false;

                // 设置显示范围
                ChartArea chartArea = Piechart.ChartAreas[0];
 
                //设置横纵坐标轴的标题
                chartArea.AxisX.Title = "x";
                chartArea.AxisY.Title = "y";
                chartArea.AxisY.TitleFont = new Font("微软雅黑", (int)Splinenumsize.Value);
                chartArea.AxisX.TitleFont = new Font("微软雅黑", (int)Splinenumsize.Value);

                chartArea.Area3DStyle.Enable3D = true;
                chartArea.Area3DStyle.Inclination = 60;
                chartArea.Area3DStyle.Rotation = 60;

                series["PieLabelStyle"] = "Outside";//将文字移到外侧 
                //series["PieLineColor"] = "Black";//绘制黑色的连线

                this.Piechart.Titles.Clear();
                //添加图表的标题
                this.Piechart.Titles.Add(new System.Windows.Forms.DataVisualization.Charting.Title(PictureName.Text,
                    System.Windows.Forms.DataVisualization.Charting.Docking.Top));
            }
        }

        #endregion
    }
}

