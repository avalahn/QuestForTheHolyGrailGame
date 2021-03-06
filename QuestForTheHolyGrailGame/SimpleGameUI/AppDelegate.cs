﻿using System.Reflection;
using Microsoft.Xna.Framework;
using CocosSharp;
using CocosDenshion;
using QuestForTheHolyGrailGame;
using System.Collections.Generic;
using System;

namespace SimpleGameUI
{
    public class AppDelegate : CCApplicationDelegate
    {
        private StoryEventLayer eventLayer;

        public override void ApplicationDidFinishLaunching(CCApplication application, CCWindow mainWindow)
        {
            application.ContentRootDirectory = "Content";
            var windowSize = mainWindow.WindowSizeInPixels;

            var desiredWidth = 1024.0f;
            var desiredHeight = 768.0f;

            // This will set the world bounds to be (0,0, w, h)
            // CCSceneResolutionPolicy.ShowAll will ensure that the aspect ratio is preserved
            CCScene.SetDefaultDesignResolution(desiredWidth, desiredHeight, CCSceneResolutionPolicy.ShowAll);

            // Determine whether to use the high or low def versions of our images
            // Make sure the default texel to content size ratio is set correctly
            // Of course you're free to have a finer set of image resolutions e.g (ld, hd, super-hd)
            if (desiredWidth < windowSize.Width)
            {
                // application.ContentSearchPaths.Add("hd");  -- Jag tog bort den här mappen, verkar inte behövas
                CCSprite.DefaultTexelToContentSizeRatio = 2.0f;
            }
            else
            {
                // application.ContentSearchPaths.Add("ld");  -- Jag tog bort den här mappen, verkar inte behövas
                CCSprite.DefaultTexelToContentSizeRatio = 1.0f;
            }

            var scene = new CCScene(mainWindow);
            eventLayer = new StoryEventLayer();

            CreateGameData();

            scene.AddChild(eventLayer);

            mainWindow.RunWithScene(scene);
        }

        public override void ApplicationDidEnterBackground(CCApplication application)
        {
            application.Paused = true;
        }

        public override void ApplicationWillEnterForeground(CCApplication application)
        {
            application.Paused = false;
        }

        private void CreateGameData()
        {
            List<StoryEvent> eventList = ContentReader.ReadCsvContent();

            Random rnd = new Random();

            int eventIndex = rnd.Next(0, 7);
            eventLayer.ShowStoryEvent(eventList[eventIndex]);

            //StoryEvent storyevent = new StoryEvent("While tracking in the woods, you notice a deer with a broken leg.");
            //storyevent.reactionA = new Reaction("Try to help the animal");
            //storyevent.reactionB = new Reaction("Put it out of its misery");
            //storyevent.reactionC = new Reaction("We could use more food in our travels");
            //storyevent.reactionD = new Reaction("It would make a fine offering to our gods");

            //eventLayer.ShowStoryEvent(storyevent);
        }
    }
}