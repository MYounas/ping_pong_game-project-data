using UnityEngine;
using System.Collections;

public class menu : MonoBehaviour {
	
	public Animator anim_inst,anim_in_inst,anim_mode,anim_levels;

	// Use this for initialization
	void Start()
	{
		anim_inst = GetComponent<Animator> ();
		anim_in_inst = GetComponent<Animator> ();
		anim_mode = GetComponent<Animator> ();
		anim_levels = GetComponent<Animator> ();
		anim_inst.enabled = false;
		anim_in_inst.enabled = false;
		anim_mode.enabled = false;
		anim_levels.enabled = false;
	}

	public void new_game()
	{
		Ball_ctrl.pl1_scr = 0;Ball_ctrl.pl2_scr = 0;
		anim_mode.enabled = true;
		anim_mode.Play ("after_new");
	}

	public void exit()
	{
		Application.Quit();
	}

	public void menu_out()
	{
		anim_inst.enabled = true;
		anim_inst.Play ("panel");
	}
	
	public void menu_in()
	{
		anim_inst.Play ("panel_bk");
	}

	public void abt_des()
	{
		anim_in_inst.enabled = true;
		anim_in_inst.Play ("about");
	}
	
	public void back()
	{
		anim_in_inst.Play ("back_menu");
	}

	public void one_player()
	{
		pl2.choice = 1;
		anim_levels.enabled = true;
		anim_levels.Play ("levels");
	}

	public void two_player()
	{
		pl2.choice = 2;
		Application.LoadLevel ("main_game");
	}

	public void easy()
	{
		pl2.level = "easy";
		Application.LoadLevel ("main_game");
	}

	public void normal()
	{
		pl2.level = "normal";
		Application.LoadLevel ("main_game");
	}

	public void hard()
	{
		pl2.level = "hard";
		Application.LoadLevel ("main_game");
	}

	public void back_modes()
	{
		anim_mode.Play ("after_new_bk");
	}

	public void back_levels()
	{
		anim_levels.Play ("levels_bk");
	}
}
