using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorEntity : MonoBehaviour
{
    public Color GetColor()
    {
        return GetComponent<SpriteRenderer>().color;
    }

    public void SetColor(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
    }
}
