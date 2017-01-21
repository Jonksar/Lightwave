using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour {

	public GameObject leftPivot;
	public GameObject rightPivot;

	private bool leftLastMoved;
	private float moveSpeed = 3.0f;

	// Use this for initialization
	void Start () {
		leftPivot = this.transform.FindChild("LeftPivot").gameObject;
		rightPivot = this.transform.FindChild("RightPivot").gameObject;

		leftLastMoved = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(leftPivot.transform.position, rightPivot.transform.position) < 1.0f) {
			if (leftLastMoved) {
				rightPivot.transform.position = Vector3.MoveTowards (rightPivot.transform.position, leftPivot.transform.position, Time.deltaTime * moveSpeed);
			} else {
				leftPivot.transform.position = Vector3.MoveTowards (leftPivot.transform.position, rightPivot.transform.position, Time.deltaTime * moveSpeed);
			}
		}
	}
}
