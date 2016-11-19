using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour 
{
    static public BallMove ballMove;
	static public GameObject ball;
	[SerializeField]
	float startSpeed;
	float speed;
    [SerializeField]
    float minSpeed;
    [SerializeField]
	float maxSpeed;
    Rigidbody rb;
	public Vector3 movement;
    ControlPoint[] controlPoint;
    int currentControlpoint;


    void SetControlPoints()
    {
        controlPoint = new ControlPoint[5];
        controlPoint[0].SetControlPoint(1000, 1);
        controlPoint[1].SetControlPoint(10000, 1);
        controlPoint[2].SetControlPoint(25000, 1);
        controlPoint[3].SetControlPoint(50000, 1);
        controlPoint[4].SetControlPoint(100000, 1);
    }
	void Awake () 
	{
        ballMove = this;
		ball = gameObject;
		speed = startSpeed;
		rb = GetComponent<Rigidbody> ();
		//StartCoroutine (IncreaseByTime ());
		movement = new Vector3 (0, 0, 1);
        SetControlPoints();
        currentControlpoint = 0;
	}

    void Start()
    {
        StartCoroutine(CheckControlPoint());
    }
		
	void Update () 
	{
        //movement.z = 1.0f;
        movement.z = speed;
        rb.velocity = movement;
	}

    IEnumerator CheckControlPoint()
    {
        while (currentControlpoint < controlPoint.Length)
        {
            if (ball.transform.position.z > controlPoint[currentControlpoint].distance)
            {
                Speed += controlPoint[currentControlpoint].acceleration;
                currentControlpoint++;
            }
            yield return new WaitForSeconds(5.0f);
        }
        yield return null;
    }

	public float Speed
	{
		get
		{
			return speed;
		}
		set
		{
			if (speed>maxSpeed)
			{
				speed = value;
			}
            else
                if (speed<minSpeed)
            {
                speed = minSpeed;
            }
            else
            {
                speed = value;
            }
		}
	}
	/// <summary>
	/// Set speed to basic
	/// </summary>
	public void ResetSpeed()
	{
		speed = startSpeed;
	}

	

	//IEnumerator IncreaseByTime()
	//{
	//	while (true)
	//	{
	//		Speed += acceleration;
	//		yield return new WaitForSeconds (1.0f);
	//	}
	//}

    public void SlowDown()
    {
        StartCoroutine(SlowDownCoroutine());
    }

    IEnumerator SlowDownCoroutine()
    {
        BallMove.ballMove.Speed -= 3.0f;
        yield return new WaitForSeconds(10.0f);
        BallMove.ballMove.Speed += 3.0f;
        yield return null;
    }
}

struct ControlPoint
{
    public float distance;
    public float acceleration;

    public void SetControlPoint(float distance, float acceleration)
    {
        this.distance = distance;
        this.acceleration = acceleration;
    }
}
