using CompanyDataApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Type = CompanyDataApp.Model.Type;

namespace CompanyDataApp
{
    public partial class AddOrEditSymbolForm : Form
    {
        String mode;
        public Symbol symbol;
        public static SQLiteConnection sqlite;

        public Symbol Symbol { get => symbol; set => symbol = value; }

        public AddOrEditSymbolForm(String mode)
        {
            InitializeComponent();
            this.mode = mode;
            this.Text = mode + " Symbol";
            sqlite = SymbolsForm.sqlite;
        }

        private void AddOrEditSymbolForm_Load(object sender, EventArgs e)
        {
            fillComboboxes();
            if (mode == "Edit")
            {
                symbol = Symbol.GetSymbol(Symbol.Name, Symbol.Ticker, Symbol.Price, Symbol.Type, Symbol.Exchange);
                nameTxt.Text = symbol.Name;
                tickerTxt.Text = symbol.Ticker;
                isinTxt.Text = symbol.Isin;
                currencyTxt.Text = symbol.CurrencyCode;
                priceTxt.Text = symbol.Price.ToString();
                priceDateTxt.Text = symbol.PriceDate.ToString("yyyy-MM-dd");
                TypeCmb.SelectedIndex = TypeCmb.FindStringExact(symbol.Type.Name);
                ExchangeCmb.SelectedIndex = ExchangeCmb.FindStringExact(symbol.Exchange.Name);
                
            }
            
        }

        private void fillComboboxes()
        {
            
            TypeCmb.DisplayMember = "name";
            ExchangeCmb.DisplayMember = "name";
            SQLiteDataAdapter dataAdapterType = new SQLiteDataAdapter("select distinct name from type", sqlite);
            SQLiteDataAdapter dataAdapterExchange = new SQLiteDataAdapter("select distinct name from exchange", sqlite);
            DataTable tableType = new DataTable();
            DataTable tableExchange = new DataTable();

            dataAdapterType.Fill(tableType);
            dataAdapterExchange.Fill(tableExchange);

            if (mode == "Add")
            {
                DataRow dr = tableType.NewRow(); 
                dr.SetField(0, " ");
                tableType.Rows.InsertAt(dr, 0);

                DataRow dr2 = tableExchange.NewRow();
                dr2.SetField(0, " ");
                tableExchange.Rows.InsertAt(dr2, 0);
            }
            TypeCmb.DataSource = tableType;
            ExchangeCmb.DataSource = tableExchange;

        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if(TypeCmb.GetItemText(TypeCmb.SelectedItem) == " " || ExchangeCmb.GetItemText(ExchangeCmb.SelectedItem) == " " ||
                nameTxt.Text == "" || tickerTxt.Text == "" || isinTxt.Text == "" || currencyTxt.Text == "" || priceTxt.Text == "" ||
                priceDateTxt.Text == "")
            {
                MessageBox.Show("One or more fields are empty");
                return;
            }
            Symbol symbol = new Symbol();
            symbol.Name = nameTxt.Text;
            symbol.Ticker = tickerTxt.Text;
            symbol.Isin = isinTxt.Text;
            symbol.CurrencyCode = currencyTxt.Text;
            try
            {
                symbol.Price = Double.Parse(priceTxt.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Price must be a number");
            }
            try
            {                
                symbol.PriceDate = DateTime.Parse(priceDateTxt.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Price date must be a valid date (YYYY-MM-DD)");
            }
            symbol.DateAdded = DateTime.UtcNow;
            String dateAddedString = symbol.DateAdded.ToString("yyyy-MM-dd");
            String priceDateString = symbol.PriceDate.ToString("yyyy-MM-dd");
            String priceString = symbol.Price.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
            symbol.Type = Type.GetTypeByName(TypeCmb.GetItemText(TypeCmb.SelectedItem));
            symbol.Exchange = Exchange.GetExchangeByName(ExchangeCmb.GetItemText(ExchangeCmb.SelectedItem));
            String query;

            if(mode == "Edit")
            {
                query = $"update Symbol set name = '{symbol.Name}', ticker = '{symbol.Ticker}', isin = '{symbol.Isin}', currencycode = '{symbol.CurrencyCode}', price = {priceString}, priceDate = '{priceDateString}', typeId = {symbol.Type.Id}, exchangeId = {symbol.Exchange.Id} " +
                    $"where id = {Symbol.Id}";
            }
            else
            {
                query = $"insert into Symbol (Name,Ticker,Isin,CurrencyCode,DateAdded,Price,PriceDate,TypeId,ExchangeId) values ('{symbol.Name}','{symbol.Ticker}','{symbol.Isin}','{symbol.CurrencyCode}'" +
                $",'{dateAddedString}',{priceString},'{priceDateString}',{symbol.Type.Id},{symbol.Exchange.Id})";
            }
             

            try
            {
                SQLiteCommand command = new SQLiteCommand(query, sqlite);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error");
                return;
            }
            MessageBox.Show("Changes saved successfully");
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
