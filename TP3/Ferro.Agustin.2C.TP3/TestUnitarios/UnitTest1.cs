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

        [TestMethod]
        public void TestLeerArchivoXml()
        {
            //arrange
            Universidad uni = new Universidad();
            Universidad uni2 = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.Becado);
            Alumno a4 = new Alumno(4, "Miguel", "Hernandez", "92264456",
            EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion,
            Alumno.EEstadoCuenta.AlDia);
            Alumno a5 = new Alumno(5, "Carlos", "Gonzalez", "12236456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
            Alumno.EEstadoCuenta.AlDia);
            Alumno a6 = new Alumno(6, "Juan", "Perez", "12234656",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio,
            Alumno.EEstadoCuenta.Deudor);
            Alumno a7 = new Alumno(7, "Joaquin", "Suarez", "91122456",
            EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
            Alumno.EEstadoCuenta.AlDia);
            Alumno a8 = new Alumno(8, "Rodrigo", "Smith", "22236456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion,
            Alumno.EEstadoCuenta.AlDia);
            Profesor i1 = new Profesor(1, "Juan", "Lopez", "12224458",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            Profesor i2 = new Profesor(2, "Roberto", "Juarez", "32234456",
            EntidadesAbstractas.Persona.ENacionalidad.Argentino);

            //act
            uni += a1;
            uni += a4;
            uni += a5;
            uni += a6;
            uni += a7;
            uni += a8;
            uni += i1;
            uni += i1;
            try
            {
                uni += Universidad.EClases.Programacion;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                uni += Universidad.EClases.Laboratorio;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                uni += Universidad.EClases.Legislacion;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                uni += Universidad.EClases.SPD;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Universidad.Guardar(uni);
                Console.WriteLine("Archivo de Universidad guardado.");
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }

            try
            {
                uni2 = Universidad.Leer();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            //assert

            Assert.AreEqual(uni2.Alumnos.Count, uni.Alumnos.Count);
        }
    }
}
