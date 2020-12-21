using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Reviser
{
    public partial class InsertLineID : Form
    {
        public InsertLineID()
        {
            InitializeComponent();
        }

        public string lineId;

        private void okButton_Click(object sender, EventArgs e)
        {
            if (lineIdBox.Text.Length != 0)
            {
                lineId = lineIdBox.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                DialogResult dr = MessageBox.Show("Insert a line ID to continue.", null, MessageBoxButtons.OKCancel);

                if (dr == DialogResult.OK)
                {
                    lineIdBox.Clear();
                }
                else if (dr == DialogResult.Cancel)
                {
                    DialogResult = dr;
                    Close();
                }
            }
        }

        private void lineIdBox_TextChanged(object sender, EventArgs e)
        {
            Regex rx = new Regex(@"[^0-9-, ]*", RegexOptions.Compiled);

            foreach (Match match in rx.Matches(lineIdBox.Text))
            {
                if (string.IsNullOrWhiteSpace(match.Value))
                    lineIdBox.Text = rx.Replace(lineIdBox.Text, "");
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
