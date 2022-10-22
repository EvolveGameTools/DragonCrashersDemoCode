using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI {

    public enum CharacterClass {

        Paladin,
        Wizard,
        Barbarian,
        Necromancer

    }

    public enum Rarity {

        Common,
        Rare,
        Special,
        All, // for filtering

    }

    public enum AttackType {

        Melee,
        Magic,
        Ranged

    }

    // baseline data for a specific character

    [CreateAssetMenu(fileName = "Assets/Resources/GameData/Characters/CharacterGameData", menuName = "UIToolkitDemo/Character", order = 1)]
    public class CharacterBaseSO : ScriptableObject {

        public string characterName;
        public GameObject characterVisualsPrefab;
        public CharacterClass characterClass;
        public Rarity rarity;
        public AttackType attackType;

        public string bioTitle;
        [TextArea] public string bio;

        public float basePointsLife;
        public float basePointsDefense;
        public float basePointsAttack;
        public float basePointsAttackSpeed;
        public float basePointsSpecialAttack;
        public float basePointsCriticalHit;

        // skill1 unlocked at level 0, skill2 unlocked at level 3, skill3 unlocked at level 6
        public SkillSO skill1;
        public SkillSO skill2;
        public SkillSO skill3;

        // starting equipment (weapon, shield/armor, helmet, boots, gloves)
        public EquipmentSO defaultWeapon;
        public EquipmentSO defaultShieldAndArmor;
        public EquipmentSO defaultHelmet;
        public EquipmentSO defaultBoots;
        public EquipmentSO defaultGloves;

        [HideInInspector] public EquipmentSO[] equippedItems = new EquipmentSO[5];

        public int currentXP = 2300;
        public int xpToNextLevel = 1000;

        public int level;

        public bool LevelUp() {
            if (currentXP < xpToNextLevel) {
                return false;
            }

            level++;
            currentXP -= xpToNextLevel;
            return true;
        }

        public SkillSO GetSkill(int index) {
            return index switch {
                0 => skill1,
                1 => skill2,
                2 => skill3,
                _ => throw new ArgumentOutOfRangeException(nameof(index), index, null)
            };
        }

        public void AutoEquip(List<EquipmentSO> inventory) {
            for (int i = 0; i < equippedItems.Length; i++) {
                equippedItems[i] = inventory[i];
            }
        }

        public void UnequipAll() {
            for (int i = 0; i < equippedItems.Length; i++) {
                equippedItems[i] = null;
            }
        }

        public void Equip(int slot, EquipmentSO item) {
            equippedItems[slot] = item;
        }

        void OnValidate() {
            if (level < 1) level = 1;

            if (defaultWeapon != null && defaultWeapon.equipmentType != EquipmentType.Weapon)
                defaultWeapon = null;

            if (defaultShieldAndArmor != null && defaultShieldAndArmor.equipmentType != EquipmentType.Shield)
                defaultShieldAndArmor = null;

            if (defaultHelmet != null && defaultHelmet.equipmentType != EquipmentType.Helmet)
                defaultHelmet = null;

            if (defaultGloves != null && defaultGloves.equipmentType != EquipmentType.Gloves)
                defaultGloves = null;

            if (defaultBoots != null && defaultBoots.equipmentType != EquipmentType.Boots)
                defaultBoots = null;

            equippedItems ??= new EquipmentSO[5];

            equippedItems[0] = defaultWeapon;
            equippedItems[1] = defaultShieldAndArmor;
            equippedItems[2] = defaultHelmet;
            equippedItems[3] = defaultGloves;
            equippedItems[4] = defaultBoots;
        }

    }

}