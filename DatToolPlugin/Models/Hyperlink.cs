using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkNavigator.DatToolPlugin.Models
{
   // use VaultViewer_DB;
   // CREATE TABLE Hyperlinks(
   //     HyperlinkId INT PRIMARY KEY IDENTITY (1, 1),
   //     HyperlinkPath NVARCHAR(max) NOT NULL,
   //     Navis3dModelId INT NOT NULL,
   //     FOREIGN KEY(Navis3dModelId) REFERENCES Navis3dModels(Navis3dModelId)
   // );
  public class Hyperlink
    {
        public int HyperlinkId { get; set; }
        public string HyperlinkPath { get; set; }
        public int Navis3dModelId { get; set; }
    }
}
