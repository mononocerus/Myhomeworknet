using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Sockets;
using System.Text;
namespace homework3
{
    [Serializable]
    public class Order
    {
        public int ID { get; set; } 
        public string CustomerName { get; set; }
        public string name { get; set; }
        public List<OrderDetails> orderItemsList { get; set; }
        public Order()
        {
            orderItemsList = new List<OrderDetails>();
        }
        public override bool Equals(object obj)
        {

            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }
            else
            {
                var order = obj as Order;
                if (order.ID != this.ID || order.name != this.name)
                {
                    return false;
                }
                return order.orderItemsList == this.orderItemsList;
            }

        }
        public override int GetHashCode()
        {
            return HashCode.Combine(ID.GetHashCode(), name.GetHashCode(), orderItemsList.GetHashCode());
        }

        public int CompareTo(object x)
        {
            if (ID == ((Order)x).ID)
            {
                return 0;
            }
            return ID < ((Order)x).ID ? -1 : 1;
        }
        public double TotalSum
        {
            get
            {
                double sum = 0;
                foreach (OrderDetails x in orderItemsList)
                {
                    sum = sum + x.cost;
                }

                return sum;
            }
        }
        public void AddOrderDetail(OrderDetails orderDetail)
        {
            foreach (var od in orderItemsList)
            {
                if (od.Equals(orderDetail))
                {
                    throw new Exception("添加OrderDetail错误，OrderDetail重复");
                }
            }
            orderItemsList.Add(orderDetail);
        }

        public override string ToString()
        {
            string str = "\nOrderID:" + ID + CustomerName.ToString();
            int i = 1;
            foreach (OrderDetails x in orderItemsList)
            {
                str += "Item " + i + ":\n";
                str += x.ToString();
                i++;
            }

            return str + "\nOrderSum:" + TotalSum + '\n';
        }
    }
}
