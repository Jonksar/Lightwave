using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour, LightInteractive {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public List<LineSegment> Interact(Vector2 origin, RaycastHit2D hit, int maxLevels = 100)
	{		
		Debug.Log ("End");


		Destroy (this.gameObject);
		return new List<LineSegment> ();
	}
}
