namespace ShopNow.Api.Registers
{
    public static partial class RegisterController
    {
        public static IServiceCollection RegisterControllers(this IServiceCollection services)
        {
            services.AddControllers();
            return services;
        }
    }
}