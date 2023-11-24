using SolucionesMedicasBilbaoDAO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolucionesMedicasBilbaoDAO
{
    public class Product:BaseModel 
    {
        public byte Id { get; set; }
        public int IdCategory { get; set; }
        public int IdIncoterm { get; set; }
        public int IdSupplier { get; set; }
        public string Name { get; set; }
        public decimal BasePrice { get; set; }
        public int Stock { get; set; }
        public string MeasureUnit { get; set; }
        public DateTime FactoryDate { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="idCategory"></param>
        /// <param name="name"></param>
        /// <param name="basePrice"></param>
        /// <param name="stock"></param>
        /// <param name="measureUnit"></param>
        /// <param name="factoryDate"></param>
        /// <param name="status"></param>
        /// <param name="registerDate"></param>
        /// <param name="updateDate"></param>
        /// <param name="userID"></param>
        public Product(byte id, int idCategory,int idIncoterm,int idSupplier,  string name, decimal basePrice, int stock, string measureUnit, DateTime factoryDate, byte status, DateTime registerDate, DateTime updateDate, int userID)
            : base(status, registerDate, updateDate, userID)
        {
            Id = id;
            IdCategory = idCategory;
            IdIncoterm = idIncoterm;
            IdSupplier = idSupplier;
            Name = name;
            BasePrice = basePrice;
            Stock = stock;
            MeasureUnit = measureUnit;
            FactoryDate = factoryDate;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="idCategory"></param>
        /// <param name="name"></param>
        /// <param name="basePrice"></param>
        /// <param name="stock"></param>
        /// <param name="measureUnit"></param>
        /// <param name="factoryDate"></param>

        public Product(int idCategory, int idIncoterm, int idSupplier, string name, decimal basePrice, int stock, string measureUnit, DateTime factoryDate)
        {
            IdCategory = idCategory;
            IdIncoterm = idIncoterm;
            IdSupplier = idSupplier;
            Name = name;
            BasePrice = basePrice;
            Stock = stock;
            MeasureUnit = measureUnit;
            FactoryDate = factoryDate;
        }

        public Product(byte id, int idCategory, int idIncoterm, int idSupplier, string name, decimal basePrice, int stock, string measureUnit, DateTime factoryDate)
        {
            Id = id;
            IdCategory = idCategory;
            IdIncoterm = idIncoterm;
            IdSupplier = idSupplier;
            Name = name;
            BasePrice = basePrice;
            Stock = stock;
            MeasureUnit = measureUnit;
            FactoryDate = factoryDate;
        }
        public Product(byte id)
        {
            Id = id;
        }

    }
}
