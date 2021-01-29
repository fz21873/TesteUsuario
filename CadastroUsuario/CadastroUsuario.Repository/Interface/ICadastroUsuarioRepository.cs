using CadastroUsuario.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CadastroUsuario.Repository.Interface
{
    interface ICadastroUsuarioRepository
    {

        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        Task<Usuario[]> GetAllUsuarioAsyncBy();
        Task<Usuario[]> GetAllUsuarioAsyncByNome(string nome);
        Task<Usuario[]> GetAllUsuarioAsyncByAtivo(bool ativo);
        Task<Usuario> GetUsuarioAsyncById(int idUsuario);
    }
}
