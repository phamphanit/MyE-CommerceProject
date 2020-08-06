using System;
using FinalProject.DataModels;

namespace FinalProject.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        MyDbContext Context { get; }
        void Commit();
    }
}
