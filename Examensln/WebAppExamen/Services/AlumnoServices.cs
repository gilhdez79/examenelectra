using Entyties.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using WebAppExamen.Services.IServices;

namespace WebAppExamen.Services
{
    public class AlumnoServices : IAlumnosServices
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public AlumnoServices(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory=httpClientFactory;
        }
        public async Task<bool> CreateAlumnos(AlumnoDto alumno)
        {
            string json = JsonConvert.SerializeObject(alumno);   //using Newtonsoft.Json

            StringContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = _httpClientFactory.CreateClient("ApiEscuela");

            var result = await response.PostAsync("Alumnos", httpContent);

            if (result.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public Task<IEnumerable<AlumnoDto>> FindAllAlumnos()
        {
            throw new NotImplementedException();
        }

        public Task<Alumno> FindAlumnosById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAlumnos(AlumnoDto alumno)
        {
            throw new NotImplementedException();
        }
    }
}
