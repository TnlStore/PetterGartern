using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {
	
	GameObject BottomMenu;
	GameObject Panel;

	void OnEnable(){
		BottomMenu = GameObject.FindGameObjectWithTag("BottomMenu");
		Panel = GameObject.Find("Panel");
	}
	
	// Use this for initialization
	void Start () {
		GameObject.Find (Constants.TAB_STATUS_BT_NAME).GetComponent<TabBottom>().onClickActive();	
		BottomMenu.transform.Find ("UpButton").gameObject.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		checkBottomMenuUI ();
	}

	private void checkBottomMenuUI(){
		if(BottomMenu.transform.position.y<=Constants.BOTTOM_MENU_Y_HIDE)
			BottomMenu.transform.Find ("UpButton").gameObject.SetActive (true);
		else
			BottomMenu.transform.Find ("UpButton").gameObject.SetActive (false);
	}
}
