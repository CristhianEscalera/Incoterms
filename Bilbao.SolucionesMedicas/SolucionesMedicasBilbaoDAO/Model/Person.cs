using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionesMedicasBilbaoDAO.Model
{
    public class Person:BaseModel
    {

        public int Id { get; set; }
        public string Ci { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }

        public Person()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ci"></param>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="secondLastName"></param>
        /// <param name="status"></param>
        /// <param name="registerDate"></param>
        /// <param name="updateDate"></param>
        /// <param name="userID"></param>
        public Person(int id, string ci, string name, string lastName, string secondLastName, byte status, DateTime registerDate, DateTime updateDate, int userID)
        : base(status, registerDate, updateDate, userID)
        {
            Id = id;
            Ci = ci;
            Name = name;
            LastName = lastName;
            SecondLastName = secondLastName;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ci"></param>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <param name="secondLastName"></param>
        public Person(string ci, string name, string lastName, string secondLastName)
        {
            Ci = ci;
            Name = name;
            LastName = lastName;
            SecondLastName = secondLastName;
        }

        public Person(int id, string ci, string name, string lastName, string secondLastName)
        {
            Id = id;
            Ci = ci;
            Name = name;
            LastName = lastName;
            SecondLastName = secondLastName;
        }

        public Person(int id)
        {
            Id = id;
        }
    }
}
