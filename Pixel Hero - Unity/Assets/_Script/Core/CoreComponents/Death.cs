using UnityEngine;

public class Death : CoreComponent
{
    [SerializeField] private GameObject[] deathParticles;

    private States States { get => states ?? core?.GetCoreComponent(ref states); }
    private States states;

    private ParticleManager ParticleManager { get => particleManager ?? core?.GetCoreComponent(ref particleManager); }
    private ParticleManager particleManager;

    public override void Init(Core core)
    {
        base.Init(core);

        States.HealthZero += Die;
    }

    public void Die()
    {
        foreach (var particle in deathParticles)
        {
            ParticleManager.StartParticles(particle);
        }

        core.transform.parent.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (States)
        {
            States.HealthZero += Die;
        }
    }

    private void OnDisable()
    {
        States.HealthZero -= Die;
    }
}
