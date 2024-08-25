using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;
using Verse.AI;
using RimWorld;
using EBSGFramework;

namespace FPM_Additions
{


    public class AbilityCompProperties_ImplantCodon : CompProperties_AbilityEffect
    {
        public List<CodonDef> codonDefs;

        
        public AbilityCompProperties_ImplantCodon()
        {
            compClass = typeof(CompAbilityEffect_ImplantCodon);
        }
    }
}