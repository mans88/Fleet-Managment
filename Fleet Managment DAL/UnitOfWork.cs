using Fleet_Managment_DAL.Entities;
using Fleet_Managment_DAL.Interfaces;
using Fleet_Managment_DAL.Repositories;
using System;

namespace Fleet_Managment_DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FleetManagmentContext context;

        public UnitOfWork(FleetManagmentContext context)
        {
            this.context = context ?? throw new ArgumentException(nameof(context));
        }

        public IModelRepository ModelRepository => new ModelRepository(context);

        public IBrandRepository BrandRepository => new BrandRepository(context);

        public ICarRepository CarRepository => new CarRepository(context);

        public IInsuranceRepository InsuranceRepository => new InsuranceRepository(context);

        public ITechnicalControlRepository TechnicalControlRepository => new TechnicalControlRepository(context);

        public int SaveChanges()
        {
            return context.SaveChanges();
        }

        #region IDisposable Support

        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support
    }
}