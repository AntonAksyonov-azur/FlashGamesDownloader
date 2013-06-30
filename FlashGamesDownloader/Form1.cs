﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FlashGamesDownloader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            Regex rg = new Regex(tbReg.Text);
            MatchCollection result = rg.Matches(tbSource.Text);

            foreach (var value in result)
            {
                listBox1.Items.Add(value);
            }
        }
    }
}
