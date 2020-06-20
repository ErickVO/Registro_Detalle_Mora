using RegistroMora.BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using RegistroMora.Models;

namespace RegistroMora.BLL.Tests
{
    [TestClass()]
    public class PersonaBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Personas personas = new Personas();
            personas.Id = 0;
            personas.Nombre = "Jose";
            personas.Telefono = " 8295669999 ";
            personas.Cedula = " 0565555559 ";
            personas.Direccion = "Duarte sfm";
            personas.FechaNacimiento = DateTime.Now;
            personas.Balance = 0;
            paso = PersonaBLL.Guardar(personas);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = PersonaBLL.Eliminar(2);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Personas personas;
            personas = PersonaBLL.Buscar(2);

            Assert.AreEqual(personas, personas);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var lista = new List<Personas>();
            lista = PersonaBLL.GetList(p => true);

            Assert.AreEqual(lista, lista);
        }
    }
}