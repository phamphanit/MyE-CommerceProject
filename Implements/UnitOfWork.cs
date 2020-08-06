using System;
using FinalProject.DataModels;
using FinalProject.Interfaces;

namespace FinalProject.Implements
{
    public class UnitOfWork : IUnitOfWork
    {
        public MyDbContext Context { get; }

        public UnitOfWork(MyDbContext context)
        {
            Context = context;
        }
        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();

        }
    }
}
