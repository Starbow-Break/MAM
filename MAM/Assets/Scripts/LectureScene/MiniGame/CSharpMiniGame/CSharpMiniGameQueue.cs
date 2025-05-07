using System.Collections.Generic;

public static class CSharpMiniGameQueue
{
    public static Queue<EventQueueData> EventQueue = new();
    public static Queue<JudgeQueueData> JudgeQueue = new();
    public static Queue<ANoteUpdater> NoteQueue = new();
    public static Queue<SoundQueueData> SoundQueue = new();

    public static void ClearAllQueues()
    {
        EventQueue.Clear();
        JudgeQueue.Clear();
        NoteQueue.Clear();
        SoundQueue.Clear();
    }
}