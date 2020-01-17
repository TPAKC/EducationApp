using EducationApp.DataAccessLayer.Entities.Enums;
using System.Collections.Generic;

namespace EducationApp.DataAccessLayer.ResponseModels.Items
{
    public class GetAllItemsEditionItemResponseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; }
        public PrintingEditionType Type { get; set; }
        public List<string> AuthorsName { get; set; }
    }
}
