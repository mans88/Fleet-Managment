using Fleet_Managment_BLL.Domain;
using Fleet_Managment_BLL.Extension;
using Fleet_Managment_BLL.Interfaces;
using Fleet_Managment_DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fleet_Managment_BLL.Services
{
    public class ModelService : IModelService
    {
        private readonly IUnitOfWork unitOfWork;

        public ModelService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public List<Model> GetAll() => unitOfWork.ModelRepository.GetAll().Select(c => c.ToDomain()).ToList();

        public Model GetById(int id) => unitOfWork.ModelRepository.GetByID(id).ToDomain();

        public Model Insert(Model model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            return unitOfWork.ModelRepository.Insert(model.ToTransfertObject()).ToDomain();
        }

        public bool RemoveById(int id) => unitOfWork.ModelRepository.RemoveById(id);

        public Model Update(Model model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));
            return unitOfWork.ModelRepository.Update(model.ToTransfertObject()).ToDomain();
        }
    }
}