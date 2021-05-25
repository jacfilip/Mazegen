using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mazegen
{
    public partial class MazeOptionsForm : Form
    {
        MainForm parent;

        public MazeOptionsForm(MainForm mf)
        {
            InitializeComponent();
            this.parent = mf;
        }

        private void X_numeric_ValueChanged(object sender, EventArgs e)
        {
            endx_numeric.Value = endx_numeric.Maximum = x_numeric.Value;
        }

        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            endy_numeric.Value = endy_numeric.Maximum = y_numeric.Value;
        }

        private void Generate_button_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Apply_button_Click(object sender, EventArgs e)
        {
            parent.SetMaze((int)this.x_numeric.Value, (int)this.y_numeric.Value, (double)this.branching_factor_numeric.Value / 100.0, new Point((int)this.startx_numeric.Value - 1, (int)this.starty_numeric.Value - 1), new Point((int)this.endx_numeric.Value - 1, (int)this.endy_numeric.Value - 1), this.solved_checkBox.Checked);
            this.Hide();
        }

        private void MazeOptionsForm_Load(object sender, EventArgs e)
        {
            if (parent.m != null)
            {
                x_numeric.Value = (decimal)parent.m.nX;
                y_numeric.Value = (decimal)parent.m.nY;
                startx_numeric.Value = (decimal)parent.m.startPoint.X + 1;
                starty_numeric.Value = (decimal)parent.m.startPoint.Y + 1;
                endx_numeric.Value = (decimal)parent.m.endPoint.X + 1;
                endy_numeric.Value = (decimal)parent.m.endPoint.Y + 1;
                branching_factor_numeric.Value = (decimal)parent.complexity * 100;
                solved_checkBox.Checked = parent.path != null;
            }

        }
    }
}
