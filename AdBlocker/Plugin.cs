using System.Reflection;
using IPA;
using HarmonyLib;
using IPA.Logging;

namespace AdBlocker
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        private const string HarmonyId = "com.BeatSaber.AdBlocker";
        private static readonly Harmony HarmonyInstance = new Harmony(HarmonyId);

        private static Plugin Instance { get; set; }

        private static Logger Log { get; set; }

        [Init]
        public void Init(Logger logger)
        {
            Instance = this;
            Log = logger;
            Log.Info("AdBlocker initialized.");
        }

        [OnEnable]
        public void OnEnable() => HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());

        [OnDisable]
        public void OnDisable() => HarmonyInstance.UnpatchSelf();
    }
}
