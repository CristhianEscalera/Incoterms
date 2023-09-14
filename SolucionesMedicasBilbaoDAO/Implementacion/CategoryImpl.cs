using SolucionesMedicasBilbaoDAO.Implementacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionesMedicasBilbaoDAO
{
    public class CategoryImpl : BaseImpl, ICategory
    {
        public DataTable CargarCombo()
        {
            query = @"SELECT id AS ID,name AS 'Nombre Categoria'
                    FROM Category
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

        public int Delete(Category t)
        {
            query = @"UPDATE Category SET status=0, dateUpdate=CURRENT_TIMESTAMP, userID=@userID
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

        public Category Get(byte id)
        {
            Category t = null;
            query = @"SELECT id,name,description,status,registrationDate,ISNULL(dateUpdate,CURRENT_TIMESTAMP),userID
                      FROM Category
                      WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                DataTable dt = DataTableCommand(command);
                if (dt.Rows.Count > 0)
                {
                    t = new Category(byte.Parse(dt.Rows[0][0].ToString()), dt.Rows[0][1].ToString(),dt.Rows[0][2].ToString(), byte.Parse(dt.Rows[0][3].ToString()),DateTime.Parse(dt.Rows[0][4].ToString()),DateTime.Parse(dt.Rows[0][5].ToString()), int.Parse(dt.Rows[0][6].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }

        public int Insert(Category t)
        {
            query = @"INSERT INTO Category (name, description,userID)
                    VALUES (@name,@description,@userID)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name",t.Name);
            command.Parameters.AddWithValue("@description", t.Description);
            command.Parameters.AddWithValue("@userID", 1);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select()
        {
            query = @"SELECT id,name AS Categoria, description AS Descripcion, registrationDate AS 'Creado en:' 
                    FROM Category
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

        public int Update(Category t)
        {
            query = @"UPDATE Category SET name=@name, description=@description, dateUpdate=CURRENT_TIMESTAMP, userID=@userID
                    WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@description", t.Description);
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
