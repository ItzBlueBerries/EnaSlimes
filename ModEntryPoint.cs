using SRML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SRML.SR;
using UnityEngine;
using SRML.SR.Translation;
using MonomiPark.SlimeRancher.Regions;
using System.Reflection;
using EnaSlime;

namespace EnaSlime
{
    public class Main : ModEntryPoint
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

        // Called before GameContext.Awake
        // You want to register new things and enum values here, as well as do all your harmony patching
        public override void PreLoad()
        {
            HarmonyInstance.PatchAll();

            TranslationPatcher.AddUITranslation("m.foodgroup.plorts", "Plorts");

            // START SLIMEPEDIA ENTRY: ENA SLIME
            PediaRegistry.RegisterIdentifiableMapping((PediaDirector.Id)1007, Ids.ENA_SLIME);
            PediaRegistry.RegisterIdentifiableMapping(Ids.ENA_ENTRY, Ids.ENA_SLIME);
            PediaRegistry.SetPediaCategory(Ids.ENA_ENTRY, (PediaRegistry.PediaCategory)1);
            new SlimePediaEntryTranslation(Ids.ENA_ENTRY)
                .SetTitleTranslation("ENA Slime")
                .SetIntroTranslation("Original Character by Joel G.")
                .SetDietTranslation("Plorts.")
                .SetFavoriteTranslation("None.")
                .SetSlimeologyTranslation("ENA Slimes are based off of a character created by Joel G [Joel Guerra]. She is a girl/slime with an asymmetrical body and two different personalities. Depending on what this slime is feeling, it will change its colors, this goes for hunger, fear (may or may not), happy, etc. Tarrs WILL eat ENA Slimes which will produce more Tarrs.")
                .SetRisksTranslation("ENA Slimes have no risk, just keep them fed & happy so they stay their happy yellow color.")
                .SetPlortonomicsTranslation("ENA Plorts are worth something, there shouldn't be much to them, besides they're produced by a multi-personality/colored slime.");
            // END SLIMEPEDIA ENTRY: ENA SLIME

            // ENA PLORT TRANSLATION

            // YELLOW

            TranslationPatcher.AddActorTranslation("l." + Ids.ENA_YELLOW_PLORT.ToString().ToLower(), "Yellow Plort");
            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, Ids.ENA_YELLOW_PLORT);
            Identifiable.PLORT_CLASS.Add(Ids.ENA_YELLOW_PLORT);
            Identifiable.NON_SLIMES_CLASS.Add(Ids.ENA_YELLOW_PLORT);

            // BLUE

            TranslationPatcher.AddActorTranslation("l." + Ids.ENA_BLUE_PLORT.ToString().ToLower(), "Blue Plort");
            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, Ids.ENA_BLUE_PLORT);
            Identifiable.PLORT_CLASS.Add(Ids.ENA_BLUE_PLORT);
            Identifiable.NON_SLIMES_CLASS.Add(Ids.ENA_BLUE_PLORT);

            // SPLIT

            TranslationPatcher.AddActorTranslation("l." + Ids.ENA_SPLIT_PLORT.ToString().ToLower(), "sPlIt pLoRt");
            PediaRegistry.RegisterIdentifiableMapping(PediaDirector.Id.PLORTS, Ids.ENA_SPLIT_PLORT);
            Identifiable.PLORT_CLASS.Add(Ids.ENA_SPLIT_PLORT);
            Identifiable.NON_SLIMES_CLASS.Add(Ids.ENA_SPLIT_PLORT);

            // START ENA SLIME SPAWNER
            SRCallbacks.PreSaveGameLoad += (s =>
            {
                foreach (DirectedSlimeSpawner spawner in UnityEngine.Object.FindObjectsOfType<DirectedSlimeSpawner>()
                    .Where(ss =>
                    {
                        ZoneDirector.Zone zone = ss.GetComponentInParent<Region>(true).GetZoneId();
                        return zone == ZoneDirector.Zone.NONE || zone == ZoneDirector.Zone.RANCH || zone == ZoneDirector.Zone.REEF || zone == ZoneDirector.Zone.QUARRY || zone == ZoneDirector.Zone.MOSS || zone == ZoneDirector.Zone.DESERT || zone == ZoneDirector.Zone.SEA || zone == ZoneDirector.Zone.RUINS || zone == ZoneDirector.Zone.RUINS_TRANSITION || zone == ZoneDirector.Zone.WILDS;
                    }))
                {
                    foreach (DirectedActorSpawner.SpawnConstraint constraint in spawner.constraints)
                    {
                        List<SlimeSet.Member> members = new List<SlimeSet.Member>(constraint.slimeset.members)
                        {
                            new SlimeSet.Member
                            {
                                prefab = GameContext.Instance.LookupDirector.GetPrefab(Ids.ENA_SLIME),
                                weight = 0.1f // The higher the value is the more often your slime will spawn
                            }
                        };
                        constraint.slimeset.members = members.ToArray();
                    }
                }
            });
            // END ENA SLIME SPAWNER
        }


        // Called before GameContext.Start
        // Used for registering things that require a loaded gamecontext
        public override void Load()
        {
            //-- LOAD --\\

            // START LOAD ENA SLIME
            (SlimeDefinition, GameObject) SlimeTuple = EnaSlime.CreateSlime(Ids.ENA_SLIME, "ENA Slime"); //Insert your own Id in the first argumeter

            //Getting the SlimeDefinition and GameObject separated
            SlimeDefinition Slime_Slime_Definition = SlimeTuple.Item1;
            GameObject Slime_Slime_Object = SlimeTuple.Item2;

            Slime_Slime_Object.GetComponent<Vacuumable>().size = Vacuumable.Size.NORMAL;
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Slime_Slime_Object);
            TranslationPatcher.AddPediaTranslation("t." + Ids.ENA_SLIME.ToString().ToLower(), "ENA Slime");
            Sprite SlimeIcon = CreateSprite(LoadImage("ena_slime.png"));
            Color PureBlue = Color.blue;
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(Ids.ENA_SLIME, PureBlue, SlimeIcon));

            //And well, registering it!
            LookupRegistry.RegisterIdentifiablePrefab(Slime_Slime_Object);
            SlimeRegistry.RegisterSlimeDefinition(Slime_Slime_Definition);
            // END LOAD ENA SLIME

            // START LOAD ENA PLORT

            // YELLOW

            GameObject PlortTuple = EnaSlimePlort.EnaYellowPlort();

            GameObject Plort_Plort_Object = PlortTuple;

            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Plort_Plort_Object);
            // Icon that is below is just a placeholder. You can change it to anything or add your own! 
            Sprite PlortIcon = CreateSprite(LoadImage("ena_slime_yellow_plort.png"));
            Color PureYellow = Color.yellow; // RGB   
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(Ids.ENA_YELLOW_PLORT, PureYellow, PlortIcon));
            AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, Ids.ENA_YELLOW_PLORT);

            float price = 35f; //Starting price for plort   
            float saturated = 5f; //Can be anything. The higher it is, the higher the plort price changes every day. I'd recommend making it small so you don't destroy the economy lol.   
            PlortRegistry.AddEconomyEntry(Ids.ENA_YELLOW_PLORT, price, saturated); //Allows it to be sold while the one below this adds it to plort market.   
            PlortRegistry.AddPlortEntry(Ids.ENA_YELLOW_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
            DroneRegistry.RegisterBasicTarget(Ids.ENA_YELLOW_PLORT);

            // BLUE

            GameObject PlortTuple2 = EnaSlimePlort2.EnaBluePlort();

            GameObject Plort_Plort_Object2 = PlortTuple2;

            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Plort_Plort_Object2);
            // Icon that is below is just a placeholder. You can change it to anything or add your own! 
            Sprite PlortIcon2 = CreateSprite(LoadImage("ena_slime_blue_plort.png"));
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(Ids.ENA_BLUE_PLORT, PureBlue, PlortIcon2));
            AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, Ids.ENA_BLUE_PLORT);

            PlortRegistry.AddEconomyEntry(Ids.ENA_BLUE_PLORT, price, saturated); //Allows it to be sold while the one below this adds it to plort market.   
            PlortRegistry.AddPlortEntry(Ids.ENA_BLUE_PLORT); //PlortRegistry.AddPlortEntry(YourCustomEnum, new ProgressDirector.ProgressType[1]{ProgressDirector.ProgressType.NONE});   
            DroneRegistry.RegisterBasicTarget(Ids.ENA_BLUE_PLORT);

            // SPLIT
            
            GameObject PlortTuple3 = EnaSlimePlort3.EnaSplitPlort();

            GameObject Plort_Plort_Object3 = PlortTuple3;

            Sprite PlortIcon3 = CreateSprite(LoadImage("ena_slime_split_plort.png"));
            Color PureGrey = Color.grey;
            AmmoRegistry.RegisterAmmoPrefab(PlayerState.AmmoMode.DEFAULT, Plort_Plort_Object3);
            LookupRegistry.RegisterVacEntry(VacItemDefinition.CreateVacItemDefinition(Ids.ENA_SPLIT_PLORT, PureGrey, PlortIcon3));
            AmmoRegistry.RegisterSiloAmmo(x => x == SiloStorage.StorageType.NON_SLIMES || x == SiloStorage.StorageType.PLORT, Ids.ENA_SPLIT_PLORT);
            // END LOAD ENA PLORT
        }

        // Called after all mods Load's have been called
        // Used for editing existing assets in the game, not a registry step
        public override void PostLoad()
        {

        }

    }
}