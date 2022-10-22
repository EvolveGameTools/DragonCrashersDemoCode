using EvolveUI;

namespace UI {

    public class Icon : UIElement {

        [ImplicitTemplateArgument] public ImageSource src;
        public UIMeasurement? size;
        
        private ImageSource _src;
        
        // if we had an icon change, look up the texture to display
        // if the texture is missing we display the not_found icon
        public override void OnUpdate() {
            if (src != _src) {
                if (src.texture == default && src.textureInfo == default) {
                    src = runtime.GetTextureInfo("not_found");
                }
                _src = src;
                style.SetBackgroundImage(_src);
            }

            // if a size was provided as an input we set the size to that
            if (size != null) {
                style.SetPreferredWidth(size.Value);
                style.SetPreferredHeight(size.Value);
            }
            
        }

    }
}