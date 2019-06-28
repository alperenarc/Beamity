using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.Service.Services
{
    public class RelationService : IRelationService
    {
        private readonly RelationRepository _repository;
        public RelationService(RelationRepository repository)
        {
            _repository = repository;
        }
    }
}
