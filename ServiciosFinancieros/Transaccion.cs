using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosFinancieros
{
    public class Transaccion
    {
        protected decimal monto { get; set; }
        protected DateTime fecha { get; set; }

        public Transaccion(decimal monto)
        {
            this.monto = monto;
            this.fecha = DateTime.Now;
        }
    }
}
