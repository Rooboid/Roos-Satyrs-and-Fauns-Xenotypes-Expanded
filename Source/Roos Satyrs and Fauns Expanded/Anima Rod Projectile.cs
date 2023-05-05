using Verse;

namespace Roos_Satyrs_and_Fauns_Expanded
{
    public class Anima_Rod_Projectile : Projectile_Explosive
    {
        protected override void Impact(Thing hitThing, bool blockedByShield = false)
        {
            Map map = base.Map;
            IntVec3 explodePosition = base.Position;
            float explosionRadius = 5;
            DamageDef damageDef = this.def.projectile.damageDef;
            int damageAmount = this.DamageAmount;
            float armorPenetration = this.ArmorPenetration;

            GenExplosion.DoExplosion(explodePosition, map, explosionRadius, damageDef, null, damageAmount, armorPenetration, null, null, null, null, null, 0f, 1, null, false, null, 0f, 1, 0f, false, null, null, null, true, 1f, 0f, true, null, 1f);


            foreach (Pawn pawn in map.mapPawns.AllPawnsSpawned)
            {
                if (pawn == null || !pawn.Position.InHorDistOf(explodePosition, explosionRadius))
                {
                    continue;
                }

                ApplyEffects(pawn);
            }
            base.Impact(hitThing);
        }

        public virtual void ApplyEffects(Pawn pawn)
        {
            var appliedHediffDef = RBSF_DefOf.RBSF_VineWrapHeDiff;
            Hediff hediff = HediffMaker.MakeHediff(appliedHediffDef, pawn);
            pawn.health.AddHediff(hediff);
            Log.Message("Pawn: " + pawn.Name + " given hediff " + hediff.Label);
            pawn.stances.stunner.StunFor(240, this);
            return;
        }
    }
}
