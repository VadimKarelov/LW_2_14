using LW_2_13;

namespace LW_2_14
{
    public class Continent
    {
        private static int _counter = 0;

        public string Name;

        public List<Country> Countries;

        public Continent()
        {
            Countries = new List<Country>();
            Name = $"Continent {_counter}";
            _counter++;
        }

        public Continent(int count, Random rn)
        {
            Countries = new List<Country>();
            Name = $"Continent {_counter}";
            for (int i = 0; i < count; i++)
            {
                Countries.Add(new Country(rn.Next(1, 10), rn));
            }
            _counter++;
        }

        public override string ToString()
        {
            string res = this.Name + '\n';
            foreach (var item in Countries)
            {
                res += item.ToString();
            }
            return res;
        }
    }
}
