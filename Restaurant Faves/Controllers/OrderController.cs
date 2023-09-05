using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant_Faves.Models;
using System.Diagnostics.Metrics;

namespace Restaurant_Faves.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        OrdersDbContext dbContext = new OrdersDbContext();

        //api/Order
        // [HttpGet]
        // public List <Order> GetOrders()
        // {
        //    return dbContext.Orders.ToList();

        // }


        //api/Order
        //api/Order?restaurant=Taco Bell
        //api/Order?orderAgain=true
        //api/Order?orderAgain=true&restaurant=Taco Bell
        [HttpGet]
        public List<Order> GetOrders(bool? orderAgain = null, string? restaurant = null)
        {
            List<Order> Result = dbContext.Orders.ToList();
            if (restaurant != null)
            {
                Result = dbContext.Orders.Where(o => o.Restaurant.Contains(restaurant)).ToList();
            }
            if (orderAgain != null)
            {
                Result = Result.Where(o => o.OrderAgain == orderAgain).ToList();
            }
            
            //List<Order> Result = dbContext.Orders.Where(o => o.Restaurant.Contains(restaurant)).ToList();

            //if (orderAgain != null)
            //{
            //    Result= Result.Where(o=> o.OrderAgain == orderAgain).ToList();
            //}
            return Result;


            //return dbContext.Orders.ToList();

            //return dbContext.Orders.Where(o => o.OrderAgain == orderAgain && o.Restaurant == restaurant).ToList();

        }



            //api/Order/1
            [HttpGet("{id}")]
        public Order GetById(int id)
        {
            return dbContext.Orders.Find(id);
        }



        //api/Order?restuarant=tacobell&description=Taco&rating=4&eatAgain=true
        //[HttpPost]
        //public Order AddOrder(string restaurant, string description, int rating, bool eatAgain)
        //{
        //    Order newOrder = new Order();
        //    newOrder.Restaurant = restaurant;
        //    newOrder.Description = description;
        //    newOrder.Rating = rating;
        //    newOrder.OrderAgain = eatAgain;
        //    dbContext.Orders.Add(newOrder);
        //    dbContext.SaveChanges();
        //    return newOrder;
        //}


        //api/Order
        [HttpPost]
        public Order AddOrder([FromBody] Order newOrder)
        {
            dbContext.Orders.Add(newOrder);
            dbContext.SaveChanges();
            return newOrder;
        }


        //api/Order/3
        [HttpPut("{id}")] 
        public Order ReplaceOrder(int id, [FromBody] Order newOrder)
        {
            Order b = dbContext.Orders.Find(id);
            b = newOrder;
            b.Restaurant = newOrder.Restaurant;
            b.Description = newOrder.Description;
            b.Rating = newOrder.Rating;
            b.OrderAgain = newOrder.OrderAgain;
            dbContext.Orders.Update(b);
            dbContext.SaveChanges();
            return b;
        }


        //api/Order/4
        [HttpDelete("{id}")]
        public Order DeleteById(int id)
        {
            Order deleted=dbContext.Orders.Find(id);
            dbContext.Orders.Remove(deleted);
            dbContext.SaveChanges();
            return deleted;
        }




    }
}
