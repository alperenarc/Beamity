using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service
{
    public interface IService<TModel>
    {
        Task<List<TModel>> GetAll();
        Task<TModel> GetById(Guid id);
        TModel Create(TModel model);
        Task Update(TModel model);
        void Delete(TModel model);
        void Delete(Guid id);
    }
}
