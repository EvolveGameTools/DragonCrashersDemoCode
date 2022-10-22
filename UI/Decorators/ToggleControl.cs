using EvolveUI;
using EvolveUI.Attributes;

namespace UI {

    // A persistent decorator that adds registration and click handling to 
    // elements which should respond to toggle group behavior
    [Decorator(DecoratorLifeTime.Persistent)]
    public struct ToggleControl {

        private ToggleController controller;

        [OnUpdate]
        public void OnUpdate(UIElement element, UIRuntime runtime) {
            controller ??= runtime.PeekContext<ToggleController>();
            controller.RegisterElement(element);
        }

        [OnMouseClick(EventPhase.AfterUpdate)]
        public void OnClick(UIElement element) {
            controller.Select(element);
        }

    }

}