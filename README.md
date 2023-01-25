# BeProduct RESTful API using Tokens
C# libraries for BeProduct Styles using refresh tokens

# Documentation
Please visit the [https://developers.beproduct.com/](https://developers.beproduct.com/)

# Usage Example
This project is dependent on:
* RestSharp (http://restsharp.org/)
* Newtonsoft.Json (http://json.codeplex.com/)

Install RestSharp package via NuGet 

`Install-Package RestSharp`

Install Newtonsoft.Json package via NuGet 

`Install-Package Newtonsoft.Json`

Refresh tokens are a type of token used in OAuth 2.0 and other authentication protocols to obtain a new access token without requiring the user to re-enter their credentials. They are typically used in situations where a user's access token has expired, but the user is still actively using the application.

When a user first logs into an application, they are typically issued both an access token and a refresh token. The access token is used to authenticate the user's requests to the application, while the refresh token is used to obtain a new access token when the original one expires.

The process of obtaining a new access token with a refresh token is called token refresh. The client sends a request to the token endpoint of the authorization server, including the refresh token, client ID and client secret. The authorization server then verifies the refresh token and issues a new access token to the client.

Refresh tokens are typically long-lived and can be revoked by the user or the authorization server at any time. This allows for increased security and control over the issuance of new access tokens.

It is important to properly store and handle refresh tokens in the application, as well as to securely transmit them between the client and the authorization server. 

# License
The library is Copyright (c) 2017 Wink Software, LLC., and distributed under the MIT License.

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
