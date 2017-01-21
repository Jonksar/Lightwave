using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour {

	public ParticleSystem particleSystem;
	public ParticleEmitter emitter;

	public Vector2 emitterPosition;

	void Awake () {
		particleSystem = GetComponent<ParticleSystem>();
		emitter = GetComponent<ParticleEmitter>();
		emitterPosition = emitter.transform.position;
	}

	void LateUpdate() {
		Particle[] particles = emitter.particles;
		int i = 0;
		while (i < particles.Length) {
			float yPosition = Mathf.Sin(Time.time) * Time.deltaTime;
			particles[i].position += new Vector3(0, yPosition, 0);
			particles[i].color = Color.red;
			particles[i].size = Mathf.Sin(Time.time) * 0.2F;
			i++;
		}
		emitter.particles = particles;
	}
}

