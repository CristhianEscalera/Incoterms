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
    public class LocationImpl : BaseImpl, ILocation
    {
        public DataTable CargarCombo()
        {
            query = @"SELECT m.id AS ID, CONCAT(m.name,' - ', s.name) AS Lugar
                    FROM Municipality m
                    INNER JOIN [State] s ON s.id = m.idState";
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

        public DataTable CargarCombo2()
        {
            query = @"SELECT c.id AS ID, CONCAT(p.firstName,' ',p.lastName) AS Cliente
                    FROM Customer c
                    INNER JOIN Person p ON p.id = c.id
                    WHERE c.status = 1";
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

        public int Delete(Location t)
        {
            query = @"UPDATE Location SET status=0, dateUpdate=CURRENT_TIMESTAMP, userID=@userID
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

        public Location Get(byte id)
        {
            Location t = null;
            query = @"SELECT id,idCustomer,idMunicipality,mainStreet,homeNumber,longitud,latitude,status,registerDate,ISNULL(dateUpdate,CURRENT_TIMESTAMP),userID
                    FROM Location
                    WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                DataTable dt = DataTableCommand(command);
                if (dt.Rows.Count > 0)
                {
                    t = new Location(byte.Parse(dt.Rows[0][0].ToString()), int.Parse(dt.Rows[0][1].ToString()), int.Parse(dt.Rows[0][2].ToString()), dt.Rows[0][3].ToString(), int.Parse(dt.Rows[0][4].ToString()), dt.Rows[0][5].ToString(), dt.Rows[0][6].ToString(), byte.Parse(dt.Rows[0][7].ToString()), DateTime.Parse(dt.Rows[0][8].ToString()), DateTime.Parse(dt.Rows[0][9].ToString()), int.Parse(dt.Rows[0][10].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }

        public int Insert(Location t)
        {
            query = @"INSERT INTO Location(idCustomer,idMunicipality,mainStreet,homeNumber,latitude,longitud,userID)
                    VALUES (@idCustomer,@idMunicipality,@mainStreet,@homeNumber,@latitude,@longitud,@userID)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idCustomer", t.idCustomer);
            command.Parameters.AddWithValue("@idMunicipality", t.idMunicipaly);
            command.Parameters.AddWithValue("@mainStreet", t.Calle);
            command.Parameters.AddWithValue("@homeNumber", t.NumCasa);
            command.Parameters.AddWithValue("@latitude", t.Lat);
            command.Parameters.AddWithValue("@longitud", t.Longitud);
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
            query = @"SELECT l.id,CONCAT(p.firstName, ' ', p.lastName) AS Cliente, CONCAT(m.name,' - ',s.name )AS Municipio,l.mainStreet AS Direccion,l.homeNumber AS 'Numero Casa' ,l.latitude AS Latitud, l.longitud AS Longitud, l.registerDate AS 'Creado en'
                    FROM Location l
                    INNER JOIN Customer c ON c.id = l.idCustomer
                    INNER JOIN Person p ON p.id = c.id
                    INNER JOIN Municipality m ON m.id = l.idMunicipality
                    INNER JOIN [State] s ON s.id = m.idState
                    WHERE l.status = 1
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

        public int Update(Location t)
        {
            query = @"UPDATE Location SET idCustomer=@idCustomer,idMunicipality=@idMunicipality,mainStreet=@mainStreet,homeNumber=@homeNumber,longitud=@longitud,latitude=@latitude, dateUpdate=CURRENT_TIMESTAMP, userID=@userID
                    WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idCustomer", t.idCustomer);
            command.Parameters.AddWithValue("@idMunicipality", t.idMunicipaly);
            command.Parameters.AddWithValue("@mainStreet", t.Calle);
            command.Parameters.AddWithValue("@homeNumber", t.NumCasa);
            command.Parameters.AddWithValue("@longitud", t.Longitud);
            command.Parameters.AddWithValue("@latitude", t.Lat);
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
