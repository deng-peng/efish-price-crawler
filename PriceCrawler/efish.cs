using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriceCrawler
{
    public partial class PriceCrawlerForm
    {
        void EfishStart()
        {
            for (int i = 10 - 1; i >= 0; i--)
            {
                this.Invoke(new Action(() => infobox2.AppendText(i.ToString())));
            }
        }
    }
}
