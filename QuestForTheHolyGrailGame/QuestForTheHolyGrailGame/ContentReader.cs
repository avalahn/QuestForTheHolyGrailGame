using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace QuestForTheHolyGrailGame
{
    internal class ContentReader
    {
        internal static List<StoryEvent> ReadCsvContent()
        {
            Dictionary<string, StoryEvent> eventList = new Dictionary<string, StoryEvent>();

            Dictionary<string, Reaction> reactionData = ReadCsvReactionList();
            //Dictionary<string, string> reactionMatrix = ReadCsvReactionMatrix();

            string eventPath = "Content/StoryEvent.csv";

            string csvData = File.ReadAllText(eventPath);
            string[] rows = csvData.Split('\n');

            // First row is header row, skip it.
            for (int i = 1; i < rows.Length; i++)
            {
                string row = rows[i];

                if (!string.IsNullOrEmpty(row))
                {
                    string[] data = row.Split(';');
                    string eventName = data[0].Trim();
                    string eventText = data[1].Trim();

                    if (!string.IsNullOrEmpty(eventName) && !string.IsNullOrEmpty(eventText))
                    {
                        eventList.Add(eventName, new StoryEvent(eventText));
                    }
                }
            }


            string matrixPath = "Content/ReactionMatrix.csv";

            csvData = File.ReadAllText(matrixPath);
            rows = csvData.Split('\n');

            // First row is header row, skip it.
            for (int i = 1; i < rows.Length; i++)
            {
                string row = rows[i];

                if (!string.IsNullOrEmpty(row))
                {
                    string[] data = row.Split(';');
                    string eventName = data[0].Trim();
                    string reactionName = data[1].Trim();

                    if (!string.IsNullOrEmpty(eventName) && !string.IsNullOrEmpty(reactionName))
                    {
                        StoryEvent storyEvent = eventList[eventName];
                        Reaction reaction = reactionData[reactionName];
                        storyEvent.allowedReactions.Add(reaction);
                    }
                }
            }

            foreach (StoryEvent storyEvent in eventList.Values)
            {
                storyEvent.SetReactionsFromAllowed();
            }
                

            return new List<StoryEvent>(eventList.Values);
        }

        private static Dictionary<string, Reaction> ReadCsvReactionList()
        {
            Dictionary<string, Reaction> reactionDict = new Dictionary<string, Reaction>();

            string eventPath = "Content/Reaction.csv";

            string csvData = File.ReadAllText(eventPath);
            string[] rows = csvData.Split('\n');

            // First row is header row, skip it.
            for (int i = 1; i < rows.Length; i++)
            {
                string row = rows[i];

                if (!string.IsNullOrEmpty(row))
                {
                    string[] data = row.Split(';');
                    string reactionName = data[0].Trim();
                    string reactionText = data[1].Trim();

                    if (!string.IsNullOrEmpty(reactionName) && !string.IsNullOrEmpty(reactionText))
                        reactionDict.Add(reactionName, new Reaction(reactionText));
                }
            }

            return reactionDict;
        }

        //private static Dictionary<string, string> ReadCsvReactionMatrix()
        //{
        //    Dictionary<string, string> matrix = new Dictionary<string, string>();

        //    string eventPath = "Content/ReactionMatrix.csv";

        //    string csvData = File.ReadAllText(eventPath);
        //    string[] rows = csvData.Split('\n');

        //    // First row is header row, skip it.
        //    for (int i = 1; i < rows.Length; i++)
        //    {
        //        string row = rows[i];

        //        if (!string.IsNullOrEmpty(row))
        //        {
        //            string[] data = row.Split(';');
        //            string eventName = data[0].Trim();
        //            string reactionName = data[1].Trim();

        //            if (!string.IsNullOrEmpty(eventName) && !string.IsNullOrEmpty(reactionName))
        //                matrix.Add(eventName, reactionName);
        //        }
        //    }

        //    return matrix;
        //}
    }
}
