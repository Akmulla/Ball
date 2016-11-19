using UnityEngine;
using System.Collections;

public class OutsideGate : MonoBehaviour
{
    Pool pool;

    void Start()
    {
        pool = GetComponentInParent<ToPoolOnExit>().pool;
    }

    void OnTriggerEnter(Collider coll)
    {
        pool.Deactivate(transform.parent.gameObject);
        Hp.hpComponent.LoseHp(true);
    }
  
}
