using System.Collections.Generic;
using System.Threading.Tasks;
using ContadSp.Data;
using ContadSp.Modelos;
using ContadSp.Repositorios;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using ContadSp.Modelos;
using ContadSp.Data;



public class Repositorio<T> : IRepositorio<T> where T : class
{
    protected readonly ContadSpContext _context;
    private readonly DbSet<T> _dbSet;

    public Repositorio(ContadSpContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> ObtenerTodo()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<IEnumerable<T>> ObtenerTodoConCategorias()
    {
        throw new NotImplementedException();
    }

    public async Task<T> Obtener(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T> Agregar(T entidad)
    {

        var result = await _dbSet.AddAsync(entidad);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<T> Actualizar(T entidad)
    {
        var result = _dbSet.Update(entidad);
        await _context.SaveChangesAsync();
        return result.Entity;
    }

    public async Task Eliminar(int id)
    {
        var result = await _dbSet.FindAsync(id);
        if (result != null)
        {
            _dbSet.Remove(result);
            await _context.SaveChangesAsync();
        }
    }
}

public class RepositorioModelo_ABM_Categoria : Repositorio<Modelo_ABM_Categoria>
{
    public RepositorioModelo_ABM_Categoria(ContadSpContext context) : base(context)
    {

    }
}

public class RepositorioModelo_Articulos : Repositorio<Modelo_Articulos>
{
    public RepositorioModelo_Articulos(ContadSpContext context) : base(context)
    {

    }

    public override async Task<IEnumerable<Modelo_Articulos>> ObtenerTodoConCategorias()
    {
        return await _context.Modelo_Articulos.Include(a => a.Categoria).ToListAsync();
    }
}
