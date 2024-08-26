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
    /*[StaticConstructorOnStartup]
    public static class CodonDefInintializer
    {
        static CodonDefInintializer()
        {
            foreach (var def in DefDatabase<CodonDef>.AllDefs)
            {
                def.ResolveReferences();
            }
        }
    }*/




    public class CodonDef : GeneDef
    {
        public bool xenogene = false;
        public bool transfer = true;
        public List<GeneDef> geneSet = new List<GeneDef>();                   // Declare the list
        public List<GeneDef> removedGenes = new List<GeneDef>();              // Declare the list
        private string aname;

        public override void PostLoad()
        {
            base.PostLoad();
            LongEventHandler.ExecuteWhenFinished(delegate ()
                {
                    GeneList(this);

                    string GeneList(CodonDef codonDef)
                    {
                        if (codonDef.geneSet == null || codonDef.geneSet.Count == 0)
                        {
                            Log.Error("Gene set is empty or null.");
                            return string.Empty;
                        }

                        StringBuilder sb = new StringBuilder();

                        foreach (var gene in codonDef.geneSet)
                        {
                            sb.Append(gene.label);
                            sb.Append(", ");
                        }

                        // Remove the last comma and space
                        if (sb.Length > 2)
                        {
                            sb.Length -= 2;
                        }

                        string result = sb.ToString();


                        Log.Error("Line 78 " + result);      //debugline
                        
                        codonDef.description = codonDef.description + "\nCodon contains the following genes:\n" + result;


                        return result;
                    }
                });
            }
    }       
}







