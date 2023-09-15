using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionesMedicasBilbaoDAO.Model
{
    public class Location:BaseModel
    {
        public byte Id { get; set; }
        public int idCustomer { get; set; }
        public int idMunicipaly { get; set; }
        public string Calle { get; set; }
        public int NumCasa { get; set; }
        public string Longitud { get; set; }
        public string Lat { get; set; }


        public Location(byte id, int idCustomer, int idMunicipaly, string calle, int numCasa, string longitud, string lat, byte status, DateTime registerDate, DateTime updateDate, int userID)
            : base(status, registerDate, updateDate, userID)
        {
            this.Id = id;
            this.idCustomer = idCustomer;
            this.idMunicipaly = idMunicipaly;
            this.Calle = calle;
            this.NumCasa = numCasa;
            this.Longitud = longitud;
            this.Lat = lat;
        }

        public Location(byte id, int idCustomer, int idMunicipaly, string calle, int numCasa, string longitud, string lat)
        {
            this.Id = id;
            this.idCustomer = idCustomer;
            this.idMunicipaly = idMunicipaly;
            this.Calle = calle;
            this.NumCasa = numCasa;
            this.Longitud = longitud;
            this.Lat = lat;
        }

        public Location( int idCustomer, int idMunicipaly, string calle, int numCasa, string longitud, string lat)
        {
            this.idCustomer = idCustomer;
            this.idMunicipaly = idMunicipaly;
            this.Calle = calle;
            this.NumCasa = numCasa;
            this.Longitud = longitud;
            this.Lat = lat;
        }

        public Location(byte id)
        {
            this.Id = id;
        }
    }
}
