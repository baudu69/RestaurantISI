using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace Restaurant.Models
{
    public class RestaurantContext
    {
        public string ConnectionString { get; set; }

        public RestaurantContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
        
        public List<Categories> getAllCategories()
        {
            List<Categories> list = new List<Categories>();  
  
            using (MySqlConnection conn = GetConnection())  
            {  
                conn.Open();  
                MySqlCommand cmd = new MySqlCommand("select * from Categories", conn);  
  
                using (var reader = cmd.ExecuteReader())  
                {  
                    while (reader.Read())  
                    {  
                        list.Add(new Categories()  
                        {  
                            idCat = Convert.ToInt32(reader["idCat"]),  
                            libCat = reader["libCat"].ToString()
                        });  
                    }  
                }  
            }  
            return list;
        }

        public Categories getUneCatById(int idCat)
        {
            Categories laCat = null;
            using (MySqlConnection conn = GetConnection())  
            {  
                conn.Open();  
                MySqlCommand cmd = new MySqlCommand("select * from Categories where idCat = " + idCat, conn);  
  
                using (var reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    laCat = new Categories()
                    {
                        idCat = Convert.ToInt32(reader["idCat"]),
                        libCat = reader["libCat"].ToString(),
                    };
                }  
            }

            return laCat;
        }

        public List<Plats> getAllPlats()
        {
            List<Plats> list = new List<Plats>();  
  
            using (MySqlConnection conn = GetConnection())  
            {  
                conn.Open();  
                MySqlCommand cmd = new MySqlCommand("select * from Plats", conn);  
  
                using (var reader = cmd.ExecuteReader())  
                {  
                    while (reader.Read())  
                    {  
                        list.Add(new Plats()  
                        {  
                            idPlat = Convert.ToInt32(reader["idPlat"]),  
                            nomPlat = reader["nomPlat"].ToString(),  
                            prixPlat = reader["prixPlat"].ToString(),
                            catPlat = getUneCatById(Convert.ToInt32(reader["idCat"]))
                        });  
                    }  
                }  
            }  
            return list;
        }
        public List<Plats> getPlatsByIdCat(int idCat)
        {
            List<Plats> list = new List<Plats>();  
  
            using (MySqlConnection conn = GetConnection())  
            {  
                conn.Open();  
                MySqlCommand cmd = new MySqlCommand("select * from Plats where idCat=" + idCat, conn);  
  
                using (var reader = cmd.ExecuteReader())  
                {  
                    while (reader.Read())  
                    {  
                        list.Add(new Plats()  
                        {  
                            idPlat = Convert.ToInt32(reader["idPlat"]),  
                            nomPlat = reader["nomPlat"].ToString(),  
                            prixPlat = reader["prixPlat"].ToString(),
                            catPlat = getUneCatById(Convert.ToInt32(reader["idCat"]))
                        });  
                    }  
                }  
            }  
            return list;
        }
    }
}