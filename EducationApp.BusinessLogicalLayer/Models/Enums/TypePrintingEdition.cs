using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EducationApp.BusinessLogicalLayer.Models.Enums
{
    //[JsonConverter(typeof(StringEnumConverter))]
    public enum TypePrintingEdition
    {
        None = 0,
        Book = 1,
        Journal = 2,
        Newspaper = 3
    }
}
