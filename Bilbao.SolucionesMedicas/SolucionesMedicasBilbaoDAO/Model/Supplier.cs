using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolucionesMedicasBilbaoDAO.Model;

namespace SolucionesMedicasBilbaoDAO.Model
{
    public class Supplier:BaseModel
    {
        public byte Id { get; set; }
        public string Nit { get; set; }
        public string Nombre { get; set; }
        public string Locacion { get; set; }
        public string Telefono { get; set; }
        public string Url { get; set; }


        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nit"></param>
        /// <param name="nombre"></param>
        /// <param name="locacion"></param>
        /// <param name="telefono"></param>
        /// <param name="url"></param>
        /// <param name="status"></param>
        /// <param name="registerDate"></param>
        /// <param name="updateDate"></param>
        /// <param name="userID"></param>
        public Supplier(byte id, string nit, string nombre, string locacion, string telefono, string url, byte status, DateTime registerDate, DateTime updateDate, int userID)
               : base(status, registerDate, updateDate, userID)
        {
            Id = id;
            Nit = nit;
            Nombre = nombre;
            Locacion = locacion;
            Telefono = telefono;
            Url = url;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="nit"></param>
        /// <param name="nombre"></param>
        /// <param name="locacion"></param>
        /// <param name="telefono"></param>
        /// <param name="url"></param>
        public Supplier(string nit, string nombre, string locacion, string telefono, string url)
        {
            Nit = nit;
            Nombre = nombre;
            Locacion = locacion;
            Telefono = telefono;
            Url = url;
        }

        public Supplier(byte id, string nit, string nombre, string locacion, string telefono, string url)
        {
            Id = id;
            Nit = nit;
            Nombre = nombre;
            Locacion = locacion;
            Telefono = telefono;
            Url = url;
        }

        public Supplier(byte id)
        {
            Id = id;
        }
    }
}
