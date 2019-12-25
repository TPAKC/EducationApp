

using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace EducationApp.BusinessLogicalLayer.Models.Enums
{
    //[JsonConverter(typeof(StringEnumConverter))]
    public enum StatusPrintingEdition
    {
        Unpaid = 0,
        Paid = 1
    }
}
