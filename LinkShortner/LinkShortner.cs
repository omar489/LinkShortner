namespace LinkShortner
{
    internal class LinkShortner
    {
        static async Task Main(string[] args)
        {
            string url = "https://www.youtube.com/watch?v=77jIzgvCIYY";

            var shortenedUrl = await ShortenAsync(url);


            Console.WriteLine($"Shortened Url: {shortenedUrl}");
        }
        public static async Task<string> ShortenAsync(string url)
        {

            string apiUrl = "https://is.gd/create.php";

            string shortenedUrl = null;

            string requestUrl = $"{apiUrl}?format=simple&url={Uri.EscapeDataString(url)}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(requestUrl);

                    response.EnsureSuccessStatusCode();

                    shortenedUrl = await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request error: {e.Message}");
                }
            }
            return shortenedUrl;
        }
    }
}
