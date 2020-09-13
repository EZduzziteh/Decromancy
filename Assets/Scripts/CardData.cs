using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Create New Card", order = 1)]
public class CardData : ScriptableObject
{
    public enum CardType
    {
        Horde, Power, Location
    }
    [SerializeField]
    [Tooltip("The sprite that should be displayed as the face of this card")]
    Sprite CardFace;

    [SerializeField]
    [Tooltip("The displayed name of the card in hand")]
    string CardName;

    [SerializeField] 
    [Tooltip("add any abilities the card should have.")]
    List<CardAbility> Abilities=new List<CardAbility>();

    
    [SerializeField]
    [Tooltip("Leave at 0 for non-horde cards")]
    int BaseAttack;

    [SerializeField]
    [Tooltip("low end of the die modifier")]
    int AttackVarianceMin;
    [SerializeField]
    [Tooltip("high end of the die modifier")]
    int AttackVarianceMax;

    [SerializeField] 
    [Tooltip("Leave at 0 for non-horde cards")]
    int Health;
    [SerializeField]
    [Tooltip("Leave at 0 for non-horde cards")]
    int CurrentHealth;

    public CardType cardtype;
    
    
    public int GetAttackDamage()
    {
        int damage = BaseAttack;
        damage += Random.Range(AttackVarianceMin, AttackVarianceMax);
        return damage;
    }

    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;

    }
    public int GetHealth()
    {
        return CurrentHealth;
    }
    public void ResetCurrentHealth()
    {
        CurrentHealth = Health;
    }
    
}
