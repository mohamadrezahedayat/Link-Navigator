using LinkNavigator.DatToolPlugin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkNavigator.DatToolPlugin.Repositories
{
   public interface INavis3dModelRepository
    {
        List<Navis3dModel> GetAllNavis3dModels();
        Navis3dModel GetNavis3dModelById(int Navis3dModelId);
        Navis3dModel GetNavis3dModelByName(string ItemName);
        bool InsertNavis3dModel(string name, string demo);
        bool UpdateNavis3dModel(Navis3dModel navis3dModel);
        bool DeleteNavis3dModel(Navis3dModel navis3dModel);
        bool DeleteNavis3dModel(int Navis3dModelId);
      
    }
}
