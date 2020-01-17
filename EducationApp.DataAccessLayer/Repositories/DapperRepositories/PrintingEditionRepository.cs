using Dapper;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Entities.Enums;
using EducationApp.DataAccessLayer.Helpers.Mapper.Interface;
using EducationApp.DataAccessLayer.Repositories.Base;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using EducationApp.DataAccessLayer.RequestModels.PrintingEdition;
using EducationApp.DataAccessLayer.ResponseModels.Items;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

            using IDbConnection connection = new SqlConnection(_connectionString);
            List<GetAllItemsEditionItemResponseModel> responceModels = new List<GetAllItemsEditionItemResponseModel>();
            var sqlQuery = "SELECT * FROM PrintingEditions WHERE type IN (";
            if (filteredModel.Types.IndexOf(PrintingEditionType.Book) != -1) sqlQuery += "'0',";
            if (filteredModel.Types.IndexOf(PrintingEditionType.Journal) != -1) sqlQuery += "'1',";
            if (filteredModel.Types.IndexOf(PrintingEditionType.Newspaper) != -1) sqlQuery += "'2',";//не забыть удалить последнюю запятую
            sqlQuery += ")";
            if (filteredModel.PriceMin != 0 && filteredModel.PriceMax != 0) sqlQuery += " price BETWEEN PriceMin = @filteredModel.PriceMin AND PriceMin = @filteredModel.PriceMax AND"; //могут быть лишние AND 
            if (!string.IsNullOrWhiteSpace(filteredModel.SearchText)) sqlQuery += " title LIKE '%filteredModel = @filteredModel.SearchText%' AND"; //могут быть лишние AND 
            if (filteredModel.SortType == SortType.Asc) sqlQuery += " ORDER BY Price ASC";
            if (filteredModel.SortType == SortType.Desc) sqlQuery += " ORDER BY Price DESC";
            return connection.Execute(sqlQuery, new { filteredModel.PriceMin, filteredModel.PriceMax, filteredModel.SearchText});

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
