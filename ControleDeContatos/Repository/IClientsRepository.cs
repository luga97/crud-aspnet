using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace ControleDeContatos.Repository
{
    public interface IClientsRepository
    {
        void SaveCLient(string name,string CPF, string image);

        Task<string> GetImage(int id);
        Task<dynamic> GetClientList();
    }
}