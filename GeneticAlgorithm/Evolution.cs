using System;
using System.Collections.Generic;
using System.Linq;


namespace GeneticAlgorithm
{
    public class Evolution
    {
        private Generation _generation;
        public List<Generation> Generations { get; private set; } = new List<Generation>();
        public Generation StrongestGeneration { get; private set; }

        static Random rnd = new Random();

        public Evolution(int countEvolution, int countChromo, int countGenes)
        {
            _generation = new Generation();
            
            for(int i =0; i < countChromo; i++)
            {

                _generation.Chromosomes.Add(new Chromosome(countGenes, true));
            }
            _generation.Calc();
            Generations.Add(_generation);
            for (int i = 1; i < countEvolution + 1; i++)
            {
                _generation = CrossingOver(_generation, countChromo, countGenes);
                Generations.Add(_generation);
            }

            StrongestGeneration = Generations.Max();
        }


        Generation CrossingOver(Generation generate, int countChromo, int countGenes)
        {

            // Пытался сделать по умному: определять сильные хромосом, 
            //которые больше среднего значения всех хромосом, но потом понял, что сложно размножать. Поэтому сделал по тупому ниже.

            //int average = (int)generate.Chromosomes.Average(chromo => chromo.ValueChromosome);

            //var strongChromos = (List<Chromosome>)generate.Chromosomes.Where(chromo => chromo.ValueChromosome >= average);

            //int difference = generate.Chromosomes.Count - strongChromos.Count;


            Chromosome strongestChromo = generate.Chromosomes.Max();

            List<Chromosome> newChromosome = new List<Chromosome>();
            //Говно полное,  тут размножение только для двух генов
            for (int i = 0; i < countChromo/2; i++)
            {
                newChromosome.Add(new Chromosome(countGenes));
                newChromosome[i].Genes[0] = strongestChromo.Genes[0];
                
                newChromosome[i].Genes[1].Value = rnd.Next(1, 1000);
                newChromosome[i].Calc();
            }

            for (int i = countChromo / 2; i < countChromo; i++)
            {
                newChromosome.Add(new Chromosome(countGenes));
                newChromosome[i].Genes[1] = strongestChromo.Genes[1];
               
                newChromosome[i].Genes[0].Value = rnd.Next(1, 1000);
                newChromosome[i].Calc();
            }

            Generation NewGeneration = new Generation(newChromosome);

            return NewGeneration;
        }

        public override string ToString()
        {
            string str = "";
            int i = 0;

            foreach(var gen in Generations)
            {
                str += $"{i.ToString()}_{gen.ToString()}";
                i++;
            }
            return str;
        }
    }
}
