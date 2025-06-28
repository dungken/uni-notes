using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.Charts.WinForms;

namespace Source.Views.Admin
{
    public partial class TextDashBoard : Form
    {
        public TextDashBoard()
        {
            InitializeComponent();
            var test = new int[] { 1, 2, 3, 4, 5 };

            var collection = new LPointCollection();
            foreach (var item in test)
            {
                collection.Add("khoi", item);
                
            }

            gunaPieDataset1.DataPoints = collection;
            gunaBarDataset1.DataPoints = collection;

        }
    }
}
