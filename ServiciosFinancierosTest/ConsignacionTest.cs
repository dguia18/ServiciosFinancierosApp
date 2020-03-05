using NUnit.Framework;
using ServiciosFinancieros;
namespace ServiciosFinancierosTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AbonoMenorACero()
        {
            string numeroDeCuenta = "1001";
            string nombreDeCuenta = "Cuenta de Ejemplo";
            string ciudad = "Valledupar";
            Banco servicios = new Banco(new CuentaDeAhorro(numeroDeCuenta, nombreDeCuenta, ciudad));

            string respuesta = servicios.Consignar(new Consignacion(-500, "Valledupar"));

            Assert.AreEqual("El valor a consignar es incorrecto", respuesta);
        }
        [Test]
        public void ConsignacionInicialCorrecta()
        {
            string numeroDeCuenta = "1001";
            string nombreDeCuenta = "Cuenta de Ejemplo";
            string ciudad = "Valledupar";
            CuentaDeAhorro cuentaDeAhorro = new CuentaDeAhorro(numeroDeCuenta, nombreDeCuenta, ciudad);
            Banco servicios = new Banco(cuentaDeAhorro);
            cuentaDeAhorro.setIsPrimeraConsignacion(true);
            string respuesta = servicios.Consignar(new Consignacion(50000, "Valledupar"));

            Assert.AreEqual($"Su Nuevo Saldo es de ${cuentaDeAhorro.getSaldo()} pesos", respuesta);
        }
        [Test]
        public void ConsignacionInicialInCorrecta()
        {
            string numeroDeCuenta = "1001";
            string nombreDeCuenta = "Cuenta de Ejemplo";
            string ciudad = "Valledupar";
            CuentaDeAhorro cuentaDeAhorro = new CuentaDeAhorro(numeroDeCuenta, nombreDeCuenta, ciudad);
            Banco servicios = new Banco(cuentaDeAhorro);
            cuentaDeAhorro.setIsPrimeraConsignacion(true);
            string respuesta = servicios.Consignar(new Consignacion(49950, "Valledupar"));

            Assert.AreEqual("El valor mínimo de la primera consignación debe ser" +
                                $"de ${50000} mil pesos. " +
                                $"Su nuevo saldo es ${cuentaDeAhorro.getSaldo()} pesos", respuesta);
        }
        [Test]
        public void ConsignacionPosteriorALaInicialCorrecta()
        {
            string numeroDeCuenta = "1001";
            string nombreDeCuenta = "Cuenta de Ejemplo";
            string ciudad = "Valledupar";
            CuentaDeAhorro cuentaDeAhorro = new CuentaDeAhorro(numeroDeCuenta, nombreDeCuenta, ciudad);
            Banco servicios = new Banco(cuentaDeAhorro);
            cuentaDeAhorro.setSaldo(30000);
            string respuesta = servicios.Consignar(new Consignacion(49950, "Valledupar"));

            Assert.AreEqual($"Su Nuevo Saldo es de ${cuentaDeAhorro.getSaldo()} pesos", respuesta);
        }
        [Test]
        public void ConsignacionPosteriorALaInicialInCorrecta()
        {
            string numeroDeCuenta = "1001";
            string nombreDeCuenta = "Cuenta de Ejemplo";
            string ciudad = "Bogota";
            CuentaDeAhorro cuentaDeAhorro = new CuentaDeAhorro(numeroDeCuenta, nombreDeCuenta, ciudad);
            Banco servicios = new Banco(cuentaDeAhorro);
            cuentaDeAhorro.setSaldo(30000);
            string respuesta = servicios.Consignar(new Consignacion(49950, "Valledupar"));

            Assert.AreEqual($"Su Nuevo Saldo es de ${cuentaDeAhorro.getSaldo()} pesos", respuesta);
        }
    }
}