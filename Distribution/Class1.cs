using System;


namespace Distribution
{
    internal class Class1
    {
        static void Main()
        {
            string DistType = "ПОСЛ";
            double Sum = 10000;
            string ArraySum = "1000;2000;3000;5000;8000;5000";
            
            Console.Write(Program.Distribute(DistType, Sum, ArraySum));
            Console.ReadKey();

        }
    }
}
