using System;
using System.IO;
using CsvHelper;

namespace GeneticAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            int countEvolv = 1000;
            Evolution evolv = new Evolution(countEvolv, 10, 2);
           // Console.WriteLine(evolv.ToString());
            //Console.WriteLine("Strongest: "+ evolv.StrongestGeneration.ToString());
            
            using (StreamWriter w = new StreamWriter("generation.cvs"))
            {
                int i = 0;
                foreach(var gen in evolv.Generations)
                {

                    w.Write($"{i}");
                    if (i != countEvolv)
                        w.Write(";");
                    i++;
                }
                w.WriteLine();
                i = 0;
                foreach (var gen in evolv.Generations)
                {
                    w.Write($"{Math.Round(gen.ValueGeneration,4)}");
                    if (i != countEvolv)
                        w.Write(";");
                    i++;
                }
            }
            Console.WriteLine("Done");
            Console.WriteLine("Strongest: " + evolv.StrongestGeneration.ToString());
            Console.ReadLine();
            
        }
    }
}
