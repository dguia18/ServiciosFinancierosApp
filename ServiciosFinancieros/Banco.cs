using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosFinancieros
{
    public class Banco
    {
        protected readonly IServiciosFinancieros serviciosFinancieros;

        public Banco(IServiciosFinancieros serviciosFinancieros)
        {
            this.serviciosFinancieros = serviciosFinancieros;
        }
        public string Consignar(Consignacion consignacion)
        {
            return serviciosFinancieros.Consignar(consignacion);
        }
    }
}
