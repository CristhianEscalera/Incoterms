using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionesMedicasBilbaoDAO.Model
{
    public class User:Person    
    {

        public int idPer { get; set; }
        public string nameUser { get; set; }
        public string password { get; set; }
        public string role { get; set; }
        public string email { get; set; }

        /// <summary>
        /// /
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ci"></param>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="secondLastName"></param>
        /// <param name="idPer"></param>
        /// <param name="nameUser"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        /// <param name="status"></param>
        /// <param name="registerDate"></param>
        /// <param name="updateDate"></param>
        /// <param name="userID"></param>
        public User(int id,string ci, string name, string lastName, string secondLastName, int idPer,string nameUser, string password, string role, string email, byte status, DateTime registerDate, DateTime updateDate, int userID) 
            : base(id, ci, name, lastName, secondLastName, status, registerDate, updateDate, userID)
        {
            this.idPer = idPer;
            this.nameUser = nameUser;
            this.password = password;
            this.role = role;
            this.email = email;
        }

        public User(string role, string email, byte status)
            : base(status)
        {
            this.role = role;
            this.email = email;
        }

        public User(string nameUser,string password)
        {
            this.nameUser = nameUser;
            this.password = password;
        }

        public User(int idPer, string nameUser, string password, string email)
        {
            this.idPer = idPer;
            this.nameUser = nameUser;
            this.password = password;
            this.email = email;
        }

        public User(int idPer)
        {
            this.idPer = idPer;
        }

        public User(string email)
        {
            this.email = email;
        }


        public User(int id, string ci, string name, string lastName, string secondLastName, int idPer, string nameUser,  string role, string email)
            : base(id, ci, name, lastName, secondLastName)
        {
            this.Id = id;
            this.Ci = ci;
            this.Name = name;
            this.LastName = lastName;
            this.SecondLastName = secondLastName;
            this.idPer = idPer;
            this.nameUser = nameUser;
            this.password = password;
            this.role = role;
            this.email = email;
        }
    }
}
