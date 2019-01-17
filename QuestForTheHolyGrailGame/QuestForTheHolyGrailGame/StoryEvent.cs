namespace QuestForTheHolyGrailGame
{
    public enum StoryEventType { ENCOUNTER, OTHER };
    public class StoryEvent
    {
        public StoryEventType type { get; private set; } = StoryEventType.ENCOUNTER;
    }
}