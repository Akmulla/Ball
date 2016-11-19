using UnityEngine;
using System.Collections;

[CreateAssetMenu(fileName = "AbilityData", menuName = "AbilityData", order = 2)]
public class AbilityDataClass : ScriptableObject
{
    public Sprite abilitySprite;
    public Gates.Ability ability;
}
