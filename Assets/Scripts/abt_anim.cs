using UnityEngine;
using System.Collections;

public class abt_anim : MonoBehaviour {

	private Animator anim;
	// Use this for initialization
	void Start()
	{
		anim = GetComponent<Animator> ();
		anim.enabled = false;
	}

	public void abt_des()
	{
		anim.enabled = true;
		anim.Play ("about");
	}

	public void back()
	{
		anim.Play ("back_menu");
	}
}
