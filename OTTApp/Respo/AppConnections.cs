namespace OTTApp.Respo
{
    public class AppConnections
    {
        public static string GetMyConnection()
        {
            string connection = "Data Source=DESKTOP-MIJAF6I;Initial Catalog=OTT; User ID=anto; Password=anto; Connect Timeout=1000;TrustServerCertificate=True";

            return connection;
        }
    }
}
