using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Contexts;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories
{
    public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : EntityBase
    {
        protected readonly BeamityDbContext _context;
        protected DbSet<TModel> Table { get; set; }
        public BaseRepository(BeamityDbContext context)
        {
            _context = context;
            this.Table = context.Set<TModel>();
        }
        public virtual TModel Create(TModel model)
        {
            _context.Add(model);
            _context.SaveChanges();
            return model;
        }

        public virtual void Delete(TModel model)
        {
            _context.Remove(model);
            _context.SaveChanges();
        }

        public async void Delete(Guid id)
        {
            var model = await Table.FirstOrDefaultAsync(p => p.Id == id);
            if(model != null)
            {
                _context.Remove(model);
                await _context.SaveChangesAsync();
            }            
        }

        public virtual List<TModel> GetAll()
        {
            return Table.Where(p => p.IsActive == true).ToList();
        }

        public virtual TModel GetById(Guid id)
        {
            return Table.FirstOrDefault(p => p.Id == id && p.IsActive == true);
        }

        public virtual void Update(TModel model)
        {
            Table.Update(model);
            _context.SaveChangesAsync();
        }
    }
}
