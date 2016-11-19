using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
    public static Hp hpComponent;
    [SerializeField]
    GameObject hpImagePrefab;
    [SerializeField]
    int baseHp;
    [SerializeField]
    int maxHp;
    public Sprite fullHp;
    public Sprite halfHp;
    int hp;
    GameObject[] hpImage;
    int tos;
    bool hitted;

    void Awake()
    {
        hitted = false;
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

    public void LoseHp(bool half)
    {
        if (!Ball.invincible)
        {
            if (half)
            {
                if (!hitted)
                {
                    StopCoroutine(HitCoroutine(hpImage[tos]));
                    StartCoroutine(HitCoroutine(hpImage[tos]));
                }
                else
                {
                    StopCoroutine(HitCoroutine(hpImage[tos]));
                    hitted = false;
                    hpImage[tos].GetComponent<Image>().sprite = fullHp;
                    if (hp > 0)
                    {
                        hpImage[tos].SetActive(false);
                        hp--;
                        tos--;
                    }
                    if (hp <= 0)
                    {
                        MainController.SwitchScene("MainMenu");
                    }
                }
            }
            else
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
    }
    
    IEnumerator HitCoroutine(GameObject obj)
    {
        hitted = true;
        hpImage[tos].GetComponent<Image>().sprite = halfHp;

        yield return new WaitForSeconds(10.0f);

        hitted = false;
        hpImage[tos].GetComponent<Image>().sprite = fullHp;
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
