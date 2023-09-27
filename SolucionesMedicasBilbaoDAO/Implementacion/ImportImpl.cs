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
            throw new NotImplementedException();
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
            query = @"SELECT I.id,I.departureDate AS 'Fecha Salida',I.tentativeArrival AS 'Fecha Tentativa',I.arrivalDate AS 'Fecha Llegada',I.incoterm AS Incoterm,CONCAT(SI.name, ' ', C.name) AS Origen, CONCAT(ST.name, ' ', C.name) AS Destino, SH.name AS Embarcador, ISNULL(S.businessName, '') AS Proveedor, I.registrationDate AS 'Creado en:' 
                    FROM Import I
                    INNER JOIN Supplier S ON S.id = I.idSupplier 
                    LEFT JOIN Shipper SH ON SH.id = I.idShipper
                    INNER JOIN StateImport SI ON SI.id = I.idOrigen
                    INNER JOIN StateImport ST ON ST.id = I.idDestiny
                    INNER JOIN Country C ON C.id = SI.idCountry
                    WHERE I.status = 1
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

        public int Update(Import t)
        {
            throw new NotImplementedException();
        }
    }
}
