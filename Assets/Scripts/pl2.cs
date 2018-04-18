using UnityEngine;
using System.Collections;

public class pl2 : MonoBehaviour {

	public static int choice;public static string level;float i;
	float y;
	public Transform pad2;
	public KeyCode dir_up,dir_down;
	
	void Start () {
		pad2 = GetComponent<Transform> ();
	}
	
	void FixedUpdate ()
	{
		if (choice == 2) {

			if (Input.GetKey (dir_up)) {
				pad2.Translate (Vector3.up * .5f);
			} else if (Input.GetKey (dir_down)) {
				pad2.Translate (Vector3.down * .5f);
			}

			y=pad2.position.y;
			pad2.position = new Vector3 (PingPong(Time.time, -15.3f, -15.5f),y,0);
		}

		if (choice == 1) {

			if(level=="easy")
			{
				i=Random.Range(0f,.12f);
				y=Vector2.Lerp(pad2.position,Ball_ctrl.ball.position,i).y;
			}

			else if(level=="normal")
			{
				i=Random.Range(0f,.18f);
				y=Vector2.Lerp(pad2.position,Ball_ctrl.ball.position,i).y;
			}

			else if(level=="hard")
			{
				y=Ball_ctrl.ball.position.y;
			}

			pad2.position = new Vector3 (PingPong(Time.time, -15.3f, -15.5f),y,0);
		}
	}

	float PingPong(float t, float minLength, float maxLength) {
		return Mathf.PingPong(t, maxLength-minLength) + minLength;
	}
}
