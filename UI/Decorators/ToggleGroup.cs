using EvolveUI;

namespace UI {

    [Decorator(DecoratorLifeTime.Persistent)]
    public class ToggleGroup {

        public UIElement selectedElement;
        public ToggleController controller;
        
        [RunBinding(BindingEvent.Update)] public int selectedIndex;

        [OnCreate]
        public void Create() {
            controller = new ToggleController();
            controller.onSelected = (el, index) => {
                selectedElement = el;
                selectedIndex = index; 
            };
        }

        [OnUpdate]
        public void Update(UIRuntime runtime) {
            // every frame we push the controller into the context tree
            // this exposes it via runtime.PeekContext() until we pop it again 
            // after the update cycle finishes. 
            runtime.PushContext(controller);
            controller.Setup(selectedIndex);
        }

        [OnPostUpdate]
        public void PostUpdate(UIRuntime runtime) {
            // when this element and all of it's child elements have finished their 
            // update cycles, we pop this controller out of the context stack and 
            // copy out the selected index from the controller
            selectedIndex = controller.selectedIndex;
            runtime.PopContext<ToggleController>();
        }

    }

}