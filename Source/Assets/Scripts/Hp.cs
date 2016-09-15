using UnityEngine;
using System.Collections;

public class Hp : MonoBehaviour
{
    public static Hp hpComponent;
    [SerializeField]
    GameObject hpImagePrefab;
    [SerializeField]
    int baseHp;
    [SerializeField]
    int maxHp;
    int hp;
    GameObject[] hpImage;
    int tos;

    void Awake()
    {
        hpComponent = this;
        hp = baseHp;
    }

    void Start()
    {
        hpImage = new GameObject[maxHp];
        tos = baseHp-1;
        for (int i = 0; i < maxHp; i++)
        {
            hpImage[i]=(GameObject)Instantiate(hpImagePrefab);
            if (i >= baseHp)
                hpImage[i].SetActive(false);
            hpImage[i].transform.SetParent(transform);
        }
    }

    public void LoseHp()
    {
        if (!Ball.invincible)
        {
            if (hp > 0)
            {
                hpImage[tos].SetActive(false);
                hp--;
                tos--;
            }
            if (hp <= 0)
            {
                //MainController.LoseGame();
            }
        }
    }

    public void GetHp()
    {
        if (hp < maxHp)
        {
            hp++;
            tos++;
            hpImage[tos].SetActive(true);
        }
    }
}
