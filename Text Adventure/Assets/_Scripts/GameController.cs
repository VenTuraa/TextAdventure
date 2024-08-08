using _Scripts.Actions;
using UnityEngine;
using UnityEngine.UI;

namespace _Scripts
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private InputField textEntryField;
        [TextArea] [SerializeField] private string introText;
        [SerializeField] private Text historyText;
        [SerializeField] private Text currentText;
        [SerializeField] private QuestAction[] actions;
        [SerializeField] private Location location;


        public PlayerController Player { get; private set; }

        public Location Location => location;

        private void Awake()
        {
            Player = new PlayerController();

            
            textEntryField.onSubmit.AddListener(delegate { TextEntered(); });
            historyText.text = introText;
            textEntryField.ActivateInputField();
        }

        private void TextEntered()
        {
            SaveCurrentText();
            ProcessInput(textEntryField.text);
            textEntryField.text = "";
            textEntryField.ActivateInputField();
        }

        private void SaveCurrentText()
        {
            historyText.text += "\n\n";
            historyText.text += currentText.text;

            historyText.text += "\n\n";
            historyText.text += "<color=#aaccaaff>" + textEntryField.text + "</color>";
        }

        public void SetCurrentText(string text)
        {
            currentText.text = text;
        }

        private void ProcessInput(string input)
        {
            input = input.ToLower();

            char[] delimiter = {' '};
            string[] separatedWords = input.Split(delimiter);

            foreach (QuestAction action in actions)
            {
                if (action.Keyword.ToLower() == separatedWords[0])
                {
                    if (separatedWords.Length > 1)
                    {
                        var noun = input[(input.IndexOf(delimiter[0]) + 1)..];

                        action.RespondToInput(this, noun);
                    }
                    else
                    {
                        action.RespondToInput(this, "");
                    }

                    return;
                }
            }

            currentText.text = "Nothing happens! (having trouble? type Help)";
        }
    }
}