using UnityEngine;

internal class ChangeColorsCommand : ICommand
{
    private ColorEntity[] entities;
    private Color col;
    private Color[] oldColors;

    public ChangeColorsCommand(ColorEntity[] entities, Color col)
    {
        this.entities = entities;
        this.col = col;
    }

    public void Execute()
    {
        // TODO: Store the oldColors and set the new color to all entities in the array
        oldColors = new Color[entities.Length];
        for (int i = 0; i < entities.Length; i++)
        {
            oldColors[i] = entities[i].GetColor();
        }

        for (int i = 0; i < entities.Length; i++)
        {
            entities[i].SetColor(col);
        }
    }

    public void Undo()
    {
        // TODO: Restore oldColors to all entities in the arrray
         for (int i = 0; i < entities.Length; i++)
        {
            entities[i].SetColor(oldColors[i]);
        }
    }
}