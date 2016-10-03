namespace Anhkheg2
{
	partial class FuelPurchaseDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label_Date = new System.Windows.Forms.Label();
			this.label_TripMileage = new System.Windows.Forms.Label();
			this.textbox_TripMileage = new System.Windows.Forms.TextBox();
			this.textbox_Odometer = new System.Windows.Forms.TextBox();
			this.textbox_Gallons = new System.Windows.Forms.TextBox();
			this.textbox_Cost = new System.Windows.Forms.TextBox();
			this.label_Odometer = new System.Windows.Forms.Label();
			this.label_Gallons = new System.Windows.Forms.Label();
			this.label_Cost = new System.Windows.Forms.Label();
			this.button_OK = new System.Windows.Forms.Button();
			this.dateTimePicker_Date = new System.Windows.Forms.DateTimePicker();
			this.SuspendLayout();
			// 
			// label_Date
			// 
			this.label_Date.AutoSize = true;
			this.label_Date.Location = new System.Drawing.Point(12, 9);
			this.label_Date.Name = "label_Date";
			this.label_Date.Size = new System.Drawing.Size(30, 13);
			this.label_Date.TabIndex = 0;
			this.label_Date.Text = "Date";
			// 
			// label_TripMileage
			// 
			this.label_TripMileage.AutoSize = true;
			this.label_TripMileage.Location = new System.Drawing.Point(12, 35);
			this.label_TripMileage.Name = "label_TripMileage";
			this.label_TripMileage.Size = new System.Drawing.Size(65, 13);
			this.label_TripMileage.TabIndex = 1;
			this.label_TripMileage.Text = "Trip Mileage";
			// 
			// textbox_TripMileage
			// 
			this.textbox_TripMileage.Location = new System.Drawing.Point(89, 32);
			this.textbox_TripMileage.Name = "textbox_TripMileage";
			this.textbox_TripMileage.Size = new System.Drawing.Size(127, 20);
			this.textbox_TripMileage.TabIndex = 3;
			// 
			// textbox_Odometer
			// 
			this.textbox_Odometer.Location = new System.Drawing.Point(89, 58);
			this.textbox_Odometer.Name = "textbox_Odometer";
			this.textbox_Odometer.Size = new System.Drawing.Size(127, 20);
			this.textbox_Odometer.TabIndex = 4;
			// 
			// textbox_Gallons
			// 
			this.textbox_Gallons.Location = new System.Drawing.Point(89, 84);
			this.textbox_Gallons.Name = "textbox_Gallons";
			this.textbox_Gallons.Size = new System.Drawing.Size(127, 20);
			this.textbox_Gallons.TabIndex = 5;
			// 
			// textbox_Cost
			// 
			this.textbox_Cost.Location = new System.Drawing.Point(89, 110);
			this.textbox_Cost.Name = "textbox_Cost";
			this.textbox_Cost.Size = new System.Drawing.Size(127, 20);
			this.textbox_Cost.TabIndex = 6;
			// 
			// label_Odometer
			// 
			this.label_Odometer.AutoSize = true;
			this.label_Odometer.Location = new System.Drawing.Point(12, 61);
			this.label_Odometer.Name = "label_Odometer";
			this.label_Odometer.Size = new System.Drawing.Size(53, 13);
			this.label_Odometer.TabIndex = 7;
			this.label_Odometer.Text = "Odometer";
			// 
			// label_Gallons
			// 
			this.label_Gallons.AutoSize = true;
			this.label_Gallons.Location = new System.Drawing.Point(12, 87);
			this.label_Gallons.Name = "label_Gallons";
			this.label_Gallons.Size = new System.Drawing.Size(42, 13);
			this.label_Gallons.TabIndex = 8;
			this.label_Gallons.Text = "Gallons";
			// 
			// label_Cost
			// 
			this.label_Cost.AutoSize = true;
			this.label_Cost.Location = new System.Drawing.Point(14, 113);
			this.label_Cost.Name = "label_Cost";
			this.label_Cost.Size = new System.Drawing.Size(28, 13);
			this.label_Cost.TabIndex = 9;
			this.label_Cost.Text = "Cost";
			// 
			// button_OK
			// 
			this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button_OK.Location = new System.Drawing.Point(89, 157);
			this.button_OK.Name = "button_OK";
			this.button_OK.Size = new System.Drawing.Size(75, 23);
			this.button_OK.TabIndex = 10;
			this.button_OK.Text = "OK";
			this.button_OK.UseVisualStyleBackColor = true;
			// 
			// dateTimePicker_Date
			// 
			this.dateTimePicker_Date.CustomFormat = "MMM d, yyyy";
			this.dateTimePicker_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker_Date.Location = new System.Drawing.Point(89, 3);
			this.dateTimePicker_Date.Name = "dateTimePicker_Date";
			this.dateTimePicker_Date.Size = new System.Drawing.Size(127, 20);
			this.dateTimePicker_Date.TabIndex = 11;
			// 
			// FuelPurchaseDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 261);
			this.Controls.Add(this.dateTimePicker_Date);
			this.Controls.Add(this.button_OK);
			this.Controls.Add(this.label_Cost);
			this.Controls.Add(this.label_Gallons);
			this.Controls.Add(this.label_Odometer);
			this.Controls.Add(this.textbox_Cost);
			this.Controls.Add(this.textbox_Gallons);
			this.Controls.Add(this.textbox_Odometer);
			this.Controls.Add(this.textbox_TripMileage);
			this.Controls.Add(this.label_TripMileage);
			this.Controls.Add(this.label_Date);
			this.Name = "FuelPurchaseDialog";
			this.Text = "FuelPurchaseDialog";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label_Date;
		private System.Windows.Forms.Label label_TripMileage;
		private System.Windows.Forms.TextBox textbox_TripMileage;
		private System.Windows.Forms.TextBox textbox_Odometer;
		private System.Windows.Forms.TextBox textbox_Gallons;
		private System.Windows.Forms.TextBox textbox_Cost;
		private System.Windows.Forms.Label label_Odometer;
		private System.Windows.Forms.Label label_Gallons;
		private System.Windows.Forms.Label label_Cost;
		private System.Windows.Forms.Button button_OK;
		private System.Windows.Forms.DateTimePicker dateTimePicker_Date;
	}
}