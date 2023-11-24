using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionesMedicasBilbaoDAO.Model
{
    public class BaseModel
    {
        public byte Status { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int UserID { get; set; }

        public BaseModel()
        {

        }
        public BaseModel(byte status, DateTime registerDate, DateTime updateDate, int userID)
        {
            Status = status;
            RegisterDate = registerDate;
            UpdateDate = updateDate;
            UserID = userID;
        }

        public BaseModel(int userID)
        {
            UserID = userID;
        }
        public BaseModel(DateTime registerDate)
        {
            RegisterDate = registerDate;
        }
    }
}
