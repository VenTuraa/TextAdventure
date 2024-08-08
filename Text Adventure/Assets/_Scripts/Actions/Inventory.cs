using System.Text;
using UnityEngine;

namespace _Scripts.Actions
{
    [CreateAssetMenu(menuName = "Actions/Inventory")]
    public class Inventory : QuestAction
    {
        public override void RespondToInput(GameController controller, string noun)
        {
            if (controller.Player.Inventory.Count == 0)
            {
                controller.SetCurrentText("You are have nothing!");
                return;
            }

            StringBuilder result = new StringBuilder("You are have ");

            bool first = true;
            foreach (var item in controller.Player.Inventory)
            {
                if (first)
                    result.Append(" a " + item.Name);
                else
                    result.Append(" and a " + item.Name);
                first = false;
            }

            controller.SetCurrentText(result.ToString());
        }
    }
}