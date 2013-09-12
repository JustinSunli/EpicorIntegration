﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EpicorIntegration
{
    public partial class TestTableViewer : Form
    {
        public TestTableViewer(DataSet ds)
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = true;

            BindingSource bindingsource1 = new BindingSource();

            bindingsource1.DataSource = ds.Tables["PartPlant"];

            dataGridView1.DataSource = bindingsource1;
        }

        private void TestTableViewer_Load(object sender, EventArgs e)
        {

        }
    }
}
