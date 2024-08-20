using System.Collections.Generic;
using Verse;

namespace FPM_Additions
{
    public class HeritogenDef : Def
    {
        //public string label; // The label for this group
        //public string description; // The description, potentially for display purposes
        //public string descriptionShort; // A shorter description
        public bool xenogene;

        // Caster effects
        public List<GeneDef> casterAddedGenes; // Genes added to the caster
        public List<GeneDef> casterRemovedGenes; // Genes removed from the caster
        public List<HediffDef> casterAddedHediffs; // Hediffs added to the caster
        public List<HediffDef> casterRemovedHediffs; // Hediffs removed from the caster

        // Target effects
        public List<GeneDef> targetAddedGenes; // Genes added to the target
        public List<GeneDef> targetRemovedGenes; // Genes removed from the target
        public List<HediffDef> targetAddedHediffs; // Hediffs added to the target
        public List<HediffDef> targetRemovedHediffs; // Hediffs removed from the target
    }

}
