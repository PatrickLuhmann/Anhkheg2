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
        private string CurrDbFilename;
		private DataSet CurrDataSet;
		private static UInt32 CurrSchemaVersion = 1;

        /// <summary>
        /// Open the given database file
        /// The filename is usually provided by the user, but could also
        /// be stored in a configuration file.
        /// </summary>
        /// <param name="filename"></param>
        public bool OpenDbFile(string filename)
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
					System.Windows.Forms.MessageBox.Show("Congratulations, you have selected a valid Anhkheg2 file.");
					return true;
				}
			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("Invalid file selected.\n" + ex.Message);
			}
			return false;

		}

		/// <summary>
		/// Close the currently-open database file
		/// The data is saved before the database is closed.
		/// </summary>
		public void CloseDbFile()
        {
			if (CurrDbFilename != null)
			{
				CurrDataSet.WriteXml(CurrDbFilename, XmlWriteMode.WriteSchema);
				CurrDbFilename = null;
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
			purchases.Columns.Add("TripMilage", typeof(Decimal));
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
		}

		public DataTable GetFuelPurchaseTable()
		{
			return CurrDataSet.Tables["Purchases"];
		}
	}
}
