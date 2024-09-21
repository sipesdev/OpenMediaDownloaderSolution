using System.IO;

using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace OpenMediaDownloader.Config
{
    /**
    * <summary>
    * Used to setup and load application configurations
    * </summary>
    */
    public class Configuration
    {
        public string DefaultPreset { get; private set; }
        
        public Array Presets { get; private set; }
        
        public int ConfigVersion { get; private set; }

        // public void Configuration(string path)
        // {
        //     var deserializer = new DeserializerBuilder().WithNamingConvention(UnderscoredNamingConvention.Instance).Build();

        //     dynamic configFile = deserializer.Deserialize<Configuration>(File.ReadAllText(path));

        //     DefaultPreset = configFile.DefaultPreset;
        //     Presets = configFile.Presets;
        //     ConfigVersion = configFile.Version;
        // }
    }
}