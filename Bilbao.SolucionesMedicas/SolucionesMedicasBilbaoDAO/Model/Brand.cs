using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionesMedicasBilbaoDAO.Model
{
    public class Brand:BaseModel
    {
        #region Atributos
        public byte Id { get; set; }
        public string Name { get; set; }
        #endregion

        #region Constructos
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="status"></param>
        /// <param name="registerDate"></param>
        /// <param name="updateDate"></param>
        /// <param name="userID"></param>
        public Brand(byte id, string name, byte status, DateTime registerDate, DateTime updateDate, int userID)
            : base(status, registerDate, updateDate, userID)
        {
            Id = id;
            Name = name;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public Brand(string name)
        {
            Name = name;
        }

        public Brand(byte id, string name)
        {
            Id = id;
            Name = name;
        }

        public Brand(byte id)
        {
            Id = id;
        }

        public Brand(byte id, string name, DateTime registerDate)
            : base(registerDate)
        {
            Id = id;
            Name = name;
        }

        public Brand()
        {
        }
        #endregion
    }
}
