using EBSGFramework;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Verse;

namespace FPM_Additions
{
    public class CompAbilityEffect_ImplantCodon : CompAbilityEffect
    {
        public new AbilityCompProperties_ImplantCodon Props => (AbilityCompProperties_ImplantCodon)props;

        public override void Apply(LocalTargetInfo target, LocalTargetInfo dest)
        {
            // Ensure we are working with a valid target
            if (target.Pawn == null)
            {
                Log.Error("Target pawn is null.");
                return;
            }

            // This is the pawn casting the ability
            Pawn casterPawn = parent.pawn;

            if (casterPawn == null)
            {
                Log.Error("Caster pawn is null.");
                return;
            }

            foreach (var codonDef in Props.codonDefs)
            {
                // Add genes to the target pawn
                EBSGFramework.EBSGUtilities.AddGenesToPawn(target.Pawn, codonDef.xenogene, codonDef.geneSet);

                // Transfer genes if specified
                if (codonDef.transfer)
                {
                    EBSGFramework.EBSGUtilities.RemoveGenesFromPawn(casterPawn, codonDef.geneSet);
                }

                // Remove genes from the caster pawn if specified
                if (codonDef.removedGenes != null && codonDef.removedGenes.Any())
                {
                    EBSGFramework.EBSGUtilities.RemoveGenesFromPawn(casterPawn, codonDef.removedGenes);
                }
            }
        }
    }

}