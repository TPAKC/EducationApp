using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using EducationApp.PresentationLayer.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EducationApp.DataAccessLayer.Repositories
{
    public class PrintingEditionRepository : BaseRepository<PrintingEdition>, IPrintingEditionRepository
    {
        public PrintingEditionRepository(Connection connection) : base(connection)
        {
        }
    }
}
