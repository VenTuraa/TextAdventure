using System;
using UnityEngine;

namespace _Scripts.Actions
{
    public abstract class QuestAction : ScriptableObject
    {
        public string Keyword;
     
        public abstract void RespondToInput(GameController controller, string noun);
    }
}