using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YankeesCodeChallenge.Configuration;
using YankeesCodeChallenge.Models.DataObjects;

namespace YankeesCodeChallenge.ViewModels
{
    public interface IBasicPlayerModel
    {
        string HeadshotImage { get; }
        string FullName { get; }
        string Number { get; }
        string Position { get; }
        string Team { get; }
        string League { get; }
    }
}
