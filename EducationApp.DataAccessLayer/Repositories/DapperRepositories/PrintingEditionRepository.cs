using Dapper;
using Dapper.Contrib.Extensions;
using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Entities.Enums;
using EducationApp.DataAccessLayer.Repositories.Base;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationApp.DataAccessLayer.Repositories.DapperRepositories
{
    public class PrintingEditionRepository : BaseDapperRepository<PrintingEdition>, IPrintingEditionRepository
    {
        public PrintingEditionRepository(Connection connection) : base(connection)
        {
        }
        public async Task<List<PrintingEdition>> GetAll(bool[] types)
        {
            List<PrintingEdition> result = new List<PrintingEdition>();
            var printingEditions = (await Connection.GetAllAsync<PrintingEdition>()).AsList();
            if (types[(int)TypePrintingEdition.Book])
            {
                var evens = printingEditions.Where(printingEdition => printingEdition.Type == TypePrintingEdition.Book);
                foreach (PrintingEdition printingEdition in evens) result.Add(printingEdition);
            }
            if (types[(int)TypePrintingEdition.Journal])
            {
                var evens = printingEditions.Where(printingEdition => printingEdition.Type == TypePrintingEdition.Journal);
                foreach (PrintingEdition printingEdition in evens) result.Add(printingEdition);
            }
            if (types[(int)TypePrintingEdition.Newspaper])
            {
                var evens = printingEditions.Where(printingEdition => printingEdition.Type == TypePrintingEdition.Newspaper);
                foreach (PrintingEdition printingEdition in evens) result.Add(printingEdition);
            }
            return printingEditions;
        }
    }
}
