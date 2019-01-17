using System;
using System.Collections.Generic;
using System.Text;

namespace QuestForTheHolyGrailGame
{
    public class Reaction
    {
        public string text { get; private set; }

        public Reaction(string reactionText)
        {
            this.text = reactionText;
        }
    }
}
