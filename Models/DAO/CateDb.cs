using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DAO
{
    public class CateDb
    {
        DtbContext context = null;

        public CateDb()
        {
            context = new DtbContext();
        }
        public List<category> ListCategory()
        {
            return context.categories.OrderByDescending(x => x.name).ToList();
       }

    }
}
