using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsUI.Bussines.Abstract;

namespace NewsUI.Controllers
{
    public class NewsController : Controller
    {
        private readonly IRequestService _requestService;
        public NewsController(IRequestService requestService)
        {
            _requestService = requestService;
        }
        [HttpGet("haberler")]
        public IActionResult Index()
        {
           var response= _requestService.GetNews("https://localhost:44345");
            return View(response);
        }
        [HttpGet("haber-{Id}")]
        public IActionResult GetNewsDetails(int id)
        {
           var response= _requestService.GetNewsDetail("https://localhost:44345",id);
            return View(response);
        }
    }
}