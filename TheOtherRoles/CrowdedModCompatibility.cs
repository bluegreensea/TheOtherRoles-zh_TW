#if RELEASE_JL
using System;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Unity.IL2CPP;
using HarmonyLib;

namespace TheOtherRoles {
    public class CrowdedModCompatibility {
        public const string CROWDEDMOD_GUID = "xyz.crowdedmods.crowdedmod";

        public static bool Loaded {get; private set;}
        public static BasePlugin Plugin { get; private set; }
        public static Assembly Assembly { get; private set; }
        public static Type[] Types { get; private set; }

        private static Type CrowdedModPluginType;

        public static int MaxPlayers;
        public static int MaxImpostors;

        public static void Initialize() {
            Loaded = IL2CPPChainloader.Instance.Plugins.TryGetValue(CROWDEDMOD_GUID, out PluginInfo plugin);

            if (!Loaded) {
                return;
            }
            
            Plugin = plugin!.Instance as BasePlugin;
            Assembly = Plugin!.GetType().Assembly;

            Types = AccessTools.GetTypesFromAssembly(Assembly);
            
            CrowdedModPluginType = Types.First(t => t.Name == "CrowdedModPlugin");
            var MaxPlayersField = AccessTools.Field(CrowdedModPluginType, "MaxPlayers");
            MaxPlayers = (int) MaxPlayersField.GetValue(null);
            var MaxImpostorsField = AccessTools.Field(CrowdedModPluginType, "MaxImpostors");
            MaxImpostors = (int) MaxImpostorsField.GetValue(null);
        }
    }
}
#endif
