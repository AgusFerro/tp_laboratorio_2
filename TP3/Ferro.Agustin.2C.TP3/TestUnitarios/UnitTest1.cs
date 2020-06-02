using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Archivos;
using EntidadesAbstractas;
using ClasesInstanciables;
using System.Collections.Generic;

namespace TestUnitarios
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestConstructorAlumno()
        {
            //arrange
             Alumno a2;

            //act
            a2 = new Alumno(2, "Juana", "Martinez", "12234458",
            EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
            Alumno.EEstadoCuenta.Deudor);

            //assert manejado en la declaracion del metodo
        }

        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestMetodoAgregarAlumnoRepetidoAUniversidad()
        {
            //arrange
            Universidad uni = new Universidad();

            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);

            Alumno a3 = new Alumno(3, "José", "Gutierrez", "12234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
            //act   
            uni += a1;
            uni += a3;

            //assert manejado en la declaracion del metodo
        }

        [TestMethod]
        public void TestProbarQueUnaColeccionSeHayaInstanciado()
        {
            //arrange
            Universidad uni;

            //act   
            uni = new Universidad();

            //assert
            Assert.IsInstanceOfType(uni.Alumnos, typeof(List<Alumno>));
        }
    }
}
