using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace MyBookStore
{
    public class Program
    {
        static void Main()
        {

            using (var ctx =new DB_Store.DB_MyStore())
            {
                var d = ctx.Categorias.ToList();
                Console.WriteLine(d.Count());
            }
            Console.ReadKey();
        }


    }
}