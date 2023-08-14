using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyDataApp.Model
{
    public class Symbol
    {
        int id;
        String name;
        String ticker;
        String isin;
        String currencyCode;
        DateTime dateAdded;
        double price;
        DateTime priceDate;
        Type type;
        Exchange exchange;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Ticker { get => ticker; set => ticker = value; }
        public string Isin { get => isin; set => isin = value; }
        public string CurrencyCode { get => currencyCode; set => currencyCode = value; }
        public DateTime DateAdded { get => dateAdded; set => dateAdded = value; }
        public double Price { get => price; set => price = value; }
        public DateTime PriceDate { get => priceDate; set => priceDate = value; }
        internal Type Type { get => type; set => type = value; }
        internal Exchange Exchange { get => exchange; set => exchange = value; }

        public Symbol(int id, String name, String ticker, String isin, String currencyCode, DateTime dateAdded, double price, DateTime priceDate, Type type, Exchange exchange)
        {
            this.id = id;
            this.name = name;
            this.ticker = ticker;
            this.isin = isin;
            this.currencyCode = currencyCode;
            this.dateAdded = dateAdded;
            this.price = price;
            this.priceDate = priceDate;
            this.type = type;
            this.exchange = exchange;
        }

        public Symbol()
        {

        }

        internal static Symbol GetSymbol(String name, String ticker, Double price, Type type, Exchange exchange)
        {
            Symbol symbol = new Symbol();
            symbol.name = name;
            symbol.ticker = ticker;
            symbol.price = price;
            symbol.type = type;
            symbol.exchange = exchange;
            SQLiteConnection sqlite = new SQLiteConnection("Data Source=C:/Users/Nikola/Downloads/database.s3db;Version=3;");
            sqlite.Open();
            SQLiteDataReader reader;
            SQLiteCommand command = new SQLiteCommand($"Select * from Symbol where name = '{name}' and ticker = '{ticker}' and typeid = {type.Id} and exchangeid = {exchange.Id}", sqlite);
            reader = command.ExecuteReader();


            while (reader.Read())
            {
                symbol.Id = reader.GetInt32(0);
                symbol.Isin = reader.GetString(3);
                symbol.CurrencyCode = reader.GetString(4);
                symbol.DateAdded = reader.GetDateTime(5);
                symbol.priceDate = reader.GetDateTime(7);
            }
            
            sqlite.Close();
            return symbol;
        }

    }
}
