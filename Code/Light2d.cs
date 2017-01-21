using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light2d : MonoBehaviour {

    ParticleSystem system;
    ParticleSystem.Particle[] particles;

    //void InitializeIfNeeded()
    //{
    //    if (m_System == null)
    //        m_System = GetComponent<ParticleSystem>();

    //    if (m_Particles == null || m_Particles.Length < m_System.main.maxParticles)
    //        m_Particles = new ParticleSystem.Particle[m_System.main.maxParticles];
    //}

    // Use this for initialization
    void Start () {
        system = GetComponent<ParticleSystem>();
        particles = new ParticleSystem.Particle[system.main.maxParticles];
        Debug.Log(particles);
	}

    //private void LateUpdate()
    //{
    //    InitializeIfNeeded();

    //    // GetParticles is allocation free because we reuse the m_Particles buffer between updates
    //    int numParticlesAlive = m_System.GetParticles(m_Particles);

    //    // Change only the particles that are alive
    //    for (int i = 0; i < numParticlesAlive; i++)
    //    {
    //        m_Particles[i].velocity += Vector3.up * m_Drift;
    //    }

    //    // Apply the particle changes to the particle system
    //    m_System.SetParticles(m_Particles, numParticlesAlive);
    //}

    // Update is called once per frame
    void Update () {
        //ParticleSystem system = GetComponent<ParticleSystem>();
        //Debug.Log(system);
        //Debug.Log(system.particleCount);
        int count = system.GetParticles(particles);
        //Debug.Log(count);
        //Debug.Log(particles.Length);
        //Debug.Log(particles);
        //particleSystem.GetParticles(emittedParticles);
        //system.SetParticles(particles, 10);
        //for (int i = 0; i < count; i++)
        //{
        //    if (particles[i].velocity.y != 0 || particles[i].position.y != 0)
        //    {
        //        ParticleSystem.Particle particle = particles[i];
        //        Vector3 vel = particle.velocity;
        //        vel.y = 0;
        //        particles[i].velocity = vel;

        //        Vector3 pos = particle.position;
        //        pos.y = 0;
        //        particles[i].position = pos;
        //    }
            
        //    if (particles[i].position.y != 0)
        //    {
        //        Debug.Log(particles[i].position.y);
        //    }

        //    system.SetParticles(particles, count);
        //}
    }
}
