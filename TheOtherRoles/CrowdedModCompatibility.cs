#if RELEASE_JL
using BepInEx;
using BepInEx.Unity.IL2CPP;

namespace TheOtherRoles {
    public class CrowdedModCompatibility {
        public const string CROWDEDMOD_GUID = "xyz.crowdedmods.crowdedmod";

        public static bool Loaded {get; private set;}

        public static void Initialize() {
            Loaded = IL2CPPChainloader.Instance.Plugins.TryGetValue(CROWDEDMOD_GUID, out PluginInfo plugin);
        }
    }
}
#endif
