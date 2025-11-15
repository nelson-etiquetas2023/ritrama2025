using Microsoft.Extensions.DependencyInjection;

namespace Ritrama2025.Services.ServiceLocator
{
    public static class ServiceLocator
    {
        private static IServiceProvider? Services;

        public static void Init(IServiceProvider services)
        {
            Services = services ?? throw new ArgumentNullException(nameof(services), "Service provider cannot be null.");
        }


        public static T Get<T>() where T : class
        {
            if (Services == null)
            {
                throw new InvalidOperationException("ServiceLocator is not initialized. Call Init() with a valid IServiceProvider.");
            }

            return Services.GetRequiredService<T>();
        }
    }
}
