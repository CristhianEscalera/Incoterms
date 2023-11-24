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
    public class UserImpl : BaseImpl, IUser
    {
        

        public int Delete(User t)
        {
            query = @"UPDATE [User] SET status=0, dateUpdate=CURRENT_TIMESTAMP, userID=@userID
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

        public User Get(int id)
        {
            User t = null;
            query = @"SELECT P.id, P.ci, P.firstName, P.lastName, P.secondLastName, U.name, U.password,U.role,U.email, U.status,U.registerDate,ISNULL(U.dateUpdate,CURRENT_TIMESTAMP),U.userID
                    FROM Person P
                    INNER JOIN [User] U ON P.id=U.id
                    WHERE P.status=1 AND U.status = 1 AND U.id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);

            try
            {
                DataTable dt = DataTableCommand(command);
                if (dt.Rows.Count > 0)
                {
                    t = new User(byte.Parse(dt.Rows[0][0].ToString()),dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString(), dt.Rows[0][4].ToString(),int.Parse(dt.Rows[0][0].ToString()), dt.Rows[0][5].ToString(), dt.Rows[0][6].ToString(), dt.Rows[0][7].ToString(), dt.Rows[0][8].ToString(), byte.Parse(dt.Rows[0][9].ToString()),DateTime.Parse(dt.Rows[0][10].ToString()),DateTime.Parse(dt.Rows[0][11].ToString()),int.Parse(dt.Rows[0][12].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }
        public User Mail()
        {
            User t = null;
            query = @"SELECT P.id, CONCAT(LOWER(SUBSTRING(P.firstName,1,1)) ,LOWER(SUBSTRING(lastname,1,5)),LOWER(SUBSTRING(P.ci,1,4))), CONCAT(LOWER(SUBSTRING(P.firstName,1,1)) ,LOWER(P.ci)), U.email
                    FROM Person P 
                    INNER JOIN [User] U ON P.id=U.id
                    WHERE U.id=(SELECT MAX(id) FROM Person)";
            SqlCommand command = CreateBasicCommand(query);
            try
            {
                DataTable dt = DataTableCommand(command);
                if (dt.Rows.Count > 0)
                {
                    t = new User(byte.Parse(dt.Rows[0][0].ToString()), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return t;
        }

        public int Insert(User t)
        {
            query = @"INSERT INTO [User] (id,name,password,role,email,userID)
                    VALUES ( (SELECT MAX(id) FROM Person),(SELECT CONCAT(LOWER(SUBSTRING(firstName,1,1)) ,LOWER(SUBSTRING(lastname,1,5)),LOWER(SUBSTRING(ci,1,4))) FROM Person WHERE id=(SELECT MAX(id) FROM Person)), HASHBYTES('MD5',(SELECT CONCAT(LOWER(SUBSTRING(firstName,1,1)) ,LOWER(ci)) FROM Person WHERE id =(SELECT MAX(id) FROM Person))),@role,@email,@userID )";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@role", t.role);
            command.Parameters.AddWithValue("@email", t.email);
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
        public DataTable Login(string userName, string password)
        {
            query = @"SELECT id, name,role, statusPass
                    FROM [User]
                    WHERE status=1 AND name=@name AND password=HASHBYTES('MD5',@password)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", userName);
            command.Parameters.AddWithValue("@password", password).SqlDbType=SqlDbType.VarChar;

            try
            {
                return DataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select()
        {
            query = @"SELECT P.id, P.ci AS CI, P.firstName AS Nombres, P.lastName AS 'Primer Apellido', P.secondLastName AS 'Segundo Apellido', U.name AS 'Nombre Usuario',U.role AS Rol , U.email AS Email ,P.resgisterDate AS 'Creado en:'
                    FROM Person P
                    INNER JOIN [User] U ON P.id=U.id
                    WHERE P.status=1 AND U.status=1 
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

        public int Update(User t)
        {
            query = @"UPDATE Person SET ci=@ci, firstName=@firstName,lastName=@lastName,secondLastName=@secondLastName,dateUpdate=CURRENT_TIMESTAMP
                    WHERE id=@id
                    UPDATE [User] SET name=@name, role=@role,email=@email ,dateUpdate=CURRENT_TIMESTAMP, userID=@userID
                    WHERE id=@idPer";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@ci", t.Ci);
            command.Parameters.AddWithValue("@firstName", t.Name);
            command.Parameters.AddWithValue("@lastName", t.LastName);
            command.Parameters.AddWithValue("@secondLastName", t.SecondLastName);
            command.Parameters.AddWithValue("@name", t.nameUser);
            command.Parameters.AddWithValue("@email", t.email);
            command.Parameters.AddWithValue("@role", t.role);
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

        public int UpdatePassword(User t)
        {
            query = @"UPDATE [User] SET password=HASHBYTES('MD5',@password), statusPass=0
				    WHERE name=@name";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", t.nameUser);
            command.Parameters.AddWithValue("@password", t.password).SqlDbType = SqlDbType.VarChar;
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable ExMail(string emailEx)
        {
            query = @"SELECT COUNT(*) FROM [User] WHERE email = @email AND status = 1";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@email", emailEx);
            try
            {
                return DataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert(Person p, User u)
        {
            query = @"INSERT INTO Person (ci,firstName,lastName,secondLastName,userID)
                    VALUES (@ci,@firstName,@lastName,@secondLastName,@userID)";

            string query2 = @"INSERT INTO [User] (id,name,password,role,email,userID)
                            VALUES ( @id,(SELECT CONCAT(LOWER(SUBSTRING(firstName,1,1)) ,LOWER(SUBSTRING(lastname,1,5)),LOWER(SUBSTRING(ci,1,4))) FROM Person WHERE id=@id), HASHBYTES('MD5',(SELECT CONCAT(LOWER(SUBSTRING(firstName,1,1)) ,LOWER(ci)) FROM Person WHERE id =@id)),@role,@email,@userID )";

            List<SqlCommand> cmds = Create2BasicCommand(query, query2);

            cmds[0].Parameters.AddWithValue("@ci", p.Ci);
            cmds[0].Parameters.AddWithValue("@firstName", p.Name);
            cmds[0].Parameters.AddWithValue("@lastName", p.LastName);
            cmds[0].Parameters.AddWithValue("@secondLastName", p.SecondLastName);
            cmds[0].Parameters.AddWithValue("@userID", 1);

            int id = int.Parse(GetGenerateIDTable("Person"));
            cmds[1].Parameters.AddWithValue("@id", id);
            cmds[1].Parameters.AddWithValue("@role", u.role);
            cmds[1].Parameters.AddWithValue("@email", u.email);
            cmds[1].Parameters.AddWithValue("@userID", 1);

            try
            {
                ExecuteNBasicCommand(cmds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Login2(string userName)
        {
            query = @"SELECT id, name,role, statusPass
                    FROM [User]
                    WHERE status=1 AND name=@name";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", userName);

            try
            {
                return DataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
