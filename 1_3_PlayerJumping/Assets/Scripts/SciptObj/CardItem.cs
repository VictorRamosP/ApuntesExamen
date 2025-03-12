using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Item/Card", order = 1)]
public class CardItem : ScriptableObject
{
    public string Name;
    public string Description;
    [Range(0, 50)]
    public int Mana;
    public int Attack;
    public int Health;
    public Sprite Image;

    public void Print()
    {
        Debug.Log(Name + " costs: " + Mana + " Mana.");
    }
}
