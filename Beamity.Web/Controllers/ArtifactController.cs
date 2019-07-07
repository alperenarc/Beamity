using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Beamity.Application.Azure;
using Beamity.Application.DTOs.ArtifactDTOs;
using Beamity.Web.Models.AzureViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Beamity.Web.Controllers
{
    public class ArtifactController : Controller
    {
        public string guid;

        private readonly IAzureBlobStorage _blobStorage;

        public ArtifactController(IAzureBlobStorage blobStorage)
        {
            _blobStorage = blobStorage;
        }
        public async Task<IActionResult> Index()
        {
            //guid = Guid.NewGuid().ToString();


            //IEnumerable<ReadArtifactDTO> artifacts = null;

            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://localhost:5001/api/");
            //    var responseTask = await client.GetAsync("Artifact/GetAllArtifacts");

            //    var readTask = responseTask.Content.ReadAsAsync<IList<ReadArtifactDTO>>();

            //    artifacts = readTask.Result;

            //}
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadFile(FileInputModel inputModel)
        {

            if (inputModel == null)
                return Content("Argument null");
            if (inputModel.File == null || inputModel.File.Length == 0)
                return Content("file not selected");

            var blobName = inputModel.File.GetFilename();
            var fileStream = await inputModel.File.GetFileStream();


            if (!string.IsNullOrEmpty(inputModel.Folder))
                blobName = string.Format(@"{0}\{1}", inputModel.Folder, blobName);

            await _blobStorage.UploadAsync(blobName, fileStream);

            
            return ViewBag.Mesaj = "Mesaj";
        }

    }
}