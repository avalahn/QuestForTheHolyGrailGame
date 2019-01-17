using System.Collections.Generic;

namespace QuestForTheHolyGrailGame
{
    public enum StoryEventType { ENCOUNTER, OTHER };
    public class StoryEvent
    {
        public StoryEventType type { get; private set; } = StoryEventType.ENCOUNTER;
        public string text { get; private set; }

        public Reaction reactionA { get; set; }
        public Reaction reactionB { get; set; }
        public Reaction reactionC { get; set; }
        public Reaction reactionD { get; set; }

        public StoryEvent(string eventText)
        {
            this.text = eventText;
        }

        //public void SetReactions(Reaction newReactionA, Reaction newReactionB, Reaction newReactionC, Reaction newReactionD)
        //{
        //    this.reactionA = newReactionA;
        //    this.reactionB = newReactionB;
        //    this.reactionC = newReactionC;
        //    this.reactionD = newReactionD;
        //}
    }
}