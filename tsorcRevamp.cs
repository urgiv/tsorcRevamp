using System.Collections.Generic;
using System.ComponentModel;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace tsorcRevamp {
    public class tsorcRevamp : Mod {
        public static ModHotKey toggleDragoonBoots;

        public override void Load() {
            toggleDragoonBoots = RegisterHotKey("Dragoon Boots", "Z");
        }
        public override void Unload() {
            toggleDragoonBoots = null;
        }

        public override void AddRecipes() {
            RecipeHelper.EditRecipes();
        }

    }

	[Label("Config")]
	[BackgroundColor(30, 60, 40, 220)]
    public class tsorcRevampConfig : ModConfig {
        public override ConfigScope Mode => ConfigScope.ServerSide;
        [Label("Adventure Mode")]
		[BackgroundColor(60, 140, 80, 192)]
        [Tooltip("Adventure mode prevents breaking and placing most blocks.\nLeave this enabled if you're playing with the custom map!")]
        [DefaultValue(true)]
        public bool AdventureMode { get; set; }
		[Label("Souls Drop on Death")]
		[BackgroundColor(60, 140, 80, 192)]
		[Tooltip("Drop all your Dark Souls when you die.\nIf \"Delete Dropped Souls on Death\" is enabled, \nyour Souls will drop after old Souls are deleted.\nDefaults to On")]
		[DefaultValue(true)]
		public bool SoulsDropOnDeath { get; set; }

		[Label("Delete Dropped Souls on Death")]
		[BackgroundColor(60, 140, 80, 192)]
		[Tooltip("Any Dark Souls in the world will be deleted when a player dies.\nEven if this option is disabled, your Souls will be deleted \nif over 400 items are active in the world after you die, \nor if you exit the game while your Souls are still on the ground.\nDefaults to On")]
		[DefaultValue(true)]
		public bool DeleteDroppedSoulsOnDeath { get; set; }
	}

    public class TilePlaceCode : GlobalItem {

        public static int[] allowed = { //these can always be placed
			4,  //torch
			10, //Closed Door
			11, //Open Door  
			13, //bottles
			14, //table
			15, //chairs
			16, //anvil
			17, //furnance
			18, //workbench
			20, //sapling
			21, //chests
			27, //sunflower
			28, //pot
			29, //piggy bank
			33, //candle
			34, //bronze chandellier
			35, //silver chandellier
			36, //gold chandellier
			42, //chain lantern
			49, //water candle
			50, //books
			51, //cobweb
			55, //Sign 
			73, //plants
			74, //plants
			78, //clay pot
			79, //bed
			81, //corals
			82, //new herbs
			83, //grown herbs
			84, //bloomed herbs
			85, //tombstone
			86, //loom
			87, //piano
			88, //drawer
			89, //bench
			90, //bathtub
			91, //banner
			92, //lamp post
			93, //tiki torch
			94, //keg
			95, //chinese lantern
			96, //cooking pot
			97, //safe
			98, //skull candle
			99, //trash can
			100, //candlabra
			101, //bookcase
			102, //throne
			103, //bowl
			104, //grandfather clock
			105, //statue
			106, //sawmill
			114, //tinkerer's workbench
			125, //crystal ball
			126, //discoball
			128, //mannequin
			129, //crystal shard
			132, //lever
			133, //adamantite forge
			134, //mythril anvil
			149, //festive lights
			172, //sinks
			173, //platinum candelabra
			174, //platinum candle
			207, //water fountain
			218, //meat grinder
			228, //dye vat
			240, //trophies
			242, //big paintings
			245, //tall paintings
			246, //wide paintings
			270, //firefly in a bottle
			271, //lightning bug in a bottle
			275, //bunny cage
			276, //squirrel cage
			277, //mallard cage
			278, //duck cage
			279, //bird cage
			280, //blue jay cage
			281, //cardinal cage
			282, //fish bowl
			283, //heavy work bench
			285, //snail cage
			286, //glowing snail cage
			287, //ammo box
			288, //monarch jar
			289, //purple emperor jar
			290, //red admiral jar
			291, //ulysses jar
			292, //sulphur jar
			293, //tree nymph jar
			294, //zebra swallowtail jar
			295, //julia jar
			296, //scorpion cage
			297, //black scorpion cage
			298, //frog cage
			299, //mouse cage
			300, //bone welder
			301, //flesh cloning vat
			302, //glass kiln
			307, //steampunk boiler
			309, //penguin cage
			310, //worm cage
			316, //blue jellyfish jar
			317, //green jellyfish jar
			318, //pink jellyfish jar
			319, //ship in a bottle
			310, //seaweed planter
			324, //seashell variants
			337, //number and letter statues
			339, //grasshopper cage
			354, //bewitching table
			355, //alchemy table
			358, //gold bird cage
			359, //gold bunny cage
			360, //gold butterfly jar
			361, //gold frog cage
			362, //gold grasshopper cage
			363, //gold mouse cage
			364, //gold worm cage
			372, //peace candle
			377, //sharpening station
			378, //target dummy
			390, //lava lamp
			391, //enchanted nightcrawler cage
			392, //buggy cage
			393, //grubby cage
			394, //sluggy cage
			413, //red squirrel cage
			414, //gold squirrel cage


    };
        public override bool CanUseItem(Item item, Player player) {
            if (ModContent.GetInstance<tsorcRevampConfig>().AdventureMode) {
                if (item.createTile > -1) {
                    foreach (int id in allowed) {
                        if (item.createTile == id) {
                            return true; //allow placing of tiles in the Allowed array
                        }
                    }
                    return false; //disallow using item if it places other tiles
                }
                return true; //allow using items if they do not create tiles
            }
			return true; //always allow if not in adventure mode
        }
    }

    public class TileKillCode : GlobalTile {
        public List<int> allowed = new List<int>() { //These can always be destroyed
			// http://tconfig.wikia.com/wiki/List_of_Tiles
    
			19, //Wood Platform 
			67, //Amethyst 
					//25, ebonstone
			12, //Heart crystal
			2, //grass
			3, //small plants
			4, // torch
			5, //tree trunk
			6, //iron
			7, //copper
			9, //silver
			10, //closed door
			11, //open door
			12, //bottles
			13, //bottles and jugs
			14, //table
			15, //chairs
			16, //anvil
			17, //furnance
			18, //workbench
			20, //sapling
				//21, //chests
			23, //corruption grass
			24, //small corruption plants
			27, //sunflower
			28, //pot
			29, //piggy bank
			31, //shadow orb
			32, //corruption barbs
			33, //candle
			34, //bronze chandellier
			35, //silver c
			36, //gold c
			37, //meteorite
			42, //chain lantern
			49, //water candle
			50, //books
			51, //cobweb
			52, //vines
			53, //sand
			55, //Sign 
			56, //obsidian
			60, //jungle grass
			61, //small jungle plants
			62, //jungle vines
			66, //Topaz 
			69, //thorns
			72, //mushroom stalks
			71, //small mushrooms
			73, //plants
			74, //plants
			78, //clay pot
			79, //bed
			80, //cactus
			81, //corals
			82, //new herbs
			83, //grown herbs
			84, //bloomed herbs
			85, //tombstone
			86, //loom
			87, //piano
			88, //drawer
			89, //bench
			90, //bathtub
			91, //banner
			92, //lamp post
			93, //tiki torch
			94, //keg
			95, //chinese lantern
			96, //cooking pot
			97, //safe
			98, //skull candle
			99, //trash can
			100, //candlabra
			101, //bookcase
			102, //throne
			103, //bowl
			104, //grandfather clock
			105, //statue
			106, //sawmill
			107, //cobalt
			108, //mythril
			109, //Hallowed Grass
			110, //Hallowed Plants	 
			111, //adamantite
			112, //ebonsand
			114, //tinkerer's workbench
			115, //Hallowed Vines 
			116, //pearlsand
			125, //crystal ball
			126, //discoball
			128, //mannequin
			129, //crystal shard
			133, //adamantite forge
			134, //mythril anvil
			138, //boulder
			141 //explosives
		};
        public List<int> unbreakable = new List<int>()
        {
            132, //lever
			130, //active stone block
			135, //pressure plates
			136, //switch
			137 //dart trap
		};
        public override bool CanKillTile(int x, int y, int type, ref bool blockDamaged) {
			if (ModContent.GetInstance<tsorcRevampConfig>().AdventureMode) {
				if (x < 10 || x > Main.maxTilesX - 10) return true; //sanity
				if (y < 10 || y > Main.maxTilesY - 10) return true; //sanity
				if (Main.tile[x, y] == null) return true; //sanity 
				if (allowed.Contains(type)) return true; //always allow Allowed
				if (unbreakable.Contains(type)) return false; //always disallow Unbreakable
				bool right = Main.tile[x + 1, y] == null || Main.tile[x + 1, y].inActive();
				bool left = Main.tile[x - 1, y] == null || Main.tile[x - 1, y].inActive();
				bool below = Main.tile[x, y - 1] == null || Main.tile[x, y - 1].inActive();
				bool above = Main.tile[x, y + 1] == null || Main.tile[x, y + 1].inActive();
				if (right && left) return true; //if a tile has no neighboring tiles horizontally, allow breaking
				if (below && above) return true; //if a tile has no neighboring tiles vertically, allow breaking
				return false; //disallow breaking tiles otherwise
			}
			return true; //always allow breaking tiles if not in adventure mode
        }
    }


}