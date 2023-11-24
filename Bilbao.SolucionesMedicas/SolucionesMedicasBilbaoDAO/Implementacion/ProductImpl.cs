using SolucionesMedicasBilbaoDAO.Implementacion;
using SolucionesMedicasBilbaoDAO.Model;
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
            query = @"SELECT id AS ID,name AS 'Name'
                      FROM Brand
                      WHERE status = 1;";
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
            query = @"  SELECT id AS 'ID' , name AS  'Name'
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

        public Product Get(int id)
        {
            Product t = null;
            query = @"SELECT id,name,basePrice,stock,measureUnit,status,registrationDate,ISNULL(dateUpdate,CURRENT_TIMESTAMP),userID,model,idBrand,idCategory
                    FROM Product
                    WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                DataTable dt = DataTableCommand(command);
                if (dt.Rows.Count > 0)
                {
                    t = new Product(int.Parse(dt.Rows[0][0].ToString()), dt.Rows[0][1].ToString(), double.Parse(dt.Rows[0][2].ToString()),
                        int.Parse(dt.Rows[0][3].ToString()), dt.Rows[0][4].ToString(), byte.Parse(dt.Rows[0][5].ToString()), DateTime.Parse(dt.Rows[0][6].ToString()), DateTime.Parse(dt.Rows[0][7].ToString()),
                        int.Parse(dt.Rows[0][8].ToString()), dt.Rows[0][9].ToString(), int.Parse(dt.Rows[0][10].ToString()), int.Parse(dt.Rows[0][11].ToString()));
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
            query = @"INSERT INTO Product(name,basePrice,stock,measureUnit,idBrand,idCategory,model,userID)
                        VALUES(@name,@basePrice,@stock,@measureUnit,@idBrand,@idCategory,@model,@userID)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@basePrice", t.BasePrice);
            command.Parameters.AddWithValue("@stock", t.Stock);
            command.Parameters.AddWithValue("@measureUnit", t.MeasureUnit);
            command.Parameters.AddWithValue("@idBrand", t.IdBrand);
            command.Parameters.AddWithValue("@idCategory", t.IdCategory);
            command.Parameters.AddWithValue("@model", t.Model);
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
            query = @"  SELECT p.id AS ID,p.name AS Nombre,p.basePrice AS 'Precio Base',p.stock AS 'Stock',ISNULL(p.measureUnit,'')AS 'Unidad de medida',p.model AS 'Modelo', c.name AS 'Categoria', b.name AS 'Marca' , p.registrationDate AS 'Creado en:'
                    FROM Product P
                    INNER JOIN Category C ON C.id = P.idCategory
                    INNER JOIN Brand B ON B.id = P.idBrand
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
            query = @"UPDATE Product SET name=@name,basePrice=@basePrice,stock=@stock,measureUnit=@measureUnit,idBrand=@idBrand,idCategory=@idCategory,model=@model, dateUpdate=CURRENT_TIMESTAMP, userID=@userID
                    WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", t.Name);
            command.Parameters.AddWithValue("@basePrice", t.BasePrice);
            command.Parameters.AddWithValue("@stock", t.Stock);
            command.Parameters.AddWithValue("@measureUnit", t.MeasureUnit);
            command.Parameters.AddWithValue("@idBrand", t.IdBrand);
            command.Parameters.AddWithValue("@idCategory", t.IdCategory);
            command.Parameters.AddWithValue("@model", t.Model);
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
