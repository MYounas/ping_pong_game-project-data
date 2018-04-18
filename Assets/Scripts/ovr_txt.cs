using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ovr_txt : MonoBehaviour {

	public Text win_text;

	void Start () {
		win_text = GetComponent<Text> ();
	}

	void Update () {

		if (Ball_ctrl.pl1_scr == 5)
			win_text.text = "Game Over \n\n\n player 1 WIN!";
		else if (Ball_ctrl.pl2_scr == 5)
			win_text.text = "Game Over \n\n\n player 2 WIN!";;
	}
}
