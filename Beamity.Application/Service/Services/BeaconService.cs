using AutoMapper;
using Beamity.Application.DTOs;
using Beamity.Application.DTOs.BeaconDTOs;
using Beamity.Application.Service.IServices;
using Beamity.Core.Models;
using Beamity.EntityFrameworkCore.EntityFrameworkCore.Repositories;
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
        private readonly BeaconRepository _repository;
        private readonly IMapper _mapper;

        public BeaconService(BeaconRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void CreateBeacon(CreateBeaconDTO input)
        {
            var beacon = _mapper.Map<Beacon>(input);
            _repository.Create(beacon);
        }

        public void DeleteBeacon(DeleteBeaconDTO input)
        {
           _repository.Delete(input.Id);
        }

        public List<ReadBeaconDTO> GetAllBeacons()
        {
            var beacons = _repository.GetAll();
            var result = _mapper.Map<List<ReadBeaconDTO>>(beacons);
            return result;
        }

        public ReadBeaconDTO GetBeacon(EntityDTO input)
        {
            var beacon = _repository.GetById(input.Id);
            var result = _mapper.Map<ReadBeaconDTO>(beacon);
            return result;
        }

        public void UpdateBeacon(UpdateBeaconDTO input)
        {
            var beacon = _mapper.Map<Beacon>(input);
            _repository.Update(beacon);
        }
    }
}
