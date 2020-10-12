

namespace GeneticAlgorithm
{
    //TODO: Добавить шаблон
    public class Gene
    {
        public double Value { get;  set; }

        public Gene(int value)
        {
            Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }

}
