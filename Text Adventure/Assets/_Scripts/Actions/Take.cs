using UnityEngine;

namespace _Scripts.Actions
{
    [CreateAssetMenu(menuName = "Actions/Take")]
    public class Take : QuestAction
    {
        public override void RespondToInput(GameController controller, string noun)
        {
            if (controller.Location.HasItem(noun))
            {
                foreach (Item item in controller.Location.Items)
                {
                    if (item.Name.ToLower() == noun)
                    {
                        controller.Player.AddToInventory(item);
                        controller.Location.RemoveItem(item);
                        controller.SetCurrentText("You are took the " + noun);
                        return;
                    }
                }
            }

            controller.SetCurrentText("You are can't take that");
        }
    }
}