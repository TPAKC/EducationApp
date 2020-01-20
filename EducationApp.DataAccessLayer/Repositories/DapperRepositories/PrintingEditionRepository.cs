using Dapper;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Extensions.Enum;
using EducationApp.DataAccessLayer.Repositories.Base;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using EducationApp.DataAccessLayer.RequestModels;
using EducationApp.DataAccessLayer.RequestModels.PrintingEdition;
using EducationApp.DataAccessLayer.ResponseModels;
using Microsoft.EntityFrameworkCore.Internal;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.DapperRepositories
{
    public class PrintingEditionRepository : BaseDapperRepository<PrintingEdition>, IPrintingEditionRepository
    {
        private readonly string _connectionString;
        public PrintingEditionRepository(string connectionString) : base(connectionString)
        {
            _connectionString = connectionString;
        }
        public async Task<GetAllItemsEditionResponceModel> FilteredAsync(FilteredModel filteredModel, PaginationModel paginationModel)
        {
            var types = filteredModel.Types.Select(v => ((int)v).ToString()).Join(",");
            var query = @"SELECT BIG_COUNT(Id) FROM PrintingEditions WHERE type IN STRING_SPLIT(@types, ',')
                AND (@PriceMin is null OR @PriceMin <= Price)
                AND (@PriceMax is null OR @PriceMax >= Price)
                AND (@SearchText is null OR CHARINDEX(UPPER(@SearchText), UPPER(Title)) > 0) ORDER BY Price " + filteredModel.SortType.GetDescription() +
            @"SELECT P.*, A.[Name] AS AuthorName FROM PrintingEditions AS P
            LEFT JOIN AuthorInPrintingEditions AS AP ON AP.PrintingEditionId = P.Id
            LEFT JOIN Authors AS A ON AP.AuthorId = A.Id 
            WHERE type IN STRING_SPLIT(@types, ',') 
            AND (@PriceMin is null OR @PriceMin <= Price) 
            AND (@PriceMax is null OR @PriceMax >= Price) 
            AND (@SearchText is null OR CHARINDEX(UPPER(@SearchText), UPPER(Title)) > 0) ORDER BY Price "+filteredModel.SortType.GetDescription() + 
            " OFFSET @start ROWS FETCH NEXT @count ROWS ONLY";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var multi = connection.QueryMultiple(query, new { types, filteredModel.PriceMin, filteredModel.PriceMax, 
                    filteredModel.SearchText, paginationModel.Start, paginationModel.Count }))
                {
                    var responseModels = new GetAllItemsEditionResponceModel();
                    responseModels.Count = await multi.ReadFirstAsync<long>();
                    responseModels.ResponseModels = (await multi.ReadAsync<GetAllItemsEditionItemResponseModel>()).AsList();
                    return responseModels;
                }
            }
        }
    }
}
