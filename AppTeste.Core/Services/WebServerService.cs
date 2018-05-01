using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using AppTeste.Core.Model;
using Xamarin.Forms;

namespace AppTeste.Core.Services
{
    public class WebServerService
    {
        public static WebServerService Initiate = new WebServerService();

        public WebServerService()
        {

        }

        /// <summary>
        /// Requests the view.
        /// </summary>
        /// <returns>The view.</returns>
        /// <param name="request">Request.</param>
        public async Task<HtmlWebViewSource> RequestView(RequestModel request, CancellationToken token)
        {
            // Simulates Timeout => See aplication Output and WebView in few seconds...
            //await Task.Delay(11000);

            return await Task.Factory.StartNew(() =>
            {
                HtmlWebViewSource html = new HtmlWebViewSource();
                html.Html = @"teste";

                try
                {
                    // Call Template
                    html.Html = @TemplateResponse(request);
                    if (token.IsCancellationRequested)
                    {
                        // Cancelation token is requested
                        throw new Exception("CancellationToken requested");
                    }
                }
                catch (Exception ex)
                {
                    CoreApp.Log2Plataform("ERROR RequestView", ex.Message);
                    html.Html = @ex.Message;
                }

                return html;
            }, token);
        }

        private string TemplateResponse(RequestModel request)
        {
            // Creates template Response
            return String.Format("<html> <body> <h1> App Teste Gustavo </h1> <p> {0} </p> <p> {1} </p>  </body> </html>"
                                 , request.GUid
                                 , DateTime.Now.ToString("D", new CultureInfo("pt-BR")));
        }
    }
}