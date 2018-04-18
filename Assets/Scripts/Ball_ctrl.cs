using UnityEngine;
using System.Collections;
//using UnityEngine.UI;

public class Ball_ctrl : MonoBehaviour {

//	int num=3;
	public GUISkin theskin;
	public static int pl1_scr=0,pl2_scr=0;float x_vel,y_vel;
	public AudioSource audio_pads,audio_scr;
	public int speed;
	public static Rigidbody2D ball;

	void Start () {
		ball = GetComponent<Rigidbody2D> ();
		StartCoroutine("Wait");
		Time.timeScale = 1;
		//win_text = GetComponent<Text> ();
//		win_text.text = "younas";
	}
	
	//put here unity text file on desktop

	float hitFactor(Vector2 ballPos,Vector2 racketPos,float racketHeight)
	{
		return (ballPos.y - racketPos.y) / racketHeight;
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.tag == "r_pad") 
		{
			audio_pads.Play();
			//calculate hit factor
			float y=hitFactor(ball.position,col.transform.position,col.collider.bounds.size.y);

			// Calculate direction, make length=1 via .normalized
			Vector2 dir=new Vector2(-1,y).normalized;

			// Set Velocity with dir * speed
			ball.velocity = dir * speed;
		}

		else if (col.collider.tag == "l_pad") 
		{
			audio_pads.Play();
			//calculate hit factor
			float y=hitFactor(ball.position,col.transform.position,col.collider.bounds.size.y);

			// Calculate direction, make length=1 via .normalized
			Vector2 dir=new Vector2(1,y).normalized;

			// Set Velocity with dir * speed
			ball.velocity = dir * speed;
		}

		else if (col.collider.tag == "r_wall") {
			audio_scr.Play ();
			Reset ();
			pl2_scr++;
		} 
		else if (col.collider.tag == "l_wall") {
			audio_scr.Play ();
			Reset ();
			pl1_scr++;
		}

	}

	void Reset () {
		ball.position = Vector3.zero;
		ball.velocity = Vector3.zero;
		StartCoroutine("Wait");
		pl1.pad1.position =new Vector3(pl1.pad1.position.x, 0 ,pl1.pad1.position.z);
	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds (3);

		int x = Random.Range (0, 2);
		if (x < 0.5)
		{
			ball.velocity = new Vector2 (speed, 5);
		}
		else
		{
			ball.velocity=new Vector2(speed*-1,5);
		}
	}
	
	void OnGUI()
	{
		GUI.skin = theskin;
		GUI.Label (new Rect (Screen.width/2+75,32, 50,100), pl1_scr.ToString ());
		GUI.Label (new Rect (Screen.width/2-75,32, 50, 100), pl2_scr.ToString ());

		if(GUI.Button(new Rect(Screen.width/2-45,30,115,50),"RESET"))
		   	{
				pl1_scr=0;pl2_scr=0;
				Reset();
			}

		if (GUI.Button (new Rect (Screen.width-110, Screen.height-70, 50, 40), "Back")) {
			Application.LoadLevel ("start_page");

		}

		//win wait
		StartCoroutine ("win_wait");

		if (Time.timeScale==1) 
		{
			if (GUI.Button (new Rect (50, Screen.height-70, 80, 40), "Pause")) 
			{
				Time.timeScale = 0;
			}
		}

		else
		{
			if (GUI.Button (new Rect (50, Screen.height-70,80, 40), "Resume")) 
			{
				Time.timeScale = 1;
			}
		}
//		if (num != 0)
//		{
//			GUI.Label (new Rect (Screen.width / 2, Screen.height / 2, 100, 150), "" + num);
//			num--;
//			StartCoroutine ("start_wait");
//		}
	}

	IEnumerator win_wait()
	{
		if (pl1_scr == 5) {
			scr_img.scr_img_anim.enabled=true;
			yield return new WaitForSeconds(3);
			Application.LoadLevel ("start_page");
		}
		
		else if (pl2_scr == 5) {
			scr_img.scr_img_anim.enabled=true;
			yield return new WaitForSeconds(3);
			Application.LoadLevel ("start_page");
		}
	}

//	IEnumerator start_wait()
//	{
//		yield return new WaitForSeconds(1);
//
//	}


}
