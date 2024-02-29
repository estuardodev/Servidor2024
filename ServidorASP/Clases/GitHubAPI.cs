using System.Text.Json;
using System.Net.Http.Headers;

namespace ServidorASP.Clases
{
    public class GitHubAPI
    {
        private static string owner = "estuardodev";
        private static string repo = "Servidor2024";
        private static string token = Environment.GetEnvironmentVariable("GithubWebApi");

        public GitHubAPI(string user, string repository)
        {
            owner = user;
            repo = repository;
        }

        public string getLicense()
        {
            string url = $"https://api.github.com/repos/{owner}/{repo}/license";
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "C# App");
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string jsonResponse = response.Content.ReadAsStringAsync().Result;
                var dataResponse = JsonSerializer.Deserialize<Dictionary<string, object>>(jsonResponse);
                var licenseObject = JsonSerializer.Deserialize<Dictionary<string, object>>(dataResponse["license"].ToString());
                return licenseObject["name"].ToString();
            }
            return "No se encontró la licencia.";
        }
    }
}
