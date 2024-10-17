namespace CarListApp.Services.Core
{
    public class UriBuilderService
    {
        private const string baseUri = "http://carlist.somee.com";

        public string BaseUri 
        {
            get => baseUri;
        }

        public Uri AddCarUri 
        { 
            get
            {
                var address = $"{baseUri}/cars";
                return new Uri(address);
            }
        }
    }
}
