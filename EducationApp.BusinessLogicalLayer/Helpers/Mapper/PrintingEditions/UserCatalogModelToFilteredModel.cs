﻿using EducationApp.BusinessLogicalLayer.Helpers.Interface;
using EducationApp.BusinessLogicalLayer.Models.PrintingEditions;
using EducationApp.DataAccessLayer.Entities.Enums;
using EducationApp.DataAccessLayer.RequestModels.PrintingEdition;
using System.Linq;
using static EducationApp.DataAccessLayer.Entities.Enums.Enum;

namespace EducationApp.BusinessLogicalLayer.Helpers
{
    public partial class Mapper : IMapper
    {
        public FilteredModel UserCatalogModelToFilteredModel(UserCatalogModel catalogModel)
        {
            var filteredModel = new FilteredModel();
            filteredModel.Types = catalogModel.Types.Select(v => (PrintingEditionType)(int)v).ToList();
            filteredModel.PriceMin = catalogModel.PriceMin;
            filteredModel.PriceMax = catalogModel.PriceMax;
            filteredModel.Currency = (Currency)catalogModel.Currency;
            filteredModel.SearchText = catalogModel.SearchText;
            filteredModel.SortType = (SortType)catalogModel.SortType;
            filteredModel.SortColumn = (PrintingEditionSortColumn)catalogModel.SortColumn;
            filteredModel.Count = catalogModel.Count;
            filteredModel.Start = catalogModel.Start;
            return filteredModel;
        }
    }
}