using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosFinancieros
{
    public class Consignacion : Transaccion
    {
        private string ciudad;

        public Consignacion(decimal monto,string ciudad) : base(monto)
        {
            this.ciudad = ciudad;
            this.monto = monto;
            
        }

        public decimal getMonto()
        {
            return this.monto;
        }
        public void setMonto(decimal monto)
        {
            this.monto = monto;
        }
        public string getCiudad()
        {
            return this.ciudad;
        }
        public void setCiudad(string ciudad)
        {
            this.ciudad = ciudad;
        }        
    }
}
