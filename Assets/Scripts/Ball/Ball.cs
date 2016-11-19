using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
    public static bool invincible;
    public static Rigidbody rb;
    public static Transform ballTransform;

    void Start()
    {
        ballTransform = transform;
        rb = GetComponent<Rigidbody>();
        invincible = false;
    }

    public static IEnumerator GetShield()
    {
        invincible = true;
        yield return new WaitForSeconds(10.0f);
        invincible = false;
    }
}
