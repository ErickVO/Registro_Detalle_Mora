using Microsoft.VisualStudio.TestTools.UnitTesting;
using RegistroMora.BLL;
using RegistroMora.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroMora.BLL.Tests
{
    [TestClass()]
    public class MorasBLLTests
    {
       
        [TestMethod()]
        public void GuardarTest()
        {
            bool paso = false;

            Mora mora = new Mora();
            mora.MoraId = 0;
            mora.Fecha = DateTime.Now;
            mora.Total = 10;
            mora.MoraDetalle.Add(new MoraDetalle
            {
                MoraDetalleId = 0,
                MoraId = mora.MoraId,
                PrestamoId = 1,
                Monto = 10
            });

            Assert.IsTrue(MorasBLL.Guardar(mora));

        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            paso = MorasBLL.Eliminar(1);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void BuscarTest()
        {
            Mora mora;
            mora = MorasBLL.Buscar(1);
            Assert.IsNotNull(mora);
        }

        [TestMethod()]
        public void GetMorasTest()
        {
            var lista = new List<Mora>();
            lista = MorasBLL.GetList(p => true);
            Assert.IsNotNull(lista);
        }

 
    }
}