using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace NeighborhoodWatch.Localization
{
    public static class NeighborhoodWatchLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(NeighborhoodWatchConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(NeighborhoodWatchLocalizationConfigurer).GetAssembly(),
                        "NeighborhoodWatch.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
