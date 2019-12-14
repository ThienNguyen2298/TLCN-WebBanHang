using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopMartWebsite.Interfaces;

namespace ShopMartWebsite.Controllers
{
    public class ChartController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        public ChartController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult ColumnChart()
        {
            List<object> model = new List<object>();
            model = _orderRepository.RevenueStatistical(DateTime.Parse("2019-12-01")).AsEnumerable().ToList();
            return Json(model);
        }
    }
}