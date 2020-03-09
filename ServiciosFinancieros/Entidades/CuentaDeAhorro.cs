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
            this.transacciones = new System.Collections.Generic.List<Transaccion>();
        }

        public string Consignar(Consignacion consignacion)
        {                        
            return IsPrimeraConsignacion(consignacion);
        }

        private string IsPrimeraConsignacion(Consignacion consignacion)
        {
            string mensaje;
            if (primeraConsignacion)
            {
                mensaje = IsMontoConsignacionInicialValido(consignacion);
            }
            else
            {
                mensaje = IsMontoNoNegativo(consignacion);
            }

            return mensaje;
        }

        private string IsMontoConsignacionInicialValido(Consignacion consignacion)
        {
            string mensaje;
            if (consignacion.GetMonto() >= VALOR_CONSIGNACION_INICIAL)
            {
                this.primeraConsignacion = true;
                ValidarCiudad(consignacion);
                EjecutarConsignacion(consignacion);
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

        private string IsMontoNoNegativo(Consignacion consignacion)
        {
            string mensaje;
            if (consignacion.GetMonto() > 0)
            {
                this.ValidarCiudad(consignacion);
                EjecutarConsignacion(consignacion);
                mensaje = $"Su Nuevo Saldo es de ${this.saldo} pesos";
            }
            else
            {
                mensaje = "El valor a consignar es incorrecto";
            }

            return mensaje;
        }

        private void ValidarCiudad(Consignacion consignacion)
        {
            if (!consignacion.GetCiudad().Equals(this.ciudad))
            {
                consignacion.SetMonto(consignacion.GetMonto() - DESCUENTO_POR_SUCURSAL_EN_OTRA_CIUDAD);
            }
        }

        private void EjecutarConsignacion(Consignacion consignacion)
        {
            this.saldo += consignacion.GetMonto();
            this.transacciones.Add(consignacion);
        }        

        public void SetIsPrimeraConsignacion(bool isPrimeraConsignacion)
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
        public string QueSoy => "soy cuenta de Ahorros";
    }
}
