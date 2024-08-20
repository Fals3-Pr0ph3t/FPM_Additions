using RimWorld;

namespace FPM_Additions
{


    public class AbilityCompProperties_ImplantHeritogen : CompProperties_AbilityEffect
    {
        public HeritogenDef heritogenDef;


        public AbilityCompProperties_ImplantHeritogen()
        {
            compClass = typeof(CompAbilityEffect_ImplantHeritogen);
        }
    }
}