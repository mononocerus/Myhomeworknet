using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using homework3;


namespace homework3test
{
    [TestClass]
    
    public class test
    {
       
            private Order order1 = new Order()
            {
                ID = 1000001,
                CustomerName = "Jerome",
                orderItemsList = new List<OrderDetails>()
                {
                    new OrderDetails(1000,"phone"),
                    new OrderDetails(8000,"PC")
                }
            };
            private Order order2 = new Order()
            {
                ID = 1000002,
                CustomerName = "Peter",
                orderItemsList = new List<OrderDetails>()
                {
                    new OrderDetails(7000,"phone2"),
                    new OrderDetails(9000,"PC2")
                }
            };
            private Order order3 = new Order()
            {
                ID = 1000003,
                CustomerName = "Kold",
                orderItemsList = new List<OrderDetails>()
                {
                    new OrderDetails(9775,"phone3"),
                    new OrderDetails(2344,"PC3")
                }
            };
            private OrderService service;

            [TestInitialize]
            public void InitializeOrderList()
            {
                service = OrderService.Instance();
                service.OrderList.Clear();
                service.Add(order1);
                service.Add(order2);
            }

            [TestMethod]
        
            
            public void SortTest()
            {
                service.Add(order3);
                service.Sort();
                var correct = new List<Order>
            {
                order1,order2,order3
            };
                CollectionAssert.Equals(service.OrderList, correct);

                service.Sort((a, b) => string.Compare(a.CustomerName, b.CustomerName));
                correct = new List<Order>
            {
                order1,order3,order2
            };
                CollectionAssert.Equals(service.OrderList, correct);
            }

            [TestMethod]
            public void ExportTest()
            {
                service.Export("order.xml");
        
            }
        }
    }

