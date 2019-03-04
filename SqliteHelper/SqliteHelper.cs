using System.Data;
using Finisar.SQLite;

namespace SqliteHelper
{
  public static class SqliteHelper
  {
    public static SQLiteConnection sql_con;
    public static SQLiteCommand sql_cmd;
    public static SQLiteDataAdapter DB;
    public static DataSet dataSet = new DataSet();
    public static DataTable DT = new DataTable();

    public static void SetConnection(string dbfullPath = "cookies.sqlite")
    {
      sql_con = new SQLiteConnection($"Data Source={dbfullPath};Version=3;New=False;Compress=True;");
    }

    public static void ExecuteQuery(string txtQuery)
    {
      SetConnection();
      sql_con.Open();
      sql_cmd = sql_con.CreateCommand();
      sql_cmd.CommandText = txtQuery;
      sql_cmd.ExecuteNonQuery();
      sql_con.Close();
    }

    public static void Delete(string table, string condition)
    {
      string txtSQLQuery = $"delete from {table} where {condition}";
      ExecuteQuery(txtSQLQuery);
    }

    public static void LoadData()
    {
      SetConnection();
      sql_con.Open();
      sql_cmd = sql_con.CreateCommand();
      const string CommandText = "select id, desc from mains";
      DB = new SQLiteDataAdapter(CommandText, sql_con);
      dataSet.Reset();
      DB.Fill(dataSet);
      DT = dataSet.Tables[0];
      //Grid.DataSource = DT;
      sql_con.Close();
    }

    public static void Add(string message)
    {
      string txtSQLQuery = "insert into  mains (desc) values ('" + message + "')";
      ExecuteQuery(txtSQLQuery);
    }
  }
}
