using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Delegates
{
    /// <summary>
    /// 尺码
    /// </summary>
    public enum Size
    {
        Small,
        Medium,
        Large
    }
    /// <summary>
    /// 形体
    /// </summary>

    public enum Body
    {
        Thin,
        Regular,
        Tight
    }

    public class Product
    {
        public Size Size { get; set; }

        public Body Body { get; set; }

        public decimal Price { get; set; }
    }

    public class Order
    {
        public List<Product> Products { get; set; }
    }

    public delegate decimal DiscountPolicy(Order order);

    /// <summary>
    /// 折扣策略
    /// </summary>
    public class DiscountPolicies
    {
        /// <summary>
        /// 买一赠一
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        private static decimal BuyOneGetOneFree(Order order)
        {
            var products = order.Products;
            if(products.Count < 2)
            {
                return 0M;
            }
            return products.Min(x => x.Price);
        }

        /// <summary>
        /// 满50减5%
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        private static decimal FivePercentOfMoreThanFiftyRMB(Order order)
        {
            decimal nonDiscounted = order.Products.Sum(x => x.Price);
            return nonDiscounted >= 50 ? nonDiscounted * 0.05M : 0M;
        }

        /// <summary>
        /// 指定形体减5元
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        private static decimal FiveRMBOffBody(Order order)
        {
            return order.Products.Sum(x => x.Body == Body.Tight ? 5M : 0M);

        }

        static DiscountPolicy CreateBestDiscountPolicy(params DiscountPolicy[] policies)
        {
            return order => policies.Max(x => x.Invoke(order));
        }

        public static DiscountPolicy DiscountAllTheProducts()
        {
            DiscountPolicy best = CreateBestDiscountPolicy(BuyOneGetOneFree, FivePercentOfMoreThanFiftyRMB, FiveRMBOffBody);
            return best;
        }
    }

    public class ProductOrderingCalulate
    {
        private readonly DiscountPolicy discountPolicy;
        public ProductOrderingCalulate(DiscountPolicy _discountPolicy)
        {
            discountPolicy = _discountPolicy;
        }

        /// <summary>
        /// 计算价格
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public decimal ComputedPrice(Order order)
        {
            decimal total = order.Products.Sum(x => x.Price);

            decimal bestDiscount = discountPolicy.Invoke(order);
            total -= bestDiscount;
            return total;
        }
    }

    public class 产品订单
    {
       public void Show()
        {
            var order = new Order()
            {
                Products = new List<Product>()
                {
                    new Product(){ Size = Size.Small, Body = Body.Regular, Price = 10},
                    new Product(){ Size = Size.Medium, Body = Body.Regular, Price = 20},
                    new Product(){ Size = Size.Large, Body = Body.Thin, Price = 30},
                    new Product(){ Size = Size.Medium, Body = Body.Tight, Price = 40},
                    new Product(){ Size = Size.Small, Body = Body.Thin, Price = 50},
                }
            };
            var discountPolicy = DiscountPolicies.DiscountAllTheProducts();
            var cal = new ProductOrderingCalulate(discountPolicy);
            

            Console.WriteLine(cal.ComputedPrice(order));
        }
    }
}
