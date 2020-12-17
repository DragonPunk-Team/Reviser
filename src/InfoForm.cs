using System;
using System.Windows.Forms;

namespace Reviser
{
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
        }

        private void InfoForm_Load(object sender, EventArgs e)
        {
            linkLabel1.Links.Add(27, 8, "Flaticon");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if ((string)e.Link.LinkData == "Flaticon")
                System.Diagnostics.Process.Start("https://www.flaticon.com/");
            else
                System.Diagnostics.Process.Start("https://www.flaticon.com/authors/freepik");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://icons8.com/icons/color");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.newtonsoft.com/json");
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
