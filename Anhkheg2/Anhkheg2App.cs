using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Anhkheg2
{
    public class Anhkheg2App
    {
        private String CurrDbFilename;
		private DataSet CurrDataSet;
		private static UInt32 CurrSchemaVersion = 1;

		public Boolean IsDbOpen
		{
			get { return CurrDbFilename != null; }
		}

        /// <summary>
        /// Open the given database file
        /// The filename is usually provided by the user, but could also
        /// be stored in a configuration file.
        /// </summary>
        /// <param name="filename">The full name of the database file.</param>
        public Boolean OpenDbFile(string filename)
        {
			if (!System.IO.File.Exists(filename))
				return false;

			CloseDbFile();

			CurrDbFilename = filename;
			CurrDataSet = new DataSet();
			CurrDataSet.ReadXml(CurrDbFilename);

			// Verify that this is a valid Anhkheg2 database file.
			string appName = "";
			try
			{
				DataRow row;
				UInt32 version;
				row = CurrDataSet.Tables["ConfigParams"].Rows.Find("AppName");
				appName = (string)row["Value"];
				System.Diagnostics.Debug.WriteLine("AppName: " + appName);
				row = CurrDataSet.Tables["ConfigParams"].Rows.Find("SchemaVersion");
				version = UInt32.Parse((string)row["Value"]);
				System.Diagnostics.Debug.WriteLine("SchemaVersion: " + row["Value"]);
				if (appName != "Anhkheg2" || version != CurrSchemaVersion)
				{
					throw new Exception();
				}
				else
				{
					System.Diagnostics.Debug.WriteLine("Valid Anhkheg2 file selected: " + filename);
				}
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Invalid file selected.\n" + ex.Message);
				CloseDbFile();
				return false;
			}
			return true;

		}

		/// <summary>
		/// Saves the currently-open database file.
		/// If there is no open file, then this function does nothing.
		/// </summary>
		public void SaveDbFile()
		{
			if (CurrDbFilename != null)
			{
				CurrDataSet.WriteXml(CurrDbFilename, XmlWriteMode.WriteSchema);
			}
		}

		/// <summary>
		/// Close the currently-open database file
		/// The data is saved before the database is closed.
		/// </summary>
		public void CloseDbFile()
        {
			SaveDbFile();
			CurrDbFilename = null;
			if (CurrDataSet != null)
			{
				// Still not sure if need to Dispose or something here.
				CurrDataSet = null;
			}
		}

		/// <summary>
		/// Create a new database and save it to the specified file.
		/// If 'filename' already exists then it will be deleted before
		/// the new database file is created.
		/// </summary>
		/// <param name="filename"></param>
		public void CreateNewDbFile(string filename)
		{
			CloseDbFile();

			// Create a new DataSet with the Anhkheg2 schema.
			DataSet newDb = new DataSet("Anhkheg2DateFile");
			DataRow row;

			// TABLE: Purchases
			DataTable purchases = newDb.Tables.Add("Purchases");
			purchases.Columns.Add("ID", typeof(UInt32));
			purchases.PrimaryKey = new DataColumn[] { purchases.Columns["ID"] };
			purchases.Columns["ID"].AutoIncrement = true;
			purchases.Columns["ID"].AutoIncrementSeed = 1;
			purchases.Columns["ID"].AutoIncrementStep = 1;
			purchases.Columns.Add("Date", typeof(DateTime));
			purchases.Columns.Add("Gallons", typeof(Decimal));
			purchases.Columns.Add("TripMileage", typeof(Decimal));
			purchases.Columns.Add("Cost", typeof(Decimal));
			purchases.Columns.Add("Odometer", typeof(UInt32));

			// TABLE: ConfigParams
			DataTable configParameters = newDb.Tables.Add("ConfigParams");
			configParameters.Columns.Add("Name", typeof(String));
			configParameters.PrimaryKey = new DataColumn[] { configParameters.Columns["Name"] };
			configParameters.Columns.Add("Value", typeof(String));

			row = configParameters.NewRow();
			row["Name"] = "AppName";
			row["Value"] = "Anhkheg2";
			configParameters.Rows.Add(row);

			row = configParameters.NewRow();
			row["Name"] = "SchemaVersion";
			row["Value"] = "1";
			configParameters.Rows.Add(row);

			newDb.WriteXml(filename, XmlWriteMode.WriteSchema);

			CurrDbFilename = filename;
			CurrDataSet = newDb;
		}

		public DataTable GetFuelPurchaseTable()
		{
			return CurrDataSet.Tables["Purchases"];
		}

		public void AddFuelPurchase(DateTime date, Decimal tripMileage, UInt32 odometer, Decimal quantity, Decimal cost)
		{
			// Create a new row in the Purchases table.
			DataRow RowToAdd = CurrDataSet.Tables["Purchases"].NewRow();
			RowToAdd["Date"] = date;
			RowToAdd["TripMileage"] = tripMileage;
			RowToAdd["Odometer"] = odometer;
			RowToAdd["Gallons"] = quantity;
			RowToAdd["Cost"] = cost;
			CurrDataSet.Tables["Purchases"].Rows.Add(RowToAdd);
		}

		public void DeleteFuelPurchases(UInt32[] indices)
		{
			foreach (UInt32 idx in indices)
			{
				DataRow selRow = CurrDataSet.Tables["Purchases"].Rows.Find(idx);
				selRow.Delete();
			}
			CurrDataSet.Tables["Purchases"].AcceptChanges(); // not sure if this is needed

		}
	}
}
