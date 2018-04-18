using UnityEngine;
using System.Collections;

public class scr_img : MonoBehaviour {

	public static Animator scr_img_anim;

	void Start () {
		scr_img_anim = GetComponent<Animator> ();
		scr_img_anim.enabled = false;
	}
}
