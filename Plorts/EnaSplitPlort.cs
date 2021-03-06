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
    class EnaSlimePlort3
    {
        public static GameObject EnaSplitPlort()
        {
            GameObject Prefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_PLORT)); //It can be any plort, but pink works the best. 
            Prefab.name = "%$-- EhEA sPlIt pLoRt HEXA ~~!!";

            Prefab.GetComponent<Identifiable>().id = Ids.ENA_SPLIT_PLORT;
            Prefab.GetComponent<Vacuumable>().size = Vacuumable.Size.GIANT;

            Prefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(Prefab.GetComponent<MeshRenderer>().material);
            Color EnaBlue = new Color32(24, 99, 255, 255);
            Color EnaYellow = new Color32(255, 213, 0, 255);
            Color EnaGrey = new Color32(183, 184, 186, 255);
            Color EnaWhite = Color.white;
            Color EnaBlack = Color.black;
            //Pretty self explanatory. These change the color of the plort. You can set the colors to whatever you want.    
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", EnaGrey);
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", EnaBlue);
            Prefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", EnaYellow);

            LookupRegistry.RegisterIdentifiablePrefab(Prefab);

            return Prefab;
        }
    }
}
