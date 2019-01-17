using System;
using System.Collections.Generic;
using System.Text;

namespace QuestForTheHolyGrailGame
{
    public class StoryArc
    {
        public string name { get; private set; }
        public Game game { get; private set; }
        private LinkedList<StoryEvent> storyEvents;
    }
}
