using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using SmartSpaceFunction.Models;

namespace SmartSpaceFunction.Models
{
    public class DeviceApplication
    {

        private static string _sessionId = Guid.NewGuid().ToString("N").ToUpper();
        /// <summary>
        /// Default Constructor
        /// </summary>
        public DeviceApplication()
        {
            _deviceDateTime = DateTime.Now;
        }

        /// <summary>
        /// Will return the unique install id for the current installation of the application.
        /// This install id will occur once for the application installation.
        /// </summary>
        /// <returns></returns>

        Position _position;
        string _installId;
        DateTime _deviceDateTime;
        string _deviceType;
        string _applicationName;

        /// <summary>
        /// The unique id of the application installation
        /// </summary>
        [JsonProperty("InstallId")]
        public string InstallId { get => _installId; set => _installId = value; }
        /// <summary>
        /// The unqiue runtime session. A new session id is created each time the application is started.
        /// </summary>
        [JsonProperty("SessionId")]
        public string SessionId { get => _sessionId; }
        /// <summary>
        /// The IDevice Date and Time
        /// </summary>
        [JsonProperty("DeviceDateTime")]
        public DateTime DeviceDateTime { get => _deviceDateTime; set => _deviceDateTime = value; }
        /// <summary>
        /// The device type (Android or iOS)
        /// </summary>
        [JsonProperty("DeviceType")]
        public string DeviceType { get => _deviceType; set => _deviceType = value; }
        /// <summary>
        /// The Latitude and Longitude of the Device
        /// </summary>
        [JsonProperty("Position")]
        public Position Position { get => _position; private set => _position = value; }
        /// <summary>
        /// The Application Name
        /// </summary>
        [JsonProperty("ApplicationName")]
        public string ApplicationName { get => _applicationName; set => _applicationName = value; }

    }
}