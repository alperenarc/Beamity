using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beamity.Application.Service.Services
{
    public class ContentService : IContentService
    {
        private readonly ContentRepository _repository;
        public ContentService(ContentRepository repository)
        {
            _repository = repository;
        }
    }
}
