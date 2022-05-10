using System.Reflection;
using IPA;
using HarmonyLib;
using IPA.Logging;
using JetBrains.Annotations;

namespace AdBlocker
{
    [Plugin(RuntimeOptions.DynamicInit)]
    public class Plugin
    {
        private const string HarmonyId = "com.BeatSaber.AdBlocker";
        private static readonly Harmony HarmonyInstance = new(HarmonyId);

        private static Plugin Instance { get; set; }

        private static Logger Log { get; set; }

        [UsedImplicitly]
        [Init]
        public void Init(Logger logger)
        {
            Instance = this;
            Log = logger;
            Log.Info("AdBlocker initialized.");
        }

        [UsedImplicitly]
        [OnEnable]
        public void OnEnable() => HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());

        [UsedImplicitly]
        [OnDisable]
        public void OnDisable() => HarmonyInstance.UnpatchSelf();
    }
}
