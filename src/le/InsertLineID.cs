using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Reviser.LE
{
    public partial class InsertLineID : Form
    {
        private readonly Regex idRx = new(@"[^0-9-, ]*", RegexOptions.Compiled);
        public InsertLineID()
        {
            InitializeComponent();
        }

        public string lineId;

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lineIdBox.Text))
            {
                lineId = lineIdBox.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void lineIdBox_TextChanged(object sender, EventArgs e)
        {
            lineIdBox.Text = idRx.Replace(lineIdBox.Text, string.Empty);
            lineIdBox.Select(lineIdBox.Text.Length, 0);
            okButton.Enabled = lineIdBox.Text.Length > 0;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
