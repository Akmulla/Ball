using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour 
{
	static int score;
	static Text text;

	void Start () 
	{
		score = 0;
		text.text = score.ToString ();
	}
	
	public static int SetScore
	{
		get
		{
			return score;
		}
		set
		{
			if (value >= 0)
			{
				score = value;
				text.text = score.ToString ();
			}
		}
	}


}
