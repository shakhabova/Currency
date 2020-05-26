using AngleSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    class Parser
    {
        public async Task<Currencies> GetCurrency()
        {
            // конфигурация
            var config = Configuration.Default.WithDefaultLoader();

            var address = "https://www.banki.ru/products/currency/cb/";
            var document = await BrowsingContext.New(config).OpenAsync(address);


        }
    }
}
