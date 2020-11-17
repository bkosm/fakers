using System;

namespace TERYTws1
{
    class Test
    {
        static void Main()
        {
            TerytWs1Client client = new TerytWs1Client();

            // Use the 'client' variable to call operations on the service.

            // Always close the client.
            client.Close();
        }
    }
}
