using EvolveUI;
using EvolveUI.ExecutionGraph;

namespace UI {

    public class ToastElement : UIElement {

        [ImplicitTemplateArgument] public ToastMessageInfo toast;

        private GraphInstance graphInstance;

        public override void OnCreate() {
            // an execution graph can orchestrate actions for one or many elements
            // in this case it's being used to managed removing the toast message after pausing for
            // `duration` milliseconds. 
            
            // these graphs are often used for complex animations or orchestrating animations 
            // across multiple elements. 
            graphInstance = CreateGraph((handle) => {
                Graph.pause(toast.durationMs);
                Graph.run(() => {
                    runtime.GetService<ToastService>().RemoveToast(toast);
                });
            });
        }

        public override void OnUpdate() {
            // we need to tick the graph once per frame 
            graphInstance.Execute();
        }

    }

}