using System.Collections.Generic;
using EvolveUI;
using UnityEngine;

namespace UI {

    // the IconService makes icon dynamic icon look ups easier and caches repeated lookups
    // it will also return a default not_found icon if the requested icon doesn't exist
    public class IconService : UIService {

        private readonly Dictionary<string, string> icons = new Dictionary<string, string>();
        private UIRuntime runtime;
        private GameIconsSO gameIcons;

        private TextureInfo missingTexture;

        public override void OnInitialize() {
            gameIcons = Resources.Load<GameIconsSO>("GameData/GameIcons");
            this.runtime = application.GetRuntime();
        }

        public TextureInfo GetIcon(CharacterClass charClass) {
            for (int i = 0; i < gameIcons.characterClassIcons.Count; i++) {
                CharacterClassIcon icon = gameIcons.characterClassIcons[i];
                if (icon.characterClass == charClass) {
                    return GetIcon(runtime, icon.iconPath);
                }
            }

            return missingTexture;

        }

        public TextureInfo GetIcon(ShopItemType shopItem) {
            for (int i = 0; i < gameIcons.shopItemTypeIcons.Count; i++) {
                ShopItemTypeIcon icon = gameIcons.shopItemTypeIcons[i];
                if (icon.shopItemType == shopItem) {
                    return GetIcon(runtime, icon.iconPath);
                }
            }

            return missingTexture;
        }

        public TextureInfo GetIcon(Rarity rarity) {
            for (int i = 0; i < gameIcons.rarityIcons.Count; i++) {
                RarityIcon icon = gameIcons.rarityIcons[i];
                if (icon.rarity == rarity) {
                    return GetIcon(runtime, icon.iconPath);
                }
            }

            return missingTexture;
        }

        public TextureInfo GetIcon(AttackType attackType) {
            for (int i = 0; i < gameIcons.attackTypeIcons.Count; i++) {
                AttackTypeIcon icon = gameIcons.attackTypeIcons[i];
                if (icon.attackType == attackType) {
                    return GetIcon(runtime, icon.iconPath);
                }
            }

            return missingTexture;
        }

        public TextureInfo GetIcon(string iconPath) {
            return GetIcon(runtime, iconPath);
        }

        private TextureInfo GetIcon(UIRuntime runtime, string icon) {
            if (string.IsNullOrEmpty(icon)) {
                return runtime.GetTextureInfo("DragonCrashers::not_found");
            }

            if (icons.TryGetValue(icon, out string transformedIcon)) {
                return GetTextureInfoOrNotFound(runtime, transformedIcon);
            }

            if (icon.Contains("::")) {
                icons.Add(icon, icon);
                // that would be an already migrated icon path
                return GetTextureInfoOrNotFound(runtime, icon);
            }

            string textureId = "DragonCrashers::" + icon;

            icons.Add(icon, textureId);
            return GetTextureInfoOrNotFound(runtime, textureId);
        }

        private static TextureInfo GetTextureInfoOrNotFound(UIRuntime runtime, string textureId) {
            TextureInfo texture = runtime.GetTextureInfo(textureId);
            if (texture == default) {
                Debug.Log($"Cannot find texture {textureId}. Did you register it under this name in that module?");
                return runtime.GetTextureInfo("DragonCrashers::not_found");
            }

            return texture;
        }

    }

}