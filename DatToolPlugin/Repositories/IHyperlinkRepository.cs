using LinkNavigator.DatToolPlugin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkNavigator.DatToolPlugin.Repositories
{
    public interface IHyperlinkRepository
    {
        List<Hyperlink> GetAllHyperlinks();
        Hyperlink GetHyperlinkById(int Navis3dModelId);
        bool InsertHyperlink(string path, int modelId);
        bool UpdateHyperlink(Hyperlink hyperlink);
        bool DeleteHyperlink(Hyperlink hyperlink);
        bool DeleteHyperlink(int HyperlinkId);
      
    }
}
