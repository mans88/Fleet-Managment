using Fleet_Managment_DAL.Entities;
using FleetManagment.Shared.TransfertObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fleet_Managment_DAL.Extensions
{
    public static class TechnicalControlExtensions
    {
        public static TechnicalControl ToEntity(this TechnicalControlTO technicalControl)
        {
            if (technicalControl is null) throw new ArgumentNullException(nameof(technicalControl));

            return new TechnicalControl
            {
                Id = technicalControl.Id,
                Comment = technicalControl.Comment,
                StartDate = technicalControl.StartDate,
                EndDate = technicalControl.EndDate,
                Car = technicalControl.Car?.ToEntity(),
            };
        }

        public static TechnicalControlTO ToTransfertObject(this TechnicalControl technicalControl)
        {
            if (technicalControl is null) throw new ArgumentNullException(nameof(technicalControl));

            return new TechnicalControlTO
            {
                Id = technicalControl.Id,
                Comment = technicalControl.Comment,
                StartDate = technicalControl.StartDate,
                EndDate = technicalControl.EndDate,
                Car = technicalControl.Car?.ToTransfertObject()
            };
        }
    }
}