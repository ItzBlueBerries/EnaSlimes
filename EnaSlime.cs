using SRML.SR;
using SRML.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace EnaSlime
{
    class EnaSlime
    {
        public static Texture2D LoadImage(string filename)
        {
            var a = Assembly.GetExecutingAssembly();
            var spriteData = a.GetManifestResourceStream(a.GetName().Name + "." + filename);
            var rawData = new byte[spriteData.Length];
            spriteData.Read(rawData, 0, rawData.Length);
            var tex = new Texture2D(1, 1);
            tex.LoadImage(rawData);
            tex.filterMode = FilterMode.Bilinear;
            return tex;
        }
        public static Sprite CreateSprite(Texture2D texture) => Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f), 1);
        public static (SlimeDefinition, GameObject) CreateSlime(Identifiable.Id SlimeId, String SlimeName)
        {
            // DEFINE
            SlimeDefinition enaSlimeDefinition = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.GLITCH_SLIME);
            SlimeDefinition slimeDefinition = (SlimeDefinition)PrefabUtils.DeepCopyObject(enaSlimeDefinition);
            slimeDefinition.AppearancesDefault = new SlimeAppearance[1];
            slimeDefinition.Diet.Produces = new Identifiable.Id[1]
            {
               Ids.ENA_PLORT
            };
            slimeDefinition.Diet.MajorFoodGroups = new SlimeEat.FoodGroup[1]
            {
                SlimeEat.FoodGroup.PLORTS
            };
            slimeDefinition.Diet.AdditionalFoods = new Identifiable.Id[0];
            slimeDefinition.Diet.Favorites = new Identifiable.Id[0];
            slimeDefinition.Diet.EatMap?.Clear();
            // TARR SUPPORT
            SlimeDefinition slimeByIdentifiableId = SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.TARR_SLIME);
            slimeByIdentifiableId.Diet.AdditionalFoods = new Identifiable.Id[1]
            {
                Ids.ENA_SLIME
            };
            slimeDefinition.CanLargofy = false;
            slimeDefinition.FavoriteToys = new Identifiable.Id[1];
            slimeDefinition.Name = "ENA Slime";
            slimeDefinition.IdentifiableId = Ids.ENA_SLIME;
            // OBJECT
            GameObject slimeObject = PrefabUtils.CopyPrefab(SRSingleton<GameContext>.Instance.LookupDirector.GetPrefab(Identifiable.Id.PINK_SLIME));
            slimeObject.name = "slimeEna";
            slimeObject.GetComponent<PlayWithToys>().slimeDefinition = slimeDefinition;
            slimeObject.GetComponent<SlimeAppearanceApplicator>().SlimeDefinition = slimeDefinition;
            slimeObject.GetComponent<SlimeEat>().slimeDefinition = slimeDefinition;
            slimeObject.GetComponent<Identifiable>().id = Ids.ENA_SLIME;
            slimeObject.AddComponent<EnaAgitated>();
            slimeObject.AddComponent<EnaHappy>();
            slimeObject.AddComponent<EnaFear>();
            slimeObject.AddComponent<EnaHungry>();
            UnityEngine.Object.Destroy(slimeObject.GetComponent<PinkSlimeFoodTypeTracker>());
            // APPEARANCE
            SlimeAppearance slimeAppearance = (SlimeAppearance)PrefabUtils.DeepCopyObject(enaSlimeDefinition.AppearancesDefault[0]);
            slimeDefinition.AppearancesDefault[0] = slimeAppearance;
            SlimeAppearanceStructure[] structures = slimeAppearance.Structures;
            foreach (SlimeAppearanceStructure slimeAppearanceStructure in structures)
            {
                Material[] defaultMaterials = slimeAppearanceStructure.DefaultMaterials;
                if (defaultMaterials != null && defaultMaterials.Length != 0)
                {
                    Color EnaBlue = new Color32(24, 99, 255, 255);
                    Color EnaYellow = new Color32(255, 213, 0, 255);
                    Material material = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.GLITCH_SLIME).AppearancesDefault[0].Structures[0].DefaultMaterials[0]);
                    material.SetColor("_TopColor", EnaYellow);
                    material.SetColor("_MiddleColor", EnaYellow);
                    material.SetColor("_BottomColor", EnaYellow);
                    material.SetColor("_SpecColor", EnaYellow);
                    material.SetFloat("_Shininess", 1f);
                    material.SetFloat("_Gloss", 1f);
                    slimeAppearanceStructure.DefaultMaterials[0] = material;
                    // THIS ADDS RAD SLIME AURAS, CAHNGE MIDDLE_COLOR AND EDGE_COLOR, IT WORKS I THINK, IT SHOULD AT LEAST.
                    /*Material material2 = UnityEngine.Object.Instantiate(SRSingleton<GameContext>.Instance.SlimeDefinitions.GetSlimeByIdentifiableId(Identifiable.Id.GLITCH_SLIME).AppearancesDefault[0].Structures[1].DefaultMaterials[0]);
                    material.SetColor("_TopColor", EnaYellow);
                    material.SetColor("_MiddleColor", EnaYellow);
                    material.SetColor("_BottomColor", EnaYellow);
                    material2.SetColor("_SpecColor", EnaYellow);
                    material2.SetColor("_EdgeColor", EnaYellow);
                    material.SetFloat("_Shininess", 1f);
                    material2.SetFloat("_Gloss", 1f);
                    slimeAppearance.Structures[1].DefaultMaterials[0] = material2;*/
                }
            }
            SlimeExpressionFace[] expressionFaces = slimeAppearance.Face.ExpressionFaces;
            for (int k = 0; k < expressionFaces.Length; k++)
            {
                SlimeExpressionFace slimeExpressionFace = expressionFaces[k];
                if ((bool)slimeExpressionFace.Mouth)
                {
                    slimeExpressionFace.Mouth.SetColor("_MouthBot", Color.white);
                    slimeExpressionFace.Mouth.SetColor("_MouthMid", Color.white);
                    slimeExpressionFace.Mouth.SetColor("_MouthTop", Color.white);
                }
                if ((bool)slimeExpressionFace.Eyes)
                {   /*
                    slimeExpressionFace.Eyes.SetColor("_EyeRed", new Color32(205, 190, 255, 255));
                    slimeExpressionFace.Eyes.SetColor("_EyeGreen", new Color32(182, 170, 226, 255));
                    slimeExpressionFace.Eyes.SetColor("_EyeBlue", new Color32(182, 170, 205, 255));
                    */
                    slimeExpressionFace.Eyes.SetColor("_EyeRed", Color.white);
                    slimeExpressionFace.Eyes.SetColor("_EyeGreen", Color.white);
                    slimeExpressionFace.Eyes.SetColor("_EyeBlue", Color.white);
                }
            }
            Color EnaBlue2 = new Color32(24, 99, 255, 255);
            Color EnaYellow2 = new Color32(255, 213, 0, 255);
            slimeAppearance.Icon = CreateSprite(LoadImage("ena_slime.png"));
            slimeAppearance.Face.OnEnable();
            slimeAppearance.ColorPalette = new SlimeAppearance.Palette
            {
                Top = EnaBlue2,
                Middle = EnaYellow2,
                Bottom = EnaYellow2
            };
            PediaRegistry.RegisterIdEntry(Ids.ENA_ENTRY, CreateSprite(LoadImage("ena_slime.png")));
            slimeObject.GetComponent<SlimeAppearanceApplicator>().Appearance = slimeAppearance;
            return (slimeDefinition, slimeObject);
        }
    }
}
