using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public GameObject carryingObject;
	public AudioClip mirrorCarrying;
	public AudioClip smthCarrying;

	private bool isCarrying;
	private bool newIsCarrying;
	private float curSpeed;
	private float normalMoveSpeed = 4f;
	private float carryingMoveSpeed = 2f;
	private SpriteRenderer renderer;
	private AudioSource SFX;

	// Use this for initialization
	void Start () {
		isCarrying = false;
		renderer = gameObject.GetComponent<SpriteRenderer> ();
		SFX = gameObject.GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log (isCarrying); 
		// Player moves towards the mouse
		Vector3 targetPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		if ((targetPos - transform.position).x > 0) {
			this.renderer.flipX = false;
		} else {
			this.renderer.flipX = true;
		}
		targetPos.z = transform.position.z;

		transform.position = Vector2.MoveTowards (transform.position, targetPos, curSpeed * Time.deltaTime);

		// Move the object towards you if mouse is down && carryingObject
		if (Input.GetMouseButton (0) && carryingObject != null && carryingObject.tag != "World") {
			newIsCarrying = true;
			this.curSpeed = carryingMoveSpeed;
		} else {
			newIsCarrying = false;
			curSpeed = normalMoveSpeed;
			this.SFX.Stop ();
		}


		if (newIsCarrying != isCarrying) {
			if (newIsCarrying) {
				this.SFX.Play ();
			} else {
				this.SFX.Stop ();
			}
		}

		isCarrying = newIsCarrying;
		if (isCarrying) {
			carryingObject.transform.position = Vector3.MoveTowards (carryingObject.transform.position, this.transform.position, curSpeed * 2f * Time.deltaTime);
		}

	}

	void OnTriggerEnter2D(Collider2D other) {
		if ((!Input.GetMouseButton (0) || carryingObject != null) && other.gameObject.tag != "World" && other.gameObject.tag != "Ignore") {
			Debug.Log (other.gameObject.tag);
			carryingObject = other.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (carryingObject == other.gameObject && !Input.GetMouseButton(0)) {
			carryingObject = null;
		}
	}
}