using HarmonyLib;
using Verse;

namespace Roos_Satyrs_and_Fauns_Expanded
{
    [StaticConstructorOnStartup]
    public static class RBSF_Satyrs_and_Fauns_Expanded
    {
        static RBSF_Satyrs_and_Fauns_Expanded()
        {
            Harmony harmony = new Harmony("rimworld.mod.rooboid.satyrandfaunexpanded");
            harmony.PatchAll();
            Log.Message("SFAUNS AND SATYRS EXPANDED MOD LOADED.");
        }
    }
}