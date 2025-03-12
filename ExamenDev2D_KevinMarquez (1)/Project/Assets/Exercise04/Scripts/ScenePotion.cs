using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenePotion : MonoBehaviour
{
    [SerializeField]
    HealthPotion HealthPotion;

    private void Start()
    {
        // TODO: Set sprite from SpriteRenderer component to HealthPotion.Sprite
        
        SpriteRenderer  _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = HealthPotion.Sprite;
    }

    private void OnMouseDown()
    {
        // TODO: Show HealthPotion results on HealthText
        // NOTE: HealthText has an static instance available
        
        HealthText.Instance.ShowResult(HealthPotion);
    
    
        
    }
}
