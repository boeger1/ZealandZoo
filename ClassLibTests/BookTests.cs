using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;


namespace ClassLib.Tests
{
    [TestClass()]
    public class BookTests
    {

        public Book _movie      = new Book(1,"batman", 300);
        public Book _nullTitle  = new Book(2, null, 1000);
        public Book _emptyTitle = new Book(3,"",600);
        public Book _pricelow   = new Book(4,"The Matrix",-10);
        public Book _pricehigh  = new Book(5,"bussemand",1300);




        [TestMethod()]
        public void ToStringTest()
        {
            Assert.AreEqual("1 batman 300", _movie.ToString());
            
        }

        [TestMethod()]
        public void ValidateTitleTest()
        {

            _movie.ValidateTitle();

            Assert.ThrowsException<ArgumentNullException>(() => _nullTitle.ValidateTitle());
            Assert.ThrowsException<ArgumentException>(() => _emptyTitle.ValidateTitle());
            
        }

        [TestMethod()]
        public void ValidatePriceTest()
        {
            _movie.ValidatePrice();

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _pricelow.ValidatePrice());
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _pricehigh.ValidatePrice());

        }

        [TestMethod()]
        public void ValidateTest()
        {
            _movie.Validate();
           
        }
    }
}