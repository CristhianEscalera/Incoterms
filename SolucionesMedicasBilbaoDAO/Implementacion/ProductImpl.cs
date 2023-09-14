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
    public class ProductImpl : BaseImpl, IProduct
    {
        public DataTable CargarCombo()
        {
            query = @"SELECT I.id AS ID,CONCAT(I.name, ' - ', I.destination) AS Incoterms
                    FROM Incoterms I 
                    WHERE I.status = 1";
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
            query = @"SELECT id AS ID, businessName AS Proveedor
                    FROM Supplier
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

        
        public int Delete(Product t)
        {
            query = @"UPDATE Product SET status=0, dateUpdate=CURRENT_TIMESTAMP, userID=@userID
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

        public Product Get(byte id)
        {
            Product t = null;
            query = @"SELECT id,idCategory,idIncoterm,idSupplier,name,basePrice,stock,measureUnit,factoryDate,status,registrationDate,ISNULL(dateUpdate,CURRENT_TIMESTAMP),userID
                    FROM Product
                    WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                DataTable dt = DataTableCommand(command);
                if (dt.Rows.Count > 0)
                {
                    t = new Product(byte.Parse(dt.Rows[0][0].ToString()),int.Parse(dt.Rows[0][1].ToString()), int.Parse(dt.Rows[0][2].ToString()), int.Parse(dt.Rows[0][3].ToString()), dt.Rows[0][4].ToString(), decimal.Parse(dt.Rows[0][5].ToString()),int.Parse(dt.Rows[0][6].ToString()),dt.Rows[0][7].ToString(), DateTime.Parse(dt.Rows[0][8].ToString()),byte.Parse(dt.Rows[0][9].ToString()),DateTime.Parse(dt.Rows[0][10].ToString()),DateTime.Parse(dt.Rows[0][11].ToString()),int.Parse(dt.Rows[0][12].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }

        public int Insert(Product t)
        {
            query = @"INSERT INTO Product(idCategory,idIncoterm,idSupplier,name,basePrice,stock,measureUnit,factoryDate,userID)
                    VALUES (@idCategory,@idIncoterm,@idSupplier,@name,@basePrice , @stock , @measureUnit, @factoryDate, @userID)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idCategory", t.IdCategory);
            command.Parameters.AddWithValue("@idIncoterm", t.IdIncoterm);
            command.Parameters.AddWithValue("@idSupplier", t.IdSupplier);
            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@basePrice", t.BasePrice);
            command.Parameters.AddWithValue("@stock", t.Stock);
            command.Parameters.AddWithValue("@measureUnit", t.MeasureUnit);
            command.Parameters.AddWithValue("@factoryDate", t.FactoryDate);
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
            query = @"SELECT P.id,P.name AS Producto, C.name AS Categoria ,CONCAT(I.name, ' - ', I.destination) AS Incoterms,S.businessName AS Proveedor ,P.basePrice AS 'Precio Base',P.stock AS Stock ,ISNULL(P.measureUnit,'') AS 'Unidad Medida',P.factoryDate AS 'Fecha de fabrica',P.registrationDate AS 'Creado en'
                    FROM Product P
                    INNER JOIN Category C ON C.id = P.idCategory
					INNER JOIN Incoterms I ON I.id = P.idIncoterm
					INNER JOIN Supplier S ON S.id = P.idSupplier
					WHERE P.status = 1
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

        public int Update(Product t)
        {
            query = @"UPDATE Product SET idCategory=@idCategory,idIncoterm=@idIncoterm,idSupplier=@idSupplier,name=@name,basePrice=@basePrice,stock=@stock,measureUnit=@measureUnit,factoryDate=@factoryDate, dateUpdate=CURRENT_TIMESTAMP, userID=@userID
                    WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@idCategory", t.IdCategory);
            command.Parameters.AddWithValue("@idIncoterm", t.IdIncoterm);
            command.Parameters.AddWithValue("@idSupplier", t.IdSupplier);
            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@basePrice", t.BasePrice);
            command.Parameters.AddWithValue("@stock", t.Stock);
            command.Parameters.AddWithValue("@measureUnit", t.MeasureUnit);
            command.Parameters.AddWithValue("@factoryDate", t.FactoryDate);
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
