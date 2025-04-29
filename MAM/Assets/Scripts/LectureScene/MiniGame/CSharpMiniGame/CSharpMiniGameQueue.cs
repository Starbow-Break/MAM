using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public static class CSharpMiniGameQueue
{
    public static Queue<EventQueueData> EventQueue = new();
    public static Queue<JudgeQueueData> JudgeQueue = new();
    public static Queue<ANoteUpdater> NoteQueue = new();

    public static void ClearAllQueues()
    {
        EventQueue.Clear();
        JudgeQueue.Clear();
        NoteQueue.Clear();
    }
}
