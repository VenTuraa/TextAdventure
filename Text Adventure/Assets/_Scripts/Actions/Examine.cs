using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Actions
{
    [CreateAssetMenu(menuName = "Actions/Examine")]
    public class Examine : QuestAction
    {
        public override void RespondToInput(GameController controller, string noun)
        {
            // check items in room
            if (CheckItems(controller, controller.Location.Items, noun))
                return;

            // check item in inventory
            if (CheckItems(controller, controller.Player.Inventory, noun))
                return;
            
            if (string.IsNullOrEmpty(noun))
            {
                controller.SetCurrentText("You are should type what you want examine ");
            }
            else
            {
                controller.SetCurrentText("You are can't see a " + noun);
            }
        }

        private bool CheckItems(GameController controller, List<Item> items, string noun)
        {
            foreach (Item item in items)
            {
                if (item.Name.ToLower() == noun)
                {
                    controller.SetCurrentText("You are see " + item.Description);

                    return true;
                }
            }

            return false;
        }
    }
}