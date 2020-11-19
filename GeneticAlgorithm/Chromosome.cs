using System;
using System.Collections.Generic;


namespace GeneticAlgorithm
{
    public class Chromosome: IComparable
    {
        public List<Gene> Genes { get; set; } = new List<Gene>();
        public int NumberGenes { get; private set; }

        public double ValueChromosome { get; private set; }
        static Random rnd = new Random();
        public Chromosome(int countGenes)
        {
            for (int i = 0; i < countGenes; i++)
            {
                Genes.Add(new Gene(0));
            }
            NumberGenes = Genes.Count;
        }

        public Chromosome(List<Gene> genes)
        {
            Genes = genes;
            NumberGenes = genes.Count;
            Calc();
        }

        public Chromosome(int countGenes, bool isrnd)
        {
            
            if (isrnd)
            {
                for (int i = 0; i < countGenes; i++)
                {
                    Genes.Add(new Gene(rnd.Next(1, 1000)));
                }

                NumberGenes = Genes.Count;
                Calc();
            }
        }

        public void Calc()
        {
            double result;

            result = Genes[0].Value / (Genes[0].Value * Genes[0].Value + 2 * Genes[1].Value + 1);

            ValueChromosome =  result;
        }


        public override string ToString()
        {
            string strChromosome = $"Chromosome({ValueChromosome}):\n";
            int i = 0;
            foreach (var gen in Genes)
            {
                strChromosome += $"  Gene { i.ToString()}:{gen.ToString()}\n";
                i++;
            }
            return strChromosome;
        }

        public int CompareTo(object obj)
        {
            Chromosome chromo = obj as Chromosome;
            if (chromo != null)
                return this.ValueChromosome.CompareTo(chromo.ValueChromosome);
            else
                throw new Exception("Невозможно сравнить два объекта");
        }
    }
}
