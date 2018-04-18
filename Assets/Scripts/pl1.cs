using UnityEngine;
using System.Collections;

public class pl1 : MonoBehaviour {

	//public ParticleSystem ps;
	float y;
	public static Transform pad1;
	public KeyCode dir_up,dir_down;
	
	void Start () {
		pad1 = GetComponent<Transform> ();
		//ps = GetComponent<ParticleSystem> ();
	}
	
	void FixedUpdate () {
		//ps.enableEmission = false;
		
		if (Input.GetKey (dir_up)) {
			pad1.Translate (Vector3.up*.5f);
		}
		else if (Input.GetKey (dir_down)) {
			pad1.Translate (Vector3.down*.5f);
		}
		
		y = pad1.position.y;
		pad1.position = new Vector3(PingPong(Time.time, 15.5f, 15.3f), y, 0);
	}
	
	float PingPong(float t, float minLength, float maxLength) {
		return Mathf.PingPong(t, maxLength-minLength) + minLength;
	}
}
