using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finisar.SQLite;

namespace SqliteHelper
{
  public class SqliteHelper
  {
    private SQLiteConnection sql_con;
    private SQLiteCommand sql_cmd;
    private SQLiteDataAdapter DB;
    private DataSet dataSet = new DataSet();
    private DataTable DT = new DataTable();

    public void SetConnection(string dbfullPath = "cookies.sqlite")
    {
      sql_con = new SQLiteConnection($"Data Source={dbfullPath};Version=3;New=False;Compress=True;");
    }

    public void ExecuteQuery(string txtQuery)
    {
      SetConnection();
      sql_con.Open();
      sql_cmd = sql_con.CreateCommand();
      sql_cmd.CommandText = txtQuery;
      sql_cmd.ExecuteNonQuery();
      sql_con.Close();
    }

    public void LoadData()
    {
      SetConnection();
      sql_con.Open();
      sql_cmd = sql_con.CreateCommand();
      string CommandText = "select id, desc from mains";
      DB = new SQLiteDataAdapter(CommandText, sql_con);
      dataSet.Reset();
      DB.Fill(dataSet);
      DT = dataSet.Tables[0];
      //Grid.DataSource = DT;
      sql_con.Close();
    }

    public void Add(string message)
    {
      string txtSQLQuery = "insert into  mains (desc) values ('" + message + "')";
      ExecuteQuery(txtSQLQuery);
    }
  }
}
