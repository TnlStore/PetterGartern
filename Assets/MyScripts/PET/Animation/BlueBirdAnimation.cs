using UnityEngine;
using System.Collections;

public class BlueBirdAnimation : MonoBehaviour, PetAnimation {

	Animator animator;
	private float animationIdleValue = 1;
	private float speed;
	private Vector3 moveDirection; 

	public float timeMoving;
	public float timeMovingDelay;
	public GameObject startPoint;
	// Use this for initialization
	void Start () {
		initialize ();
		idle ();
	}
	
	// Update is called once per frame
	void Update () {
		moveAround ();
		if(Time.time > timeMoving){
			moveDirection = Utils.randomDirection();
			timeMoving = timeMovingDelay + Time.time;
		}
	}

	// @ Pet.cs : idle()
	public void idle(){
		iTween.MoveBy (gameObject,iTween.Hash("y", 0.2f, "time", 0.5f,  "easeType", iTween.EaseType.linear, "loopType", iTween.LoopType.pingPong));
	}

	public void moveAround(){
		transform.Translate (moveDirection*Time.deltaTime*speed);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Wall")
			Utils.Log ("Bird Touches Wall2");
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Wall") {
			moveDirection = Utils.opositeDirection(moveDirection);
			timeMoving = 0.5f + Time.time;
		}
		if(other.gameObject.tag == "Wall Wrapper"){
			moveDirection = Utils.getDirectionFromTo(gameObject, startPoint);
			timeMoving = 1f + Time.time;
		}
	}


	// *****  Initialize at Start Scene  ******
	private void initialize(){
		animator = gameObject.GetComponent<Animator> ();
		moveDirection = Utils.randomDirection();
		speed = PetConstanst.petDefaultSpeed();
	}


	// **** Animator Controller  ****
	// ******************************

	public void runAngryAnimation(){
		animator.SetBool ("angry", true);
		speed = PetConstanst.petFastSpeed();
		timeMovingDelay = 0.4f;
	}

	public void turnOffAngryAnimation(){
		animator.SetBool ("angry", false);
	}

	public void runSadAnimation(){
		animator.SetBool ("sad", true);
		speed = PetConstanst.petSlowSpeed();
		timeMovingDelay = 3f;
	}

	public void turnOffSadAnimation(){
		animator.SetBool ("sad", false);
	}

	public void runIdleAnimation(){
		reserAnimation ();
		speed = PetConstanst.petDefaultSpeed();
		timeMovingDelay = 1f;
	}

	public void reserAnimation(){
		animator.SetBool ("angry", false);
		animator.SetBool ("sad", false);
	}

}
