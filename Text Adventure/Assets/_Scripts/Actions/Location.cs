using System.Text;
using UnityEngine;

namespace _Scripts.Actions
{
    [CreateAssetMenu(menuName = "Actions/Location")]
    public class Location: QuestAction
    {
        public override void RespondToInput(GameController controller, string noun)
        {
            if (controller.Location.Items.Count == 0)
            {
                controller.SetCurrentText("There are no items around you!");
                return;
            }


            controller.SetCurrentText(controller.Location.GetItemsText());
        }
    }
}