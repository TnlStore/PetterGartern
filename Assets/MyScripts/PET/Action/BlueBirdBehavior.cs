using UnityEngine;
using System.Collections;

public class BlueBirdBehavior : MonoBehaviour {

	public GameObject statusBarController;
	public GameObject birdAnimation;

	private float health_value;
	private float happy_value;
	private float clean_value;
	private float hungry_value;
	private float sleepy_value;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		doStatusConnect ();
		statusReacting ();
	}

	private void doStatusConnect(){
		health_value = statusBarController.GetComponent<StatusBarController> ()
									.getStatusValue (StatusBarController.STATUS_HEALTH_KEY);
		happy_value = statusBarController.GetComponent<StatusBarController> ()
									.getStatusValue (StatusBarController.STATUS_HAPPY_KEY);
		clean_value = statusBarController.GetComponent<StatusBarController> ()
									.getStatusValue (StatusBarController.STATUS_CLEAN_KEY);
		hungry_value = statusBarController.GetComponent<StatusBarController> ()
									.getStatusValue (StatusBarController.STATUS_HUNGRY_KEY);
		sleepy_value = statusBarController.GetComponent<StatusBarController> ()
									.getStatusValue (StatusBarController.STATUS_SLEEPY_KEY);
	}		

	private bool isHealthy(){
		return (health_value > 0.5f
						&& happy_value > 0.5f
						&& clean_value > 0.5f
						&& hungry_value > 0.5f
						&& sleepy_value > 0.5f);
	}
	
	private void statusReacting(){
		if(hungry_value<0.5f)
			birdAnimation.GetComponent<BlueBirdAnimation>().runAngryAnimation();
		else
			birdAnimation.GetComponent<BlueBirdAnimation>().turnOffAngryAnimation();
		if(happy_value<0.5f)
			birdAnimation.GetComponent<BlueBirdAnimation>().runSadAnimation();
		else
			birdAnimation.GetComponent<BlueBirdAnimation>().turnOffSadAnimation();
		if(isHealthy())
			birdAnimation.GetComponent<BlueBirdAnimation>().runIdleAnimation();
	}
}
