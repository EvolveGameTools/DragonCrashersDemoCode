using EvolveUI;
using EvolveUI.Attributes;
using System.Collections.Generic;

namespace UI {

    public struct Option<T> {

        public T value;
        public string label;

        public Option(T value, string label) {
            this.value = value;
            this.label = label;
        }

    }

    public class DropdownOptions<T> {

        public IList<Option<T>> list;

        public int Count => list.Count;

        public DropdownOptions() {
            this.list = new List<Option<T>>();
        }

        public DropdownOptions(IList<Option<T>> list) {
            this.list = list;
        }

        public void Add(T value) {
            list.Add(new Option<T>(value, value.ToString()));
        }

        public void Add(T value, string label) {
            list.Add(new Option<T>(value, label));
        }

        public Option<T> this[int index] {
            get => list[index];
            set => list[index] = value;
        }

    }

    // A generically typed dropdown element 
    public class Dropdown<T> : UIElement {

        [ImplicitTemplateArgument] public DropdownOptions<T> options;
        
        // these need to be public because they are referenced by the .ui file 
        public T selectedValue;
        public bool isSelecting; // indicates if the option list is open or not
        public int selectedIndex = -1;
        public string placeholder = "Select...";
        
        private bool updateSelection = true;
        private EqualityComparer<T> equalityComparer;

        public bool ShowingPlaceholder => selectedIndex < 0;
        
        public override void OnCreate() {
            equalityComparer = EqualityComparer<T>.Default;
        }

        // whenever the selected value changes we need to make sure we update our selection 
        [OnPropertyChanged(nameof(selectedValue))]
        public void OnSelectedValueChanged() {
            updateSelection = true;
        }

        // update our selection if needed every frame 
        public override void OnUpdate() {
            if (!updateSelection) {
                return;
            }
            updateSelection = false;
            selectedIndex = -1;
            for (int i = 0; i < options.list.Count; i++) {
                if (equalityComparer.Equals(options.list[i].value, selectedValue)) {
                    selectedIndex = i;
                    break;
                }
            }
        }

        public void SelectItem(int selectedIndex) {
            isSelecting = false;
            this.selectedIndex = selectedIndex;
            selectedValue = options.list[selectedIndex].value;
        }

        // this could have been set in the template file
        // but I wanted to show that you can also handle input events in C#
        [OnMouseClick]
        public void OnClick() {
            isSelecting = true;
        }

    }

}