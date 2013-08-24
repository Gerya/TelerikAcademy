namespace CodeJewels.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using CodeJewels.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeJewels.Data.CodeJewelsContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CodeJewels.Data.CodeJewelsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.CodeJewels.AddOrUpdate(
            cj => cj.SourceCode,
            new CodeJewel()
            {
                AuthorEmail = "yourname@example.com",
                Category = "Scala",
                SourceCode = @"  object HelloWorld {
    def main(args: Array[String]) {
      println(""Hello, world!"")
    }
  }"
            },
            new CodeJewel()
            {
                AuthorEmail = "wildcode@hardcoders.com",
                Category = "Scala",
                SourceCode = @"/** Bigint's can be used seamlessly */
object bigint extends Application {
  def factorial(n: BigInt): BigInt =
    if (n == 0) 1 else n * factorial(n-1)

  val f50 = factorial(50); val f49 = factorial(49)
  println(""50! = "" + f50)
  println(""49! = "" + f49)
  println(""50!/49! = "" + (f50 / f49))
}"
            },
            new CodeJewel()
            {
                AuthorEmail = "scala@bigdata.com",
                Category = "Scala",
                SourceCode = @"/** Basic command line parsing. */
object Main {
  var verbose = false

  def main(args: Array[String]) {
    for (a <- args) a match {
      case ""-h"" | ""-help""    =>
        println(""Usage: scala Main [-help|-verbose]"")
      case ""-v"" | ""-verbose"" =>
        verbose = true
      case x =>
        println(""Unknown option: '"" + x + ""'"")
    }
    if (verbose)
      println(""How are you today?"")
  }
}"
            },
            new CodeJewel()
            {
                AuthorEmail = "johny@ci.mre.ura.gov",
                Category = "Scala",
                SourceCode = @"/** Print prime numbers less than 100, very inefficiently */
object primes extends Application {
  def isPrime(n: Int) = (2 until n) forall (n % _ != 0)
  for (i <- 1 to 100 if isPrime(i)) println(i)
}"
            },
            new CodeJewel()
            {
                AuthorEmail = "mad@python.com",
                Category = "Python",
                SourceCode = @"import urllib2
import urllib
import json
 
# GoogleSearch.py
url = ""http://ajax.googleapis.com/ajax/services/search/web?v=1.0&""

query = raw_input(""What do you want to search for ? >> "")
 
query = urllib.urlencode( {'q' : query } )
 
response = urllib2.urlopen (url + query ).read()
 
data = json.loads ( response )
 
results = data [ 'responseData' ] [ 'results' ]
 
for result in results:
    title = result['title']
    url = result['url']
    print ( title + '; ' + url )"
            },
            new CodeJewel()
            {
                AuthorEmail = "bro@pi.com",
                Category = "Python",
                SourceCode = @"#!/usr/bin/env python
 
# Import the modules
 
import bitlyapi
import sys
 
# Define your API information
 
API_USER = ""your_api_username""
API_KEY = ""your_api_key""
 
b = bitlyapi.BitLy(API_USER, API_KEY)
 
# Define how to use the program
 
usage = """"""Usage: python shortener.py [url]
e.g python shortener.py http://www.google.com""""""
 
if len(sys.argv) != 2:
    print usage
    sys.exit(0)
 
longurl = sys.argv[1]
 
response = b.shorten(longUrl=longurl)
 
print response['url']"
            });

            context.SaveChanges();
        }
    }
}
