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

⚠ `<incompatibleWith>XMB.AncientMiningIndustry.MO</incompatibleWith>` — disable the upstream Workshop version when running this fork.

## Installation

1. Clone or download this repo
2. Place each subfolder in your RimWorld `Mods/` directory
3. Enable the individual mods in your modlist
4. Load **after** Hardcore SK + Vanilla Expanded Framework + the upstream version (if you have it disabled)

## How It Works

Each conversion is a self-contained replacement of the upstream mod:
- Bundles all upstream content (Defs / Textures / Sounds / Source) so no Workshop subscription is needed
- Edits the player-craftable defs in place to use HSK's canonical building pattern
- Marked `incompatibleWith` upstream `packageId` to prevent double-loading
- Switch back to upstream when not playing HSK

## Credits

- Original mods: their respective authors (linked per-subfolder)
- HSK conversions: **CarbineAction**
