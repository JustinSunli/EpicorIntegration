﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Epicor.Mfg.Core;
using Epicor.Mfg.BO;

namespace EpicorIntegration
{
    public partial class EpicLogin : Form
    {
        public EpicLogin()
        {
            InitializeComponent();
        }

        private void EpicLogin_Load(object sender, EventArgs e)
        {

        }

        private const int CP_NOCLOSE_BUTTON = 0x200;

	    protected override CreateParams CreateParams
	    {
            get
		    {
			    CreateParams mdiCp = base.CreateParams;
			    mdiCp.ClassStyle = mdiCp.ClassStyle | CP_NOCLOSE_BUTTON;
			    return mdiCp;
		    }
	    }

        private void Cancelbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Savebtn_Click(object sender, EventArgs e)
        {
            //save settings to resource file then test settings to connect

            Properties.Settings.Default.uname = Uname.Text;

            Properties.Settings.Default.passw = Passw.Text;

            string server = Properties.Settings.Default .svrname + ":" + Properties.Settings.Default.svrport;

            try
            {
                BLConnectionPool EpicConn = new BLConnectionPool(Uname.Text, Passw.Text, "AppServerDC://" + server);

                Part EpicPart = new Part(EpicConn);
               
                bool ValidLogin = EpicPart.PartExists(null);

                this.Close();

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message,"Try Again");
            }
        }
    }
}
