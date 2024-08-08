using System.Collections.Generic;
using UnityEngine;

namespace _Scripts.Actions
{
    [CreateAssetMenu(menuName = "Actions/Use")]
    public class Use : QuestAction
    {
        public override void RespondToInput(GameController controller, string noun)
        {
            if (UseItems(controller, controller.Player.Inventory, noun))
                return;

            controller.SetCurrentText("You are haven't " + noun);
        }

        private bool UseItems(GameController controller, List<Item> items, string noun)
        {
            foreach (var item in items)
            {
                if ( item.Name.ToLower() == noun)
                {
                    controller.SetCurrentText("You are using " + item.Name + "\n\n" + item.UsingResult);
                    return true;
                }
            }

            return false;
        }
    }
}