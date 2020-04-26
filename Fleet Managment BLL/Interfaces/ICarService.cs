using Fleet_Managment_BLL.Domain;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fleet_Managment_BLL.Interfaces
{
    public interface ICarService
    {
        List<Car> GetAll();

        Car GetById(int id);

        Car Insert(Car car);

        bool Delete(int id);
    }
}