namespace ContadSP.Repositorios
{
    public interface IRepositorio<T> where T : class
    {
        // Metodos generales
        Task<IEnumerable<T>> ObtenerTodo();
        Task<T> ObtenerPorId(int id);
        Task<T> Agregar(T entidad);
        Task<T> Actualizar(T entidad);
        Task<T> Eliminar(int id);
        // Fin metodos generales

        // Metodos especificos
        Task<List<Models.Articulo>> Buscar(string buscar);
        Task<IEnumerable<Models.Pedido>> ObetnerPedidos();
        Task<Models.Pedido> ObetnerPedidoPorId(int id);
        Task<int> ObtenerUltimaProvision();
        Task<Models.Provision> ObtenerProvisionPorId(int id);
        Task<IEnumerable<Models.DetallePedido>> ObtenerDetallePedidoPorId(int id);
        Task<IEnumerable<Models.Provision>> ObtenerProvisiones();
        Task<Models.Provision> CambiarEstado(int id);
        Task<IEnumerable<Models.Articulo>> ObtenerArticulos();
        Task<int> ObtenerUltimoProcesoNumero(int id);
        Task<int> ObtenerUltimoProcesoPedidoId();
        Task<int> ObtenerUltimoPedido();
        // Fin metodos especificos
    }
}
