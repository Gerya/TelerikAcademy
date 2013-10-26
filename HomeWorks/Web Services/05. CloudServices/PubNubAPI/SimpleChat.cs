using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PubNubAPI
{
    public class SimpleChat
    {

        static void Main()
        {
            // Start the HTML5 Pubnub client
            Process.Start("..\\..\\PubNub-HTML5-Client.html");

            System.Threading.Thread.Sleep(2000);

            PubnubAPI pubnub = new PubnubAPI(
                "pub-c-96036ed5-b848-4f13-96ed-116460e341f2",               // PUBLISH_KEY
                "sub-c-3cb2c784-0670-11e3-a3d6-02ee2ddab7fe",               // SUBSCRIBE_KEY
                "sec-c-MWE3N2U3ZjgtYmI5OC00MGRmLTkwNGMtYjRkMjk4NTkyMTg5",   // SECRET_KEY
                true                                                        // SSL_ON?
            );
            string channel = "simple-chat";

            // Subscribe for receiving messages (in a background task to avoid blocking)
            System.Threading.Tasks.Task t = new System.Threading.Tasks.Task(
                () =>
                pubnub.Subscribe(
                    channel,
                    delegate(object message)
                    {
                        Console.WriteLine("Received Message -> '" + message + "'");
                        return true;
                    }
                )
            );
            t.Start();

            // Read messages from the console and publish them to Pubnub
            while (true)
            {
                Console.Write("Enter a message to be sent to Pubnub: ");
                string msg = Console.ReadLine();
                pubnub.Publish(channel, msg);
                Console.WriteLine("Message sent.");
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
