using System;
using System.Net;
using System.IO;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace ServidorWeb.Clases
{
    public class TwitchAPI
    {
        private static string ClientID;
        private static string SecretID;
        private static string? token;
        private static long expiresIn;
        

        public TwitchAPI(String _clientId, String secretId) {
            ClientID = _clientId;
            SecretID = secretId;
        }

        public void generate_token()
        {
            String url = "https://id.twitch.tv/oauth2/token";


            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new StringContent($"client_id={ClientID}&client_secret={SecretID}&grant_type=client_credentials", Encoding.UTF8, "application/x-www-form-urlencoded");
            var response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var tokenResponse = JsonSerializer.Deserialize<Dictionary<string, object>>(responseContent);
                Console.WriteLine(responseContent);
                string accessToken = tokenResponse["access_token"].ToString();
                string expiresInString = tokenResponse["expires_in"].ToString();
                token = accessToken;
                var data = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds + Convert.ToInt64(expiresInString);
                expiresIn = data;

            }
            else
            {
                Console.WriteLine("Failed to get access token. Status code: " + response.StatusCode);
            }
        }

        public bool token_valid()
        {
            double currentTime = (DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
            return currentTime < expiresIn;
        }

        public String live(String user) {
            if (!token_valid())
            {
                generate_token();
            }

            String url = $"https://api.twitch.tv/helix/streams?user_login={user}";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Client-ID", ClientID);
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");
           
            var response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response);
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var tokenResponse = JsonSerializer.Deserialize<Dictionary<string, object>>(responseContent);
                if (tokenResponse.ContainsKey("data") && tokenResponse["data"] is JsonElement data && data.GetArrayLength() > 0)
                {
                    return data.ToString();
                }
                else
                {
                    return "{'message': 'none'}";
                }
            }
            else
            {
                Console.WriteLine(response);
                return "{'message': 'none'}";
            }
        }

        public int followers(String broadcaster_id) {
            
            if (!token_valid())
            {
                Console.WriteLine("Token no valido");
                Console.WriteLine("Valor de expiresIn en live: " + expiresIn);
                generate_token();
            }

            String url = $"https://api.twitch.tv/helix/channels/followers?broadcaster_id={broadcaster_id}";

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Client-ID", ClientID);
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            var response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content.ReadAsStringAsync().Result;
                var jsonContent = JsonSerializer.Deserialize<Dictionary<string, object>>(responseContent);
                return Convert.ToInt32(jsonContent["total"].ToString());
            }
            else
            {
                Console.WriteLine(response);
            }
            return 0;
        }
    }
}
