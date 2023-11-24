using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SolucionesMedicasBilbaoDAO.Model
{
    public class Customer:Person
    {

        public int idPer { get; set; }
        public string Nit { get; set; }
        public string Telefono { get; set; }
        public string Nombre { get; set; }
        public string Titulos { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ci"></param>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="secondLastName"></param>
        /// <param name="idPer"></param>
        /// <param name="nit"></param>
        /// <param name="telefono"></param>
        /// <param name="nombre"></param>
        /// <param name="titulos"></param>
        /// <param name="status"></param>
        /// <param name="registerDate"></param>
        /// <param name="updateDate"></param>
        /// <param name="userID"></param>
        public Customer(int id, string ci, string name, string lastName, string secondLastName, int idPer, string nit, string telefono, string nombre, string titulos, byte status, DateTime registerDate, DateTime updateDate, int userID)
            : base(id, ci, name, lastName, secondLastName, status, registerDate, updateDate, userID)
        {
            this.idPer = idPer;
            this.Nit = nit;
            this.Telefono = telefono;
            this.Nombre = nombre;
            this.Titulos = titulos;
        }

        public Customer( string nit, string telefono, string nombre, string titulos)
        {
            this.Nit = nit;
            this.Telefono = telefono;
            this.Nombre = nombre;
            this.Titulos = titulos;
        }

        public Customer(int idPer, string nit, string telefono, string nombre, string titulos)
        {
            this.idPer = idPer;
            this.Nit = nit;
            this.Telefono = telefono;
            this.Nombre = nombre;
            this.Titulos = titulos;
        }

        public Customer(int id, string ci, string name, string lastName, string secondLastName, int idPer, string nit, string telefono, string nombre, string titulos)
            : base(id, ci, name, lastName, secondLastName)
        {
            this.Id = id;
            this.Ci = ci;
            this.Name = name;
            this.LastName = lastName;
            this.SecondLastName = secondLastName;
            this.idPer = idPer;
            this.Nit = nit;
            this.Telefono = telefono;
            this.Nombre = nombre;
            this.Titulos = titulos;
        }

        public Customer(int idPer)
        {
            this.idPer = idPer;
        }
    }
}
