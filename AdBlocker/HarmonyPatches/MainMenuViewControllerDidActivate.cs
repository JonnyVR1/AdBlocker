using HarmonyLib;
using JetBrains.Annotations;

namespace AdBlocker.HarmonyPatches
{
    [HarmonyPatch(typeof (MainMenuViewController))]
    [HarmonyPatch("DidActivate")]
    internal class MainMenuViewControllerDidActivate
    {
        [UsedImplicitly]
        internal static void Postfix(ref MusicPackPromoBanner ____musicPackPromoBanner) => ____musicPackPromoBanner.gameObject.SetActive(false);
    }
}
