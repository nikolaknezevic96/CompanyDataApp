using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace CompanyDataApp.Model
{
    public class Exchange
    {
        int id;
        String name;

        public Exchange()
        {
        }

        public Exchange(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        internal static Exchange GetExchangeByName(string name)
        {
            Exchange exchange = new Exchange();
            SQLiteConnection sqlite = new SQLiteConnection("Data Source=C:/Users/Nikola/Downloads/database.s3db;Version=3;");
            sqlite.Open();
            SQLiteDataReader reader;
            SQLiteCommand command = new SQLiteCommand("Select * from exchange where name = '" + name + "'", sqlite);
            reader = command.ExecuteReader();


            while (reader.Read())
            {
                exchange.Id = reader.GetInt32(0);
            }
            exchange.Name = name;
            sqlite.Close();
            return exchange;
        }
    }
}
