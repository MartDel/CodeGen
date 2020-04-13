using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace CodeGen
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            this.AutoScaleDimensions = new SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
        }

        private void Home_Load(object sender, EventArgs e)
        {
            Control test = new Label();
            test.Text = "test" + Environment.NewLine + "encore";
            ListUpdate.Controls.Add(test);

        }
    }
}
