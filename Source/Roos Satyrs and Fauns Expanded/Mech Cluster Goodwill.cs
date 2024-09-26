using HarmonyLib;
using RimWorld;
using Verse;

namespace Roos_Satyrs_and_Fauns_Expanded
{

    [HarmonyPatch(typeof(LordJob_MechanoidDefendBase))]
    [HarmonyPatch("OnDefeat")]
    static class LordJob_MechanoidDefendBase_OnDefeat_Patch
    {
        static void Postfix()
        {
            //List<Faction> allFaeFactions = null;
            foreach (Faction faction in Find.FactionManager.GetFactions())
            {
                if (faction?.def == RBSF_DefOf.RBSFE_TribeFae && !faction.defeated)
                {
                    //allFaeFactions.AddItem(faction);
                    int GoodwillGain = 10;
                    Faction.OfPlayer.TryAffectGoodwillWith(faction, GoodwillGain);
                    Faction.OfPlayer.Notify_GoodwillSituationsChanged(faction, true, null, null);
                    Log.Message("Goodwill situation changed with " + faction.Name + "due to a mechanoid cluster being destroyed.");
                }
            }
        }
    }
}


