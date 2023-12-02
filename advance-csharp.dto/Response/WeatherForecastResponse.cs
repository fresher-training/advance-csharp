namespace advance_csharp.dto.Response
{
    public class WeatherForecastResponse
    {
        public DateTime Date { get; set; }

        private int _TemperatureC;
        public int TemperatureC
        {
            get => _TemperatureC;
            set
            {
                _TemperatureC = value;
                TemperatureF = 32 + (int)(_TemperatureC / 0.5556);
            }
        }

        public int TemperatureF { get; private set; }

        public string? Summary { get; set; }
    }
}