using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    public bool ExecuteImmediate;

    private static Queue<ICommand> CommandQueue;
    private static List<ICommand> CommandHistory;
    private static int _currentIndex;

    void Awake()
    {
        CommandQueue = new Queue<ICommand>();
        CommandHistory = new List<ICommand>();
    }

    void Update()
    {
       if (ExecuteImmediate) ExecuteAll();
    }

    public static void ExecuteAll()
    {
        while (CommandQueue.Count > 0)
        {
            ICommand command = CommandQueue.Dequeue();
            command.Execute();

            CommandHistory.Add(command);
            _currentIndex++;
        }
    }

    public static void AddCommand(ICommand command)
    {
        CommandQueue.Enqueue(command);

        while (CommandHistory.Count > _currentIndex)
        {
            CommandHistory.RemoveAt(_currentIndex);
        }
    }

    public static void Undo()
    {
        if (_currentIndex > 0)
        {
            _currentIndex--;
            CommandHistory[_currentIndex].Undo();
        }
    }

    public static void Redo()
    {
        if (_currentIndex < CommandHistory.Count)
        {
            CommandHistory[_currentIndex].Execute();
            _currentIndex++;
        }
    }
}
