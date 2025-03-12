using UnityEngine;

// TODO: Define new health potion type, hereby from HealthPotion (ScriptableObject)
[CreateAssetMenu(fileName = "LUCKYHEALTHPOTION", menuName = "POTIONS/HEALTHPOTION/LUCKYHEALTHPOTION")]
public class LuckyHealthPotion: HealthPotion
{
    // TODO: Add additional variables
    [Range(0,1)]
    public float ExtraProbability;
    public int ExtraAmount;
    // TODO: Define and implement GetHealth(), overrides base class method
    // NOTE: Health ExtraAmount is only added to BaseAmount on (Random.value < ExtraProbability)
     public override int GetHealth()
    {
        if (Random.value > 1 - ExtraProbability)
        {
            Debug.Log("LUCKY!");
            return BaseAmount + ExtraAmount;
        }

        Debug.Log("maybe next time..");
        return BaseAmount;
    }
}