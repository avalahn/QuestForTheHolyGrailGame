using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;
using QuestForTheHolyGrailGame;

namespace SimpleGameUI
{
    public class StoryEventLayer : CCLayerColor
    {

        private CCLabel eventText;
        private CCLabel reactionHeader;
        private CCMenu reactionMenu;

        private CCMenuItemFont reactionA;
        private CCMenuItemFont reactionB;
        private CCMenuItemFont reactionC;
        private CCMenuItemFont reactionD;

        public StoryEventLayer() : base(new CCColor4B(220, 220, 255))
        {
            // create and initialize children objects
            eventText = new CCLabel("Event text here; \r\nWhile traveling on the road you have an argument about \r\nwhich is most important: Money or Fame. What do you do?", "fonts/MarkerFelt", 22, CCLabelFormat.SpriteFont);
            eventText.Color = CCColor3B.Black;
            reactionHeader = new CCLabel("Choose your reaction:", "fonts/MarkerFelt", 22, CCLabelFormat.SpriteFont);
            reactionHeader.Color = CCColor3B.Black;

            CCMenuItemFont.FontName = "arial";
            CCMenuItemFont.FontSize = 18;

            reactionA = new CCMenuItemFont("A: Reaction 1", OnMenuItemClick);
            reactionB = new CCMenuItemFont("B: Reaction 2", OnMenuItemClick);
            reactionC = new CCMenuItemFont("C: Reaction 3", OnMenuItemClick);
            reactionD = new CCMenuItemFont("D: Reaction 4", OnMenuItemClick);
            reactionA.Color = CCColor3B.Black;
            reactionB.Color = CCColor3B.Black;
            reactionC.Color = CCColor3B.Black;
            reactionD.Color = CCColor3B.Black;

            reactionMenu = new CCMenu(reactionA, reactionB, reactionC, reactionD);
            reactionMenu.AlignItemsVertically(10);

            // add the objects as a children to this Layer
            AddChild(eventText);
            AddChild(reactionHeader);
            AddChild(reactionMenu);

        }

        protected override void AddedToScene()
        {
            base.AddedToScene();

            // Use the bounds to layout the positioning of our drawable assets
            var windowSize = VisibleBoundsWorldspace.Size;

            // position the label on the center of the screen
            eventText.Position = new CCPoint(windowSize.Width / 2, windowSize.Height - 85);
            reactionHeader.Position = new CCPoint(windowSize.Width / 2, 300f);
            reactionMenu.Position = new CCPoint(150f, 200f);

            // Register for events
            var mouseListener = new CCEventListenerMouse();
            mouseListener.OnMouseDown = OnMouseDown;
            AddEventListener(mouseListener, this);
        }

        void OnMenuItemClick(object sender)
        {
            reactionHeader.Text = ((CCMenuItemFont)sender).Label.Text;
        }

        void OnMouseDown(CCEventMouse mouseEvent)
        {
        }

        internal void ShowStoryEvent(StoryEvent storyEvent)
        {
            eventText.Text = storyEvent.text;

            reactionA.Label.Text = "A: " + storyEvent.reactionA.text;
            reactionB.Label.Text = "B: " + storyEvent.reactionB.text;
            reactionC.Label.Text = "C: " + storyEvent.reactionC.text;
            reactionD.Label.Text = "D: " + storyEvent.reactionD.text;
        }
    }
}

