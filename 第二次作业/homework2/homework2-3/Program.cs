using System;

namespace p3
{
    class Program
    {
		static void Main(string[] args)
		{
			ModifyNode<int> list = new ModifyNode<int>();
			list.Add(7);
			list.Add(5);
			list.Add(-1);
			list.Add(3);
			list.ForEach(d => Console.WriteLine(d));

			int maxNum = int.MinValue;
			int minNum = int.MaxValue;
			long sum = 0;
			list.ForEach(d => {
				if (d >= maxNum) maxNum = d;
				if (d <= minNum) minNum = d;
				sum += d;
			});
			Console.WriteLine("Max:"+maxNum+"____Min:"+minNum+"____Sum:"+sum);
		}
	}
}
