using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace EveryJuanCount
{
    public partial class ResidentsForm3 : Form
    {
        
         
        public ResidentsForm3()
        {
            InitializeComponent();
        }

   

        bool sidebarExpand = true;
        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                sidebar.Width -= 4;
                if (sidebar.Width <= 66)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();
                    
                }
            }
            else
            {
                sidebar.Width += 4;
                if (sidebar.Width >= 249)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();

                    pl2Dashboard_ResF.Width = sidebar.Width;
                    pl3MyPrrofile_ResF.Width = sidebar.Width;
                    pl4SubmitRep_ResF.Width = sidebar.Width;
                    pl5RepHistory_ResF.Width = sidebar.Width;
                    pl6ChangePass_ResF.Width = sidebar.Width;

                }
            }
        }

        private void btHam_ResF_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

    }
}
