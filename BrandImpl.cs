using SolucionesMedicasBilbaoDAO.Interfaces;
using SolucionesMedicasBilbaoDAO.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionesMedicasBilbaoDAO.Implementacion
{
    public class BrandImpl : BaseImpl, IBrand
    {
        public DataTable CargarCombo()
        {
            query = @"SELECT id AS ID,name AS 'Nombre Marca'
                    FROM Brand
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

        public int Delete(Brand t)
        {
            query = @"UPDATE Brand SET status=0, dateUpdate=CURRENT_TIMESTAMP, userID=@userID
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

        public Brand Get(byte id)
        {
            Brand t = null;
            query = @"SELECT id,name,status,registrationDate,ISNULL(dateUpdate,CURRENT_TIMESTAMP),userID
                      FROM Brand
                      WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable dt = DataTableCommand(command);
                if (dt.Rows.Count > 0)
                {
                    t = new Brand(byte.Parse(dt.Rows[0][0].ToString()), dt.Rows[0][1].ToString(), byte.Parse(dt.Rows[0][2].ToString()), DateTime.Parse(dt.Rows[0][3].ToString()), DateTime.Parse(dt.Rows[0][4].ToString()), int.Parse(dt.Rows[0][5].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }

        public int Insert(Brand t)
        {
            query = @"INSERT INTO Brand (name,userID)
                    VALUES (@name,@userID)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", t.Name);
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
            query = @"SELECT id,name AS Marca, registrationDate AS 'Creado en:' 
                    FROM Brand
                    WHERE status=1
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

        public int Update(Brand t)
        {
            query = @"UPDATE Brand SET name=@name, dateUpdate=CURRENT_TIMESTAMP, userID=@userID
                    WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", t.Name);
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
