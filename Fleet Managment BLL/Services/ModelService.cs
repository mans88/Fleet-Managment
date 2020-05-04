﻿using Fleet_Managment_BLL.Domain;
using Fleet_Managment_BLL.Extension;
using Fleet_Managment_BLL.Interfaces;
using Fleet_Managment_DAL.Interfaces;
using FleetManagment.Shared.TransfertObject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Fleet_Managment_BLL.Services
{
    public class ModelService : IModelService
    {
        private readonly IUnitOfWork unitOfWork;

        public ModelService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public List<ModelTO> GetAll() => unitOfWork.ModelRepository.GetAll().Select(c => c.ToDomain().ToTransfertObject()).ToList();

        public ModelTO GetById(int id) => unitOfWork.ModelRepository.GetByID(id).ToDomain().ToTransfertObject();

        public ModelTO Insert(ModelTO model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));

            return unitOfWork.ModelRepository.Insert(model.ToDomain().ToTransfertObject());
        }

        public bool RemoveById(int id) => unitOfWork.ModelRepository.RemoveById(id);

        public ModelTO Update(ModelTO model)
        {
            if (model is null)
                throw new ArgumentNullException(nameof(model));
            return unitOfWork.ModelRepository.Update(model.ToDomain().ToTransfertObject());
        }
    }
}