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
                lineBox.Text = FormatSavedLines(ld.fc);
                commentBox.Text = ld.fc.proposal;

            }
        }

        private string FormatSavedLines(ProjectFile.FileContent fc)
        {
            StringBuilder sb = new StringBuilder();

            int len = fc.character.Length;
            string lastChar = "";

            for (int i = 0; i < len; i++)
            {
                if (lastChar == fc.character[i])
                {
                    sb.AppendLine();
                }
                else
                {
                    if (sb.Length > 0)
                        sb.AppendLine();

                    sb.AppendLine(fc.character[i] + ":");
                }

                lastChar = fc.character[i];

                sb.AppendLine(fc.orig_line[i]);
                sb.AppendLine(fc.tran_line[i]);
            }            

            return sb.ToString();
        }
    }
}
