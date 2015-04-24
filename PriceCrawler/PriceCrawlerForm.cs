using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CsvHelper;
using CsvHelper.Configuration;

namespace PriceCrawler
{
    public partial class PriceCrawlerForm : Form
    {
        public PriceCrawlerForm()
        {
            InitializeComponent();
            InitPath();
        }

        private StreamWriter cfmSw, efishSw;
        private CsvWriter cfmWrite, efishWrite;
        private void InitPath()
        {
            var filename1 = string.Concat("Cfm-", DateTime.Now.ToString("yyyyMMdd"), "-", new Random().Next(1000, 9999), ".csv");
            var filename2 = string.Concat("Efish-", DateTime.Now.ToString("yyyyMMdd"), "-", new Random().Next(1000, 9999), ".csv");
            var path = Application.StartupPath;
            savePath1.Text = Path.Combine(path, filename1);
            savePath2.Text = Path.Combine(path, filename2);
        }

        private void btnStart2_Click(object sender, EventArgs e)
        {
            if (!CheckDate())
                return;
            efishSw = new StreamWriter(savePath2.Text, false, Encoding.UTF8);
            efishWrite = new CsvWriter(efishSw);
            var csv = new CsvObj
            {
                MarketName = "市场名",
                ProductName = "产品名",
                Code = "代码",
                Spec = "规格",
                TopPrice = "上价",
                MidPrice = "中价",
                LowPrice = "下价",
                Date = "发布日期"
            };
            efishWrite.WriteRecord(csv);
            ThreadPool.QueueUserWorkItem(delegate { EfishStart(); });
        }

        private void btnStart1_Click(object sender, EventArgs e)
        {
            if (!CheckDate())
                return;
            cfmSw = new StreamWriter(savePath1.Text, false, Encoding.UTF8);
            cfmWrite = new CsvWriter(cfmSw);
            var csv = new CsvObj
            {
                MarketName = "市场名",
                ProductName = "产品名",
                Code = "代码",
                Spec = "规格",
                TopPrice = "上价",
                MidPrice = "中价",
                LowPrice = "下价",
                Date = "发布日期"
            };
            cfmWrite.WriteRecord(csv);
            ThreadPool.QueueUserWorkItem(delegate { CfmStart(); });
        }

        private DateTime startDate, endDate;
        private bool CheckDate()
        {
            //startDate = new DateTime(dpStart.Value.Year, dpStart.Value.Month, dpStart.Value.Day);
            //endDate = new DateTime(dpEnd.Value.Year, dpEnd.Value.Month, dpEnd.Value.Day);
            startDate = dpStart.Value.Date;
            endDate = dpEnd.Value.Date;
            if (startDate > endDate)
            {
                MessageBox.Show("开始时间不能超过结束时间");
                return false;
            }

            return true;
        }

        bool IsInDateSpan(string s)
        {
            try
            {
                DateTime dt = DateTime.Parse(s);
                if (dt < startDate || dt > endDate)
                    return false;
                return true;
            }
            catch (Exception)
            {

                return false;
            }


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

public class CsvObj
{
    public string MarketName { get; set; }
    public string ProductName { get; set; }
    public string Code { get; set; }
    public string Spec { get; set; }
    public string TopPrice { get; set; }
    public string MidPrice { get; set; }
    public string LowPrice { get; set; }
    public string Date { get; set; }
}