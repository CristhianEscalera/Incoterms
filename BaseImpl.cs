using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionesMedicasBilbaoDAO.Implementacion
{
    public class BaseImpl
    {
        string connectionString = @"Server=CAEM\CAEM;Database=BDEquiposMedicos;User Id=CAEM7;Password=REDBULl2019;";
        internal string query = "";

        public string GetGenerateIDTable(string tableName)
        {
            query = "SELECT IDENT_CURRENT('"+tableName+"') + IDENT_INCR('"+tableName+"')";
            SqlCommand command = CreateBasicCommand(query);
            try
            {
                command.Connection.Open();
                return command.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
        }
        public SqlCommand CreateBasicCommand()
        {
            SqlConnection connection= new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            return command;
        }

        public SqlCommand CreateBasicCommand(string sql)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql,connection);
            return command;
        }

        public List<SqlCommand> Create2BasicCommand(string sql1,string sql2)
        {
            List<SqlCommand> cmds = new List<SqlCommand>();
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command1 = new SqlCommand(sql1, connection);
            cmds.Add(command1);

            SqlCommand command2 = new SqlCommand(sql2, connection);
            cmds.Add(command2);

            return cmds;
        }

        public int ExecuteBasicCommand(SqlCommand command)
        {
            try
            {
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();

            }
        }

        public void ExecuteNBasicCommand(List<SqlCommand> cmds)
        {
            SqlCommand command0 = cmds[0];
            SqlTransaction t = null;
            try
            {
                command0.Connection.Open();
                t = command0.Connection.BeginTransaction();

                foreach (SqlCommand item in cmds)
                {
                     item.Transaction = t;
                     item.ExecuteNonQuery();
                }
                t.Commit();
            }
            catch (Exception ex)
            {
                t.Rollback();
                throw ex;
            }
            finally
            {
                command0.Connection.Close();
            }
        }

        public DataTable DataTableCommand(SqlCommand command)
        {
            DataTable dt = new DataTable();
            try
            {
                command.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                command.Connection.Close();
            }
            return dt;
        }
    }
}
