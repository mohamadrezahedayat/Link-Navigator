//using LinkNavigator.DatToolPlugin.Models;
//using LinkNavigator.DatToolPlugin.Repositories;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using LinkNavigator.DatToolPlugin.DataLayer;
//using System.Data;
//using System.Data.SqlClient;
//using Dapper;

//namespace LinkNavigator.DatToolPlugin.Services
//{
//   public class Navis3dModelRepository : INavis3dModelRepository
//    {

//        private string connectionString = Connection.connectionString;


//        public List<Navis3dModel> GetAllNavis3dModels()
//        {
//            List<Navis3dModel> list;
//            using (IDbConnection db = new SqlConnection(connectionString))
//            {
//                list = db.Query<Navis3dModel>("SELECT * FROM Navis3dModels").ToList();
//            }
//            return list;
//        }

//        public Navis3dModel GetNavis3dModelById(int Navis3dModelId)
//        {
//            Navis3dModel navis3DModel;
//            using (IDbConnection db = new SqlConnection(connectionString))
//            {
//                navis3DModel = db.Query<Navis3dModel>("SELECT * FROM Navis3dModels WHERE Navis3dModelId=@id ", new { id = Navis3dModelId }).SingleOrDefault();
//            }
//            return navis3DModel;
//        }
//        public Navis3dModel GetNavis3dModelByName(string ItemName)
//        {
//            Navis3dModel navis3DModel;
//            using (IDbConnection db = new SqlConnection(connectionString))
//            {
//                navis3DModel = db.Query<Navis3dModel>("SELECT * FROM Navis3dModels WHERE ItemName=@name ", new { name = ItemName }).SingleOrDefault();
//            }


//            return navis3DModel;
//        }
//        public bool InsertNavis3dModel(Navis3dModel navis3dModel)
//        {
//            try
//            {
//                using (IDbConnection db = new SqlConnection(connectionString))
//                {
//                    string query = "insert into Navis3dModels (ItemName) values (@ItemName)";
//                    db.Execute(query, navis3dModel);
//                }
//                return true;
//            }
//            catch
//            {

//                return false;
//            }
//        }


//        public bool UpdateNavis3dModel(Navis3dModel navis3dModel)
//        {
//            try
//            {
//                using (IDbConnection db = new SqlConnection(connectionString))
//                {
//                    string query = "UPDATE Navis3dModels SET ItemName=@ItemName WHERE Navis3dModelId =@Navis3dModelId ";
//                    db.Execute(query, navis3dModel);
//                }
//                return true;
//            }
//            catch
//            {

//                return false;
//            }
//        }
//        public bool DeleteNavis3dModel(int Navis3dModelId)
//        {
//            try
//            {
//                using (IDbConnection db = new SqlConnection(connectionString))
//                {
//                    string query = "DELETE FROM Navis3dModels WHERE Navis3dModelId =@navis3dModelId ";
//                    db.Execute(query, new { navis3dModelId = Navis3dModelId });
//                }
//                return true;
//            }
//            catch
//            {

//                return false;
//            }
//        }
//        public bool DeleteNavis3dModel(Navis3dModel navis3dModel)
//        {
//            try
//            {
//                using (IDbConnection db = new SqlConnection(connectionString))
//                {
//                    string query = "DELETE FROM Navis3dModels WHERE Navis3dModelId =@navis3dModelId ";
//                    db.Execute(query, navis3dModel);
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
