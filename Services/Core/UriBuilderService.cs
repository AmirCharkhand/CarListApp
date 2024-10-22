namespace CarListApp.Services.Core
{
    public class UriBuilderService
    {
        private const string baseUri = "http://carlist.somee.com";

        public Uri BaseUri 
        {
            get => new Uri(baseUri);
        }

        public Uri CarsUri 
        {
            get => new Uri(BaseUri, "cars/");
        }

        public Uri GetAddCarUri()
        {
            return CarsUri;
        }

        public Uri GetDeleteCarUri(int carId)
        {
            return new Uri(CarsUri, carId.ToString());
        }

        public Uri GetGetCarUri(int carId)
        {
            return new Uri(CarsUri, carId.ToString());
        }

        public Uri GetGetCarsUri()
        {
            return CarsUri;
        }
    }
}
