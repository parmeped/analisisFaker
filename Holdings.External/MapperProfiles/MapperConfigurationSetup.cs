using AutoMapper;

namespace AuthenticationServer.MapperProfiles
{
    public static class MapperConfigurationSetup
    {
        /// <summary>
        /// Sets up mapper profiles and returns the mapper already configured.
        /// </summary>
        /// <returns>A configured mapper</returns>
        public static IMapper Setup()
        {
            var assembly = typeof(MapperConfigurationSetup).Assembly;
            // Automapper scans assembly for classes implementing Profile and adds them to configuration.
            var mappingConfig = new MapperConfiguration(cfg => cfg.AddMaps(assembly));
            return mappingConfig.CreateMapper();
        }
    }
}
