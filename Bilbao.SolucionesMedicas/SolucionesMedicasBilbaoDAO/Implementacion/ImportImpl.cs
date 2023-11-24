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
    public class ImportImpl : BaseImpl, IImport
    {
        public DataTable CargarCombo()
        {
            query = @"SELECT ST.id AS ID,CONCAT(ST.name,' - ', C.name) AS Origen
                    FROM StateImport ST
                    INNER JOIN Country C  ON C.id= ST.idCountry
                    WHERE ST.status = 1";
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
            query = @"SELECT ST.id AS ID,CONCAT(ST.name,' - ', C.name) AS Destino
                    FROM StateImport ST
                    INNER JOIN Country C  ON C.id= ST.idCountry
                    WHERE ST.status = 1";
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

        public DataTable CargarCombo3()
        {
            query = @"SELECT id AS ID, businessName AS Proveedor
                    FROM Supplier
                    WHERE status = 1 ";
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

        public DataTable CargarCombo4()
        {
            query = @"SELECT id AS ID, name AS Embarcador
                    FROM Shipper
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

        public int Delete(Import t)
        {
            query = @"UPDATE Import SET status=0, dateUpdate=CURRENT_TIMESTAMP, userID=@userID
                    WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@userID", SessionClass.SessionCont);
            command.Parameters.AddWithValue("@id", t.id);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Import Get(int id)
        {
            Import t = null;
            query = @"SELECT id,departureDate,tentativeArrival,arrivalDate,incoterm,idOrigen,idDestiny,idShipper,idSupplier ,registrationDate,ISNULL(dateUpdate,CURRENT_TIMESTAMP),userID
                    FROM Import
                    WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                DataTable dt = DataTableCommand(command);
                DateTime? arrivalDate = null;
                if (!string.IsNullOrEmpty(dt.Rows[0][3].ToString()))
                {
                    DateTime tempDate;
                    if (DateTime.TryParse(dt.Rows[0][3].ToString(), out tempDate))
                    {
                        arrivalDate = tempDate;
                    }
                }

                int? idEmbarcador = null;
                if (!string.IsNullOrEmpty(dt.Rows[0][7].ToString()))
                {
                    int tempId;
                    if (int.TryParse(dt.Rows[0][7].ToString(), out tempId))
                    {
                        idEmbarcador = tempId;
                    }
                }

                if (dt.Rows.Count > 0)
                {
                    t = new Import(int.Parse(dt.Rows[0][0].ToString()),DateTime.Parse(dt.Rows[0][1].ToString()), DateTime.Parse(dt.Rows[0][2].ToString()), arrivalDate, dt.Rows[0][4].ToString(), int.Parse(dt.Rows[0][5].ToString()), int.Parse(dt.Rows[0][6].ToString()), idEmbarcador, int.Parse(dt.Rows[0][8].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }

        public int Insert(Import t)
        {
            query = @"INSERT INTO Import(departureDate,tentativeArrival,arrivalDate,incoterm,idOrigen,idDestiny,idSupplier,idShipper,userID)
                    VALUES (@departureDate,@tentativeArrival,@arrivalDate,@incoterm,@idOrigen,@idDestiny,@idSupplier,@idShipper,@userID)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@departureDate", t.fechaSalida);
            command.Parameters.AddWithValue("@tentativeArrival", t.fechaTentativa);
            if (t.fehcaLlegada.HasValue)
            {
                command.Parameters.AddWithValue("@arrivalDate", t.fehcaLlegada);
            }
            else
            {
                command.Parameters.AddWithValue("@arrivalDate", DBNull.Value);
            }
            command.Parameters.AddWithValue("@incoterm", t.incoterm);
            command.Parameters.AddWithValue("@idOrigen", t.idOrigen);
            command.Parameters.AddWithValue("@idDestiny", t.idDestino);
            command.Parameters.AddWithValue("@idSupplier", t.idProveedor);
            if (t.idEmbarcador.HasValue)
            {
                command.Parameters.AddWithValue("@idShipper", t.idEmbarcador.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@idShipper", DBNull.Value);
            }
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
            query = @" SELECT I.id, CONVERT(DATE, I.departureDate) AS 'FechaSalida', CONVERT(DATE, I.tentativeArrival) AS 'FechaTentativa', CONVERT(DATE, I.arrivalDate) AS 'FechaLlegada', 
                        I.incoterm AS Incoterms, CONCAT(SI.name, ' ', C1.name) AS Origen, CONCAT(ST.name, ' ', C2.name) AS Destino, 
                        SH.name AS Embarcador, 
                        ISNULL(S.businessName, '') AS Proveedor, 
                        I.registrationDate AS 'Creado en:' 
                    FROM 
                        Import I
                    INNER JOIN 
                        Supplier S ON S.id = I.idSupplier 
                    LEFT JOIN 
                        Shipper SH ON SH.id = I.idShipper
                    INNER JOIN 
                        Country C1 ON C1.id = (SELECT idCountry FROM StateImport WHERE id = I.idOrigen)
                    INNER JOIN 
                        Country C2 ON C2.id = (SELECT idCountry FROM StateImport WHERE id = I.idDestiny)
                    INNER JOIN 
                        StateImport SI ON SI.id = I.idOrigen
                    INNER JOIN 
                        StateImport ST ON ST.id = I.idDestiny
                    WHERE 
                        I.status = 1
                    ORDER BY 
                        2;";
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

        public int Update(Import t)
        {
            query = @"UPDATE Import SET departureDate= @departureDate, tentativeArrival=@tentativeArrival ,arrivalDate=@arrivalDate,incoterm=@incoterm,idOrigen=@idOrigen,idDestiny=@idDestiny,idShipper=@idShipper,idSupplier=@idSupplier,dateUpdate=CURRENT_TIMESTAMP, userID=@userID
                    WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@departureDate", t.fechaSalida);
            command.Parameters.AddWithValue("@tentativeArrival", t.fechaTentativa);
            if (t.fehcaLlegada.HasValue)
            {
                command.Parameters.AddWithValue("@arrivalDate", t.fehcaLlegada);
            }
            else
            {
                command.Parameters.AddWithValue("@arrivalDate", DBNull.Value);
            }
            command.Parameters.AddWithValue("@incoterm", t.incoterm);
            command.Parameters.AddWithValue("@idOrigen", t.idOrigen);
            command.Parameters.AddWithValue("@idDestiny", t.idDestino);
            command.Parameters.AddWithValue("@idSupplier", t.idProveedor);
            if (t.idEmbarcador.HasValue)
            {
                command.Parameters.AddWithValue("@idShipper", t.idEmbarcador.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@idShipper", DBNull.Value);
            }
            command.Parameters.AddWithValue("@userID", SessionClass.SessionCont);
            command.Parameters.AddWithValue("@id", t.id);
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
