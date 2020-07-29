using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;

namespace SmartSpaceFunction.Models
{
    public class Position
    {
        /// <summary>
        /// Constructs the position given the two cooridinates needed.
        /// </summary>
        /// <param name="latitude">Latitude.</param>
        /// <param name="longitude">Longitude.</param>
        [JsonConstructor()]
        public Position(double latitude, double longitude)
        {
            _longitude = longitude;
            _latitude = latitude;

        }

        double _latitude;
        double _longitude;

        [JsonProperty("Latitude")]
        public double Latitude { get => _latitude; private set => _latitude = value; }
        [JsonProperty("Longitude")]
        public double Longitude { get => _longitude; private set => _longitude = value; }

    }
}
