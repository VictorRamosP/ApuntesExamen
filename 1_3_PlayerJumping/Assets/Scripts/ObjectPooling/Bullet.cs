using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    private SpriteRenderer _renderer;

    public void Init(Vector2 velocity, Color color)
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponent<SpriteRenderer>();

        _rigidbody.linearVelocity = velocity;
        _renderer.color = color;
    }

    private void OnBecameInvisible()
    {
        // WARNING: Enable OLD/NEW code as required for testing

        // OLD: NoPoolSpawner: Destroy object when out of visible area
        Destroy(gameObject);

        // NEW: PoolSpawner: "Return" object to pool (deactivate)
        //PoolManager.BackToPool(this.gameObject);
    }
}
