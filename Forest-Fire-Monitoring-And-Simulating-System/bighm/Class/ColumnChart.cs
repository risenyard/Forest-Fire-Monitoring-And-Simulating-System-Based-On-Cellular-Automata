using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bighm.Class
{
    class ColumnChart
    {
		#region fields
		Int32 _width;
		Int32 _height;
		Int32 _columnSpacing;
		Int32 _margins;
		Int32 _depth;
		String _valueFormat;
		Font _valueFont;
		Boolean _showDescriptions;
		Boolean _showValues;
		Boolean _showGuideLines;
		Font _descriptionFont;
		Color _backgroundColor;
		Font _guideLineFont;
		Color _guideLineColor;
		Color _guideLineTextColor;
		Single _guideLineWidth;
		String _guideLineFormat;
		Int32 _guideLinesCount;
		Color _xyColor;
		Single _xyLineWidth;
		Color _xyTextColor;
		List<ColumnChartItem> _items;
		String _xLabel;
		String _yLabel;
		String _PictrueName;
		#endregion

		#region properties
		public String PictrueName
		{
			get { return _PictrueName; }
			set { _PictrueName = value; }
		}

		public String Xlabel
        {
			get { return _xLabel; }
			set { _xLabel = value; }
		}
		public String Ylabel
		{
			get { return _yLabel; }
			set { _yLabel = value; }
		}
		public Int32 Width
		{
			get { return _width; }
			set { _width = value; }
		}
		public Int32 Height
		{
			get { return _height; }
			set { _height = value; }
		}
		public Int32 ColumnSpacing
		{
			get { return _columnSpacing; }
			set { _columnSpacing = value; }
		}
		public Int32 Margins
		{
			get { return _margins; }
			set { _margins = value; }
		}
		public Int32 Depth
		{
			get { return _depth; }
			set { _depth = value; }
		}
		public Boolean ShowDescriptions
		{
			get { return _showDescriptions; }
			set { _showDescriptions = value; }
		}
		public Boolean ShowValues
		{
			get { return _showValues; }
			set { _showValues = value; }
		}
		public Boolean ShowGuideLines
		{
			get { return _showGuideLines; }
			set { _showGuideLines = value; }
		}
		public String ValueFormat
		{
			get { return _valueFormat; }
			set { _valueFormat = value; }
		}
		public Font ValueFont
		{
			get { return _valueFont; }
			set { _valueFont = value; }
		}
		public Font DescriptionFont
		{
			get { return _descriptionFont; }
			set { _descriptionFont = value; }
		}
		public Font GuideLineFont
		{
			get { return _guideLineFont; }
			set { _guideLineFont = value; }
		}
		public Color GuideLineColor
		{
			get { return _guideLineColor; }
			set { _guideLineColor = value; }
		}
		public Color GuideLineTextColor
		{
			get { return _guideLineTextColor; }
			set { _guideLineTextColor = value; }
		}
		public Single GuideLineWidth
		{
			get { return _guideLineWidth; }
			set { _guideLineWidth = value; }
		}
		public String GuideLineFormat
		{
			get { return _guideLineFormat; }
			set { _guideLineFormat = value; }
		}
		public Int32 GuideLinesCount
		{
			get { return _guideLinesCount; }
			set { _guideLinesCount = value; }
		}
		public Color XYColor
		{
			get { return _xyColor; }
			set { _xyColor = value; }
		}
		public Single XYLineWidth
		{
			get { return _xyLineWidth; }
			set { _xyLineWidth = value; }
		}
		public Color XYTextColor
		{
			get { return _xyTextColor; }
			set { _xyTextColor = value; }
		}
		public Color BackgroundColor
		{
			get { return _backgroundColor; }
			set { _backgroundColor = value; }
		}
		public List<ColumnChartItem> Items
		{
			get { return _items; }
		}
		#endregion

		#region constructors
		public ColumnChart()
		{
			_backgroundColor = Color.White;
			_width = 300;
			_height = 280;
			_columnSpacing = 5;
			_margins = 10;
			_depth = 20;
			_valueFont = new Font("Arial", 8);
			_descriptionFont = new Font("Arial", 8);
			_guideLineFont = new Font("Arial", 6);
			_guideLineColor = Color.LightGray;
			_guideLineTextColor = Color.Gray;
			_guideLineWidth = 0.5f;
			_showGuideLines = true;
			_showDescriptions = true;
			_showValues = true;
			_guideLinesCount = 6;
			_guideLineFormat = "#######0.00";
			_xyColor = Color.Gray;
			_xyLineWidth = 0.5f;
			_xyTextColor = Color.DimGray;
			_items = new List<ColumnChartItem>();
		}
		#endregion

		#region public methods
		public Bitmap GetChart()
		{
			Bitmap bmp = new Bitmap(_width, _height);
			Graphics g = Graphics.FromImage(bmp);
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.CompositingQuality = CompositingQuality.HighQuality;

			Rectangle r = new Rectangle(0, 0, _width - 1, _height - 1);
			if (_backgroundColor != Color.Empty && _backgroundColor != Color.Transparent)
				g.FillRectangle(new SolidBrush(_backgroundColor), r);

			Decimal maxValue = getMaxColumnValue();
			Int32 guideLineWidth = Convert.ToInt32(g.MeasureString(getFormattedValue(_guideLineFormat, maxValue), _guideLineFont).Width) + _margins;
			if (!_showGuideLines)
				guideLineWidth = 0;

			Int32 barCounter = 0;
			Int32 barWidth = _items.Count > 0 ? getColumnWidth(guideLineWidth) : 0;
			Int32 descHeight = getMaxDescriptionHeight(g, barWidth);
			if (!_showDescriptions)
				descHeight = 0;
			Int32 top = _margins + _depth / 2 + 1;
			if (_showDescriptions)
				top += descHeight;

			Decimal minValue = getMinColumnValue();
			Int32 minValueColumnHeight = getColumnHeight(g, minValue, barWidth);

			Int32 baseY = _height - (_depth / 2) - descHeight - _margins - 1 - ((minValueColumnHeight < 0) ? Math.Abs(minValueColumnHeight) : 0);
			Brush xyBrush = new SolidBrush(_xyTextColor);
			g.DrawString(_PictrueName, _guideLineFont, xyBrush, Width / 2, 0);
			if (_showGuideLines)
			{
				Int32 positiveGuideLines = getPositiveGuideLines();
				Int32 negativeGuideLines = getNegativeGuideLines();
				Decimal maxGuideLineValue = maxValue - (maxValue % 5);
				Decimal minGuideLineValue = minValue - (minValue % 5);
				if (maxGuideLineValue == 0)
					maxGuideLineValue = maxValue;
				if (minGuideLineValue == 0)
					minGuideLineValue = minValue;
				Int32 maxGuideLineHeight = _items.Count > 0 ? getColumnHeight(g, maxGuideLineValue, barWidth) : _height - (_margins * 2);
				Int32 minGuideLineHeight = _items.Count > 0 ? getColumnHeight(g, minGuideLineValue, barWidth) : _height - (_margins * 2);

				Pen xyPen = new Pen(_xyColor, _xyLineWidth);
				xyBrush = new SolidBrush(_xyTextColor);
				g.DrawLine(xyPen, guideLineWidth, _margins, guideLineWidth, _height - _margins);
				g.DrawLine(xyPen, _margins, baseY, _width - _margins, baseY);
				g.DrawString(getFormattedValue(_guideLineFormat,0), _guideLineFont, xyBrush, _margins, baseY);
				g.DrawString(_xLabel, _guideLineFont, xyBrush, (float)(0.5 * _width) - _margins, _height - _margins);
				g.DrawString(_yLabel, _guideLineFont, xyBrush, barWidth / 2, 0);
				Pen glPen = new Pen(_guideLineColor, _guideLineWidth);
				Brush glBrush = new SolidBrush(_guideLineTextColor);
				for (int x = 0; x < positiveGuideLines; x++)
				{
					Single pos = baseY - (maxGuideLineHeight / positiveGuideLines * (x + 1));
					g.DrawLine(glPen, _margins, pos, _width - _margins, pos);
					g.DrawString(getFormattedValue(_guideLineFormat, maxGuideLineValue / positiveGuideLines * (x + 1)), _guideLineFont, glBrush, _margins, baseY - (maxGuideLineHeight / positiveGuideLines * (x + 1)));
				}
				for (int x = 0; x < negativeGuideLines; x++)
				{
					Single pos = baseY - (minGuideLineHeight / negativeGuideLines * (x + 1));
					g.DrawLine(glPen, _margins, pos, _width - _margins, pos);
					g.DrawString(getFormattedValue(_guideLineFormat, minGuideLineValue / negativeGuideLines * (x + 1)), _guideLineFont, glBrush, _margins, baseY - (minGuideLineHeight / negativeGuideLines * (x + 1)));
				}
			}

			foreach (ColumnChartItem item in _items)
			{
				Int32 l1 = _margins + (_columnSpacing * barCounter) + (barCounter * barWidth) + guideLineWidth;
				Int32 l2 = _margins + (_columnSpacing * barCounter) + (barCounter * barWidth) + barWidth + guideLineWidth;
				Int32 h = getColumnHeight(g, item.Value, barWidth);

				Int32 elTop1 = baseY - h - (_depth / 2);
				Int32 elTop2 = baseY - (_depth / 2);
				if (elTop2 < elTop1)
				{
					Int32 auxTop = elTop1;
					elTop1 = elTop2;
					elTop2 = auxTop;
				}

				Rectangle colR = new Rectangle(l1, (h > 0 ? baseY - h : baseY), barWidth, Math.Abs(h));
				if (colR.Height > 0)
				{
					LinearGradientBrush b1 = new LinearGradientBrush(colR, item.FillColor, Color.FromArgb(30, item.FillColor), 360);
					g.FillRectangle(b1, colR);
				}

				Rectangle elR = new Rectangle(l1, baseY, barWidth, _depth);
				if (_depth > 0 && elR.Height > 0)
				{
					LinearGradientBrush b2 = new LinearGradientBrush(elR, item.FillColor, Color.FromArgb(30, item.FillColor), 360);
					g.FillEllipse(b2, l1, elTop1, barWidth, _depth);
					g.FillEllipse(b2, l1, elTop2, barWidth, _depth);
				}

				if (_showValues)
				{
					String str = getFormattedValue(_valueFormat, item.Value);
					SizeF strSize1 = g.MeasureString(str, _valueFont);
					g.DrawString(str, _valueFont, Brushes.Black, (l1 + barWidth / 2) - strSize1.Width / 2 + 2, elTop1 - strSize1.Height + 2);
				}

				if (_showDescriptions)
				{
					SizeF strSize2 = g.MeasureString(item.Description, _descriptionFont, barWidth);
					StringFormat sf = new StringFormat();
					sf.Alignment = StringAlignment.Center;
					g.DrawString(item.Description, _descriptionFont, Brushes.Black, new RectangleF(l1 + 2, _height - top + _depth / 2, barWidth, strSize2.Height), sf);								
				}		
			barCounter++;
			}
			g.Dispose();
			return bmp;
		}

		Int32 getPositiveGuideLines()
		{
			Decimal maxValue = getMaxColumnValue();
			Decimal minValue = getMinColumnValue();
			Decimal totalValue = getTotalValue();
			if (totalValue == maxValue)
				return _guideLinesCount;
			if (totalValue == minValue)
				return 0;
			return Convert.ToInt32(_guideLinesCount * (maxValue / totalValue));
		}

		Int32 getNegativeGuideLines()
		{
			Decimal maxValue = getMaxColumnValue();
			Decimal minValue = getMinColumnValue();
			Decimal totalValue = getTotalValue();
			if (totalValue == Math.Abs(minValue))
				return _guideLinesCount;
			if (totalValue == maxValue)
				return 0;
			return Math.Abs(Convert.ToInt32(_guideLinesCount * (minValue / totalValue)));
		}

		public void SaveAs(String filename)
		{
			Bitmap bmp = GetChart();
			bmp.Save(filename);
		}

		public void SaveAs(String filename, ImageFormat imageFormat)
		{
			Bitmap bmp = GetChart();
			bmp.Save(filename, imageFormat);
		}

		public void SetDataSource(DataTable source, String valueColumn, String descriptionColumn)
		{
			Color[] colors = new Color[] { Color.DarkOrange, Color.Blue, Color.Red, Color.DarkGreen, Color.Black, Color.DarkBlue, Color.DarkRed };
			for (int x = 0; x < source.Rows.Count; x++)
			{
				Decimal v = source.Rows[x][valueColumn] != DBNull.Value ? Convert.ToDecimal(source.Rows[x][valueColumn]) : 0;
				String d = source.Rows[x][descriptionColumn] != DBNull.Value ? Convert.ToString(source.Rows[x][descriptionColumn]) : null;
				Items.Add(new ColumnChartItem(colors[x], d, v));
			}
		}
		#endregion

		#region private methods
		Int32 getColumnWidth(Int32 maxValueWidth)
		{
			if (!_showGuideLines)
				maxValueWidth = 0;
			return (_width - (2 * _margins) - ((_items.Count - 1) * _columnSpacing) - maxValueWidth) / _items.Count;
		}

		Decimal getTotalValue()
		{
			Decimal maxValue = getMaxColumnValue();
			Decimal minValue = getMinColumnValue();
			if (maxValue > 0 && minValue >= 0)
				return Math.Abs(maxValue);
			else if (maxValue > 0 && minValue < 0)
				return Math.Abs(maxValue) + Math.Abs(minValue);
			else if (maxValue <= 0 && minValue < 0)
				return Math.Abs(minValue);
			return maxValue;
		}

		Int32 getColumnHeight(Graphics g, Decimal itemValue, Int32 barWidth)
		{
			if (_items.Count == 0)
				return 0;

			Decimal totalValue = getTotalValue();
			if (totalValue == 0)
				return 0;

			Decimal maxLengthValue = getMaxLengthValue();
			Int32 valueHeight = Convert.ToInt32(g.MeasureString(getFormattedValue(_valueFormat, maxLengthValue), _valueFont).Height);
			Int32 descriptionHeight = getMaxDescriptionHeight(g, barWidth);
			if (!_showValues)
				valueHeight = 0;
			if (!_showDescriptions)
				descriptionHeight = 0;
			return Convert.ToInt32(((Convert.ToDecimal(itemValue) * 100m) / totalValue * (_height - _depth - valueHeight - descriptionHeight - 2 * _margins)) / 100m);
		}

		Decimal getMaxLengthValue()
		{
			Decimal maxLengthValue = 0;
			Int32 maxLength = 0;
			foreach (ColumnChartItem item in _items)
			{
				String formattedValue = getFormattedValue(_valueFormat, item.Value);
				if (formattedValue.Length > maxLength)
				{
					maxLengthValue = item.Value;
					maxLength = formattedValue.Length;
				}
			}
			return maxLengthValue;
		}

		Int32 getMaxColumnHeight(Graphics g, Int32 barWidth)
		{
			Decimal maxValue = getMaxColumnValue();
			return getColumnHeight(g, maxValue, barWidth);
		}

		String getFormattedValue(String format, Decimal value)
		{
			return String.Format("{0:" + ValueFormat + "}", value);
		}

		Decimal getMaxColumnValue()
		{
			if (_items.Count == 0)
				return 0;

			Decimal maxValue = _items[0].Value;
			foreach (ColumnChartItem p in _items)
				if (p.Value > maxValue)
					maxValue = p.Value;
			return maxValue;
		}

		Decimal getMinColumnValue()
		{
			if (_items.Count == 0)
				return 0;

			Decimal minValue = _items[0].Value;
			foreach (ColumnChartItem p in _items)
				if (p.Value < minValue)
					minValue = p.Value;
			return minValue;
		}

		Int32 getMaxDescriptionHeight(Graphics g, Int32 barWidth)
		{
			String maxDescription = getMaxLengthDescription();
			SizeF strSize = g.MeasureString(maxDescription, _descriptionFont, barWidth);
			return Convert.ToInt32(strSize.Height);
		}

		String getMaxLengthDescription()
		{
			if (_items.Count == 0)
				return null;

			String str = _items[0].Description;
			foreach (ColumnChartItem p in _items)
				if (p.Description != null && p.Description.Length > str.Length)
					str = p.Description;
			return str;
		}
		#endregion
	}
}
