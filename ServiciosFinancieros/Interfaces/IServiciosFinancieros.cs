namespace ServiciosFinancieros
{
    public interface IServiciosFinancieros
    {
        string Consignar(Consignacion consignacion);
        string Retirar(Retiro retiro);
        string TrasladarDinero(Transferencia transferencia);
    }
}
