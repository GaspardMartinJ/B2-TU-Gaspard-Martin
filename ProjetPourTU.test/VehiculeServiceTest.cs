using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ProjetPourTU.Services;
using ProjetPourTU.Model;
using ProjetPourTU.Services.CustomExceptions;
using Moq;

namespace ProjetPourTU.test
{
    class VehiculeServiceTest
    {
        private VehiculeService vehiculeService;

        [SetUp]
        public void Setup()
        {
            var _mkV = new Mock<VehiculeService>();
            _mkV.Setup(s => s.getAll()).Returns(() => new List<Vehicule> { 
                new Vehicule() { ID = 1, Immatriculation = "AAA", Nom = "Peugeot 308" }, 
                new Vehicule() { ID = 2, Immatriculation = "BBB", Nom = "Toyota Aygo" },
                new Vehicule() { ID = 3, Immatriculation = "CCC", Nom = "Renault Clio" }
            });
            this.vehiculeService = _mkV.Object;
        }

        [TestCase(1, "AAA")]
        [TestCase(2, "BBB")]
        [TestCase(3, "CCC")]
        public void getByIdTest(int ID, string excpected)
        {
            Vehicule result = vehiculeService.getByID(ID);
            Assert.AreEqual(excpected, result.Immatriculation);
        }
        [Test]
        public void getByIdInvalidExceptionTest()
        {
            Assert.Throws<InvalidIDException>(() => vehiculeService.getByID(0));
        }

        [Test]
        public void getByIdNotFoundExceptionTest()
        {
            Assert.Throws<VehiculeNotFoundException>(() => vehiculeService.getByID(5));
        }
    }
}
