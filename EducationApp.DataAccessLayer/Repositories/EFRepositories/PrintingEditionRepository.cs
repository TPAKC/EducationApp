    using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Base;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using EducationApp.PresentationLayer.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace EducationApp.DataAccessLayer.Repositories.EFRepositories
{
    public class PrintingEditionRepository : BaseEFRepository<PrintingEdition>
    {
        public PrintingEditionRepository(ApplicationDbContext context) : base(context)
        {
        }
        /*public async Task<List<PrintingEdition>> GetAll(bool[] types)
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
            };
            return result;
        }*/
    }
}
