using CadastroUsuario.Domain;
using CadastroUsuario.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuario.Repository.Repository
{
    public class CadastroUsuarioRepository : ICadastroUsuarioRepository
    {
        private readonly CadastroUsuarioContext _context;

        public CadastroUsuarioRepository(CadastroUsuarioContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);

        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Usuario[]> GetAllUsuarioAsyncByAtivo(bool ativo)
        {

            IQueryable<Usuario> query = _context.Usuario
                   .Where(c => c.Ativo.Equals(ativo));
            return await query.ToArrayAsync();
        }

        public async Task<Usuario[]> GetAllUsuarioAsyncByNome(string nome)
        {
            IQueryable<Usuario> query = _context.Usuario
                   .OrderBy(c => c.DataNacimento)
                   .Where(c => c.Nome.ToLower().Equals(nome.ToLower()));
            return await query.ToArrayAsync();
        }
        public async Task<Usuario> GetUsuarioAsyncById(int idUsuario)
        {
            IQueryable<Usuario> query = _context.Usuario
                .Where(u => u.IdUsuario.Equals(idUsuario)).AsNoTracking();
                    
           

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Usuario[]> GetAllUsuarioAsyncBy()
        {
            IQueryable<Usuario> query = _context.Usuario;
                    

            
            return await query.ToArrayAsync();
        }
    }
}
