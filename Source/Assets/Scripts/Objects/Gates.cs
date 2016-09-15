using UnityEngine;
using System.Collections;

public class Gates : MonoBehaviour
{
    public GateDataClass gateData;
    public Transform left;
    public Transform right;
    public BoxCollider boxCollider;
    public AbilityDataClass abilityData;
    public SpriteRenderer spriteRenderer;
    
    public enum Ability { none,x2,x3,x5,x10,Clock,Hp,Shield,Jump,Count};
    delegate void AbilityDelegate();
    AbilityDelegate[] abilityDelegate;
    public Ability activeAbility;

    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        activeAbility = Ability.none;
        abilityDelegate = new AbilityDelegate[(int)Ability.Count];
        abilityDelegate[(int)Ability.none] = AbilityNone;
        abilityDelegate[(int)Ability.x2] = AbilityX2;
        abilityDelegate[(int)Ability.x3] = AbilityX3;
        abilityDelegate[(int)Ability.x5] = AbilityX5;
        abilityDelegate[(int)Ability.x10] = AbilityX10;
        abilityDelegate[(int)Ability.Clock] = Clock;
        abilityDelegate[(int)Ability.Hp] = GetHp;
        abilityDelegate[(int)Ability.Shield] = Shield;
        abilityDelegate[(int)Ability.Jump] = AbilityJump;

    }

    public void SetData(GateDataClass newGateData)
    {
        gateData = newGateData;
        left.localPosition = new Vector3(-gateData.size - GenerateObjects.cylinderRadius,0.0f,0.0f);
        right.localPosition = new Vector3(gateData.size + GenerateObjects.cylinderRadius, 0.0f, 0.0f);
        boxCollider.size = new Vector3(gateData.size+ GenerateObjects.cylinderRadius *2.0f
            ,boxCollider.size.y,boxCollider.size.z);
    }

    public void SetAbility(AbilityDataClass newAbilityData)
    {
        abilityData = newAbilityData;
        activeAbility = abilityData.ability;
        if (abilityData.abilitySprite != null)
            spriteRenderer.sprite = abilityData.abilitySprite;
        else
            spriteRenderer.sprite = null;
    }

    public void GoThroughRing()
    {
        abilityDelegate[(int)activeAbility]();
    }

    void AbilityNone()
    {
        //нихуя
        Score.SetScore += gateData.score;
    }

    void AbilityX2()
    {
        Score.SetScore += gateData.score*2;
    }

    void AbilityX3()
    {
        Score.SetScore += gateData.score * 3;
    }

    void AbilityX5()
    {
        Score.SetScore += gateData.score * 5;
    }

    void AbilityX10()
    {
        Score.SetScore += gateData.score * 10;
    }

    void Clock()
    {
        BallMove.ballMove.SlowDown();
    }

    void GetHp()
    {
        //сердечко
        Hp.hpComponent.GetHp();
    }

    void Shield()
    {
        StartCoroutine(Ball.GetShield());
    }

    void AbilityJump()
    {
        Jump.jump.GetJump();
    }
}
