using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionesMedicasBilbaoDAO.Model
{
    public class Import : BaseModel
    {
        public int id { get; set; }
        public DateTime fechaSalida { get; set; }
        public DateTime fechaTentativa { get; set; }
        public DateTime? fehcaLlegada { get; set; }
        public string incoterm { get; set; }
        public int idOrigen { get; set; }
        public int idDestino { get; set; }
        public int? idEmbarcador { get; set; }
        public int idProveedor { get; set; }

        public Import(int id, DateTime fechaSalida, DateTime fechaTentativa, DateTime? fehcaLlegada, string incoterm, int idOrigen, int idDestino, int? idEmbarcador, int idProveedor)
        {
            this.id = id;
            this.fechaSalida = fechaSalida;
            this.fechaTentativa = fechaTentativa;
            this.fehcaLlegada = fehcaLlegada;
            this.incoterm = incoterm;
            this.idOrigen = idOrigen;
            this.idDestino = idDestino;
            this.idEmbarcador = idEmbarcador;
            this.idProveedor = idProveedor;
        }

        public Import(int id, DateTime fechaSalida, DateTime fechaTentativa, DateTime? fehcaLlegada, string incoterm, int idOrigen, int idDestino, int? idEmbarcador, int idProveedor, byte status, DateTime registerDate, DateTime updateDate, int userID)
            : base(status, registerDate, updateDate, userID)
        {
            this.id = id;
            this.fechaSalida = fechaSalida;
            this.fechaTentativa = fechaTentativa;
            this.fehcaLlegada = fehcaLlegada;
            this.incoterm = incoterm;
            this.idOrigen = idOrigen;
            this.idDestino = idDestino;
            this.idEmbarcador = idEmbarcador;
            this.idProveedor = idProveedor;
        }

        public Import(DateTime fechaSalida, DateTime fechaTentativa, DateTime? fehcaLlegada, string incoterm, int idOrigen, int idDestino, int? idEmbarcador, int idProveedor)
        {
            this.fechaSalida = fechaSalida;
            this.fechaTentativa = fechaTentativa;
            this.fehcaLlegada = fehcaLlegada;
            this.incoterm = incoterm;
            this.idOrigen = idOrigen;
            this.idDestino = idDestino;
            this.idEmbarcador = idEmbarcador;
            this.idProveedor = idProveedor;
        }

        public Import(int id)
        {
            this.id = id;
        }
    }
}
