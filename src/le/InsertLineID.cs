using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Reviser.LE
{
    public partial class InsertLineID : Form
    {
        Regex idRx = new Regex(@"[^0-9-, ]*", RegexOptions.Compiled);
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
            lineIdBox.Text = idRx.Replace(lineIdBox.Text, "");
            lineIdBox.Select(lineIdBox.Text.Length, 0);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
