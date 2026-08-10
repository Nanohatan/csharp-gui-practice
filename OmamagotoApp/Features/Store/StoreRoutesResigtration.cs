namespace OmamagotoApp.Features.Store;

public static class StoreRoutesRegistration
{
    /// <summary>
    /// Registers the store navigation routes.
    /// </summary>
    public static void RegistrationStoreRoutes()
    {
        Routing.RegisterRoute(
            StoreRoutes.Front,
            typeof(StoreFrontPage)
        );
    }
}