namespace MultiQuoteApi.Core.Infrastructure.Configuration
{
    public class HttpConfig
    {
        /// <summary>
        /// Gets or sets the name of the HTTP configuration.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the URL for the HTTP request.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the location of the certificate for the HTTP request.
        /// </summary>
        public string CertificateLocation { get; set; }

        /// <summary>
        /// Gets or sets the username for the HTTP request.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the password for the HTTP request.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the token for the HTTP request.
        /// </summary>
        public string Token { get; set; }
        

        /// <summary>
        /// Gets or sets the policy configuration for the HTTP request.
        /// </summary>
        public PolicyConfig Policy { get; set; }
    }
}
