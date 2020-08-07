using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reviser
{
    public partial class LineEditor : Form
    {
        public class LineData
        {
            public bool newLine { get; set; }
            public ProjectFile.FileContent fc { get; set; }
            public string lineId { get; set; }
            public string currentFile { get; set; }
        }

        LineData ld;

        public LineEditor(LineData lineData)
        {
            InitializeComponent();

            ld = lineData;

            FixLabels();
        }

        private void FixLabels()
        {
            int all = 3;

            int left = 14;
            int top = 28;
            int right = all;
            int bottom = all;
            
            Padding pad = new Padding(all);
            Padding top_pad = new Padding(left, top, right, bottom);

            tranLblText.Location = FixLabelsLocation(tranLblText);
            tranLblText.Padding = pad;
            tranLblText.Parent = tranLblPicBox;

            tranTextBox.Location = FixLabelsLocation(tranTextBox);
            tranTextBox.Padding = top_pad;
            tranTextBox.Parent = tranPicBox;

            origLblText.Location = FixLabelsLocation(origLblText);
            origLblText.Padding = pad;
            origLblText.Parent = origLblPicBox;

            origTextBox.Location = FixLabelsLocation(origTextBox);
            origTextBox.Padding = top_pad;
            origTextBox.Parent = origPicBox;
        }

        private Point FixLabelsLocation(Label label)
        {
            return label.PointToClient(this.PointToScreen(label.Location));
        }

        private void LineEditor_Load(object sender, EventArgs e)
        {
            if (ld.newLine)
            {
                Text = "Add New Line";
            }
            else
            {
                Text = "Edit Line";

                idBox.Text = ld.lineId;

                tranLblText.Text = ld.fc.character;
                tranTextBox.Text = ld.fc.tran_line;
                origLblText.Text = ld.fc.character;
                origTextBox.Text = ld.fc.orig_line;
            }
        }
    }
}
