using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces
{
    public interface IBaseRepository<TModel>
    {
        List<TModel> GetAll();
        TModel GetById(Guid id);
        TModel Create(TModel model);
        void Update(TModel model);
        void Delete(TModel model);
        void Delete(Guid id);
    }
}
