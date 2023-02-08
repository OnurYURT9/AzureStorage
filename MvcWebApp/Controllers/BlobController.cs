using AzureStorageLibrary;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcWebApp.Models;

namespace MvcWebApp.Controllers
{
    public class BlobController : Controller
    {
        private readonly IBlobStorage _blobStorage;
        public BlobController(IBlobStorage blobStorage)
        {
            _blobStorage = blobStorage;
        }
        public async Task<IActionResult> Index()
        {
            var names = _blobStorage.GetNames(EContainerName.userpictures);
            string blobUrl = $"{_blobStorage.BlobUrl}/{EContainerName.userpictures.ToString()}";
           ViewBag.blobs = names.Select(x=>new FileBlob { Name= x,Url=$"{blobUrl}/{x}" }).ToList();
            ViewBag.logs =await _blobStorage.GetLogAsync("controller.txt");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile picture)
        {
            
            await _blobStorage.SetLogAsync("Upload metoduna giriş yapıldı", "controller.txt");
            var newFileName = Guid.NewGuid().ToString()+Path.GetExtension(picture.FileName);
            await _blobStorage.UploadAsync(picture.OpenReadStream(), newFileName,EContainerName.userpictures);
            await _blobStorage.SetLogAsync("Upload metodundan çıkış yapıldı", "controller.txt");
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Download(string fileName)
        {
            var stream = await _blobStorage.DownloadAsync(fileName, EContainerName.userpictures);
            return File(stream,"application/octet-stream",fileName);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string fileName)
        {
               await _blobStorage.DeleteAsync(fileName, EContainerName.userpictures);
            return RedirectToAction("Index");
        }
    }
}
