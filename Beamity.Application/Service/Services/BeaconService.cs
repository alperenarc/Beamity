using AutoMapper;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.BeaconDTOs;
using Beamity.Application.Service.IServices;
using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Interfaces;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beamity.Application.Service.Services
{
    public class BeaconService : IBeaconService
    {
        /*
         * This Class for define the Methods
         * This class contain 
         *  1.CreateBeacon
         *  2.DeleteBeacon
         *  3.GetAllBeacons
         *  4.GetBeacon
         *  5.UpdateBeacon methods
         */
        private readonly IBaseGenericRepository<Beacon> _repository;
        private readonly IMapper _mapper;

        public BeaconService(IBaseGenericRepository<Beacon> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task CreateBeacon(CreateBeaconDTO input)
        {
            var beacon = _mapper.Map<Beacon>(input);
            await _repository.Create(beacon);
        }

        public async Task DeleteBeacon(DeleteBeaconDTO input)
        {
           await _repository.Delete(input.Id);
        }
        public async Task<List<ReadBeaconDTO>> GetAllBeacons( EntityDTO input )
        {
            var beacons = await _repository.GetAll().ToListAsync();
            var result = _mapper.Map<List<ReadBeaconDTO>>(beacons);
            return result;
        }

        public async Task<ReadBeaconDTO> GetBeacon(EntityDTO input)
        {
            var beacon = await _repository.GetById(input.Id);
            var result = _mapper.Map<ReadBeaconDTO>(beacon);
            return result;
        }

        public async Task UpdateBeacon(UpdateBeaconDTO input)
        {
            var beacon = _mapper.Map<Beacon>(input);
            await _repository.Update(input.Id, beacon);
        }
    }
}
