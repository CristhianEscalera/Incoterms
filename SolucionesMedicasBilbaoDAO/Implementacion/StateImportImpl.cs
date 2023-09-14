using SolucionesMedicasBilbaoDAO.Interfaces;
using SolucionesMedicasBilbaoDAO.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionesMedicasBilbaoDAO.Implementacion
{
    public class StateImportImpl : BaseImpl, IStateImport
    {
        public DataTable CargarCombo()
        {
            query = @"SELECT id AS ID,name AS 'País'
                    FROM Country
                    WHERE status = 1";
            SqlCommand command = CreateBasicCommand(query);
            try
            {
                return DataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Delete(StateImport t)
        {
            query = @"UPDATE StateImport SET status=0, dateUpdate=CURRENT_TIMESTAMP, userID=@userID
                    WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@userID", 1);
            command.Parameters.AddWithValue("@id", t.Id);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public StateImport Get(int id)
        {
            StateImport t = null;
            query = @"SELECT id,name,idCountry,status,registrationDate,ISNULL(dateUpdate,CURRENT_TIMESTAMP),userID
                    FROM StateImport
                    WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                DataTable dt = DataTableCommand(command);
                if (dt.Rows.Count > 0)
                {
                    t = new StateImport(int.Parse(dt.Rows[0][0].ToString()), dt.Rows[0][1].ToString(), byte.Parse(dt.Rows[0][2].ToString()), byte.Parse(dt.Rows[0][3].ToString()), DateTime.Parse(dt.Rows[0][4].ToString()), DateTime.Parse(dt.Rows[0][5].ToString()), int.Parse(dt.Rows[0][6].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }

        public int Insert(StateImport t)
        {
            query = @"INSERT INTO StateImport(name,idCountry,userID)
                    VALUES (@name,@idCountry, @userID)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@idCountry", t.IdCountry);
            command.Parameters.AddWithValue("@userID", 1);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select()
        {
            query = @"SELECT SI.id,SI.name AS Estado, C.name AS 'País',SI.registrationDate AS 'Creado en:'
                    FROM StateImport SI
                    INNER JOIN Country C ON C.id = SI.idCountry
					WHERE SI.status = 1
                    ORDER BY 2";
            SqlCommand command = CreateBasicCommand(query);
            try
            {
                return DataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(StateImport t)
        {
            query = @"UPDATE StateImport SET name=@name,idCountry=@idCountry, dateUpdate=CURRENT_TIMESTAMP, userID=@userID
                    WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@idCountry", t.IdCountry);
            command.Parameters.AddWithValue("@userID", 1);
            command.Parameters.AddWithValue("@id", t.Id);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
