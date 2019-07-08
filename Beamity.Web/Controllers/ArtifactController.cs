﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Beamity.Application.DTOs.ArtifactDTOs;
using Beamity.Application.Service.IServices;
using Beamity.Web.Blob;
using Beamity.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Beamity.Web.Controllers
{
    public class ArtifactController : Controller
    {
        public string guid;

        private readonly IBlobManager _blobManager;
        private readonly IArtifactService _artifactService;
      

        public ArtifactController(IBlobManager blobManager, IArtifactService artifactService)
        {
            _blobManager = blobManager;
            _artifactService = artifactService;
        }
        public IActionResult Index()
        {
            IEnumerable<ReadArtifactDTO> artifacts = _artifactService.GetAllArtifacts();
            return View(artifacts);
        }
        [HttpPost]
        public async Task CreateArtifact(CreateArtifactViewModel input)
        {
            try
            {
                string url = await _blobManager.UploadImageAsBlob(input.File);

                using (var client = new HttpClient())
                {
                    CreateArtifactDTO data = new CreateArtifactDTO()
                    {
                        Name = input.Name,
                        MainImageURL = url,
                        RoomId = input.RoomId
                    };
                    _artifactService.CreateArtifact(data);                 

                }
               
            }
            catch (Exception e)
            {

                throw e;
            }

        }

    }
}