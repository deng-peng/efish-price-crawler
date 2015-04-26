using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace PriceCrawler
{
    public partial class PriceCrawlerForm
    {
        Dictionary<string, string> _efishMarketDict;


        private const string EfishDataUrl = "http://efish.fa.gov.tw/efish/statistics/daysinglemarketmultifish.htm";

        //"dateStr=104.4.12&calendarType=tw&year=104&month=4&day=12&mid=F109&numbers=999&orderby=w"
        private const string EfishDataBody = "dateStr={0}&calendarType=tw&year={1}&month={2}&day={3}&mid={4}&numbers=999&orderby=w";
        void EfishStart()
        {
            _efishMarketDict = new Dictionary<string, string>
            {
                {"F109","台北"},
#if !DEBUG
                {"F200","基隆"},
                {"F241","三重"},
                {"F261","頭城"},
                {"F270","蘇澳"},
                {"F300","新竹"},
                {"F330","桃園"},
                {"F360","苗栗"},
                {"F400","台中"},
                {"F500","彰化"},
                {"F513","埔心"},
                {"F545","埔里"},
                {"F600","嘉義"},
                {"F630","斗南"},
                {"F708","台南"},
                {"F709","興達"},
                {"F722","佳里"},
                {"F730","新營"},
                {"F800","高雄"},
                {"F820","岡山"},
                {"F826","梓官"},
                {"F880","澎湖"},
                {"F916","東港"},
                {"F936","新港"},
                {"F950","花蓮"}
#endif
            };

            try
            {
                foreach (var market in _efishMarketDict)
                {
                    try
                    {
                        EfishInfo(string.Format("开始获取{0}的价格\r\n", market.Value));

                        for (var dt = startDate; dt < endDate.AddDays(1); dt = dt.AddDays(1))
                        {
                            EfishInfo(string.Format("开始获取{0}的价格\r\n", dt.ToShortDateString()));

                            HttpWebRequest request = WebRequest.Create(EfishDataUrl) as HttpWebRequest;
                            if (ckbProxy.Checked && !string.IsNullOrEmpty(tbProxy.Text))
                            {
                                var proxy = new WebProxy(new Uri(tbProxy.Text.Trim()));
                                request.Proxy = proxy;
                            }
                            request.Method = "POST";
                            request.Referer = EfishDataUrl;

                            //"dateStr=104.4.12&calendarType=tw&year=104&month=4&day=12&mid=F109&numbers=999&orderby=w"
                            string postString = string.Format(EfishDataBody, GetMingDate(dt), dt.Year - 1911, dt.Month, dt.Day, market.Key);
                            byte[] postData = Encoding.ASCII.GetBytes(postString);
                            request.KeepAlive = true;
                            request.ContentType = "application/x-www-form-urlencoded";
                            request.ContentLength = postData.Length;

                            byte[] bytesReq = Encoding.UTF8.GetBytes(postString);

                            using (Stream reqStream = request.GetRequestStream())
                            {
                                reqStream.Write(bytesReq, 0, bytesReq.Length);
                            }

                            using (var response = request.GetResponse() as HttpWebResponse)
                            {
                                using (var instream = response.GetResponseStream())
                                {
                                    try
                                    {
                                        HtmlDocument doc = new HtmlDocument();
                                        doc.Load(instream, Encoding.UTF8);
                                        var rows = doc.DocumentNode.SelectNodes("id('ltable')/tbody[1]/tr");
                                        foreach (var row in rows)
                                        {
                                            var cols = row.SelectNodes("td");
                                            var csv = new CsvObj
                                            {
                                                MarketName = market.Value,
                                                ProductName = cols[1].InnerText,
                                                Code = cols[0].InnerText,
                                                Spec = "",
                                                TopPrice = cols[2].InnerText,
                                                MidPrice = cols[3].InnerText,
                                                LowPrice = cols[4].InnerText,
                                                Date = dt.ToShortDateString()
                                            };
                                            efishWrite.WriteRecord(csv);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                    }

                                }
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }


                }
                EfishInfo("已完成");

            }

            catch (Exception ex)
            {
                MessageBox.Show("error");
            }
            finally
            {
                efishSw.Flush();
                efishSw.Close();
                MessageBox.Show("已完成");
            }
        }

        string GetMingDate(DateTime dt)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(dt.Year - 1911);
            sb.Append(".");
            sb.Append(dt.Month);
            sb.Append(".");
            sb.Append(dt.Day);
            return sb.ToString();
        }

        void EfishInfo(string s)
        {
            this.Invoke(new Action(() => infobox2.AppendText(s)));
        }
    }
}
