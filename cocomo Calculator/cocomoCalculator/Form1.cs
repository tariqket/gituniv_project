using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cocomoCalculator
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            indexes.fillData();

            // fill comboox type of project
            string[] indx = indexes.getProjectTypes();
            cBProjectType.Items.AddRange(indx);
            cBProjectType.SelectedIndex = 0;
        }

        private double countCocomoBAsic(string ProjectTypeName)
        {

            int size = int.Parse(tbSize.Text);
            //int size = 100;

            // 0 -a, 1-b, 2-c, 3-d
            double[] basicIndexes = indexes.getIndexesByPrjName(ProjectTypeName, 0);
            // a*(size)^b
            double PM = basicIndexes[0] * Math.Pow(size,basicIndexes[1]);

            // c*(PM)^d
            double TM = basicIndexes[2] * Math.Pow(PM, basicIndexes[3]);

            return TM;
        }





        //-----------------------------------
        //------------------------FORM EVENTS
        //-----------------------------------
        private void tbSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar)
                    || e.KeyChar == '\b')) //only digits and backspace
            {
                e.Handled = true;
            }
        }

        private void btnBasic_Click(object sender, EventArgs e)
        {
            if (tbSize.Text.Length > 0 && cBProjectType.SelectedIndex != -1)
            {
                lblTMis.Text = countCocomoBAsic(cBProjectType.Text).ToString();
            }
            else if (tbSize.Text.Length == 0)
            {
                MessageBox.Show("entr size first");
            }
            else if (cBProjectType.SelectedIndex == -1)
            {
                MessageBox.Show("choose project type first");
            }
                
        }

    }
}
