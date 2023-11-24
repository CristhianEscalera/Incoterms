using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionesMedicasBilbaoDAO.Model
{
    public class StateImport:BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte IdCountry { get; set; }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="idCountry"></param>
        /// <param name="status"></param>
        /// <param name="registerDate"></param>
        /// <param name="updateDate"></param>
        /// <param name="userID"></param>
        public StateImport(int id, string name, byte idCountry, byte status, DateTime registerDate, DateTime updateDate, int userID)
            : base(status, registerDate, updateDate, userID)
        {
            Id = id;
            Name = name;
            IdCountry = idCountry;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="name"></param>
        /// <param name="idCountry"></param>
        public StateImport(string name, byte idCountry)
        {
            Name = name;
            IdCountry = idCountry;
        }

        public StateImport(int id, string name, byte idCountry)
        {
            Id = id;
            Name = name;
            IdCountry = idCountry;
        }
        public StateImport(int id)
        {
            Id = id;
        }
    }
}
