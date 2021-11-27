using InfoTechBlog.Data;
using InfoTechBlog.Data.FileManager;
using InfoTechBlog.Data.Repository;
using InfoTechBlog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoTechBlog.Controllers
{
    public class HomeController: Controller
    {
        private IRepository _repository;
        private IFileManager _fileManager;

        public HomeController(IRepository repository, IFileManager fileManager)
        {
            _repository = repository;
            _fileManager = fileManager;
        }

        public IActionResult Index(string category) => View(string.IsNullOrEmpty(category) ? _repository.GetAllPosts() : _repository.GetAllPosts(category));
        
        public IActionResult Post(int id) => View(_repository.GetPost(id));
          
        [HttpGet("/Image/{image}")]
        public IActionResult Image(string image) => new FileStreamResult(_fileManager.ImageStream(image), $"image/{image.Substring(image.LastIndexOf(".") + 1)}");
         
    }
}
