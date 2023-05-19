using ControleDeContatos.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Buffers.Text;
using System.IO;
using System.Threading.Tasks;

namespace ControleDeContatos.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IClientsRepository repository;

        public ClientsController(IClientsRepository repository) {
            this.repository = repository;
        }


        [HttpPost]
        public async Task<IActionResult> CreateClient()
        {

            try
            {
                // Recibir el formulario enviado
                var form = await Request.ReadFormAsync();

                // Obtener los valores del formulario
                var name = form["name"];
                var CPF = form["cpf"];
                var image = form["image"];

                // Validar y procesar los datos recibidos
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(image))
                {
                    return BadRequest("Name and image required");
                }
                // Guardar la imagen en una ubicación específica
                repository.SaveCLient(name, CPF, image);
            }
            catch (Exception ex) 
            {
                return BadRequest($"Error saving data, error detail: {ex.Message}");
            }



            // Realizar cualquier otra lógica de negocio necesaria

            return Ok("Formulario recibido y procesado correctamente.");
        }

        //endpoint to get all the clients
        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            try
            {
                var clients = await repository.GetClientList();
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error getting clients, error detail: {ex.Message}");
            }
        }


        //endpoint to get the image of a client
        [HttpGet("image/{id}")]
        public async Task<IActionResult> GetImage(int id)
        {
            try
            {
                var image = await repository.GetImage(id);
                var file = Convert.FromBase64String(image);
                return File(file, "image/png");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error getting image, error detail: {ex.Message}");
            }
        }
    }
}
