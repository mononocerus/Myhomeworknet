using System;
using System.Collections.Generic;
using System.Text;

namespace p3
{
	public class ListNode<T>
	{
		public ListNode<T> Next { get; set; }
		public T Data { get; set; }
		public ListNode(T t)
		{
			Next = null;
			Data = t;
		}
	}
	
	public class ModifyNode<T>
	{
		public ListNode<T> first { get; set; }
		private ListNode<T> last {get;set;}
		public ModifyNode()
		{
			first = last = null;
		}
		public void Add(T t)
		{
			ListNode<T> n = new ListNode<T>(t);
			if (last == null)
			{
				first = last = n;
			}
			else
			{
				last.Next = n;
				last = n;
			}
		}

		public void ForEach(Action<T> action)
		{
			for (ListNode<T> it = first; it != null; it = it.Next)
			{
				action(it.Data);
			}
		}
	}
}
