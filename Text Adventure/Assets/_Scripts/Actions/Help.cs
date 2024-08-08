using UnityEngine;

namespace _Scripts.Actions
{
    [CreateAssetMenu(menuName = "Actions/Help")]
    public class Help : QuestAction
    {
        [TextArea]
        public string Description;
        public override void RespondToInput(GameController controller, string noun)
        {
            controller.SetCurrentText(Description);
        }
    }
}