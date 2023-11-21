namespace advance_csharp.dto.Response
{
    public class WeatherForecastResponse
    {
        public DateTime Date { get; set; }

        private int _TemperatureC;
        public int TemperatureC {
            get
            {
                return _TemperatureC;
            }
            set
            {
                this._TemperatureC = value;
                this._TemperatureF = 32 + (int)(this._TemperatureC / 0.5556);
            }
        }

        private int _TemperatureF;
        public int TemperatureF
        {
            get
            {
                return _TemperatureF;
            }
        }

        public string? Summary { get; set; }
    }
}