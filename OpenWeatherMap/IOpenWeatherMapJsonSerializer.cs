namespace OpenWeatherMap
{
    public interface IOpenWeatherMapJsonSerializer
    {
        T DeserializeObject<T>(string value);

        string SerializeObject<T>(T value);
    }
}
