using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Actions
{
    [CreateAssetMenu(menuName = "Actions/Read")]
    public class Read : QuestAction
    {
    
        public override void RespondToInput(GameController controller, string noun)
        {
            if (ReadItem(controller, controller.Location.Items, noun))
            {
                return;
            }

            if (ReadItem(controller, controller.Player.Inventory, noun))
            {
                return;
            }

            controller.SetCurrentText("You have nothing on " + noun + "to read");
        }

        private bool ReadItem(GameController controller, List<Item> items, string noun)
        {
            foreach (var item in items)
            {
                if (item.Name.ToLower() == noun)
                {
                    controller.SetCurrentText(item.Description);

                    return true;
                }
            }

            return false;
        }
    }
}