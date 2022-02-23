using LW_2_13;

namespace LW_2_14
{
    public class Continent
    {
        public List<Organization> OrganizationList;

        public Continent()
        {
            OrganizationList = new List<Organization>();
        }

        public Continent(int count, Random rn)
        {
            OrganizationList = new List<Organization>();
            for (int i = 0; i < count; i++)
            {
                switch (rn.Next(0, 5))
                {
                    case 0: OrganizationList.Add(new Organization(ref rn)); break;
                    case 1: OrganizationList.Add(new Factory(ref rn)); break;
                    case 2: OrganizationList.Add(new InsuranceCompany(ref rn)); break;
                    case 3: OrganizationList.Add(new Library(ref rn)); break;
                    case 4: OrganizationList.Add(new ShipConstructingCompany(ref rn)); break;
                }
            }
        }

        public string Show()
        {
            string res = "";
            foreach (var item in OrganizationList)
            {
                res += item.ToString() + '\n';
            }
            return res;
        }
    }
}
