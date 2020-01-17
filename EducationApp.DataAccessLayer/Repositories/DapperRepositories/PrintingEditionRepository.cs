using Dapper;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Entities.Enums;
using EducationApp.DataAccessLayer.Extensions.Enum;
using EducationApp.DataAccessLayer.Helpers.Mapper.Interface;
using EducationApp.DataAccessLayer.Repositories.Base;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using EducationApp.DataAccessLayer.RequestModels.PrintingEdition;
using EducationApp.DataAccessLayer.ResponseModels.Items;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using static EducationApp.DataAccessLayer.Entities.Enums.Enum;

namespace EducationApp.DataAccessLayer.Repositories.DapperRepositories
{
    public class PrintingEditionRepository : BaseDapperRepository<PrintingEdition>, IPrintingEditionRepository
    {
        private readonly string _connectionString;
        private readonly IMapper _mapper;
        public PrintingEditionRepository(string connectionString, IMapper mapper) : base(connectionString)
        {
            _connectionString = connectionString;
            _mapper = mapper;
        }
        public async Task<List<GetAllItemsEditionItemResponseModel>> FilteredAsync(FilteredModel filteredModel)
        {
            /*  using IDbConnection connection = new SqlConnection(_connectionString);
              List<GetAllItemsEditionItemResponseModel> responceModels = new List<GetAllItemsEditionItemResponseModel>();
              var printingEditions = (await connection.GetAllAsync<PrintingEdition>()).AsList();
              responceModels = printingEditions.Select(printingEdition => _mapper.EntityToResponceModel(printingEdition)).ToList();
              List<GetAllItemsEditionItemResponseModel> result = new List<GetAllItemsEditionItemResponseModel>();
              if (types[(int)TypePrintingEdition.Book])
              {
                  var evens = responceModels.Where(responceModels => responceModels.Type == TypePrintingEdition.Book);
                  foreach (GetAllItemsEditionItemResponseModel responceModel in evens) result.Add(responceModel);
              }
              if (types[(int)TypePrintingEdition.Journal])
              {
                  var evens = responceModels.Where(responceModels => responceModels.Type == TypePrintingEdition.Journal);
                  foreach (GetAllItemsEditionItemResponseModel responceModel in evens) result.Add(responceModel);
              }
              if (types[(int)TypePrintingEdition.Newspaper])
              {  
                  var evens = responceModels.Where(responceModels => responceModels.Type == TypePrintingEdition.Newspaper);
                  foreach (GetAllItemsEditionItemResponseModel responceModel in evens) result.Add(responceModel);
              }*/

            var types = filteredModel.Types.Select(v => ((int)v).ToString()).Join(",");
            using (var connection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM PrintingEditions WHERE type IN STRING_SPLIT(@types, ',') " +
                    "AND (@PriceMin is null OR @PriceMin <= Price) " +
                    "AND (@PriceMax is null OR @PriceMax >= Price) " +
                    "AND (@SearchText is null OR CHARINDEX(UPPER(@SearchText), UPPER(Title)) > 0) ORDER BY Price " + filteredModel.SortType.GetDescription();
                var response = (await connection.QueryAsync<GetAllItemsEditionItemResponseModel>(query, new { types, filteredModel.PriceMin, filteredModel.PriceMax, filteredModel.SearchText })).AsList();
                return response;
            }


    

            /*var sortOrder = SortStatePrintingEditions.IdAsc;

            printingEditions = sortOrder switch
            {
                SortStatePrintingEditions.IdAsc => result.OrderBy(s => s.Id),
                SortStatePrintingEditions.IdDesc => result.OrderByDescending(s => s.Id),
                //SortStatePrintingEditions.NameAsc => result.OrderBy(s => s.Name),
                //SortStatePrintingEditions.NameDesc => result.OrderByDescending(s => s.Name),
                SortStatePrintingEditions.CategoryAsc => result.OrderBy(s => s.Type),
                SortStatePrintingEditions.CategoryDesc => result.OrderByDescending(s => s.Type),
                SortStatePrintingEditions.PriceAsc => result.OrderBy(s => s.Price),
                SortStatePrintingEditions.PriceDesc => result.OrderByDescending(s => s.Price),
            };*/
        }
    }
}
