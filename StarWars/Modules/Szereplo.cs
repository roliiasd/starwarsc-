using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StarWars.Modules
{
    internal class Szereplo
    {
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("species")]
        public string Species { get; set; }
    }
}
