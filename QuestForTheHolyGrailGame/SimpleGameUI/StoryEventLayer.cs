using System;
using System.Collections.Generic;
using CocosSharp;
using Microsoft.Xna.Framework;

namespace SimpleGameUI
{
    public class StoryEventLayer : CCLayerColor
    {

        CCLabel eventText;
        CCLabel reactionHeader;
        CCMenu reactionMenu;

        public StoryEventLayer() : base(new CCColor4B(220, 220, 255))
        {
            // create and initialize children objects
            eventText = new CCLabel("Event text here; \r\nWhile traveling on the road you have an argument about \r\nwhich is most important: Money or Fame. What do you do?", "fonts/MarkerFelt", 22, CCLabelFormat.SpriteFont);
            eventText.Color = CCColor3B.Black;
            reactionHeader = new CCLabel("Choose your reaction:", "fonts/MarkerFelt", 22, CCLabelFormat.SpriteFont);
            reactionHeader.Color = CCColor3B.Black;

            CCMenuItemFont.FontName = "arial";
            CCMenuItemFont.FontSize = 18;

            CCMenuItemFont item = new CCMenuItemFont("A: Reaction 1", OnMenuItemClick);
            CCMenuItemFont item2 = new CCMenuItemFont("B: Reaction 2", OnMenuItemClick);
            CCMenuItemFont item3 = new CCMenuItemFont("C: Reaction 3", OnMenuItemClick);
            CCMenuItemFont item4 = new CCMenuItemFont("D: Reaction 4", OnMenuItemClick);
            item.Color = CCColor3B.Black;
            item2.Color = CCColor3B.Black;
            item3.Color = CCColor3B.Black;
            item4.Color = CCColor3B.Black;

            reactionMenu = new CCMenu(item, item2, item3, item4);
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
            reactionMenu.Position = new CCPoint(windowSize.Width / 2, 200f);

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
    }
}

