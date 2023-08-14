using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace CompanyDataApp.Model
{
    public class Type
    {
        int id;
        String name;

        public Type(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public Type()
        {

        }
        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }

        internal static Type GetTypeByName(string name)
        {
            Type type = new Type();
            SQLiteConnection sqlite = new SQLiteConnection("Data Source=C:/Users/Nikola/Downloads/database.s3db;Version=3;");
            sqlite.Open();
            SQLiteDataReader reader;            
            SQLiteCommand command = new SQLiteCommand("Select * from type where name = '" + name + "'", sqlite);
            reader = command.ExecuteReader();
            

            while(reader.Read())
            {
                type.Id = reader.GetInt32(0);
            }
            type.Name = name;
            sqlite.Close();
            return type;
        }
    }
}
