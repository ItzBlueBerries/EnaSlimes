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
    class EnaSlimePlort2
    {
        public static GameObject EnaBluePlort()
        {
            GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_PLORT)); //It can be any plort, but pink works the best. 
            Prefab.name = "Blue Plort";

            Prefab.GetComponent<Identifiable>().id = Ids.ENA_BLUE_PLORT;
            Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;

            Prefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(Prefab.GetComponent<MeshRenderer>().material);
            Color EnaBlue = new Color32(24, 99, 255, 255);
            Color EnaYellow = new Color32(255, 213, 0, 255);
            Color EnaGrey = new Color32(183, 184, 186, 255);
            Color EnaWhite = Color.white;
            Color EnaBlack = Color.black;
            //Pretty self explanatory. These change the color of the plort. You can set the colors to whatever you want.    
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", EnaBlue);
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", EnaBlue);
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", EnaBlue);

            LookupRegistry.RegisterIdentifiablePrefab(Prefab);

            return Prefab;
        }
    }
}
