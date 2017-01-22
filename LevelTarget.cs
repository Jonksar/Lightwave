using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTarget :  MonoBehaviour, LightInteractive {

	public int reachCount = 0;
	public int levelCompleteLimit = 1;
	private bool reachedEnd;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (reachedEnd) {
            GameObject manager = GameObject.FindGameObjectWithTag("LevelManager");
            manager.GetComponent<LevelManager>().NextLevel();
        }
	}

	public void ResetProgress() {
		this.reachCount = 0;
	}

	public List<LineSegment> Interact(Vector2 origin, RaycastHit2D hit, int count)
	{
		reachCount++;
		if (reachCount > levelCompleteLimit) {
			reachedEnd = true;
		}

		return new List<LineSegment> ();
	}

}
