using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TestEntepME.Model;

namespace TestEntepME
{
    class Program
    {
        public static void Main()
        {
            TestPostMessage();
        }

        static void TestPostMessage()
        {
            string urlWithAccessToken = "https://hooks.slack.com/services/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";

            SlackClient client = new SlackClient(urlWithAccessToken);
            client.PostMessage(username: "UE2HQME05",
                       text: "HEllo world!!",
                       channel: "#général");
        }

        public static void TestGetChannel()
        {
            string urlGetChannel = "https://slack.com/api/channels.history?token=xoxp-477797858753-478602728005-477749554640-c0df60759e6318c8ee8f54332a22cef7&channel=CE2BU9DPU&pretty=1";
            SlackClient client = new SlackClient(urlGetChannel);


            Console.Write("--------------SUPER CHAT !--------------\r\n");
            var lstMessages = client.GetAllChannel().lstMessages;

            var newlstMessages = lstMessages.AsEnumerable().Reverse();
            foreach (var message in newlstMessages)
            {
                string user = message.Username ?? message.User;
                AfficherMEssageDansConsole(user, message.Text);
            }


            Console.Read();
        }
        public static void AfficherMEssageDansConsole(string userName, string text)
        {
            Console.Write(string.Format("{0} : {1}\r\n", userName, text));

        }
    }
}
