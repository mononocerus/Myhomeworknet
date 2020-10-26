using System;
namespace homework3test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            test test0=new test();
            test0.InitializeOrderList();
            test0.SortTest();
            test0.ExportTest();
        }
    }
}