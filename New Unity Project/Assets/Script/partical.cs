using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class partical : MonoBehaviour
{
    public Transform target;
    public float force = 10.0f;

    ParticleSystem part;


    private void Start()
    {
        part = GetComponent<ParticleSystem>();
    }

    private void LateUpdate()
    {
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[part.particleCount];
        
        part.GetParticles(particles);

        //for every particale

        for (int i = 0; i < particles.Length; i++)
        {
            ParticleSystem.Particle p = particles[i];
            
            Vector3 wordPosition;

            if (part.main.simulationSpace == ParticleSystemSimulationSpace.Local)
            {
                wordPosition = transform.TransformPoint(p.position);
            }
            else if (part.main.simulationSpace == ParticleSystemSimulationSpace.Custom)
            {
                wordPosition = part.main.customSimulationSpace.TransformPoint(p.position);
            }
            else
            {
                wordPosition = p.position;
            }

            // to move particales toward the ceinter with force

            Vector3 directiontocenter = (target.position - p.position).normalized;

            Vector3 seekForce = directiontocenter * force * Time.deltaTime;
            p.velocity += seekForce;
            particles[i] = p; 
        }

        part.SetParticles(particles, particles.Length);
    }
}
