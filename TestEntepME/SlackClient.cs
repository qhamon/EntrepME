using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestEntepME.Model;

namespace TestEntepME
{
    public class SlackClient
    {
        private readonly Uri _uri;
        private readonly Encoding _encoding = new UTF8Encoding();

        public SlackClient(string urlWithAccessToken)
        {
            _uri = new Uri(urlWithAccessToken);
        }

        /// <summary>
        /// Récuperer tous les channel
        /// </summary>
        /// <returns></returns>
        public Messages GetAllChannel()
        {
            using (WebClient client = new WebClient())
            {
                NameValueCollection dadta = new NameValueCollection();
                //Retourne les données dans un format de Type Messages
                var reponse = _encoding.GetString(client.UploadValues(_uri, "POST", dadta));
                return JsonConvert.DeserializeObject<Messages>(reponse);
            }
        }

        /// <summary>
        /// Post un message avec des parametres 
        /// </summary>
        /// <param name="text">Message a afficher dans le chanel</param>
        /// <param name="username">Nom de l'utilisateur</param>
        /// <param name="channel">Channel que l'on veut diffuser</param>
        public void PostMessage(string text, string username = null, string channel = null)
        {
            Payload payload = new Payload()
            {
                Channel = channel,
                Username = username,
                Text = text
            };

            PostMessage(payload);
        }

        /// <summary>
        /// Post un message dans le chat 
        /// </summary>
        /// <param name="payload">Objet contenant les informations a afficher dans le chat</param>
        /// <returns>Retourne si le message est bien envoyer</returns>
        public bool PostMessage(Payload payload)
        {
            try
            {
                string payloadJson = JsonConvert.SerializeObject(payload);

                using (WebClient client = new WebClient())
                {
                    NameValueCollection data = new NameValueCollection();
                    data["payload"] = payloadJson;

                    var response = client.UploadValues(_uri, "POST", data);

                    //The response text is usually "ok"  
                    return _encoding.GetString(response).Contains("ok");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
