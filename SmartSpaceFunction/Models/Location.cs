using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SmartSpaceFunction.Models
{
    public class Location
    {
        List<Position> _positions;
        string _name;
        string _buildingNumber;
        Address _address;
        int _capacity;
        int _numberOfFloors;
        string _buildingFunction;

        public Location() { }

        /// <summary>
        /// The Default Constructor
        /// </summary>
        /// <param name="positions">Collection of Positions used for plotting.</param>
        /// <param name="name">The name of the building</param>
        /// <param name="buildingNumber">The building number</param>
        /// <param name="address">The address object for the current building.</param>
        /// <param name="capacity">The number of people the building will hold</param>
        /// <param name="numberOfFloors">The number of floors in the building</param>
        /// <param name="buildingFunction">The function or purpose of the building.</param>
        public Location(List<Position> positions, string name, string buildingNumber, Address address, int capacity, int numberOfFloors, string buildingFunction)
        {
            _positions = positions;
            _name = name;
            _buildingNumber = buildingNumber;
            _address = address;
            _capacity = capacity;
            _numberOfFloors = numberOfFloors;
            _buildingFunction = buildingFunction;
        }



        [JsonProperty("Positions")]
        public List<Position> Positions { get => _positions; set => _positions = value; }
        [JsonProperty("Name")]
        public string Name { get => _name; set => _name = value; }
        [JsonProperty("BuildingNumber")]
        public string BuildingNumber { get => _buildingNumber; set => _buildingNumber = value; }
        [JsonProperty("Address")]
        public Address Address { get => _address; set => _address = value; }
        [JsonProperty("Capacity")]
        public int Capacity { get => _capacity; set => _capacity = value; }
        [JsonProperty("NumberOfFloors")]
        public int NumberOfFloors { get => _numberOfFloors; set => _numberOfFloors = value; }
        [JsonProperty("BuildingFunction")]
        public string BuildingFunction { get => _buildingFunction; set => _buildingFunction = value; }



    }
}
