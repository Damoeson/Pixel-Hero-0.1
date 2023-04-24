using UnityEngine;

public class ParticleManager : CoreComponent
{
    // Transform that will be the parent of spawned particles
    private Transform particleContainer;

    protected override void Awake()
    {
        base.Awake();

        // Setting the reference
        particleContainer = GameObject.FindGameObjectWithTag("ParticleContainer").transform;
    }

    public GameObject StartParticles(GameObject particlesPrefab, Vector2 position, Quaternion rotation)
    {
        return Instantiate(particlesPrefab, position, rotation, particleContainer);
    }

    public GameObject StartParticles(GameObject particlesPrefab)
    {
        return StartParticles(particlesPrefab, transform.position, Quaternion.identity);
    }

    public GameObject StartParticlesWithRandomRotation(GameObject particlesPrefab)
    {
        // Generate a random rotation along the z-axis
        var randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));
        // Spawn the particle and return
        return StartParticles(particlesPrefab, transform.position, randomRotation);
    }
}
