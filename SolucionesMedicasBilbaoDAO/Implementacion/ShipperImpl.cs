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
    public class ShipperImpl : BaseImpl, IShipper
    {
        public int Delete(Shipper t)
        {
            query = @"UPDATE Shipper SET status=0, dateUpdate=CURRENT_TIMESTAMP, userID=@userID
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

        public Shipper Get(int id)
        {
            Shipper t = null;
            query = @"SELECT id,name, price, location, shippingType,status,registrationDate,ISNULL(dateUpdate,CURRENT_TIMESTAMP),userID
                    FROM Shipper
                    WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                DataTable dt = DataTableCommand(command);
                if (dt.Rows.Count > 0)
                {
                    t = new Shipper(int.Parse(dt.Rows[0][0].ToString()), dt.Rows[0][1].ToString(), decimal.Parse(dt.Rows[0][2].ToString()), dt.Rows[0][3].ToString(), dt.Rows[0][4].ToString(), byte.Parse(dt.Rows[0][5].ToString()), DateTime.Parse(dt.Rows[0][6].ToString()), DateTime.Parse(dt.Rows[0][7].ToString()), int.Parse(dt.Rows[0][8].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }

        public int Insert(Shipper t)
        {
            query = @"INSERT INTO Shipper(name,price,location,shippingType,userID)
                     VALUES (@name, @price,@location,@shippingType,@userID)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", t.Nombre);
            command.Parameters.AddWithValue("@price", t.Precio);
            command.Parameters.AddWithValue("@location", t.Locacion);
            command.Parameters.AddWithValue("@shippingType", t.Tipo);
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
            query = @"SELECT id,name AS Nombre, location AS Locacion, price AS Precio, shippingType AS Tipo, registrationDate AS 'Creado en'  
                        FROM Shipper
                        WHERE status = 1
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

        public int Update(Shipper t)
        {
            query = @"UPDATE Shipper SET name= @name, price=@price,location=@location,shippingType=@shippingType,dateUpdate=CURRENT_TIMESTAMP, userID=@userID
                    WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", t.Nombre);
            command.Parameters.AddWithValue("@price", t.Precio);
            command.Parameters.AddWithValue("@location", t.Locacion);
            command.Parameters.AddWithValue("@shippingType", t.Tipo);
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
