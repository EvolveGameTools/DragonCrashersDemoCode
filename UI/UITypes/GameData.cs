using UnityEngine;

namespace UI {

    public class GameData {

        public int softCurrency = 250;
        public int hardCurrency = 5000;
        public ScreenId currentScreen = ScreenId.Home;
        public int selectedCharacterIndex;

        public CharacterBaseSO[] characters;

        public GameData() {
            characters = Resources.LoadAll<CharacterBaseSO>("GameData/Characters");
        }

        public void NextCharacter() {
            selectedCharacterIndex++;
            if (selectedCharacterIndex >= characters.Length) {
                selectedCharacterIndex = 0;
            }
        }

        public void PrevCharacter() {
            selectedCharacterIndex--;
            if (selectedCharacterIndex < 0) {
                selectedCharacterIndex = characters.Length - 1;
            }
        }

        public CharacterBaseSO CurrentCharacter => characters[selectedCharacterIndex];

    }

}