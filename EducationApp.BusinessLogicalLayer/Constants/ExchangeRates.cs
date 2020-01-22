using System.Collections.Generic;
using static EducationApp.BusinessLogicalLayer.Models.Enum;

namespace EducationApp.BusinessLogicalLayer
{
    public partial class Constants
    {
        public class ExchangeRates
        {
            public Dictionary<decimal, Currency> rates = new Dictionary<decimal, Currency>
        {
            { 1m, Currency.USD },
            { 24.34m, Currency.UAH},
            { 0.9m, Currency.EUR},
            { 0.77m, Currency.GBP},
            { 0.97m ,Currency.CHF},
            { 110m ,Currency.JPY}
        };
        }
    }
}
