namespace ContadSp.Repositorios
{
    public interface IRepositorio<T> where T : class
    {
        Task<IEnumerable<T>> ObtenerTodo();
        Task<T> Obtener(int id);
        Task<T> Agregar(T entidad);
        Task<T> Actualizar(T entidad);
        Task Eliminar(int id);
        Task<List<Modelos.Modelo_Articulos>> Buscar(string buscar);
        Task<int> ObtenerUltimo();
    }

}
