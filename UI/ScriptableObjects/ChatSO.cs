using UnityEngine;

namespace UI
{
    [CreateAssetMenu(fileName = "Assets/Resources/GameData/Chat/ChatMessages", menuName = "UIToolkitDemo/ChatMessage", order = 6)]
    public class ChatSO : ScriptableObject
    {
        public string chatname;

        public string message;


    }
}
