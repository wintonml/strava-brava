using System.Net;
using DotNetEnv;

class Program
{
    static void Main()
    {
        // Load values from the .env file
        Env.Load();

        string accessToken = Environment.GetEnvironmentVariable("ACCESS_TOKEN");
        string clientId = Environment.GetEnvironmentVariable("CLIENT_ID");
        string clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");
        string redirectUri = Environment.GetEnvironmentVariable("REDIRECT_URI");

        // Step 1: Redirect user to the Strava authorization URL
        string authorizationUrl = $"https://www.strava.com/oauth/authorize?client_id={clientId}&redirect_uri={WebUtility.UrlEncode(redirectUri)}&response_type=code&scope=read_all";
        Console.WriteLine($"Visit the following URL to authorize the application:\n{authorizationUrl}");

        // Step 2: Retrieve the authorization code from the user (usually via a callback URL)

        Console.Write("Enter the authorization code: ");
        string authorizationCode = Console.ReadLine();

        // Step 3: Exchange authorization code for access token
        string tokenUrl = "https://www.strava.com/oauth/token";
        string postData = $"client_id={clientId}&client_secret={clientSecret}&code={authorizationCode}&grant_type=authorization_code";

        using (WebClient client = new WebClient())
        {
            client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            string response = client.UploadString(tokenUrl, "POST", postData);
            Console.WriteLine($"Access Token Response:\n{response}");
        }

        Console.ReadLine();
    }
}
