using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace mvc.Repository.DataBese
{
    class conexao
    {
        public readonly SqlConnection Connection;
        public SqlTransaction Transaction;

        public Conexao()
        {
            Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connectionString"].ToString());
        }

        public SqlConnection Open()
        {
            if (Connection.State == ConnectionState.Broken)
            {
                Connection.Close();
                Connection.Open();
            }

            if (Connection.State != ConnectionState.Open)
                Connection.Open();

            return Connection;
        }

        //Métodos utilizados nas transações 
        public void BeginTransaction()
        {
            Open();
            Transaction = Connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            Transaction.Commit();
        }

        public void RollBackTransaction()
        {
            Transaction.Rollback();
        }
    }
}