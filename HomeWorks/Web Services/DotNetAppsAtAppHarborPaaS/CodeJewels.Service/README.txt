http://localhost:8826/api/codejewels -- Listing all Code Jewels
http://localhost:8826/api/codejewels?sourceCode={term} -- Searching for some code.
http://localhost:8826/api/codejewels?sourceCode={term}&category={name} -- Same as above but including category name.
http://localhost:8826/api/codejewels/upvote/{codejewelId} -- Upvoting some jewel.
http://localhost:8826/api/codejewels/downvote/{codejewelId} -- Obviously the opposite of the above description.
http://localhost:8826/api/codejewels/create -- Uploading new jewel

Code jewels with negative rating are automatically deleted.

Here is the URL for the Code Jewels project:
http://codejewels-9.apphb.com/


Brief introduction of the hooks in case you don't know a thing about them.

Basically, at the end of the deployment process (there might be some other
unknown processes to me) AppHarbor sends HTTP POST request with JSON payload
as body. The so called payload contains some information about the deployment.

Please read the info located in the Mailer controller.

Enjoy!