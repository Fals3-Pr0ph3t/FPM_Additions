using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;
using RimWorld;
using RimWorld.SketchGen;

namespace FPM_Additions
{
    [StaticConstructorOnStartup]
    public static class CodonDefInintializer
    {
        static CodonDefInintializer()
        {
            foreach (var def in DefDatabase<CodonDef>.AllDefs)
            {
                def.ResolveReferences();
            }
        }
    }




    public class CodonDef : GeneDef
    {
        public bool xenogene = false;
        public bool transfer = true;
        public List<GeneDef> geneSet;       // Declare the list
        public List<GeneDef> removedGenes;  // Declare the list

        private void ImplantAbility(string codonDefName)
        {
            var ability = new AbilityDef
            {
                defName = codonDefName + "_ability",
            };
            DefDatabase<AbilityDef>.Add(ability);
        }

        public override void PostLoad()
        {
            base.PostLoad();
            


           Log.Message("Accessing geneSet: " + string.Join(", ", geneSet.Select(g => g.defName)));

            if (geneSet == null)
            {
                geneSet = new List<GeneDef>();
                Log.Warning($"CodonDef {defName} had a null geneSet, initializing with an empty list.");
            }

            // Add logic to initialize or modify geneSet
            if (geneSet.Count == 0)
            {
                // Example: Add a default gene if the list is empty
                GeneDef defaultGene = DefDatabase<GeneDef>.GetNamed("DefaultGeneName", false);
                if (defaultGene != null)
                {
                    geneSet.Add(defaultGene);
                    Log.Message($"CodonDef {defName} had an empty geneSet, added DefaultGeneName.");
                }
                else
                {
                    Log.Warning($"CodonDef {defName} could not find DefaultGeneName to add.");
                }
            }

            // Format the description using the geneSet
            if (!string.IsNullOrEmpty(description))
            {
                description = FormatDescription(description, this);
            }
        }

        private string FormatDescription(string template, CodonDef codonDef)
        {
            geneSet = codonDef.geneSet;

            StringBuilder geneLabels = new StringBuilder();

            foreach (var gene in geneSet)
            {
                geneLabels.Append(gene.label);
                geneLabels.Append(", ");
            }

            if (geneLabels.Length > 0)
            {
                geneLabels.Length -= 2; // Remove the last comma and space
            }

            return string.Format(template, geneLabels.ToString());
        }
    }
}
