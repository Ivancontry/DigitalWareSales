using SysVentas.Domain.Entities.Clients;

namespace SysVentas.Infrastructure.Data.initialize
{
    public static class ClientInitialize
    {
        public static void InitializeClient(ProductDataContext productDataContext) { 
        
            var clientIvan = new Client("1003195636","Ivan Contreras","3004558041","22","Mz C Casa 19 San Jeronimo","ivancontry.13@gmail.com");
            var clientDuvan = new Client("1065135735", "Duvan Guia", "31046599041", "23", "Calle 16 #24-65", "duvan@gmail.com");
            var clientHelmer = new Client("10650145781", "Helmer Fuentes", "3204817032", "25", "Diagonal 21 #56-12", "helmer@gmail.com");
            productDataContext.Clients.Add(clientIvan);
            productDataContext.Clients.Add(clientDuvan);
            productDataContext.Clients.Add(clientHelmer);
            productDataContext.SaveChanges();
        }
    }
}
