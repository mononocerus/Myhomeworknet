using System;

namespace homework3
{
    public class OrderDetails
    {
        public string goodsName { get; set; }
        public double cost { get; set; }
        public OrderDetails()
        {
        }
        //重载
        public OrderDetails(double _cost, string _goodsName)
        {
            this.cost = _cost;
            this.goodsName = _goodsName;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.goodsName == ((OrderDetails)obj).goodsName &&
                this.cost == ((OrderDetails)obj).cost;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(goodsName.GetHashCode(), cost.GetHashCode());
        }
        public override string ToString()
        {
            return base.ToString() + "goodsname:" + goodsName + "cost:" + cost + "\n";
        }
    }
}
