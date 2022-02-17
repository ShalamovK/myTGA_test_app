using System;

namespace myTGA_Common.Extensions {
    public static class IServiceProviderExtensions {
        public static T GetTypedService<T>(this IServiceProvider serviceProvider) {
            return (T)serviceProvider.GetService(typeof(T));
        }
    }
}
