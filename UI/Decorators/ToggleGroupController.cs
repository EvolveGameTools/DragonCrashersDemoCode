using System;
using System.Collections.Generic;
using EvolveUI;

namespace UI {

    public class ToggleController {

        public int selectedIndex;
        private List<UIElement> registeredElements;
        public Action<UIElement, int> onSelected;

        public void Setup(int index) {
            registeredElements ??= new List<UIElement>();
            registeredElements.Clear();
            selectedIndex = index;
        }

        public void RegisterElement(UIElement el) {
            registeredElements.Add(el);
            SetupSelectionState(el);
        }

        public void Select(UIElement element) {
            int selectedElementIndex = IndexOf(element);
            if (selectedElementIndex == selectedIndex) {
                return;
            }

            if (selectedIndex > -1 && selectedIndex < registeredElements.Count) {
                registeredElements[selectedIndex].SetAttribute("selected", false);
            }

            element.SetAttribute("selected", true);
            selectedIndex = selectedElementIndex;
        }

        private int IndexOf(UIElement el) {
            for (int index = 0; index < registeredElements.Count; index++) {
                if (registeredElements[index] == el) {
                    return index;
                }
            }

            throw new Exception("You made a mistake");
        }

        private bool SetupSelectionState(UIElement el) {
            bool isSelected = IndexOf(el) == selectedIndex;
            el.SetAttribute("selected", isSelected);
            if (isSelected) {
                onSelected?.Invoke(el, selectedIndex);
            }

            return isSelected;
        }

    }

}