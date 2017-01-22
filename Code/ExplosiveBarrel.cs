using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBarrel : MonoBehaviour, LightInteractive {

	public GameObject explosion;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public List<LineSegment> Interact(Vector2 origin, RaycastHit2D hit, int maxLevels = 100)
	{		
		Debug.Log ("End");

		this.gameObject.GetComponent<SpriteRenderer> ().enabled = false;
		doExplosion (this.transform.position);
		Destroy (this.gameObject);
		return new List<LineSegment> ();
	}

	private void doExplosion(Vector3 location, string animation = "explosionanimation")
	{
		GameObject expl = Instantiate(explosion);
		expl.transform.position = location;
		expl.GetComponent<Animator>().Play(animation);
		Destroy(expl, expl.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
	}
}
