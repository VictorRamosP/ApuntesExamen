using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public CardItem CardItem;

    public TextMeshProUGUI TextName;
    public TextMeshProUGUI TextDescription;
    public TextMeshProUGUI TextMana;
    public TextMeshProUGUI TextAttack;
    public TextMeshProUGUI TextHealth;
    public Image Image;

    void Start()
    {
        SetCard(CardItem);
    }

    void SetCard(CardItem cardItem)
    {
        TextName.text = cardItem.Name;
        TextDescription.text = cardItem.Description;
        TextMana.text = cardItem.Mana.ToString();
        TextAttack.text = cardItem.Attack.ToString();
        TextHealth.text = cardItem.Health.ToString();
        Image.sprite = cardItem.Image;
    }
}
