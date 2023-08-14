using CompanyDataApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Type = CompanyDataApp.Model.Type;

namespace CompanyDataApp
{
    public partial class SymbolsForm : Form
    {
        public static SQLiteConnection sqlite;
        
        public SymbolsForm()
        {
            InitializeComponent();
            
            
        }

       

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void SymbolsForm_Load(object sender, EventArgs e)
        {
            if (sqlite != null)
            {
                fillTable("All","All");
                fillComboboxes();
            }
        }

        private void fillComboboxes()
        {            
            //sqlite.Open();            
            TypeCmb.DisplayMember = "name";
            ExchangeCmb.DisplayMember = "name";
            SQLiteDataAdapter dataAdapterType = new SQLiteDataAdapter("select distinct name from type", sqlite);
            SQLiteDataAdapter dataAdapterExchange = new SQLiteDataAdapter("select distinct name from exchange", sqlite);
            DataTable tableType = new DataTable();
            DataTable tableExchange = new DataTable();

            dataAdapterType.Fill(tableType);
            dataAdapterExchange.Fill(tableExchange);

            DataRow dr = tableType.NewRow(); // Added "All" filter option
            dr.SetField(0, "All");
            tableType.Rows.InsertAt(dr, 0);

            DataRow dr2 = tableExchange.NewRow();
            dr2.SetField(0, "All");
            tableExchange.Rows.InsertAt(dr2, 0);

            TypeCmb.DataSource = tableType;
            ExchangeCmb.DataSource = tableExchange;

        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            

        }        

        private void Database1ToolStripMenuItem_Click(object sender, EventArgs e) // Database selected.
        {
            String connectionString = "Data Source=C:/Users/Nikola/Downloads/database.s3db;Version=3;";
            EstablishConnection(connectionString);
            SymbolsForm_Load(sender, e);
            

        }

        private SQLiteConnection EstablishConnection(string connectionString)
        {
            sqlite = new SQLiteConnection(connectionString);
            sqlite.Open();
            return sqlite;
        }

        private void fillTable(String typeFilter, String exchangeFilter)
        {
            //sqlite.Open();
            SQLiteCommand sqlcmd = sqlite.CreateCommand();

            String query = "SELECT s.Name, s.Ticker, s.Price, e.Name as ExchangeName, t.Name as TypeName FROM Symbol s left join Type t on s.TypeId = t.Id left join Exchange e on s.ExchangeId = e.Id ";
            if(typeFilter != "All" || exchangeFilter != "All")
            {
                query += " WHERE ";
                if(typeFilter != "All")
                {
                    query += "t.Name ='" + typeFilter + "'";
                    if(exchangeFilter != "All")
                    {
                        query += " and e.Name = '" + exchangeFilter + "'";
                    }
                }
                else if(exchangeFilter != "All")
                {
                    query += " e.Name = '" + exchangeFilter + "'";
                }
            }
            SQLiteCommand command = new SQLiteCommand(query, sqlite);
            SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);
            DataTable dataTable = new DataTable();                        
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

            //sqlite.Close();
            
            
        }

        private void FilterBtn_Click(object sender, EventArgs e)
        {
            String typeFilter = TypeCmb.GetItemText(TypeCmb.SelectedItem);
            String exchangeFilter = ExchangeCmb.GetItemText(ExchangeCmb.SelectedItem);            

            
            fillTable(typeFilter, exchangeFilter);
            
        }

        private void AddSymbolBtn_Click(object sender, EventArgs e)
        {
            if( sqlite == null)
            {
                MessageBox.Show("Choose a database first");
                return;
            }
            AddOrEditSymbolForm form = new AddOrEditSymbolForm("Add");
            form.Show();
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void EditSymbolBtn_Click(object sender, EventArgs e)
        {
            if (sqlite == null)
            {
                MessageBox.Show("Choose a database first");
                return;
            }
            int i = dataGridView1.CurrentRow.Index;
            if(i==0)
            {
                MessageBox.Show("Select a row first");
                return;
            }
            AddOrEditSymbolForm form = new AddOrEditSymbolForm("Edit");

            Symbol symbol = new Symbol();
            symbol.Name = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            symbol.Ticker = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            symbol.Price = Double.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            symbol.Type = Type.GetTypeByName(dataGridView1.CurrentRow.Cells[4].Value.ToString());
            symbol.Exchange = Exchange.GetExchangeByName(dataGridView1.CurrentRow.Cells[3].Value.ToString());
            form.Symbol = symbol;
            form.Show();
        }

        private void DeleteSymbolBtn_Click(object sender, EventArgs e)
        {
            if (sqlite == null)
            {
                MessageBox.Show("Choose a database first");
                return;
            }
            int i = dataGridView1.CurrentRow.Index;
            if (i == 0)
            {
                MessageBox.Show("Select a row first");
                return;
            }
            DialogResult res = MessageBox.Show("Are you sure you want to delete the selected symbol?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                Symbol symbol = new Symbol();
                symbol.Name = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                symbol.Ticker = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                symbol.Price = Double.Parse(dataGridView1.CurrentRow.Cells[2].Value.ToString());
                symbol.Type = Type.GetTypeByName(dataGridView1.CurrentRow.Cells[4].Value.ToString());
                symbol.Exchange = Exchange.GetExchangeByName(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                symbol = Symbol.GetSymbol(symbol.Name, symbol.Ticker, symbol.Price, symbol.Type, symbol.Exchange);
                String query = $"delete from symbol where id = {symbol.Id}";
                try
                {
                    SQLiteCommand command = new SQLiteCommand(query, sqlite);
                    command.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error");
                    return;
                }
                MessageBox.Show("Symbol successfully deleted");
            }
            if (res == DialogResult.Cancel)
            {
               
            }
        }
    }
}
