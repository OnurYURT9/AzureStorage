using AzureStorageLibrary;
using AzureStorageLibrary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcWebApp.Models;

namespace MvcWebApp.Controllers
{
    public class PicturesController : Controller
    {
        public string UserId { get; set; } = "1234";
        public string City { get; set; } = "Kütahya";
        private readonly INoSqlStorage<UserPicture> _noSqlStorage;
        private readonly IBlobStorage _blobStorage;
        public PicturesController(INoSqlStorage<UserPicture> noSqlStorage,IBlobStorage blobStorage)
        {
           _noSqlStorage= noSqlStorage;
            _blobStorage= blobStorage;
        }


		public async Task<IActionResult> Index()
		{
			ViewBag.UserId = UserId;
			ViewBag.City = City;

			List<FileBlob> fileBlobs = new List<FileBlob>();

			var user = await _noSqlStorage.Get(UserId, City);

			if (user != null)
			{
				user.Paths.ForEach(x =>
				{
					fileBlobs.Add(new FileBlob { Name = x, Url = $"{_blobStorage.BlobUrl}/{EContainerName.userpictures}/{x}" });
				});
			}
			ViewBag.fileBlobs = fileBlobs;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(IEnumerable<IFormFile> userpictures)
		{
			List<string> picturesList = new List<string>();
			foreach (var item in userpictures)
			{
				var newPictureName = $"{Guid.NewGuid()}{Path.GetExtension(item.FileName)}";

				await _blobStorage.UploadAsync(item.OpenReadStream(), newPictureName, EContainerName.userpictures);

				picturesList.Add(newPictureName);
			}

			var isUser = await _noSqlStorage.Get(UserId, City);

			if (isUser != null)
			{
				picturesList.AddRange(isUser.Paths);
				isUser.Paths = picturesList;
			}
			else
			{
				isUser = new UserPicture();

				isUser.RowKey = UserId;
				isUser.PartitionKey = City;
				isUser.Paths = picturesList;
			}

			await _noSqlStorage.Add(isUser);

			return RedirectToAction("Index");
		}


		public async Task<IActionResult> AddWatermark()
        {
            return View();
        }
    }
}
