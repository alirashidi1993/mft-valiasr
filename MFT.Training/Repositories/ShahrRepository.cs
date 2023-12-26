using MFT.Training.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MFT.Training.Repositories
{
    public class ShahrRepository
    {
        AmlakEntities dbContext;
        public ShahrRepository()
        {
            dbContext = new AmlakEntities();
        }
        public List<Shahr> GetShahrsByOstanId(long ostanId)
        {
            List<Shahr> shahrhayeOstan=dbContext.Shahrs.Where(i=>i.OstanId==ostanId).ToList();
            return shahrhayeOstan;
        }
    }
}