using System.Collections.Generic;
using EvolveUI;

namespace UI {

    // this service handles showing temporary messages in the overlay panel 
    public class ToastService : UIService {

        public readonly List<ToastMessageInfo> toastMessages = new List<ToastMessageInfo>();

        private int idGen;

        public void AddToast(string message, int durationMS) {
            toastMessages.Add(new ToastMessageInfo() {
                durationMs = durationMS,
                id = idGen++,
                message = message
            });
        }

        public void RemoveToast(ToastMessageInfo toast) {
            for (int i = 0; i < toastMessages.Count; i++) {
                ToastMessageInfo message = toastMessages[i];
                if (message.id == toast.id) {
                    message.id = -1;
                    toastMessages[i] = message;
                    return;
                }
            }
        }

        // when the frame ends we want to remove any expired messages 
        public override void OnFrameEnd() {
            for (int i = 0; i < toastMessages.Count; i++) {
                if (toastMessages[i].id < 0) {
                    toastMessages.RemoveAt(i);
                }
            }
        }

    }

}