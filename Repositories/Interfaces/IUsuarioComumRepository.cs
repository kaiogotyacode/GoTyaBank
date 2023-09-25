using CodeChallenge02.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge02.Repositories.Interfaces
{
    public interface IUsuarioComumRepository
    {
        public Task<bool> novoUsuario(UsuarioComum usuario); 
        public Task<Usuario?> buscarUsuarioCNPJ(string CNPJ);
        public Task<Usuario?> buscarUsuarioCPF(string CPF);
        public Task<bool> Transferir(string idPayer, string idPayee, decimal amount);
    }
}
