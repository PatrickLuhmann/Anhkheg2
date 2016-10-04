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
    public partial class MainGUI : Form
    {
        Anhkheg2App AppObj;

        public MainGUI(Anhkheg2App app)
        {
            AppObj = app;
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("File -> Open");

            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = "c:\\";
            fileDialog.Filter = "XML files|*.xml";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                System.Diagnostics.Debug.WriteLine("The user selected the file " + fileDialog.FileName);

				if (AppObj.OpenDbFile(fileDialog.FileName))
				{
					UpdateFuelPurchaseDataView();
				}
            }
        }

		private void newToolStripMenuItem_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.WriteLine("File -> New");

			SaveFileDialog fileDialog = new SaveFileDialog();
			fileDialog.InitialDirectory = "c:\\";
			fileDialog.Filter = "XML files|*.xml";
			fileDialog.OverwritePrompt = true;

			if (fileDialog.ShowDialog() == DialogResult.OK)
			{
				System.Diagnostics.Debug.WriteLine("The user selected the file " + fileDialog.FileName);

				AppObj.CreateNewDbFile(fileDialog.FileName);

				UpdateFuelPurchaseDataView();
			}
		}

		private void addFuelPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!AppObj.IsDbOpen)
			{
				MessageBox.Show("ERROR: A database file must be opened before adding a fuel purchase.", "No database open");
				return;
			}

			FuelPurchaseDialog dlgAddPurchase = new FuelPurchaseDialog();

			if (dlgAddPurchase.ShowDialog() == DialogResult.OK)
			{
				// Send the data to the app for processing.
				try
				{
					// Get and parse the info entered.
					DateTime newDate = dlgAddPurchase.Date.Date;  // want date only
					Decimal newTripMileage = dlgAddPurchase.TripMileage;
					UInt32 newOdometer = dlgAddPurchase.Odometer;
					Decimal newGallons = dlgAddPurchase.Gallons;
					Decimal newCost = dlgAddPurchase.Cost;
					System.Diagnostics.Debug.WriteLine("You clicked OK\n" +
						"Date: " + newDate + "\n" +
						"Trip Mileage: " + newTripMileage.ToString() + "\n" +
						"Odometer: " + newOdometer.ToString() + "\n" +
						"Gallons: " + newGallons.ToString() + "\n" +
						"Cost: " + newCost.ToString() + "\n");

					// Add it to the db.
					AppObj.AddFuelPurchase(newDate, newTripMileage, newOdometer, newGallons, newCost);

					// Save the db back to its file.
					AppObj.SaveDbFile();

					// Update the main data view.
					UpdateFuelPurchaseDataView();
				}
				catch (Exception Ex)
				{
					MessageBox.Show("ERROR: Bad input.\n" + Ex.Message);
				}
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Assume that there are no unsaved changes.
			Application.Exit();
		}

		private void UpdateFuelPurchaseDataView()
		{
			dataGridView1.DataSource = AppObj.GetFuelPurchaseTable();
			dataGridView1.Columns["ID"].Visible = false;
		}

		private void deleteFuelPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// A single purchase must already be selected
			// TODO: Allow multiple deletions at a time?
			System.Diagnostics.Debug.Write("Selected rows: ");
			foreach (DataGridViewRow r in dataGridView1.SelectedRows)
			{
				// Get the ID for the selected row
				string idx = r.Cells["ID"].Value.ToString();
				UInt32 i_idx = Convert.ToUInt32(r.Cells["ID"].Value);
				String msg = "ID of row " + r.Index.ToString() + " is " + i_idx.ToString() + "; ";
				System.Diagnostics.Debug.Write(msg);

				DataRow selRow = ((DataTable)dataGridView1.DataSource).Rows.Find(i_idx);
				selRow.Delete();
				((DataTable)dataGridView1.DataSource).AcceptChanges(); // not sure if this is needed
			}

			// Delete the row from the Purchases table.

			// Redraw the data grid.
			UpdateFuelPurchaseDataView();
		}
	}
}
