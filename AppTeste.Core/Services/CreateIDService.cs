using System;
using System.Threading;
using System.Threading.Tasks;

namespace AppTeste.Core.Services
{
    public class CreateIDService
    {
        public static CreateIDService Initiate = new CreateIDService();

        public CreateIDService()
        {
        }

        /// <summary>
        /// Creates the GUID.
        /// </summary>
        /// <returns>The GUID.</returns>
        /// <param name="cancelToken">Cancel token - For Api requests</param>
        public async Task<Guid> CreateGuid(CancellationToken cancelToken)
        {
            Guid id;

            try
            {
                await Task.Delay(5000); // wait 5 seconds
                id = Guid.NewGuid();
            }
            catch (Exception ex)
            {
                CoreApp.Log2Plataform("ERROR CreateGuid", ex.Message);
            }

            return id; 
        }
    }
}
