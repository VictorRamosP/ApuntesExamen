using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Define scriptable object asset
[CreateAssetMenu(fileName = "HEALTHPOTION", menuName = "POTIONS/HEALTHPOTION/HEALTHPOTION")]
public class HealthPotion : ScriptableObject
{
    // TODO: Define required variables
    public int BaseAmount;
    public Sprite Sprite;
    public virtual int GetHealth()
    {
        //int health = 0;

        // TODO: Assign base amount of health

        return BaseAmount;
    }
}
