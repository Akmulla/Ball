using UnityEngine;
using System.Collections;

public class Jump : MonoBehaviour
{
    public static Jump jump;
    public float force;
    bool isJumping;
    public GameObject jumpButton;

    void Start()
    {
        jump = this;
        isJumping = false;
        jumpButton.SetActive(false);
    }

    public void GetJump()
    {
        StopCoroutine(GetJumpCoroutine());
        StartCoroutine(GetJumpCoroutine());
    }

    IEnumerator GetJumpCoroutine()
    {
        jumpButton.SetActive(true);
        yield return new WaitForSeconds(10.0f);
        jumpButton.SetActive(false);
    }

    void Update()
    {
        if (isJumping)
            Ball.rb.AddForce(new Vector3(0.0f, 1.0f, 0.0f) * force, ForceMode.Force);
    }

    public void JumpBall()
    {
        if (Ball.ballTransform.position.y < 0.51f)
            StartCoroutine(JumpCoroutine());
    }    

    IEnumerator JumpCoroutine()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.8f);
        isJumping = false;
    }
}
