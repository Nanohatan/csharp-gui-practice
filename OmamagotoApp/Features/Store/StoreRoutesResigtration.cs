

namespace OmamagotoApp.Features.Store;

public static class StoreRoutesRegistration
{
    public static void RegistrationStoreRoutes()
    {
        Routing.RegisterRoute(
            StoreRoutes.Front,
            typeof(StoreFrontPage)
        );
    }
}