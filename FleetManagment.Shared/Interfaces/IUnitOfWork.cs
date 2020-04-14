using System;
using System.Collections.Generic;
using System.Text;

namespace FleetManagment.Shared
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