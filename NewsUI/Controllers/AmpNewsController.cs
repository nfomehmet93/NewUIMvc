using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NewsUI.Bussines.Abstract;

namespace NewsUI.Controllers
{
    [Route("amp/")]
    public class AmpNewsController : Controller
    {
        private readonly IRequestService _requestService;
        private readonly IConfiguration _config;
        public AmpNewsController(IRequestService requestService, IConfiguration configuration)
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
            return RedirectToAction("AmpPageNotFound", "Home");
        }
        [HttpGet("haber-{Id}")]
        public IActionResult GetNewsDetails(int id)
        {
            var endPoint = _config.GetValue<string>("Api");
            if (!string.IsNullOrEmpty(endPoint))
            {
                var response = _requestService.GetNewsDetail(endPoint, id,true);
                if (response.IsSuccess)
                    return View(response);
            }
            return RedirectToAction("AmpPageNotFound");
        }
        public IActionResult AmpPageNotFound()
        {
            return View();
        }
    }
}