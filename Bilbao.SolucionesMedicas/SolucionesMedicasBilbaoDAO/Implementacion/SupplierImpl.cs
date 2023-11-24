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
    public class SupplierImpl : BaseImpl, ISupplier
    {
        public int Delete(Supplier t)
        {
            query = @"UPDATE Supplier SET status=0, dateUpdate=CURRENT_TIMESTAMP, userID=@userID
                    WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@userID", SessionClass.SessionCont);
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

        public Supplier Get(byte id)
        {
            Supplier t = null;
            query = @"SELECT id,nit, businessName, location, phone, url,status,registrationDate,ISNULL(dateUpdate,CURRENT_TIMESTAMP),userID
                    FROM Supplier
                    WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                DataTable dt = DataTableCommand(command);
                if (dt.Rows.Count > 0)
                {
                    t = new Supplier(byte.Parse(dt.Rows[0][0].ToString()), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString(), dt.Rows[0][4].ToString(), dt.Rows[0][5].ToString(),byte.Parse(dt.Rows[0][6].ToString()), DateTime.Parse(dt.Rows[0][7].ToString()),DateTime.Parse(dt.Rows[0][8].ToString()),int.Parse(dt.Rows[0][9].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }

        public int Insert(Supplier t)
        {
            query = @"INSERT INTO Supplier(nit,businessName,location,phone,url,userID)
                     VALUES (@nit, @businessName,@location,@phone,@url,@userID)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@nit", t.Nit);
            command.Parameters.AddWithValue("@businessName", t.Nombre);
            command.Parameters.AddWithValue("@location", t.Locacion);
            command.Parameters.AddWithValue("@phone", t.Telefono);
            command.Parameters.AddWithValue("@url", t.Url);
            command.Parameters.AddWithValue("@userID", SessionClass.SessionCont);

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
            query = @"SELECT id,nit AS NIT, businessName AS 'Nombre Local', location AS Lugar, phone AS Telefono, url AS 'Sitio Web', registrationDate AS 'Creado en'  
                      FROM Supplier
                      WHERE status=1
                      ORDER BY 3";
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

        public int Update(Supplier t)
        {
            query = @"UPDATE Supplier SET nit= @nit, businessName=@businessName,location=@location,phone=@phone,url=@url ,dateUpdate=CURRENT_TIMESTAMP, userID=@userID
                    WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@nit", t.Nit);
            command.Parameters.AddWithValue("@businessName", t.Nombre);
            command.Parameters.AddWithValue("@phone", t.Telefono);
            command.Parameters.AddWithValue("@location", t.Locacion);
            command.Parameters.AddWithValue("@url", t.Url);
            command.Parameters.AddWithValue("@userID", SessionClass.SessionCont);
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
