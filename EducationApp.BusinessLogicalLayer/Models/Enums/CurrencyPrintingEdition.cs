using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EducationApp.BusinessLogicalLayer.Models.Enums
{
    //[JsonConverter(typeof(StringEnumConverter))]
    public enum CurrencyPrintingEdition
    {
        USD = 0,
        UAH = 1,
        EUR = 2,
        GBP = 3,
        CHF = 4,
        JPY = 5
    }
}
