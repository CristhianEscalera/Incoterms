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
    public class CustomerImpl : BaseImpl, ICustomer
    {
        public int Delete(Customer t)
        {
            query = @"UPDATE Customer SET status=0, dateUpdate=CURRENT_TIMESTAMP, userID=@userID
                      WHERE id = @id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@userID", 1);
            command.Parameters.AddWithValue("@id", t.idPer);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Customer Get(byte id)
        {
            Customer t = null;
            query = @"SELECT P.id, P.ci, P.firstName, P.lastName, P.secondLastName, C.nit,C.phone, C.businessName,C.degree,C.status,C.registerDate,ISNULL(C.dateUpdate,CURRENT_TIMESTAMP),C.userID
                    FROM Person P
                    INNER JOIN Customer C ON P.id= C.id
                    WHERE P.status=1 AND C.status=1 AND C.id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                DataTable dt = DataTableCommand(command);
                if (dt.Rows.Count > 0)
                {
                    t = new Customer(byte.Parse(dt.Rows[0][0].ToString()), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString(), dt.Rows[0][4].ToString(), int.Parse(dt.Rows[0][0].ToString()), dt.Rows[0][5].ToString(), dt.Rows[0][6].ToString(), dt.Rows[0][7].ToString(), dt.Rows[0][8].ToString(),byte.Parse(dt.Rows[0][9].ToString()), DateTime.Parse(dt.Rows[0][10].ToString()), DateTime.Parse(dt.Rows[0][11].ToString()),int.Parse(dt.Rows[0][12].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }

        public void Insert(Person p, Customer u)
        {
            query = @"INSERT INTO Person (ci,firstName,lastName,secondLastName,userID)
                    VALUES (@ci,@firstName,@lastName,@secondLastName,@userID)";

            string query2 = @"INSERT INTO Customer(id,nit,phone,businessName,degree,userID)
                            VALUES (@id,@nit,@phone,@businessName,@degree,@userID)";

            List<SqlCommand> cmds = Create2BasicCommand(query, query2);

            cmds[0].Parameters.AddWithValue("@ci", p.Ci);
            cmds[0].Parameters.AddWithValue("@firstName", p.Name);
            cmds[0].Parameters.AddWithValue("@lastName", p.LastName);
            cmds[0].Parameters.AddWithValue("@secondLastName", p.SecondLastName);
            cmds[0].Parameters.AddWithValue("@userID", SessionClass.SessionCont);

            int id = int.Parse(GetGenerateIDTable("Person"));
            cmds[1].Parameters.AddWithValue("@id", id);
            cmds[1].Parameters.AddWithValue("@nit", u.Nit);
            cmds[1].Parameters.AddWithValue("@phone", u.Telefono);
            cmds[1].Parameters.AddWithValue("@businessName", u.Nombre);
            cmds[1].Parameters.AddWithValue("@degree", u.Titulos);
            cmds[1].Parameters.AddWithValue("@userID", SessionClass.SessionCont);

            try
            {
                ExecuteNBasicCommand(cmds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insert(Customer t)
        {
            throw new NotImplementedException();
        }

        public DataTable Select()
        {
            query = @"SELECT P.id, P.ci AS CI, P.firstName AS Nombres, P.lastName AS 'Primer Apellido', P.secondLastName AS 'Segundo Apellido', C.nit AS 'NIT',C.degree AS Titulo , C.businessName AS 'Nombre Institucion' ,C.phone As Telefono ,P.resgisterDate AS 'Creado en:'
                    FROM Person P
                    INNER JOIN Customer C ON P.id= C.id
                    WHERE P.status=1 AND C.status=1 
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

        public int Update(Customer t)
        {
            query = @"UPDATE Person SET ci=@ci, firstName=@firstName,lastName=@lastName,secondLastName=@secondLastName,dateUpdate=CURRENT_TIMESTAMP
                    WHERE id=@id
                    UPDATE Customer SET nit =@nit , phone=@phone, businessName=@businessName, degree=@degree ,dateUpdate=CURRENT_TIMESTAMP, userID=@userID
                    WHERE id=@idPer";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@ci", t.Ci);
            command.Parameters.AddWithValue("@firstName", t.Name);
            command.Parameters.AddWithValue("@lastName", t.LastName);
            command.Parameters.AddWithValue("@secondLastName", t.SecondLastName);
            command.Parameters.AddWithValue("@nit", t.Nit);
            command.Parameters.AddWithValue("@phone", t.Telefono);
            command.Parameters.AddWithValue("@businessName", t.Nombre);
            command.Parameters.AddWithValue("@degree", t.Titulos);
            command.Parameters.AddWithValue("@id", t.Id);
            command.Parameters.AddWithValue("@idPer", t.idPer);
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
    }
}
