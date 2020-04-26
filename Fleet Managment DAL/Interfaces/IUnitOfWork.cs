using System;

namespace Fleet_Managment_DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IModelRepository ModelRepository { get; }
        IBrandRepository BrandRepository { get; }
        ICarRepository CarRepository { get; }
        IFuelRepository FuelRepository { get; }
        IInsuranceRepository InsuranceRepository { get; }
        ITechnicalControlRepository TechnicalControlRepository { get; }

        int SaveChanges();
    }
}