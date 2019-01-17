using System;
using System.Collections.Generic;
using System.Text;

namespace QuestForTheHolyGrailGame
{
    class Game
    {
        public World world { get; private set; }
        public Hero hero { get; private set; }
        public StoryEvent currentEvent;


        public void Run()
        {
            this.world = new World();
            this.hero = new Hero();

            // Generate first game event
            StoryEvent ge = new StoryEvent();
            this.currentEvent = ge;
        }
    }
}
