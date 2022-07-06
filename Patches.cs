using System;
using System.Collections.Generic;
using Extensions;
using HarmonyLib;
using UnityEngine;

namespace Patches
{

    [HarmonyPatch(typeof(SlimeEat), "EatAndProduce")]
    internal class Patch_SlimeEatProduce
    {
        // Token: 0x06000036 RID: 54 RVA: 0x00006058 File Offset: 0x00004258
        private static bool Prefix(SlimeEat __instance, SlimeDiet.EatMapEntry em)
        {

            bool flag5 = __instance.slimeDefinition.Matches(Ids.ENA_SLIME);
            if (flag5)
            {
                List<Identifiable.Id> list2 = new List<Identifiable.Id>();
                list2.Add(Ids.ENA_YELLOW_PLORT);
                list2.Add(Ids.ENA_YELLOW_PLORT);
                list2.Add(Ids.ENA_YELLOW_PLORT);
                list2.Add(Ids.ENA_BLUE_PLORT);
                list2.Add(Ids.ENA_BLUE_PLORT);
                list2.Add(Ids.ENA_BLUE_PLORT);
                list2.Add(Ids.ENA_SPLIT_PLORT);
                // You can add multiple ids! :D
                // You could also add duplicates of the same thing to make the probability different!

                em.producesId = list2.RandomObject<Identifiable.Id>();
            }

            return true;
        }
    }
}
