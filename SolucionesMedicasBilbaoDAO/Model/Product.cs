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
        public int Id { get; set; }
        public string Name { get; set; }
        public double BasePrice { get; set; }
        public int Stock { get; set; }
        public string MeasureUnit { get; set; }
        public string Model { get; set; }
        public int IdBrand { get; set; }
        public int IdCategory { get; set; }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="basePrice"></param>
        /// <param name="stock"></param>
        /// <param name="measureUnit"></param>
        /// <param name="status"></param>
        /// <param name="registrationDate"></param>
        /// <param name="dateUpdate"></param>
        /// <param name="userID"></param>
        /// <param name="model"></param>
        /// <param name="idBranch"></param>
        /// <param name="idCategory"></param>

        public Product(int id, string name, double basePrice, int stock, string measureUnit,byte status, DateTime registrationDate, DateTime dateUpdate, int userID, string model, int idBrand, int idCategory)
            :base(status,registrationDate,dateUpdate,userID)
        {
            Id = id;
            Name = name;
            BasePrice = basePrice;
            Stock = stock;
            MeasureUnit = measureUnit;
            Model = model;
            IdBrand = idBrand;
            IdCategory = idCategory;
        }

        public Product(string name, double basePrice, int stock, string measureUnit,int userID, string model, int idBrand, int idCategory)
                : base(userID)
        {
            Name = name;
            BasePrice = basePrice;
            Stock = stock;
            MeasureUnit = measureUnit;
            UserID = userID;
            Model = model;
            IdBrand = idBrand;
            IdCategory = idCategory;
        }
        public Product(int id)
        {
            Id=id;
        }


        //Para el Edit
        public Product(string name, double basePrice, int stock, string measureUnit, string model, int idBrand, int idCategory)
        {
            Name = name;
            BasePrice = basePrice;
            Stock = stock;
            MeasureUnit = measureUnit;
            Model = model;
            IdBrand = idBrand;
            IdCategory = idCategory;
        }

        public Product(int id, string name, double basePrice, int stock, string measureUnit, string model, int idBrand, int idCategory)
        {
            Id = id;
            Name = name;
            BasePrice = basePrice;
            Stock = stock;
            MeasureUnit = measureUnit;
            Model = model;
            IdBrand = idBrand;
            IdCategory = idCategory;
        }
    }
}
