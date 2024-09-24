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
        }
    }
}
