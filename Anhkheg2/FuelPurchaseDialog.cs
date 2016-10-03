using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Anhkheg2
{
	public partial class FuelPurchaseDialog : Form
	{
		public FuelPurchaseDialog()
		{
			InitializeComponent();
		}

		public DateTime Date
		{
			get { return dateTimePicker_Date.Value; }
		}

		public Decimal TripMileage
		{
			// TripMileage: decimal(6,1). 
			get { return Convert.ToDecimal(textbox_TripMileage.Text); }
		}

		public UInt32 Odometer
		{
			// Odometer: int.
			get { return Convert.ToUInt32(textbox_Odometer.Text); }
		}

		public Decimal Gallons
		{
			// Gallons: decimal(,3).
			get { return Convert.ToDecimal(textbox_Gallons.Text); }
		}

		public Decimal Cost
		{
			// Cost: decimal(,2).
			get { return Convert.ToDecimal(textbox_Cost.Text); }
		}
	}
}
