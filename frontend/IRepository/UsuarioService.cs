using frontend.Dto;
using frontend.Model;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace frontend.IRepository
{
    public class UsuarioService : IUsuario
    {
        public async Task<Usuario> Login(string email, string senha)
        {
            try
            {
                var client = new HttpClient();
                string url = $"http://localhost:5220/api/Usuario/Login?email={Uri.EscapeDataString(email)}&senha={Uri.EscapeDataString(senha)}";
                HttpResponseMessage response = await client.PostAsync(url, null);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Resposta da API: {content}"); // Log da resposta

                    Usuario usuario = JsonConvert.DeserializeObject<Usuario>(content);
                    return usuario;
                }
                else
                {
                    Console.WriteLine($"Erro na resposta da API: {response.StatusCode} - {response.ReasonPhrase}"); // Log de erro
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exceção ao chamar a API: {ex.Message}"); // Log de exceção
            }

            return null;
        }
    }
}
