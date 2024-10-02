using RimWorld;
using Verse;

namespace Roos_Satyrs_and_Fauns_Expanded
{
    public class RBSF_Building_LeafTrap : Building_TrapDamager
    {

        protected override void SpringSub(Pawn p)
        {
            base.SpringSub(p);
            p.stances.stunner.StunFor(560, this);
            p.health.AddHediff(RBSF_DefOf.RBSF_LeafTrapHeDiff);
            MakePitfallThoughtBubble(p);
        }

        MoteBubble MakePitfallThoughtBubble(Pawn pawn)
        {
            if (Current.ProgramState != ProgramState.Playing)
            {
                return null;
            }
            if (!pawn.Spawned)
            {
                return null;
            }
            MoteBubble moteBubble = (MoteBubble)ThingMaker.MakeThing(ThingDefOf.Mote_ThoughtBad);
            moteBubble.SetupMoteBubble(RBSF_DefOf.RBSFE_Trapped.Icon, null, null);
            moteBubble.Attach(pawn);
            GenSpawn.Spawn(moteBubble, pawn.Position, pawn.Map, WipeMode.Vanish);
            return moteBubble;
        }
    }
}
