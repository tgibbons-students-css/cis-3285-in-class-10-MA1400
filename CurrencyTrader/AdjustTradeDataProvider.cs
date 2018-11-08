using CurrencyTrader.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace CurrencyTrader
{
    public class AdjustTradeDataProvider : ITradeDataProvider
    {
        private readonly String url;
        ITradeDataProvider urlProvider;
        public AdjustTradeDataProvider(String url)
        {
            this.url = url;
            urlProvider = new UrlTradeDataProvider(url);
        }

        public IEnumerable<string> GetTradeData()
        {
            string replacement = "";
            IEnumerable<string> tradeTxt;
            tradeTxt = urlProvider.GetTradeData();
            var trades = new List<string>();


            foreach (string line in tradeTxt)
            {
                replacement = line.Replace("GBP", "EUR");
                trades.Add(replacement);
            }
            return trades;
        }
    }
}
