using System;
using System.Collections.Generic;
using Xunit;
using Challenge_Api.Modals;
using Challenge_Api;

namespace Tests
{
    public class UnitTest1
    {
        
        public class OrderTest
        {
            [Theory]
            [InlineData(2, 2.5, 5)]
            [InlineData(1, 2.5, 2.5)]
            [InlineData(5, 3, 15)]

                public void CalculateTotal(int qty, float price, float expected)          {
                
                Product prod = new Product() { UnitPrice = price };
                Order order = new Order() { Quantity = qty, Product = prod };
                
                Assert.Equal(expected, order.GetTotal());
            }

            [Theory]
            [InlineData(10, 1)]
            [InlineData(100, 10)]
            [InlineData(500, 50)]

            public void CalculateGst(int total, float expected)
            {

                //Product prod = new Product() { UnitPrice = price };
                Order order = new Order() { Total = total};
                
                Assert.Equal(expected, order.CalculateGST());
            }
        }
    }
}