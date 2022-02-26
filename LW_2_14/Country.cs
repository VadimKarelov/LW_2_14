using LW_2_13;

namespace LW_2_14
{
    public  class Country
    {
        private static int _counter = 0;

        public string Name;

        public SortedDictionary<string, Organization> OrganizationList;

        public Country()
        {
            OrganizationList = new SortedDictionary<string, Organization>();
            Name = $"Country {_counter}";
            _counter++;
        }

        public Country(int count, Random rn)
        {
            OrganizationList = new SortedDictionary<string, Organization>();
            Name = $"Country {_counter}";
            while (OrganizationList.Count < count)
            {
                switch (rn.Next(0, 5))
                {
                    case 0: var org0 = new Organization(ref rn); OrganizationList.TryAdd(org0.Name, org0); break;
                    case 1: var org1 = new Factory(ref rn); OrganizationList.TryAdd(org1.Name, org1); break;
                    case 2: var org2 = new Library(ref rn); OrganizationList.TryAdd(org2.Name, org2); break;
                    case 3: var org3 = new InsuranceCompany(ref rn); OrganizationList.TryAdd(org3.Name, org3); break;
                    case 4: var org4 = new ShipConstructingCompany(ref rn); OrganizationList.TryAdd(org4.Name, org4); break;
                }
            }
            _counter++;
        }

        public override string ToString()
        {
            string res = "\n>>>" + this.Name + '\n';
            foreach (var item in OrganizationList.Values)
            {
                res += ">>>>>>" + item.ToString() + '\n';
            }
            return res;
        }
    }
}
