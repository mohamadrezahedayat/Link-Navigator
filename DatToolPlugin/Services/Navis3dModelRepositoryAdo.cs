using LinkNavigator.DatToolPlugin.Models;
using LinkNavigator.DatToolPlugin.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkNavigator.DatToolPlugin.Services
{
    class Navis3dModelRepositoryAdo : INavis3dModelRepository
    {
        private string connectionString = "Data Source =.; Initial Catalog = VaultViewer_DB; Integrated Security = true";
        public bool InsertNavis3dModel(string ItemName, string demo)
        {
            string queryString = "insert into Navis3dModel(ItemName, demo ) values(@itemName,@demo)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@itemName", ItemName);
                command.Parameters.AddWithValue("@demo", demo);
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    return true;
                }
                catch
                {
                    return false;

                }
            }
        }
        public bool DeleteNavis3dModel(Navis3dModel navis3dModel)
        {
            throw new NotImplementedException();
        }

        public bool DeleteNavis3dModel(int Navis3dModelId)
        {
            throw new NotImplementedException();
        }

        public List<Navis3dModel> GetAllNavis3dModels()
        {
            throw new NotImplementedException();
        }

        public Navis3dModel GetNavis3dModelById(int Navis3dModelId)
        {
            string queryString = "SELECT * FROM Navis3dModel WHERE Navis3dModelId = @id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
            using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                command.Parameters.AddWithValue("@id", Navis3dModelId);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string name= reader.GetString(1);
                            return new Navis3dModel { ItemName = name };
                        }
                        return null;
                    }
                }
               
            }
        }

        public Navis3dModel GetNavis3dModelByName(string ItemName)
        {
            string queryString = "SELECT * FROM Navis3dModel WHERE ItemName = @name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(queryString, connection))
                {
                    command.Parameters.AddWithValue("@name", ItemName);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            return new Navis3dModel {Navis3dModelId =id ,ItemName = ItemName };
                        }
                        return null;
                    }
                }

            }
        }


        public bool UpdateNavis3dModel(Navis3dModel navis3dModel)
        {
            throw new NotImplementedException();
        }
    }
}
