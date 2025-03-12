using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(EntityManager))]
[RequireComponent(typeof(PlayerInput))]
public class InputHandler : MonoBehaviour
{
    private EntityManager _entityManager;

    private void Start()
    {
        _entityManager = GetComponent<EntityManager>();
    }

    private void OnMove(InputValue value)
    {
        var direction = value.Get<Vector2>();
        var moveCommand = new MoveCommand(_entityManager.ActiveEntity, direction);

        Invoker.AddCommand(moveCommand);
    }

    private void OnNextPlayer()
    {
        _entityManager.SetNextEntity();
    }

    private void OnUndo()
    {
        Invoker.Undo();
    }

    private void OnRedo()
    {
        Invoker.Redo();
    }
}
