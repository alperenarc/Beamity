using Beamity.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces
{
    public interface IBaseGenericRepository<TEntity>
 where TEntity : class, IEntityBase
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(Guid id);

        Task Create(TEntity entity);

        Task Update(Guid id, TEntity entity);

        Task Delete(Guid id);
    }
}
