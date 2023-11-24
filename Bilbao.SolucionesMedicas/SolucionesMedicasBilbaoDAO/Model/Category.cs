using SolucionesMedicasBilbaoDAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionesMedicasBilbaoDAO
{
    public class Category:BaseModel
    {
        #region Atributos
        public byte Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion

        #region Constructos
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="status"></param>
        /// <param name="registerDate"></param>
        /// <param name="updateDate"></param>
        /// <param name="userID"></param>
        public Category(byte id, string name, string description, byte status, DateTime registerDate, DateTime updateDate, int userID)
            :base(status,registerDate,updateDate,userID)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public Category(byte id,string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Category(byte id)
        {
            Id = id;
        }

        public Category(byte id, string name, string description, DateTime registerDate)
            : base(registerDate)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Category()
        {
        }



        #endregion
    }
}
