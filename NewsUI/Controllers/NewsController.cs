using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NewsUI.Bussines.Abstract;

namespace NewsUI.Controllers
{
    public class NewsController : Controller
    {
        private readonly IRequestService _requestService;
        private readonly IConfiguration _config;
        public NewsController(IRequestService requestService, IConfiguration configuration)
        {
            _requestService = requestService;
            _config = configuration;
        }
        [HttpGet("haberler")]
        public IActionResult Index()
        {
            var endPoint = _config.GetValue<string>("Api");
            if (!string.IsNullOrEmpty(endPoint))
            {
                var response = _requestService.GetNews(endPoint);
                if (response.IsSuccess)
                    return View(response);
            }
            return RedirectToAction("PageNotFound", "Home"); ;
        }
        [HttpGet("haber-{Id}")]
        public IActionResult GetNewsDetails(int id)
        {
            var endPoint = _config.GetValue<string>("Api");
            if (!string.IsNullOrEmpty(endPoint))
            {
                var response = _requestService.GetNewsDetail(endPoint,id);
                if (response.IsSuccess)
                    return View(response);
            }
            return RedirectToAction("PageNotFound", "Home");
        }
    }
}