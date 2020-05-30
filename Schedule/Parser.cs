using AngleSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schedule
{
    class Parser
    {
        public async Task<List<Currencies>> GetCurrency()
        {
            //  configuration

            var config = Configuration.Default.WithDefaultLoader();

            const string address = "https://www.banki.ru/products/currency/cb/";
            var document = await BrowsingContext.New(config).OpenAsync(address);

            var rowSelector = @"tr[data-currency-code]";
            var rows = document.QuerySelectorAll(rowSelector);

            // projecting from DOM elements to Currency objects
           
            return rows.Select(r => new Currencies 
            {
                Code = r.Children[0].TextContent.Trim(),
                Count = r.Children[1].TextContent.Trim(),
                Name = r.Children[2].Children.Length > 0 ? r.Children[2].Children[0].TextContent.Trim() : r.Children[2].TextContent.Trim(),
                Currency = r.Children[3].TextContent.Trim(),
                Changes = r.Children[4].TextContent.Trim(),
                IsChangePositive = r.Children[4].TextContent.Trim().StartsWith('+')
            }).ToList();
        }
    }
}
