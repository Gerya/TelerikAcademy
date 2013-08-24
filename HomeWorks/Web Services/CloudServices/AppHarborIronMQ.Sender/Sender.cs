using io.iron.ironmq;
using io.iron.ironmq.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AppHarborIronMQ.Model;
using Newtonsoft.Json;

namespace AppHarborIronMQ.Sender
{
    class Sender
    {
        static void Main(string[] args)
        {
            var projectId = ConfigurationManager.AppSettings["IRON_MQ_PROJECT_ID"];
            var token = ConfigurationManager.AppSettings["IRON_MQ_TOKEN"];
            var client = new Client(projectId, token);
            Queue queue = client.queue("simpleChat");
            Console.WriteLine("Please enter your name");
            string name = Console.ReadLine();
            Console.WriteLine("Send messages for IronMQ server:");
            while (true)
            {
                string text = Console.ReadLine();
                ChatMsg newMsg = new ChatMsg()
                {
                    Text = text,
                    Sender = name
                };

                queue.push(JsonConvert.SerializeObject(newMsg));
                Console.WriteLine("Message sent to the IronMQ server.");
            }
        }
    }
}
