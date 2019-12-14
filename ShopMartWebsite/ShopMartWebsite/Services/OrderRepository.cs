﻿using Microsoft.EntityFrameworkCore;
using ShopMartWebsite.Data;
using ShopMartWebsite.Entities;
using ShopMartWebsite.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopMartWebsite.Services
{
    public class OrderRepository : IOrderRepository
    {
        private ShopDbContext _ctx;
        public OrderRepository(ShopDbContext ctx)
        {
            _ctx = ctx;
        }

        public bool DeleteOrder(Order order)
        {
            _ctx.Entry(order).State = EntityState.Modified;
            return _ctx.SaveChanges() > 0;
        }

        public IEnumerable<Order> GetAllOrder()
        {
            return _ctx.orders.Where(x => x.status == true).Include(od => od.OrderDetails).ToList();
        }

        public Order GetOrderById(int id)
        {
            return _ctx.orders.Include(od => od.OrderDetails).FirstOrDefault(x => x.id == id);
        }

        public bool SaveOrder(Order order)
        {
            _ctx.orders.Add(order);
            return _ctx.SaveChanges() > 0;
        }

        public IEnumerable<Order> SearchOrders(string searchTerm, DateTime? searchDate, int page, int recordSize)
        {
            var orders = _ctx.orders.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                orders = orders.Where(x => x.status == true && (x.user.displayname.ToLower().Contains(searchTerm.ToLower()) || x.customer.ToLower().Contains(searchTerm.ToLower())));
            }
            if (searchDate.HasValue && searchDate.Value <= DateTime.Now.Date)
            {
                orders = orders.Where(x => x.status == true && x.createDate.Date == searchDate.Value);
            }

            var skip = (page - 1) * recordSize;
            // skip  = (1    - 1) * 3 = 0 * 3 = 0
            // skip  = (2    - 1) * 3 = 1 * 3 = 3
            // skip  = (3    - 1) * 3 = 2 * 3 = 6

            return orders.Where(x => x.status == true && x.confirm ==true).Include(u=>u.user).Include(a => a.OrderDetails).OrderBy(x => x.createDate).Skip(skip).Take(recordSize).ToList();
        }

        public int SearchOrdersCount(string searchTerm, DateTime? searchDate)
        {
            var orders = _ctx.orders.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                orders = orders.Where(x => x.status == true  && (x.user.displayname.ToLower().Contains(searchTerm.ToLower()) || x.customer.ToLower().Contains(searchTerm.ToLower())));
            }
            if (searchDate.HasValue && searchDate.Value <= DateTime.Now.Date)
            {
                orders = orders.Where(x => x.status == true  && x.createDate.Date == searchDate.Value);
            }



            return orders.Where(x => x.status == true && x.confirm == true).Count();
        }

        public IEnumerable<object> RevenueStatistical(DateTime date)
        {
            /*var report = _ctx.orders
                .GroupBy(x => new { x.createDate.Date })
                .Select(x => new { Date = x.Key.Date.ToShortDateString(), Count = x.Count(), Total = x.Sum(y=> y.total) });*/
            var report = from o in _ctx.orders
                         group o by o.createDate.Date into g
                         //where g.Key > date && g.Key < DateTime.Parse("2019-12-06")
                         select new
                         {
                             Day = g.Key.ToString("dd/MM/yyyy"),
                             Count = g.Count(),
                             Total = g.Sum(x=>x.total)
                         };
            return report.ToList();
        }

        public IEnumerable<Order> SearchOrdersNotConfirm(string searchTerm, DateTime? searchDate, int page, int recordSize)
        {
            var orders = _ctx.orders.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                orders = orders.Where(x => x.status == true && (x.user.displayname.ToLower().Contains(searchTerm.ToLower()) || x.customer.ToLower().Contains(searchTerm.ToLower())));
            }
            if (searchDate.HasValue && searchDate.Value <= DateTime.Now.Date)
            {
                orders = orders.Where(x => x.status == true && x.createDate.Date == searchDate.Value);
            }

            var skip = (page - 1) * recordSize;
            // skip  = (1    - 1) * 3 = 0 * 3 = 0
            // skip  = (2    - 1) * 3 = 1 * 3 = 3
            // skip  = (3    - 1) * 3 = 2 * 3 = 6

            return orders.Where(x => x.status == true && x.confirm == false).Include(u => u.user).Include(a => a.OrderDetails).OrderBy(x => x.createDate).Skip(skip).Take(recordSize).ToList();
        }

        public int SearchOrdersCountNotConfirm(string searchTerm, DateTime? searchDate)
        {
            var orders = _ctx.orders.AsQueryable();
            if (!string.IsNullOrEmpty(searchTerm))
            {
                orders = orders.Where(x => x.status == true && (x.user.displayname.ToLower().Contains(searchTerm.ToLower()) || x.customer.ToLower().Contains(searchTerm.ToLower())));
            }
            if (searchDate.HasValue && searchDate.Value <= DateTime.Now.Date)
            {
                orders = orders.Where(x => x.status == true && x.createDate.Date == searchDate.Value);
            }



            return orders.Where(x => x.status == true && x.confirm == false).Count();
        }
    }
}
