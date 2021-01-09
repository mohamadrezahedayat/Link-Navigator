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
    class HyperlinkRepositoryAdo : IHyperlinkRepository
    {
        private string connectionString = "Data Source =.; Initial Catalog = VaultViewer_DB; Integrated Security = true";
        public bool DeleteHyperlink(Hyperlink hyperlink)
        {
            throw new NotImplementedException();
        }

        public bool DeleteHyperlink(int HyperlinkId)
        {
            throw new NotImplementedException();
        }

        public List<Hyperlink> GetAllHyperlinks()
        {
            throw new NotImplementedException();
        }

        public Hyperlink GetHyperlinkById(int Navis3dModelId)
        {
            throw new NotImplementedException();
        }

        public bool InsertHyperlink(string path, int modelId)
        {
            string queryString = "insert into Hyperlinks(HyperlinkPath, Navis3dModelId) values(@path, @modelid)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Parameters.AddWithValue("@path", path);
                command.Parameters.AddWithValue("@modelid", modelId);
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

        public bool UpdateHyperlink(Hyperlink hyperlink)
        {
            throw new NotImplementedException();
        }
    }
}
