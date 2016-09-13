using UnityEngine;
using System.Collections;

public class DangerZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Hp.hpComponent.LoseHp();
    }
}
