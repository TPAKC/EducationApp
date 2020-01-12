using EducationApp.DataAccessLayer.Entities.Enums;

namespace EducationApp.DataAccessLayer.ResponseModels.Items
{
    public class GetAllItemsEditionItemResponseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long Price { get; set; }
        public CurrencyPrintingEdition Currency { get; set; }
        public TypePrintingEdition Type { get; set; }
        public string AuthorsName { get; set; }
    }
}
