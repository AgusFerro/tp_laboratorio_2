using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestListaPaquetesEsteInstanciada()
        {
            //arrange
            Correo correo;
            //act
            correo = new Correo();
            //assert
            Assert.IsInstanceOfType(correo.Paquetes,(typeof(List<Paquete>)));
        }

        [TestMethod]
        [ExpectedException(typeof(TrackingIDRepetidoException))]
        public void TestVerifcarQueDosPaquetesIgualesNoSeCarguen()
        {
            //arrange
            Paquete p1 = new Paquete("asd", "123");
            Paquete p2 = new Paquete("asd", "123");
            Correo correo = new Correo();
            //act
            correo += p1;
            correo += p2;

            //assert manejado en la declaracion del metodo
        }
    }
}
