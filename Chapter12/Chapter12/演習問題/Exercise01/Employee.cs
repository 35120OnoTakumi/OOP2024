using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
namespace Exercise01 {
    public class Employee {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime HireDate { get; set; }
    }
}