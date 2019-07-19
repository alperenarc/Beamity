using Beamity.Application.DTOs;
using Beamity.Application.DTOs.AnalyticDTO;
using Beamity.Application.Service.IServices;
using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service.Services
{
    public class AnalyticService : IAnalyticService
    {
        private readonly IBaseGenericRepository<Statistics> _statisticRepository;
        private readonly IBaseGenericRepository<Beacon> _beaconRepository;

        public AnalyticService(IBaseGenericRepository<Statistics> statisticRepository
            , IBaseGenericRepository<Beacon> beaconRepository)
        {
            _statisticRepository = statisticRepository;
            _beaconRepository = beaconRepository;
        }

        public async Task CreateAnalytic(CreateAnalyticDTO input)
        {
            //Get Beacon for Major Minor and UUID.
            var beacon = await _beaconRepository.GetAll()
                .FirstOrDefaultAsync(x => x.Id == input.BeaconId);

            if(beacon != null)
            {
                Statistics result = new Statistics()
                {
                    BeaconId = beacon.Id
                };
                await _statisticRepository.Create(result);
            }
            else
            {
                return;
            }
           
        }

       
        public async Task<List<ReadAnalyticDTO>> GetAllBeaconsWithHours(EntityDTO input)
        {
            var data = await _statisticRepository
                .GetAll()
                .Include(x => x.Beacon)
                .ThenInclude(x => x.Location)
                .Where(x => x.IsActive && x.CreatedTime.AddDays(30) > DateTime.Now && x.Beacon.Location.Id == input.Id)
                .ToListAsync();
            List<ReadAnalyticDTO> result = new List<ReadAnalyticDTO>();
            foreach (var item in data)
            {
                ReadAnalyticDTO dto = new ReadAnalyticDTO();
                dto.BeaconName = item.Beacon.Name;
                dto.CreatedTime = item.CreatedTime;
                dto.IsActive = item.IsActive;
                result.Add(dto);
            }
            return result;
        }

        
    }
}
