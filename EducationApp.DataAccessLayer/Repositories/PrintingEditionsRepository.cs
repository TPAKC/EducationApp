using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;

namespace EducationApp.DataAccessLayer.Repositories
{
    public class PrintingEditionsRepository : BaseRepository<PrintingEdition>, IPrintingEditionRepository
    {
        public PrintingEditionsRepository(Connection connection) : base(connection)
        {
        }
    }
}
