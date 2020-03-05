using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosFinancieros
{
    public class Cuenta
    {
        protected string numeroDeCuenta { get; set; }
        protected string nombreDeCuenta { get; set; }
        protected decimal saldo { get; set; }
        protected string ciudad { get; set; }        
        protected List<Transaccion> transaccions { get; set; }

        public Cuenta(string numeroDeCuenta, string nombreDeCuenta, string ciudad)
        {
            this.numeroDeCuenta = numeroDeCuenta;
            this.nombreDeCuenta = nombreDeCuenta;
            this.ciudad = ciudad;
        }

        protected int getNumeroTransacciones(Transaccion transaccion)
        {
            return this.transaccions.FindAll(x => x.GetType().IsInstanceOfType(transaccion)).Count;
        }
        
        public decimal getSaldo()
        {
            return this.saldo;
        }
        public void setSaldo(decimal saldo)
        {
            this.saldo = saldo;
        }
    }
}
