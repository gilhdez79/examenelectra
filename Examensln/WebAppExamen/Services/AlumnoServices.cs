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

            var apiClient = _httpClientFactory.CreateClient("ApiEscuela");

            var result = await apiClient.PostAsJsonAsync("Alumnos", alumno);

            string responseBody = await result.Content.ReadAsStringAsync();
            //result = JsonConvert.DeserializeObject<RequestResult<T>>(responseBody);
           // var rsl = await result.Content.<bool>();

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
