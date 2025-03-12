using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class InputHandler : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeColors();
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Invoker.Undo();
        }

        if (Input.GetKeyDown(KeyCode.Y))
        {
            Invoker.Redo();
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Invoker.ExecuteAll();
        }
    }

    private void ChangeColors()
    {
        // TODO: Get an array of 5 ColorEntity array using EntityManager.GetRandomEntities()
        ColorEntity[] entities = EntityManager.GetRandomEntities(5);
        // TODO: Create a new command containing the entities and a random color 
        Color randomColor = GetRandomColor();  
        ICommand changeColorsCommand = new ChangeColorsCommand(entities, randomColor);
        // TODO: Add the command to the Invoker
        Invoker.AddCommand(changeColorsCommand);
    }

    private Color GetRandomColor()
    {
        Color color = new Color();
        color.r = Random.value;
        color.g = Random.value;
        color.b = Random.value;
        color.a = 1;

        return color;
    }
}
