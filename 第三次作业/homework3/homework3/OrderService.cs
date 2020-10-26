using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace homework3
{
    public class OrderService
    {

        public List<Order> OrderList;
        static private OrderService Servicer;
        public OrderService()
        {
            OrderList = new List<Order>();
        }
        static public ref OrderService Instance()
        {
            if (Servicer == null)
            {
                Servicer = new OrderService();
            }
            return ref Servicer;
        }
        public void Add(Order NewOrder)
        {
       
            OrderList.Add(NewOrder);
        }
        public void Delete(Order Order)
        {
            Search(Order);
            OrderList.Remove(Order);
        }
        public void Modify(Order order, Order newOrder)
        {
            int index = OrderList.IndexOf(order);
            if (index == -1)
            {
                throw new Exception("没有该订单");
            }
            else
            {
                OrderList[index] = newOrder;
            }
        }
        public void Export(string path)
        {
            if (Path.GetExtension(path) != ".xml")
            {
                throw new ArgumentException($"{path} is not a xml file!");
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                xmlSerializer.Serialize(fs, OrderList);
            }
        }
        public Order SearchWithId(int Id)
        {
            return OrderList.FirstOrDefault(o => o.ID == Id);
        }
        public Order Search(Order order)
        {
            int index = OrderList.IndexOf(order);
            if (index == -1)
            {
                throw new Exception("没有该订单");
            }
            else
            {
                return OrderList[index] as Order;
            }
        }
        public void Sort(Func<Order, Order, int> func = null)
        {
            if (func == null)
            {
                OrderList.Sort();
            }
            else
            {
                OrderList.Sort((x, y) => func(x, y));
            }
        }
    }
}
