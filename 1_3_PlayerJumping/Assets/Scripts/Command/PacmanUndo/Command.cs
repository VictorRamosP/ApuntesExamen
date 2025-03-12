using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command : ICommand
{
    protected Entity _entity;

    protected Command(Entity entity)
    {
        _entity = entity;
    }

    public abstract void Execute();
    public abstract void Undo();
}
