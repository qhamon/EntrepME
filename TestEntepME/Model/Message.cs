using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEntepME.Model
{
    /// <summary>
    /// Classe définissant un message pour sclack
    /// </summary>
    public class Message
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("user")]
        public string User { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
