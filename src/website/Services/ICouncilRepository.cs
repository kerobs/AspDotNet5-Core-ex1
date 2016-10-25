using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using website.Models;

namespace website.Services
{
    public interface ICouncilRepository {

        IList<Council> getAllCouncils();
        Council getCouncilById(int Id);

    }
}
