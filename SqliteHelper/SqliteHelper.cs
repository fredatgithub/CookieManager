using System.Data;
using Finisar.SQLite;

namespace SqliteHelper
{
  public static class SqliteHelper
  {
    public static SQLiteConnection sql_con;
    public static SQLiteCommand sql_cmd;
    public static SQLiteDataAdapter DatabaseAdapter;
    public static DataSet dataSet = new DataSet();
    public static DataTable dataTable = new DataTable();

    public static void SetConnection(string dbfullPath = "cookies.sqlite")
    {
      sql_con = new SQLiteConnection($"Data Source={dbfullPath};Version=3;New=False;Compress=True;");
    }

    public static void ExecuteQuery(string dbPath, string txtQuery)
    {
      SetConnection(dbPath);
      sql_con.Open();
      sql_cmd = sql_con.CreateCommand();
      sql_cmd.CommandText = txtQuery;
      sql_cmd.ExecuteNonQuery();
      sql_con.Close();
    }

    public static void Delete(string dbPath, string table, string condition)
    {
      string txtSQLQuery = $"delete from {table} where {condition}";
      ExecuteQuery(dbPath, txtSQLQuery);
    }

    public static DataTable LoadData(string tableName)
    {
      SetConnection();
      sql_con.Open();
      sql_cmd = sql_con.CreateCommand();
      string CommandText = $"select * from {tableName}";
      DatabaseAdapter = new SQLiteDataAdapter(CommandText, sql_con);
      dataSet.Reset();
      DatabaseAdapter.Fill(dataSet);
      dataTable = dataSet.Tables[0];
      //Grid.DataSource = DT;
      sql_con.Close();
      return dataTable;
    }

    public static void Add(string dbPath, string message)
    {
      string txtSQLQuery = "insert into  mains (desc) values ('" + message + "')";
      ExecuteQuery(dbPath, txtSQLQuery);
    }
  }
}
