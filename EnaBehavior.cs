using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using DG.Tweening;
using MonomiPark.SlimeRancher.Regions;
using System.Collections;
using SimpleSRmodLibrary.Creation;
using SRML.Utils;
using Object = UnityEngine.Object;
using SRML.SR;

namespace EnaSlime
{
    class EnaHungry : SlimeSubbehaviour
    {
        private Material[] enaMaterials;

        // Material enaMaterial = Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.GLITCH_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
        public override void Awake()
        {
            base.Awake();
            List<Material> list = new List<Material>();
            foreach (Renderer renderer in base.GetComponentsInChildren<Renderer>())
            {
                if (renderer.sharedMaterial.HasProperty("_TopColor"))
                {
                    list.Add(renderer.material);
                }
            }
            this.enaMaterials = list.ToArray();
        }

        public override void Action()
        {
            Color EnaBlue = new Color32(24, 99, 255, 255);
            Color EnaYellow = new Color32(255, 213, 0, 255);

            foreach (Material material in this.enaMaterials)
            {
                material.SetColor("_TopColor", EnaBlue);
                material.SetColor("_MiddleColor", EnaBlue);
                material.SetColor("_BottomColor", EnaBlue);
                material.SetColor("_SpecColor", EnaYellow);
                material.SetFloat("_Shininess", 1f);
                material.SetFloat("_Gloss", 1f);
            }

            /*GameObject SlimePrefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Ids.ENA_SLIME));

            // SlimePrefab.GetComponent<Identifiable>().id = Ids.ENA_SLIME;
            // SlimePrefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            SlimePrefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(SlimePrefab.GetComponent<MeshRenderer>().material);

            SlimePrefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", EnaBlue);
            SlimePrefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", EnaBlue);
            SlimePrefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", EnaBlue);
            SlimePrefab.GetComponent<MeshRenderer>().material.SetColor("_SpecColor", EnaBlue);
            SlimePrefab.GetComponent<MeshRenderer>().material.SetFloat("_Shininess", 1f);
            SlimePrefab.GetComponent<MeshRenderer>().material.SetFloat("_Gloss", 1f);*/
        }

        public override float Relevancy(bool isGrounded)
        {
            if (emotions.GetCurr(SlimeEmotions.Emotion.HUNGER) >= 0.5f) //When the slime starts to get agitated
                return 1f; //This means do the action. Important; don't remove it
            return 0f; //This means don't do the actions. Important; don't remove it
        }

        public override void Selected() { }
    }



    class EnaHappy : SlimeSubbehaviour
    {
        private Material[] enaMaterials;

        // Material enaMaterial = Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.GLITCH_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
        public override void Awake()
        {
            base.Awake();
            List<Material> list = new List<Material>();
            foreach (Renderer renderer in base.GetComponentsInChildren<Renderer>())
            {
                if (renderer.sharedMaterial.HasProperty("_TopColor"))
                {
                    list.Add(renderer.material);
                }
            }
            this.enaMaterials = list.ToArray();
        }

        public override void Action()
        {
            Color EnaBlue = new Color32(24, 99, 255, 255);
            Color EnaYellow = new Color32(255, 213, 0, 255);

            foreach (Material material in this.enaMaterials)
            {
                material.SetColor("_TopColor", EnaYellow);
                material.SetColor("_MiddleColor", EnaYellow);
                material.SetColor("_BottomColor", EnaYellow);
                material.SetColor("_SpecColor", EnaBlue);
                material.SetFloat("_Shininess", 1f);
                material.SetFloat("_Gloss", 1f);
            }

            /*GameObject SlimePrefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Ids.ENA_SLIME));

            // SlimePrefab.GetComponent<Identifiable>().id = Ids.ENA_SLIME;
            // SlimePrefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            SlimePrefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(SlimePrefab.GetComponent<MeshRenderer>().material);

            SlimePrefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", EnaBlue);
            SlimePrefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", EnaBlue);
            SlimePrefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", EnaBlue);
            SlimePrefab.GetComponent<MeshRenderer>().material.SetColor("_SpecColor", EnaBlue);
            SlimePrefab.GetComponent<MeshRenderer>().material.SetFloat("_Shininess", 1f);
            SlimePrefab.GetComponent<MeshRenderer>().material.SetFloat("_Gloss", 1f);*/
        }

        public override float Relevancy(bool isGrounded)
        {
            if (emotions.GetCurr(SlimeEmotions.Emotion.NONE) >= 0.5f) //When the slime starts to get agitated
                return 1f; //This means do the action. Important; don't remove it
            return 0f; //This means don't do the actions. Important; don't remove it
        }

        public override void Selected() { }
    }



    class EnaFear : SlimeSubbehaviour
    {
        private Material[] enaMaterials;

        // Material enaMaterial = Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.GLITCH_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
        public override void Awake()
        {
            base.Awake();
            List<Material> list = new List<Material>();
            foreach (Renderer renderer in base.GetComponentsInChildren<Renderer>())
            {
                if (renderer.sharedMaterial.HasProperty("_TopColor"))
                {
                    list.Add(renderer.material);
                }
            }
            this.enaMaterials = list.ToArray();
        }

        public override void Action()
        {
            Color EnaBlue = new Color32(24, 99, 255, 255);
            Color EnaYellow = new Color32(255, 213, 0, 255);
            Color EnaGrey = new Color32(183, 184, 186, 255);

            foreach (Material material in this.enaMaterials)
            {
                material.SetColor("_TopColor", EnaGrey);
                material.SetColor("_MiddleColor", EnaGrey);
                material.SetColor("_BottomColor", EnaGrey);
                material.SetColor("_SpecColor", EnaGrey);
                material.SetFloat("_Shininess", 1f);
                material.SetFloat("_Gloss", 1f);
            }

            /*GameObject SlimePrefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Ids.ENA_SLIME));

            // SlimePrefab.GetComponent<Identifiable>().id = Ids.ENA_SLIME;
            // SlimePrefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            SlimePrefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(SlimePrefab.GetComponent<MeshRenderer>().material);

            SlimePrefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", EnaBlue);
            SlimePrefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", EnaBlue);
            SlimePrefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", EnaBlue);
            SlimePrefab.GetComponent<MeshRenderer>().material.SetColor("_SpecColor", EnaBlue);
            SlimePrefab.GetComponent<MeshRenderer>().material.SetFloat("_Shininess", 1f);
            SlimePrefab.GetComponent<MeshRenderer>().material.SetFloat("_Gloss", 1f);*/
        }

        public override float Relevancy(bool isGrounded)
        {
            if (emotions.GetCurr(SlimeEmotions.Emotion.FEAR) >= 0.5f) //When the slime starts to get agitated
                return 1f; //This means do the action. Important; don't remove it
            return 0f; //This means don't do the actions. Important; don't remove it
        }

        public override void Selected() { }
    }



    class EnaAgitated : SlimeSubbehaviour
    {
        private Material[] enaMaterials;

        // Material enaMaterial = Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.GLITCH_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
        public override void Awake()
        {
            base.Awake();
            List<Material> list = new List<Material>();
            foreach (Renderer renderer in base.GetComponentsInChildren<Renderer>())
            {
                if (renderer.sharedMaterial.HasProperty("_TopColor"))
                {
                    list.Add(renderer.material);
                }
            }
            this.enaMaterials = list.ToArray();
        }

        public override void Action()
        {
            Color EnaBlue = new Color32(24, 99, 255, 255);
            Color EnaYellow = new Color32(255, 213, 0, 255);
            Color EnaWhite = Color.white;
            Color EnaBlack = Color.black;

            foreach (Material material in this.enaMaterials)
            {
                material.SetColor("_TopColor", EnaWhite);
                material.SetColor("_MiddleColor", EnaBlack);
                material.SetColor("_BottomColor", EnaWhite);
                material.SetColor("_SpecColor", EnaBlack);
                material.SetFloat("_Shininess", 1f);
                material.SetFloat("_Gloss", 1f);
            }

            /*GameObject SlimePrefab = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Ids.ENA_SLIME));

            // SlimePrefab.GetComponent<Identifiable>().id = Ids.ENA_SLIME;
            // SlimePrefab.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            SlimePrefab.GetComponent<MeshRenderer>().material = Object.Instantiate<Material>(SlimePrefab.GetComponent<MeshRenderer>().material);

            SlimePrefab.GetComponent<MeshRenderer>().material.SetColor("_TopColor", EnaBlue);
            SlimePrefab.GetComponent<MeshRenderer>().material.SetColor("_MiddleColor", EnaBlue);
            SlimePrefab.GetComponent<MeshRenderer>().material.SetColor("_BottomColor", EnaBlue);
            SlimePrefab.GetComponent<MeshRenderer>().material.SetColor("_SpecColor", EnaBlue);
            SlimePrefab.GetComponent<MeshRenderer>().material.SetFloat("_Shininess", 1f);
            SlimePrefab.GetComponent<MeshRenderer>().material.SetFloat("_Gloss", 1f);*/
        }

        public override float Relevancy(bool isGrounded)
        {
            if (emotions.GetCurr(SlimeEmotions.Emotion.AGITATION) >= 0.5f) //When the slime starts to get agitated
                return 1f; //This means do the action. Important; don't remove it
            return 0f; //This means don't do the actions. Important; don't remove it
        }

        public override void Selected() { }
    }
}