using EducationApp.DataAccessLayer.Entities;
using System;

namespace EducationApp.DataAccessLayer.Repositories.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<PrintingEdition> PrintingEditions { get; }
        IBaseRepository<Author> Authors { get; }
        IBaseRepository<Order> Orders { get; }
        void Save();
    }
}
