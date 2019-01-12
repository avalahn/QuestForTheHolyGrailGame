namespace QuestForTheHolyGrailGame
{
    public enum GameEventType { ENCOUNTER, OTHER };
    public class GameEvent
    {
        public GameEventType type { get; private set; } = GameEventType.ENCOUNTER;
    }
}