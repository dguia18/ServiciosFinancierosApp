

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

        public decimal GetMonto()
        {
            return this.monto;
        }
        public void SetMonto(decimal monto)
        {
            this.monto = monto;
        }
        public string GetCiudad()
        {
            return this.ciudad;
        }
        public void SetCiudad(string ciudad)
        {
            this.ciudad = ciudad;
        }        
    }
}
