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
					dataGridView1.DataSource = AppObj.GetFuelPurchaseTable();
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
			}
		}

		private void addFuelPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			FuelPurchaseDialog dlgAddPurchase = new FuelPurchaseDialog();

			if (dlgAddPurchase.ShowDialog() == DialogResult.OK)
			{
				MessageBox.Show("You clicked OK on the add fuel purchase dialog.");
				// Get and parse the info entered.
			}
		}
	}
}
