using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace EnaSlime
{
    class EnaSlimePlort
    {
        public static GameObject EnaPlort()
        {
            GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_PLORT)); //It can be any plort, but pink works the best. 
            Prefab.name = "ENA Plort";

            Prefab.GetComponent<Identifiable>().id = Ids.ENA_PLORT;
            Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

            Prefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(Prefab.GetComponent<MeshRenderer>().material);
            Color EnaBlue = new Color32(24, 99, 255, 255);
            Color EnaYellow = new Color32(255, 213, 0, 255);
            Color EnaGrey = new Color32(183, 184, 186, 255);
            Color EnaWhite = Color.white;
            Color EnaBlack = Color.black;
            //Pretty self explanatory. These change the color of the plort. You can set the colors to whatever you want.    
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", EnaYellow);
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", EnaGrey);
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", EnaBlue);

            LookupRegistry.RegisterIdentifiablePrefab(Prefab);

            return Prefab;
        }
    }
}
