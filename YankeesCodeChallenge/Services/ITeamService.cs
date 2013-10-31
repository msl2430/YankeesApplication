using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YankeesCodeChallenge.ViewModels;

namespace YankeesCodeChallenge.Services
{
    public interface ITeamService
    {
        IList<TeamDetail> FindAllTeams();
    }
}
