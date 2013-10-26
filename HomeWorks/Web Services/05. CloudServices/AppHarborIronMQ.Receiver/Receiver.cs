using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using io.iron.ironmq;
using System.Configuration;
using io.iron.ironmq.Data;
using System.Threading;
using AppHarborIronMQ.Model;

namespace AppHarborIronMQ.Receiver
{
    class Receiver
    {
        static void Main(string[] args)
        {

            var projectId = ConfigurationManager.AppSettings["IRON_MQ_PROJECT_ID"];
            var token = ConfigurationManager.AppSettings["IRON_MQ_TOKEN"];
            var client = new Client(projectId, token);
            Queue queue = client.queue("simpleChat");
            Console.WriteLine("Listening for new messages from IronMQ server:");
                while (true)
                {
                    Message queueMsg = queue.get();

                    if (queueMsg != null)
                    {
                        ChatMsg msg = Newtonsoft.Json.JsonConvert.DeserializeObject<AppHarborIronMQ.Model.ChatMsg>(queueMsg.Body);
                        Console.WriteLine("New message from {0} : {1}", msg.Sender, msg.Text);
                        queue.deleteMessage(queueMsg);
                    }
                    Thread.Sleep(100);
                }
        }
    }
}
