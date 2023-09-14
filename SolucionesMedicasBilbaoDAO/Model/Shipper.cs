using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionesMedicasBilbaoDAO.Model
{
    public class Shipper:BaseModel
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string Locacion { get; set; }
        public string Tipo { get; set; }



        public Shipper(int id, string nombre, decimal precio, string locacion, string tipo, byte status, DateTime registerDate, DateTime updateDate, int userID)
            : base(status, registerDate, updateDate, userID)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Locacion = locacion;
            Tipo = tipo;
        }

        public Shipper(int id, string nombre, decimal precio, string locacion, string tipo)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Locacion = locacion;
            Tipo = tipo;
        }

        public Shipper(string nombre, decimal precio, string locacion, string tipo)
        {
            Nombre = nombre;
            Precio = precio;
            Locacion = locacion;
            Tipo = tipo;
        }

        public Shipper(int id)
        {
            Id = id;
        }
    }
}
