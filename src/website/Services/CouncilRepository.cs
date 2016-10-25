using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using website.Models;
using website.Data;

namespace website.Services
{
    public class CouncilRepository : ICouncilRepository
    {
        private readonly MyDbContext _dbContext;

        public CouncilRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IList<Council> getAllCouncils()
        {
            return _dbContext.Councils.ToList();
        }

        public Council getCouncilById(int Id)
        {
            return _dbContext.Councils.Where(x => x.Id == Id).FirstOrDefault();
        }


    }

}
