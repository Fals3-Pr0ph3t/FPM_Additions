using RimWorld;
using Verse;

namespace FPM_Additions
{
    public class CompAbilityEffect_ImplantHeritogen : CompAbilityEffect
    {
        public new AbilityCompProperties_ImplantHeritogen Props => (AbilityCompProperties_ImplantHeritogen)props;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            base.Apply(target, dest);
            if (target.Pawn != null)
            {
                Pawn pawn = target.Pawn;
            }
            bool xenogene = Props.heritogenDef.xenogene;
            FPM_Utilites.ImplantHeritogen(parent.pawn, target.Pawn, Props.heritogenDef);
        }
    }
}