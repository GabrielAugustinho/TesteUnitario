using System;

namespace DELEGATES
{
    class Program
    {

        public delegate void MetodoDelegate();

        public static void Qualquer()
        {
            Console.WriteLine("Método Delegate");
        }

        public static void UtilizaDelegate(MetodoDelegate metodoDelegate)
        {
            metodoDelegate();
        }

        static void Main(string[] args)
        {
            UtilizaDelegate(Qualquer);

            MetodoDelegate metodoDelegate = Qualquer;
            metodoDelegate();
        }
    }
}
