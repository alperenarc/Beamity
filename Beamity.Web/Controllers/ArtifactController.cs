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


            //IEnumerable <ReadArtifactDTO> artifacts = null;

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


            var ext = blobName.Split('.');
            var e = ext[ext.Length - 1];

            string guid = Guid.NewGuid().ToString();
            blobName = guid + "." + e;
            await _blobStorage.UploadAsync(blobName, fileStream);
            string url = "https://testblobkayten.blob.core.windows.net/blobcontainer/" + blobName + "?sv=2018-03-28&ss=bqtf&srt=sco&sp=rwdlacup&se=2019-07-05T16:28:48Z&sig=E8YuTSKxReDDt8%2F4fvHKiMtsNmS8X8KfOXuax9Ut5I4%3D&_=1562317007361";


            return RedirectToAction("Index");
        }

    }
}