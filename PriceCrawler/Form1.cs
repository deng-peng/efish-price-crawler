﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PriceCrawler
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitPath();
        }

        private void InitPath()
        {
            var filename1 = string.Concat(DateTime.Now.ToString("yyyyMMdd"), "-", new Random().Next(1000, 9999), ".csv");
            var filename2 = string.Concat(DateTime.Now.ToString("yyyyMMdd"), "-", new Random().Next(1000, 9999), ".csv");
            var path = Application.StartupPath;
            savePath1.Text = Path.Combine(path, filename1);
            savePath2.Text = Path.Combine(path, filename2);
        }

        private void btnStart2_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(delegate { EfishStart(); });
        }

        private void btnStart1_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(delegate { CfmStart(); });
        }

    }

}

public class Market
{
    public int Mid { get; set; }

    public string Mname { get; set; }

    public string Mdate { get; set; }

    public string Price { get; set; }

    //public string CrawlTime { get; set; }
}
