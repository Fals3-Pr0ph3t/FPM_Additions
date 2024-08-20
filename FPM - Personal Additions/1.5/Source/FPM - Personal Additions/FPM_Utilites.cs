using EBSGFramework;
using Verse;

namespace FPM_Additions
{
    public static class FPM_Utilites
    {
        public static void ImplantHeritogen(Pawn caster, Pawn target, HeritogenDef heritogenDef)
        {
            if (caster.genes == null) return;
            if (target.genes == null) return;

            EBSGUtilities.AddGenesToPawn(target, heritogenDef.xenogene, heritogenDef.targetAddedGenes);
            EBSGUtilities.AddGenesToPawn(caster, heritogenDef.xenogene, heritogenDef.casterAddedGenes);
            EBSGUtilities.RemoveGenesFromPawn(target, heritogenDef.targetRemovedGenes);
            EBSGUtilities.RemoveGenesFromPawn(caster, heritogenDef.casterRemovedGenes);
        }
    }
}

