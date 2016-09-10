using UnityEngine;
using System.Collections;

public class Edges : MonoBehaviour 
{
	public static float leftEdge,rightEdge,topEdge,botEdge;
    public static float leftWall;
    public static float rightWall;

	void Awake () 
	{
        leftWall = -13.0f;
        rightWall = 13.0f;
        //leftEdge = -10.0f;
        //rightEdge = 10.0f;
        //topEdge = 10.0f;

        /*leftEdge = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x;
        rightEdge = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x;
        topEdge = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y;
        botEdge = Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y;*/
        //Vector3 screenPosition = new Vector3(0, 0, 0);
        //Vector3 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        Vector3 worldPosition = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane + 3.0f));
        leftEdge = worldPosition.x;
        botEdge = worldPosition.y;

        worldPosition = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane + 3.0f));
        rightEdge = worldPosition.x;
        topEdge = worldPosition.y;
    }

	void Update()
	{
        

        
    }
}
