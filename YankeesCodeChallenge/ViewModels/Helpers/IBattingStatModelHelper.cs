using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YankeesCodeChallenge.ViewModels.Helpers
{
    public interface IBattingStatModelHelper
    {
        int Year { get; }
        int Games { get; }
        int AtBats { get; }
        int Hits { get; }
        int StrikeOuts { get; }
        int Walks { get; }
        string Average { get; }
        string OBP { get; }
        string SLG { get; }
        string OPS { get; }
    }
}
