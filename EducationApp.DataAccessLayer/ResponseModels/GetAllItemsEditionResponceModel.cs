using EducationApp.DataAccessLayer.ResponseModels.Items;
using System.Collections.Generic;

namespace EducationApp.DataAccessLayer.ResponseModels
{
    public class GetAllItemsEditionResponceModel
    {
        public List<GetAllItemsEditionItemResponseModel> ResponseModels { get; set; }
        public long Count { get; set; }
    }
}
