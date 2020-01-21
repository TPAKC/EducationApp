using EducationApp.BusinessLogicalLayer.Helpers.Interface;
using EducationApp.BusinessLogicalLayer.Models;

namespace EducationApp.BusinessLogicalLayer.Helpers
{
    public partial class Mapper : IMapper
    {
        public DataAccessLayer.RequestModels.PaginationModel PaginationModel(PaginationModel pagination)
        {
            var paginationModel = new DataAccessLayer.RequestModels.PaginationModel();
            paginationModel.Count = pagination.Count;
            paginationModel.Start = pagination.Start;
            return paginationModel;
        }
    }
}
