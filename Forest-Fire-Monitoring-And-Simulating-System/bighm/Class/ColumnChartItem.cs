using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bighm.Class
{
    class ColumnChartItem
    {

		#region fields
		Color _fillColor;
		Decimal _value;
		String _description;
		#endregion

		#region properties
		public Color FillColor
		{
			get { return _fillColor; }
			set { _fillColor = value; }
		}
		public Decimal Value
		{
			get { return _value; }
			set { _value = value; }
		}
		public String Description
		{
			get { return _description; }
			set { _description = value; }
		}
		#endregion

		#region constructors
		public ColumnChartItem() { }
		public ColumnChartItem(Color fillColor, String description, Decimal value)
		{
			_fillColor = fillColor;
			_description = description;
			_value = value;
		}
		#endregion
	}
}
