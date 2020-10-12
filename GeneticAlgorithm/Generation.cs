using System;
using System.Collections.Generic;


namespace GeneticAlgorithm
{
    public class Generation: IComparable
    {
        public List<Chromosome> Chromosomes { get; set; } = new List<Chromosome>();
        public int NumberChromosomes { get; private set; }
        public double ValueGeneration { get;  set; }

        
        public Generation()
        {
          
        }

        public Generation(List<Chromosome> chromos)
        {
            Chromosomes = chromos;
            NumberChromosomes = chromos.Count;
            Calc();

        }


        public void Calc()
        {
            foreach(var chromo in Chromosomes)
            {
                ValueGeneration += chromo.ValueChromosome;
            }
        }

        public override string ToString()
        {
            string strGen = $"Generation({ValueGeneration}):\n";
            int i = 0;
            foreach (var chromo in Chromosomes)
            {
                strGen += $" { i.ToString()}_{chromo.ToString()}";
                i++;
            }
            return strGen;
        }

        public int CompareTo(object obj)
        {
            Generation gen = obj as Generation;
            if (gen != null)
                return this.ValueGeneration.CompareTo(gen.ValueGeneration);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
    }
}
