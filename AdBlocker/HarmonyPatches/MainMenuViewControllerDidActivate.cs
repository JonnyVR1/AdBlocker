using HarmonyLib;

namespace AdBlocker.HarmonyPatches
{
    [HarmonyPatch(typeof (MainMenuViewController))]
    [HarmonyPatch("DidActivate")]
    internal class MainMenuViewControllerDidActivate
    {
        internal static void Postfix(ref MusicPackPromoBanner ____musicPackPromoBanner) => ____musicPackPromoBanner.gameObject.SetActive(false);
    }
}
