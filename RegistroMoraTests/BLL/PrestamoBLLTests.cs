using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroMora.BLL;
using RegistroMora.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroMora.BLL.Tests
{
    [TestClass()]
    public class PrestamoBLLTests
    {
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;
            Prestamos prestamos = new Prestamos();

            prestamos.PrestamoId = 0;
            prestamos.Fecha = DateTime.Now;
            prestamos.PersonaId = 1;
            prestamos.Concepto = "Compra de TV";
            prestamos.Monto = 2000;
            prestamos.Balance = 0;

            paso = PrestamoBLL.Guardar(prestamos);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso = false;

            paso = PrestamoBLL.Eliminar(1);

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Prestamos prestamos = new Prestamos();
            bool paso = false;

            prestamos = PrestamoBLL.Buscar(1);

            if (prestamos != null)
                paso = true;

            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            var Lista = new List<Prestamos>();
            Lista = PrestamoBLL.GetList(p => true);

            Assert.AreEqual(Lista, Lista);
        }

       
    }
}