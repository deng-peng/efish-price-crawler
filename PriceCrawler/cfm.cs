using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace PriceCrawler
{
    public partial class Form1
    {
        Dictionary<int, string> _cfmMarketDict;


        private const string CfmLoginUrl = "http://www.cfm.com.cn/user/Login.aspx";
        private const string CfmDataUrl = "http://www.cfm.com.cn/showmarket.aspx?mid={0}";

        private const string CfmLoginBody =
            "__EVENTTARGET=&__EVENTARGUMENT=&__VIEWSTATE={0}&niceName=karst&password=Karst5099&btnLogin={1}&__EVENTVALIDATION={2}";

        private const string CfmDataBody =
            "__EVENTTARGET=&__EVENTARGUMENT=&__LASTFOCUS=&__VIEWSTATE={0}&DropDownList1={1}&ddlDate={2}&btnQuery=%B2%E9%D1%AF&__EVENTVALIDATION={3}";
        void CfmStart()
        {
            _cfmMarketDict = new Dictionary<int, string>
            {
                {29, "中国舟山国际水产城"},
                //{3, "广东市黄沙海鲜水产品交易市场"},
                //{5, "上海铜川水产品批发市场"},
                //{6, "山东威海市水产品批发市场"},
                //{9, "广州鱼市场"},
                //{10, "天津市南开区王顶提水产品批发市场"},
                //{11, "青岛城阳蔬菜水产品批发市场"},
                //{13, "温州水产品批发交易市场"},
                //{14, "厦门市水产品批发市场"},
                //{15, "南京水产品中心批发市场"},
                //{16, "北京市岳各庄水产品批发市场"},
                //{31, "江苏常州市宣塘桥水产批发市场"},
                //{34, "杭州市近江农副产品综合市场"},
                //{35, "江苏省南通市水产品批发市场"},
                //{36, "宁波象山中国水产城交易市场"},
                //{37, "江门水产品批发市场"},
                //{38, "远大(连云港)水产品批发市场"},
                //{40, "广东汕头水产市场"},
                //{41, "广东湛江郊区水产公司交易市场"},
                //{42, "广东阳西县沙扒水产市场"},
                //{43, "南京市惠民桥农副产品市场"},
                //{44, "广东南海盐步环球水产交易市场"},
                //{45, "浙江瑞安市东埠水产品交易市场"},
                //{46, "宁波孔蒲水产品交易市场"},
                //{48, "广东汕尾海滨水产品批发市场"},
                //{50, "广东阳江市闸坡镇水产品市场"},
                //{51, "江苏省扬州市水产品批发市场"},
                //{52, "江苏海门市东灶水产品批发市场"},
                //{53, "上海市曹安四平水产批发市场"},
                //{54, "福州市水产批发市场"},
                //{55, "海南省海口水产品批发市场"},
                //{57, "浙江松门水产品批发市场"},
                //{58, "浙江省台州水产品交易中心"},
                //{59, "江苏吕四港水产品批发市场"}
            };

            try
            {
                CfmInfo("开始登录/");
                CookieContainer cookieContainer = new CookieContainer();

                HttpWebRequest request = WebRequest.Create(CfmLoginUrl) as HttpWebRequest;
                request.Method = "GET";
                request.KeepAlive = false;

                // 访问登录页
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                System.IO.Stream responseStream = response.GetResponseStream();
                System.IO.StreamReader reader = new System.IO.StreamReader(responseStream, Encoding.UTF8);
                //string srcString = reader.ReadToEnd();

                // 获取页面的 VeiwState                
                HtmlDocument logindoc = new HtmlDocument();
                logindoc.Load(reader);
                string viewState =
                    logindoc.DocumentNode.SelectSingleNode("//input[@id='__VIEWSTATE']").Attributes["value"].Value;
                string eventValidation = logindoc.DocumentNode.SelectSingleNode("//input[@id='__EVENTVALIDATION']").Attributes["value"].Value;

                // 将文本转换成 URL 编码字符串
                viewState = System.Web.HttpUtility.UrlEncode(viewState);
                eventValidation = System.Web.HttpUtility.UrlEncode(eventValidation);
                string submitButton = System.Web.HttpUtility.UrlEncode("登陆");

                string postString =
                    string.Format(CfmLoginBody, viewState, submitButton, eventValidation);

                byte[] postData = Encoding.ASCII.GetBytes(postString);
                request = WebRequest.Create(CfmLoginUrl) as HttpWebRequest;
                request.Method = "POST";
                request.KeepAlive = false;
                request.ContentType = "application/x-www-form-urlencoded";
                request.CookieContainer = cookieContainer;
                request.ContentLength = postData.Length;

                // 提交登录
                System.IO.Stream outputStream = request.GetRequestStream();
                outputStream.Write(postData, 0, postData.Length);
                outputStream.Close();

                // 登录返回
                response = request.GetResponse() as HttpWebResponse;
                responseStream = response.GetResponseStream();
                //reader = new System.IO.StreamReader(responseStream, Encoding.GetEncoding("GB2312"));
                //srcString = reader.ReadToEnd();
                CfmInfo("登录成功/");
                foreach (var market in _cfmMarketDict)
                {
                    try
                    {
                        CfmInfo(string.Format("开始获取{0}的信息/", market.Value));
                        //请求market数据
                        request = WebRequest.Create(string.Format(CfmDataUrl, market.Key)) as HttpWebRequest;
                        request.Method = "GET";
                        request.KeepAlive = false;
                        request.CookieContainer = cookieContainer;

                        // 接收返回的页面
                        response = request.GetResponse() as HttpWebResponse;
                        responseStream = response.GetResponseStream();
                        reader = new System.IO.StreamReader(responseStream, Encoding.GetEncoding("GB2312"));
                        //srcString = reader.ReadToEnd();
                        HtmlDocument doc = new HtmlDocument();
                        doc.Load(reader);
                        var dateOptions = doc.DocumentNode.SelectNodes("id('ddlDate')/option");
                        List<string> dateList = new List<string>();
                        foreach (var option in dateOptions)
                        {
                            dateList.Add(option.Attributes["value"].Value);
                        }
                        foreach (var datestring in dateList)
                        {
                            CfmInfo(string.Format("开始获取{0}的信息/", datestring));

                            viewState = doc.DocumentNode.SelectSingleNode("//input[@id='__VIEWSTATE']").Attributes["value"].Value;
                            eventValidation = doc.DocumentNode.SelectSingleNode("//input[@id='__EVENTVALIDATION']").Attributes["value"].Value;
                            viewState = System.Web.HttpUtility.UrlEncode(viewState);
                            eventValidation = System.Web.HttpUtility.UrlEncode(eventValidation);
                            request.Method = "POST";
                            //提交某天的查询
                            postString = string.Format(CfmDataBody, viewState, market.Key, datestring, eventValidation);
                            postData = Encoding.ASCII.GetBytes(postString);
                            request = WebRequest.Create(string.Format(CfmDataUrl, market.Key)) as HttpWebRequest;
                            request.Method = "POST";
                            request.KeepAlive = false;
                            request.ContentType = "application/x-www-form-urlencoded";
                            request.CookieContainer = cookieContainer;
                            request.ContentLength = postData.Length;
                            outputStream = request.GetRequestStream();
                            outputStream.Write(postData, 0, postData.Length);
                            outputStream.Close();

                            // 某天的返回
                            response = request.GetResponse() as HttpWebResponse;
                            responseStream = response.GetResponseStream();
                            reader = new System.IO.StreamReader(responseStream, Encoding.GetEncoding("GB2312"));
                            string dataHtml = reader.ReadToEnd();
                            doc.LoadHtml(dataHtml);
                            viewState = doc.DocumentNode.SelectSingleNode("//input[@id='__VIEWSTATE']").Attributes["value"].Value;
                            eventValidation = doc.DocumentNode.SelectSingleNode("//input[@id='__EVENTVALIDATION']").Attributes["value"].Value;
                            //string save = doc.DocumentNode.SelectSingleNode("id('LabelSpec')").InnerHtml.Trim();
                            string save = CfmGetContentPrice(dataHtml);
                            var item = new Market();
                            item.Mid = market.Key;
                            item.Mname = market.Value;
                            item.Mdate = datestring;
                            item.Price = save;
                            ParseCfm(item);
                        }
                    }
                    catch (Exception)
                    {
                    }


                }

            }

            catch (Exception ex)
            {
                MessageBox.Show("error");
            }
        }

        private void ParseCfm(Market item)
        {
            MessageBox.Show(item.Price);
        }

        private string CfmGetContentPrice(string dataHtml)
        {
            if (string.IsNullOrEmpty(dataHtml))
                return "";
            string tag = "<span id=\"LabelSpec\">";
            int start = dataHtml.IndexOf(tag) + tag.Length;
            if (start < 0)
                return "";
            int end = dataHtml.IndexOf("</span>", start);
            if (end <= start)
                return "";
            return dataHtml.Substring(start, end - start);
        }

        void CfmInfo(string s)
        {
            this.Invoke(new Action(() => infobox1.AppendText(s)));
        }

    }
}
