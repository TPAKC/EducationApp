using EducationApp.DataAccessLayer.Entities.Enums;
using System.Collections.Generic;

namespace EducationApp.DataAccessLayer.ResponseModels.Items
{
    public class GetAllItemsEditionItemResponseModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; }
        public PrintingEditionType Type { get; set; }
        public long AuthorId { get; set; }
        public string AuthorName { get; set; }
    }
}
