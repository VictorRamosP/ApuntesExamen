using UnityEngine;

public class CreateOrbCommand : ICommand
{
    private Color _color;
    private GameObject _prefab;
    private Vector2 _position;

    public CreateOrbCommand(GameObject prefab, Vector2 position, Color color)
    {
        _color = color;
        _prefab = prefab;
        _position = position;
    }

    public void Execute()
    {
        OrbSpawner.AddOrb(_prefab, _position, _color);
    }

    public void Undo()
    {
        OrbSpawner.RemoveOrb(_prefab, _position, _color);
    }
}
