using System;


namespace ServiciosFinancieros
{
    public class CuentaDeAhorro : Cuenta, IServiciosFinancieros
    {
        private bool primeraConsignacion = false;
        const decimal VALOR_CONSIGNACION_INICIAL = 50000;
        const decimal DESCUENTO_POR_SUCURSAL_EN_OTRA_CIUDAD = 10000;

        public CuentaDeAhorro(string numeroDeCuenta, string nombreDeCuenta, string ciudad) : base(numeroDeCuenta, nombreDeCuenta, ciudad)
        {
            this.ciudad = ciudad;
            this.nombreDeCuenta = nombreDeCuenta;
            this.numeroDeCuenta = numeroDeCuenta;
            this.transaccions = new System.Collections.Generic.List<Transaccion>();
        }

        public string Consignar(Consignacion consignacion)
        {                        
            return isPrimeraConsignacion(consignacion);
        }

        private string isPrimeraConsignacion(Consignacion consignacion)
        {
            string mensaje;
            if (primeraConsignacion)
            {
                mensaje = isMontoConsignacionInicialValido(consignacion);
            }
            else
            {
                mensaje = isMontoNoNegativo(consignacion);
            }

            return mensaje;
        }

        private string isMontoConsignacionInicialValido(Consignacion consignacion)
        {
            string mensaje;
            if (consignacion.getMonto() >= VALOR_CONSIGNACION_INICIAL)
            {
                this.primeraConsignacion = true;
                validarCiudad(consignacion);
                ejecutarConsignacion(consignacion);
                mensaje = $"Su Nuevo Saldo es de ${this.saldo} pesos";
            }
            else
            {
                mensaje = "El valor mínimo de la primera consignación debe ser" +
                            $"de ${VALOR_CONSIGNACION_INICIAL} mil pesos. " +
                            $"Su nuevo saldo es ${this.saldo} pesos";
            }

            return mensaje;
        }

        private string isMontoNoNegativo(Consignacion consignacion)
        {
            string mensaje;
            if (consignacion.getMonto() > 0)
            {
                this.validarCiudad(consignacion);
                ejecutarConsignacion(consignacion);
                mensaje = $"Su Nuevo Saldo es de ${this.saldo} pesos";
            }
            else
            {
                mensaje = "El valor a consignar es incorrecto";
            }

            return mensaje;
        }

        private void validarCiudad(Consignacion consignacion)
        {
            if (!consignacion.getCiudad().Equals(this.ciudad))
            {
                consignacion.setMonto(consignacion.getMonto() - DESCUENTO_POR_SUCURSAL_EN_OTRA_CIUDAD);
            }
        }

        private void ejecutarConsignacion(Consignacion consignacion)
        {
            this.saldo += consignacion.getMonto();
            this.transaccions.Add(consignacion);
        }        

        public void setIsPrimeraConsignacion(bool isPrimeraConsignacion)
        {
            this.primeraConsignacion = isPrimeraConsignacion;
        }
        public string Retirar(Retiro retiro)
        {
            throw new NotImplementedException();
        }

        public string TrasladarDinero(Transferencia transferencia)
        {
            throw new NotImplementedException();
        }
        public string QueSoy()
        {
            return "soy cuenta de Ahorros";
        }
    }
}
