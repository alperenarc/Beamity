using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces
{
    interface IBaseRepository<TModel>
    {
        List<TModel> GetAll();
        TModel GetById(Guid id);
        TModel Create(TModel model);
        void Update(Guid id, TModel model);
        void Delete(TModel model);
        void Delete(Guid id);
    }
}
