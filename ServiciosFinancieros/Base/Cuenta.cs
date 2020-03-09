using System;
using System.Collections.Generic;

namespace ServiciosFinancieros
{
    public abstract class Cuenta
    {
        protected string numeroDeCuenta { get; set; }
        protected string nombreDeCuenta { get; set; }
        protected decimal saldo { get; set; }
        protected string ciudad { get; set; }        
        protected List<Transaccion> transacciones { get; set; }

        protected Cuenta(string numeroDeCuenta, string nombreDeCuenta, string ciudad)
        {
            this.numeroDeCuenta = numeroDeCuenta;
            this.nombreDeCuenta = nombreDeCuenta;
            this.ciudad = ciudad;
        }

        protected int GetNumeroTransacciones(Transaccion transaccion)
        {
            return this.transacciones.FindAll(x => x.GetType().IsInstanceOfType(transaccion)).Count;
        }
        
        public decimal GetSaldo()
        {
            return this.saldo;
        }
        public void SetSaldo(decimal saldo)
        {
            this.saldo = saldo;
        }
        protected void RegistrarTransaccion(Transaccion transaccion)
        {
            this.transacciones.Add(transaccion);
        }
    }
}
