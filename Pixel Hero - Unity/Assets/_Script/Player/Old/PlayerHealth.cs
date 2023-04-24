using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    private float currentHealth;

    public HealthBar HealthBar;
    public AudioClip HurtSound;

    [SerializeField]
    private GameObject
        deathBloodParticle;

    private GameManager GM;

    public void Start()
    {
        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);
        //GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        //GM = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(100.0f);
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        HealthBar.SetHealth(currentHealth);
        SoundManager.instance.PlaySound(HurtSound);

        if (currentHealth <= 0.0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(deathBloodParticle, transform.position, deathBloodParticle.transform.rotation);
        Destroy(gameObject);
        GM.Respawn();
        HealthBar.SetMaxHealth(maxHealth);
    }
}
