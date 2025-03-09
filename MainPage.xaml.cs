using System.Text;
using System.Text.Json;

namespace MauiWipeout;

public partial class MainPage : ContentPage
{
    private readonly IHttpClientFactory _httpClientFactory;

	// TODO: This needs to be wired up to a real authentication system
	const string _loginUrl = "https://localhost:5001/api/auth/login";

	public MainPage() : this(new SentryHttpClientFactory())
	{		
	}

    public MainPage(IHttpClientFactory httpClientFactory)
	{
        _httpClientFactory = httpClientFactory;
    	InitializeComponent();
	}

	private async void OnLoginButtonClicked(object sender, EventArgs e)
	{
		var loginData = new LoginRequest(UsernameEntry.Text, PasswordEntry.Text);
		var json = JsonSerializer.Serialize(loginData);

		using var client = _httpClientFactory.CreateClient();
		// TODO: We should probably use a third party for authentication
		var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Post, _loginUrl)
		{
			Content = new StringContent(json, Encoding.UTF8, "application/json")
		});
		if (response.IsSuccessStatusCode)
		{
			HandleSuccessfulLogin();
		}
		else
        {
            await DisplayAlert("Login Failed", "Invalid username or password. Please try again.", "OK");
        }
	}

    record LoginRequest(string Username, string Password);

    private void HandleSuccessfulLogin()
    {
        throw new NotImplementedException();
    }
}

