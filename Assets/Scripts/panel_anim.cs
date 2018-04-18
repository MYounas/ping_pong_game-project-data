using UnityEngine;
using System.Collections;

public class panel_anim : MonoBehaviour {

	private Animator anim;
	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator> ();
		anim.enabled = false;
	}
	
	public void menu_out()
	{
		anim.enabled = true;
		anim.Play ("panel");
	}
	
	public void menu_in()
	{
		anim.Play ("panel_bk");
	}
}
