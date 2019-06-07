using System;
using System.Data;
using System.Data.OleDb;

abstract class DataAccessObject{
    protected string connectionString;
    protected DataSet dataSet;

    public virtual void Connect(){
        connectionString = "provider=Microsoft.JET.OLEDB.4.0; " +
        "data source=..\\..\\..\\db1.mdb";
    }

    public abstract void Select();
    public abstract void Process();
    public virtual void Disconnect(){
        connectionString = "";
    }

    public void Run(){
        Connect();
        Select();
        Process();
        Disconnect();
    }
}


class Categories : DataAccessObject{
    public override void Select(){
        string sql = "select CategoryName from Categories";
        //OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, connectionString);
        
        dataSet = new DataSet();
        //dataAdapter.Fill(dataSet, "Categories");
    }

    public override void Process(){
        Console.WriteLine("Categories ---- ");
        DataTable dataTable = dataSet.Tables["Categories"];
        foreach(DataRow row in dataTable.Rows){
            Console.WriteLine(row["CategoryName"]);
        }
        Console.WriteLine();
    }
}

class Products : DataAccessObject{
    public override void Select(){
        string sql = "select ProductName from Products";
        //OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, connectionString);

        dataSet = new DataSet();
        //dataAdapter.Fill(dataSet, "Products");
    }

    public override void Process(){
        Console.WriteLine("Products ---- ");
        DataTable dataTable = dataSet.Tables["Products"];
        foreach(DataRow row in dataTable.Rows){
            Console.WriteLine(row["ProductName"]);
        }
        Console.WriteLine();
    }
}
