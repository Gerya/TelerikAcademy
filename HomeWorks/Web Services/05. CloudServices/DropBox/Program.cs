using Spring.IO;
using Spring.Social.Dropbox.Api;
using Spring.Social.Dropbox.Connect;
using Spring.Social.OAuth1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DropBox
{
    class Program
    {
        private const string DropboxAppKey = "81v0x7xbk9jfpwu";
        private const string DropboxAppSecret = "cfp7miu9vn38nel";
        private const string OAuthTokenFileName = "OAuthTokenFileName.txt";

        static void Main()
        {
            DropboxServiceProvider dropboxServiceProvider =
                new DropboxServiceProvider(DropboxAppKey, DropboxAppSecret, AccessLevel.AppFolder);

            if (!File.Exists(OAuthTokenFileName))
            {
                AuthorizeAppOAuth(dropboxServiceProvider);
            }
            OAuthToken oauthAccessToken = LoadOAuthToken();

            IDropbox dropbox = dropboxServiceProvider.GetApi(oauthAccessToken.Value, oauthAccessToken.Secret);

            
            Entry createFolderEntry = new Entry();
            string newFolderName = string.Empty;

            while (true)
            {
                try
                {
                    Console.WriteLine("Please enter name of photo album folder");
                    newFolderName = Console.ReadLine();
                    createFolderEntry = dropbox.CreateFolderAsync(newFolderName).Result;
                    Console.WriteLine("Created folder: {0}", createFolderEntry.Path);
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("This folder already exists; " + ex.InnerException.Message);
                }
            }

            Console.WriteLine("Eneter number of files to upload");
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Enter file path");
                string filePath = Console.ReadLine();
                Entry uploadFileEntry = dropbox.UploadFileAsync(
                    new FileResource(filePath), "/" + newFolderName + "/" + Path.GetFileName(filePath).Trim()).Result;
                Console.WriteLine("Uploaded a file: {0}", uploadFileEntry.Path);

            }

            DropboxLink sharedUrl = dropbox.GetShareableLinkAsync(createFolderEntry.Path).Result;
            Console.WriteLine(sharedUrl.Url);
            Process.Start(sharedUrl.Url);
        }

        private static OAuthToken LoadOAuthToken()
        {
            string[] lines = File.ReadAllLines(OAuthTokenFileName);
            OAuthToken oauthAccessToken = new OAuthToken(lines[0], lines[1]);
            return oauthAccessToken;
        }

        private static void AuthorizeAppOAuth(DropboxServiceProvider dropboxServiceProvider)
        {
            // Authorization without callback url
            Console.Write("Getting request token...");
            OAuthToken oauthToken = dropboxServiceProvider.OAuthOperations.FetchRequestTokenAsync(null, null).Result;
            Console.WriteLine("Done.");

            OAuth1Parameters parameters = new OAuth1Parameters();
            string authenticateUrl = dropboxServiceProvider.OAuthOperations.BuildAuthorizeUrl(
                oauthToken.Value, parameters);
            Console.WriteLine("Redirect the user for authorization to {0}", authenticateUrl);
            Process.Start(authenticateUrl);
            Console.Write("Press [Enter] when authorization attempt has succeeded.");
            Console.ReadLine();

            Console.Write("Getting access token...");
            AuthorizedRequestToken requestToken = new AuthorizedRequestToken(oauthToken, null);
            OAuthToken oauthAccessToken =
                dropboxServiceProvider.OAuthOperations.ExchangeForAccessTokenAsync(requestToken, null).Result;
            Console.WriteLine("Done.");

            string[] oauthData = new string[] { oauthAccessToken.Value, oauthAccessToken.Secret };
            File.WriteAllLines(OAuthTokenFileName, oauthData);
        }
    }
}
