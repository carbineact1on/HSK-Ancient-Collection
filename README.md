# HSK-Ancient-Collection

HSK/CE-patched conversions of **Ancient-themed** mods for RimWorld, tuned for the [Hardcore SK](https://github.com/skyarkhangel/Hardcore-SK) modpack.

This repository contains separate mod folders, each with its own `About/About.xml`. RimWorld's mod manager scans subfolders, so each subfolder is recognized as an independent mod.

## Requirements

- **RimWorld 1.5** (1.6 supported as well where applicable)
- **Hardcore SK Modpack**
- **Vanilla Expanded Framework**
- Mod-specific dependencies listed in each subfolder's `About/About.xml`

## What's Inside

### ⛏ HSK-AncientMiningIndustry
HSK-balanced fork of **[Ancient Mining Industry](https://steamcommunity.com/sharedfiles/filedetails/?id=3141472661)** by Bread MO + AobaKuma.

Player-craftable buildings (drilling rig, tunnel boring machine, ore dressing machine, conveyors, structural supports, mini turrets) rebalanced to HSK's true canonical building pattern from `Core_SK/Defs/ThingDefs_Buildings/Buildings_Production_Hightech.xml` — same style as native HSK DeepDrill / Hemopump:

- `stuffCategories: RuggedMetallic` + `costStuffCount` (player picks SteelBar / Plasteel / etc., gets stuff variation)
- HSK component pipeline (ComponentIndustrial / ComponentSpacer / ElectronicComponents / Mechanism)
- Turret barrel-fuel filter swapped from raw Steel → SteelBar
- Raw `Uranium` → `DepletedUranium` on the TBM
- ANCIENT (loot/spawn) variants left untouched — Pacas Patches Compilation already covers those

⚠ `<incompatibleWith>XMB.AncientMiningIndustry.MO</incompatibleWith>` — disable the upstream Workshop version.

### 🏙 HSK-AncientUrbanRuins
Full HSK conversion of **[Ancient Urban Ruins](https://steamcommunity.com/sharedfiles/filedetails/?id=3316062206)** by MO. End-to-end audit covering buildings, weapons, apparel, ammo, scenarios, traders, loot drops, and research progression.

#### Buildings (~119 craftable + ~150 loot/spawn)
- Bulk Steel → SteelBar across every player-buildable def
- 10 functional buildings get full HSK component pattern (ElectronicComponents / Mechanism / Microchips / Wire) — Generator, Television, Electrical Box, Workbench, Virtual Miner, all 5 Elevators
- 19 ungated functional buildings now have HSK research gates: MicroelectronicsBasics (TransportPod, LargeScreenTelevision, MaterialElevators), Fortifications (5× ArmoredGate variants), ComplexFurniture (8× RollingShutter variants)
- ~150 loot/spawn buildings (lockers, ruins, ancient turrets, walls, etc.) now drop HSK refined materials when destroyed in combat: ChunkSlagSteel + SteelBar + ComponentIndustrial / ReinforcedConcrete by tier (added via abstract parent classes)

#### Weapons (~35 craftable)
- Bulk Steel → SteelBar on every craftable weapon
- HSK weapon-component pipeline added based on tier:
  - Pistols (Makarov, APS, FNHG, CPHG): + Pistol_Component
  - SMGs (MPX/MPXL/STM/STMC): + Weapon_Parts
  - Standard rifles (M4A/M4C/AK101A/ASVAL/MCX/MCXC/ADAR): + Rifle_Component
  - Advanced rifles (M5A3LT, Spear68A/C, TKB68A, AK68A, MK68A, RM68A, M4ASOP, M42U, MK17A, R11A, AVT): + AdvRifle_Component
  - DMR/Sniper (SR25A, Hunter, VSS, M700A, MK18M): + Sniper_Component
  - LMG (PKM, PKP): + Heavy_Component
  - Top-tier bullpup (DTMDR): + AdvRifle_Component + Heavy_Component
- AUR's custom AM_ComponentWeapon / AM_227FURYComponents / AM_338PrecisionComponents / AM_PKPMagazineComponents preserved
- CE compatibility (verb, ammo, magazines, ToolCE melee, GunDrawExtension) handled by mod author's own `/CE/Patches/Weapons_Guns.xml`

#### Apparel (7 craftable + 2 loot helmets)
- Armor rescaled from vanilla CE (0.85-1.20 Sharp / 0.25-0.50 Blunt) to **HSK CE scale**:
  - AM_AScompFD: 3 / 6 (FlakJacket-tier)
  - AM_MK4aConcealed: 3 / 6 (light flak)
  - AM_MK4aDefensive: 7 / 15 (FlakVest)
  - AM_CompFlakSuit: 8 / 18 (combat shell)
  - AM_FullyEnclosedHelmet / NightVisionHelmet: 9 / 25 (PowerArmorHelmet)
  - AM_BulletproofMask: 3 / 6 (FlakHelmet)
  - AM_CataphractHelmetFashion / Slaughter: 12 / 30 (DoomHelmet-tier)
- Rescaled in BOTH base def and the mod's own `/CE/Patches/Armor.xml + BossArmor.xml + Helmet.xml` so the runtime CE override no longer wipes our base rescale
- HSK component pipeline added (ComponentIndustrial / SyntheticFibers / ElectronicComponents) on top of AUR's existing AM_AramidCloth / AM_UHMWPEPlate / AM_HeavyCompositePlate / ComponentSpacer custom materials

#### Ammo (1 custom AP round)
- AUR's SSAAP (Super Steel Armor Piercing 5.56×45mm NATO) rescaled from vanilla-CE-extreme to HSK CE premium-AP tier:
  - Sharp Pen 35 → **18** (1.4× HSK 5.56 AP)
  - Blunt Pen 99.18 → **24**
  - Damage 6 → 8

#### Scenarios / Traders / Patches (Steel sweep)
- ScenarioDef SafeHouse map-gen scatter: 720 raw Steel → SteelBar
- TraderKinds 1.5+1.6 trader stock: Steel → SteelBar (Silver kept as currency)
- Patches/PatchesReplace.xml + SimplifiedMode/PatchesReplace.xml: all costList Steel → SteelBar
- **Zero raw `<Steel>` / `<Gold>` / `<Uranium>` references left in any XML across the entire mod**

#### Untouched (verified safe)
- Items (14 medical/LEGO): use Cloth/Neutroamine/MedicineHerbal — no Steel
- RecipeDefs (decomposing recipes): output AUR's custom AM materials
- CE compatibility (mod author's `/CE/` folder): weapons, ammo, hediffs, ThingSetMaker, pawnkind loadouts — all properly tuned with magazine counts, sidearms, ToolCE melee, etc.
- PawnKindDefs: mod author's CE LoadoutPropertiesExtension covers all tiers (Boss 5-8 mags, Pirate 3-5 mags, Scav 1-2 mags)
- Decoration loot (signs, atrium, filth): no materials invested → nothing to refund
- Salvage-point loot interactions (refrigerators, vending, BDA shelves): DLL-driven custom right-click "Salvage" mechanic

⚠ `<incompatibleWith>XMB.AncientUrbanrUins.MO</incompatibleWith>` — disable the upstream Workshop version.

### 🌱 HSK-AncientHydroponicFarmFacilities
HSK-balanced fork of **[Ancient Hydroponic Farm Facilities](https://steamcommunity.com/sharedfiles/filedetails/?id=3075384838)** by MO. Player-craftable hydroponic farming setup (basins, sunlamps, nutrient pumps/dispensers/fermenters/tanks, pipe network) rebalanced to HSK material economy.

#### Player buildings (~17 craftable)
- Bulk Steel → SteelBar across all costLists
- HSK component pipeline added by tier:
  - **Hydroponic basins** (AncientHydro, DualHydroponicsBasin): + ElecComp 1, Mech 1
  - **Sunlamp**: + ElecComp 2, Microchips 1, Uranium → DepletedUranium
  - **Nutrient Pump / Tap / Drain**: + ElecComp 1, Mech 1
  - **Storage Tank**: + ElecComp 1, Plasteel 10
  - **Pipes (above + underground) / Feed/Outlet ports**: + Wire
  - **Nutrient Dispenser** (large): + ElecComp 4, Mech 4, Microchips 2
  - **Nutrient Solution Fermenter** (top tier): + ElecComp 6, Mech 6, Microchips 2

#### Decorative loot crates (6)
- Bulk Steel → SteelBar
- Mod's custom HydroponicNutrientSolution / MealNutrientPaste / Cloth / DevilstrandCloth contents preserved

#### Scenarios
- ScenarioDef AF_Scenarios.xml scatter: Steel → SteelBar

⚠ `<incompatibleWith>XMB.AncientHydroponicFarmFacilities.MO</incompatibleWith>` — disable the upstream Workshop version.

## Installation

1. Clone or download this repo
2. Place each subfolder in your RimWorld `Mods/` directory
3. Enable the individual mods in your modlist
4. Load **after** Hardcore SK + Vanilla Expanded Framework + the upstream version (if you have it disabled)

## How It Works

Each conversion is a self-contained replacement of the upstream mod:
- Bundles all upstream content (Defs / Textures / Sounds / Source) so no Workshop subscription is needed
- Edits the player-craftable defs in place to use HSK's canonical patterns
- Marked `incompatibleWith` upstream `packageId` to prevent double-loading
- Switch back to upstream when not playing HSK

## Credits

- Original mods: **Bread MO + AobaKuma** (Ancient Mining Industry), **MO** (Ancient Urban Ruins, Ancient Hydroponic Farm Facilities)
- HSK conversions: **CarbineAction**
- Pacas Patches Compilation referenced for the AMI Ancient* loot patches
