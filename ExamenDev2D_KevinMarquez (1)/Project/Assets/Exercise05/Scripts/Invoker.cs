using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoker : MonoBehaviour
{
    public static Invoker Instance;

    private static Queue<ICommand> PendingCommands = new Queue<ICommand>();
    private static List<ICommand> HistoricCommands;

    [SerializeField]
    bool ExecuteInmendiatly;

    static int _currentIndex;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void Update()
    {
        if (ExecuteInmendiatly)
            ExecuteAll();

       
    }


    public static void AddCommand(ICommand command)
    {
        if (PendingCommands == null)
            PendingCommands = new Queue<ICommand>();

        PendingCommands.Enqueue(command);

    }

    public static void ExecuteAll()
    {
        if (HistoricCommands == null)
            HistoricCommands = new List<ICommand>();

        while (PendingCommands.Count>0)
        {
            var command = PendingCommands.Dequeue();
            command.Execute();

            while(HistoricCommands.Count > _currentIndex)
            {
                HistoricCommands.RemoveAt(_currentIndex);
            }

            HistoricCommands.Add(command);
            _currentIndex++;
        }
    }

    public static void Undo()
    {
        if (_currentIndex > 0)
        {
            _currentIndex--;
            HistoricCommands[_currentIndex].Undo();
        }
    }

    public static void Redo()
    {
        if(_currentIndex< HistoricCommands.Count)
        {
            
            HistoricCommands[_currentIndex].Execute();
            _currentIndex++;
        }
       
    }
        
    

}
