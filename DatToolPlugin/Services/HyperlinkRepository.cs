//using Dapper;
//using LinkNavigator.DatToolPlugin.DataLayer;
//using LinkNavigator.DatToolPlugin.Models;
//using LinkNavigator.DatToolPlugin.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LinkNavigator.DatToolPlugin.Services
//{
//    public class HyperlinkRepository : IHyperlinkRepository
//    {

//        private string connectionString = Connection.connectionString;


//        public List<Hyperlink> GetAllHyperlinks()
//        {
//            List<Hyperlink> list;
//            using (IDbConnection db = new SqlConnection(connectionString))
//            {
//                list = db.Query<Hyperlink>("SELECT * From Hyperlinks").ToList();
//            }
//            return list;
//        }

//        public Hyperlink GetHyperlinkById(int HyperlinkId)
//        {
//            Hyperlink hyperlink;
//            using (IDbConnection db = new SqlConnection(connectionString))
//            {
//                hyperlink = db.Query<Hyperlink>("SELECT * From Hyperlinks WHERE HyperlinkId=@id ", new { id = HyperlinkId }).SingleOrDefault();
//            }


//            return hyperlink;
//        }

//        public bool InsertHyperlink(Hyperlink hyperlink)
//        {
//            try
//            {
//                using (IDbConnection db = new SqlConnection(connectionString))
//                {
//                    string query = "INSERT INTO Hyperlinks (HyperlinkPath, Navis3dModelId) VALUES (@HyperlinkPath, @Navis3dModelId)";
//                    db.Execute(query, hyperlink);
//                }
//                return true;
//            }
//            catch
//            {

//                return false;
//            }
//        }


//        public bool UpdateHyperlink(Hyperlink hyperlink)
//        {
//            try
//            {
//                using (IDbConnection db = new SqlConnection(connectionString))
//                {
//                    string query = "UPDATE Hyperlinks SET HyperlinkPath=@HyperlinkPath,Navis3dModelId=@Navis3dModelId WHERE HyperlinkId =@HyperlinkId ";
//                    db.Execute(query, hyperlink);
//                }
//                return true;
//            }
//            catch
//            {

//                return false;
//            }
//        }
//        public bool DeleteHyperlink(int HyperlinkId)
//        {
//            try
//            {
//                using (IDbConnection db = new SqlConnection(connectionString))
//                {
//                    string query = "DELETE FROM Hyperlinks WHERE HyperlinkId =@hyperlinkId ";
//                    db.Execute(query, new { hyperlinkId = HyperlinkId });
//                }
//                return true;
//            }
//            catch
//            {

//                return false;
//            }
//        }
//        public bool DeleteHyperlink(Hyperlink hyperlink)
//        {
//            try
//            {
//                using (IDbConnection db = new SqlConnection(connectionString))
//                {
//                    string query = "DELETE FROM Hyperlinks WHERE HyperlinkId =@hyperlinkId ";
//                    db.Execute(query, hyperlink);
//                }
//                return true;
//            }
//            catch
//            {

//                return false;
//            }
//        }

//    }
//}
