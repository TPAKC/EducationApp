using EducationApp.BusinessLogicalLayer.Helpers.Interface;
using EducationApp.BusinessLogicalLayer.Models.PrintingEditions;
using EducationApp.DataAccessLayer.Entities.Enums;
using System.Linq;
using static EducationApp.DataAccessLayer.Entities.Enums.Enum;

namespace EducationApp.BusinessLogicalLayer.Helpers
{
    public partial class Mapper : IMapper
    {
        public DataAccessLayer.RequestModels.PrintingEdition.FilteredModel FilteredModel(FilteredModel oldFilteredModel)
        {
            var filteredModel = new DataAccessLayer.RequestModels.PrintingEdition.FilteredModel();
            filteredModel.Types = oldFilteredModel.Types.Select(v => (PrintingEditionType)(int)v).ToList();
            filteredModel.PriceMin = oldFilteredModel.PriceMin;
            filteredModel.PriceMax = oldFilteredModel.PriceMax;
            filteredModel.Currency = (Currency)oldFilteredModel.Currency;
            filteredModel.SearchText = oldFilteredModel.SearchText;
            filteredModel.SortType = (SortType)oldFilteredModel.SortType;
            filteredModel.SortColumn = (PrintingEditionSortColumn)oldFilteredModel.SortColumn;
            return filteredModel;
        }
    }
}
