using MFT.Training.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MFT.Training.Repositories
{
    public class OstanRepository
    {
        AmlakEntities amlakEntities;
        public OstanRepository() 
        {
            amlakEntities=new AmlakEntities();
        }
        public List<Ostan> GetOstans()
        {
            List<Ostan> ostanha = amlakEntities.Ostans.ToList();
            return ostanha;
        }
    }
}