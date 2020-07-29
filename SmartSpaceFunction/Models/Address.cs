using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Newtonsoft.Json;

namespace SmartSpaceFunction.Models
{
    public class Address
    {
        string _number;
        string _street;
        string _city;
        string _state;
        string _zip;

        public Address() { }
        /// <summary>
        /// Default Constructor
        /// </summary>
        /// <param name="number">The street number of the address</param>
        /// <param name="street">Street, exluding street nummber</param>
        /// <param name="city">City</param>
        /// <param name="state">State</param>
        /// <param name="zip">Zip</param>
        [JsonConstructor()]
        public Address(string number, string street, string city, string state, string zip)
        {
            _number = number;
            _street = street;
            _city = city;
            _state = state;
            _zip = zip;
        }

        [JsonProperty("Number")]
        public string Number { get => _number; set => _number = value; }
        [JsonProperty("Street")]
        public string Street { get => _street; set => _street = value; }
        [JsonProperty("City")]
        public string City { get => _city; set => _city = value; }
        [JsonProperty("State")]
        public string State { get => _state; set => _state = value; }
        [JsonProperty("Zip")]
        public string Zip { get => _zip; set => _zip = value; }


        /// <summary>
        /// Location Full Address
        /// </summary>
        public string FullAddress
        {
            get
            {
                return $"{Number} {Street} {City} {State} {Zip}";
            }
        }



    }
}
