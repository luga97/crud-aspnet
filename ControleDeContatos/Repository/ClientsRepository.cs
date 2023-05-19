using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using System.Threading.Tasks;
using BrandsCrud.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq;
namespace ControleDeContatos.Repository
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly CrudContext crudContext;

        public ClientsRepository(CrudContext crudContext)
        {
            this.crudContext = crudContext;
        }

        public async Task<string> GetImage(int id)
        {
            var client = await crudContext.Clients.FindAsync(id);
            return client.ImageBase64;
        }

        public async Task<dynamic> GetClientList()
        {
            var clients = await crudContext
                .Clients
                .Select(x => new { 
                    x.Id, 
                    x.Name,
                    x.CPF,
                    ImageUrl = $"/api/clients/image/{x.Id}"
                })
                .ToListAsync();
            return clients;
        }

        public void SaveCLient(string name, string CPF, string image)
        {

            var result = crudContext.Database.ExecuteSqlRaw(
                "EXEC SaveClient @Name, @ImageBase64,@CPF",
                new SqlParameter("@Name", name),
                new SqlParameter("@ImageBase64", image),
                new SqlParameter("@CPF", CPF)
            );

            if (result <= 0)
            {
                throw new Exception("Error saving client in db.");
            }
            //crudContext.Clients.Add(new Models.ClientModel { ImageBase64 = base64String,Name = name });
            //await crudContext.SaveChangesAsync();
        }

    }
}
