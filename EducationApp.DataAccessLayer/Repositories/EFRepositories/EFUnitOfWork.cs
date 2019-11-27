using EducationApp.DataAccessLayer.Entities;
using EducationApp.DataAccessLayer.Repositories.Interfaces;
using EducationApp.PresentationLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace EducationApp.DataAccessLayer.Repositories.EFRepositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext db;
        private OrderRepository orderRepository;
        private PrintingEditionRepository printingEditionRepository;
        private AuthorRepository authorRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new ApplicationDbContext(connectionString);
        }
        public IBaseRepository<PrintingEdition> PrintingEditions
        {
            get
            {
                if (printingEditionRepository == null)
                    printingEditionRepository = new PrintingEditionRepository(db);
                return printingEditionRepository;
            }
        }  

        public IBaseRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }
        public IBaseRepository<Author> Authors
        {
            get
            {
                if (authorRepository == null)
                    authorRepository = new OrderRepository(db);
                return authorRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
