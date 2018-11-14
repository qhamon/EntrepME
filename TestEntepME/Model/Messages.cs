using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestEntepME.Model
{
   public class Messages
    {
        [JsonProperty("Messages")]
        public List<Message> lstMessages { get; set; }
    }
}
