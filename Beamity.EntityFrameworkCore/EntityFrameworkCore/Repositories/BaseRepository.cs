using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Contexts;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories
{
    public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : EntityBase
    {
        private readonly BeamityDbContext _context;

        public BaseRepository(BeamityDbContext context)
        {
            _context = context;
        }
        public TModel Create(TModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(TModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<TModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public TModel GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Guid id, TModel model)
        {
            throw new NotImplementedException();
        }
    }
}
