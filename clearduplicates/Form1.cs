using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace clearduplicates
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        public void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
		    this.openFileDialog1.FileName = "";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                input.Text = this.openFileDialog1.FileName;
				string otpot = input.Text.Replace(".txt", "");
				output.Text = otpot+"_Cleaned.txt";
				string ext = Path.GetExtension(output.Text);
				var lineCounter = 0;
				using (var reader = new StreamReader(input.Text))
				{
					while (reader.ReadLine() != null)
					{
						lineCounter++;
					}
					rows.Text = Convert.ToString(lineCounter);
				}
			}
        }

        private void clear_Click(object sender, EventArgs e)
        {
            if (!File.Exists(this.input.Text))
			{
				MessageBox.Show("Error, please insert a correct file path to remove duplicate lines.");
				return;
			}
			if (string.IsNullOrEmpty(output.Text))
			{
				MessageBox.Show("Error, please insert a file path to save new file without duplicate lines.");
				return;
			}
			try
			{
				List<string> UnrepeatedList = File.ReadAllText(input.Text).Split(new string[]
				{
					Environment.NewLine
				}, StringSplitOptions.None).ToList<string>().Distinct<string>().ToList<string>();
				File.WriteAllLines(output.Text, UnrepeatedList.ToArray());
				var lineCounter = 0;

				using (var reader = new StreamReader(output.Text))
				{
					while (reader.ReadLine() != null)
					{
						lineCounter++;
					}
					cleaned.Text = Convert.ToString(lineCounter);
					int a = Int32.Parse(cleaned.Text);
					int b = Int32.Parse(rows.Text);
					int c = b - a;
					duplicates.Text = Convert.ToString(c);
				}
			}
			catch (Exception exp)
			{
				MessageBox.Show("Error. " + exp.Message);
			}
			MessageBox.Show("File successfully created.");
		}

        private void bunifulines_Click(object sender, EventArgs e)
        {

        }

        private void labelClose_Click(object sender, EventArgs e)
        {
			Application.Exit();

		}

        private void labelHide_Click(object sender, EventArgs e)
        {
			base.WindowState = FormWindowState.Minimized;

		}

		private void panelInfo_MouseDown(object sender, MouseEventArgs e)
		{
			this.iFormX = base.Location.X;
			this.iFormY = base.Location.Y;
			this.iMouseX = Control.MousePosition.X;
			this.iMouseY = Control.MousePosition.Y;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x000036DC File Offset: 0x000018DC
		private void panelInfo_MouseMove(object sender, MouseEventArgs e)
		{
			int x = Control.MousePosition.X;
			int y = Control.MousePosition.Y;
			if (e.Button == MouseButtons.Left)
			{
				base.Location = new Point(this.iFormX + (x - this.iMouseX), this.iFormY + (y - this.iMouseY));
			}
		}
		private int iFormX;

		// Token: 0x04000016 RID: 22
		private int iFormY;

		// Token: 0x04000017 RID: 23
		private int iMouseX;

		// Token: 0x04000018 RID: 24
		private int iMouseY;


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }


}
