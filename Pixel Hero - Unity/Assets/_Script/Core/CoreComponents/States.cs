using System;
using UnityEngine;

public class States : CoreComponent
{
    [SerializeField] private float maxHealth;
    private float currentHealth;

    public event Action HealthZero;

    [SerializeField] private HealthBar HealthBar;

    public HealthbarEnemy HealthbarEnemy;

    public AudioClip HurtSound;
    public AudioClip HealSound;

    public GameObject[] droppableItems;

    public int minItemsToDrop;
    public int maxItemsToDrop;
    public int maxDistance;

    GameObject itemToDrop;
    int itemsToDrop;

    protected override void Awake()
    {
        base.Awake();

        currentHealth = maxHealth;

        if (HealthBar != null)
        {
            HealthBar.SetMaxHealth(maxHealth);
        }

        if (HealthbarEnemy != null)
        {
            HealthbarEnemy.SetHealth(maxHealth, maxHealth);
        }
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
        SoundManager.instance.PlaySound(HurtSound);

        if (HealthBar != null)
        {
            HealthBar.SetHealth(currentHealth);
        }

        if (HealthbarEnemy != null)
        {
            HealthbarEnemy.SetHealth(currentHealth, maxHealth);
        }

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            HealthZero?.Invoke();
            Debug.Log("Health is zero!!!");
            Die();
            
            if (HealthBar != null)
            {
                HealthBar.SetHealth(0.0f);
                Die();
            }
        }
    }

    public void IncreaseHealth(float amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        SoundManager.instance.PlaySound(HealSound);

        if (HealthBar != null)
        {
            HealthBar.SetHealth(currentHealth);
        }
    }

    public void Die()
    {
        itemsToDrop = UnityEngine.Random.Range(minItemsToDrop, maxItemsToDrop);
        for (int i = 0; i < itemsToDrop; i++)
        {
            DropItem();
        }
    }

    void DropItem()
    {
        itemToDrop = droppableItems[UnityEngine.Random.Range(0, droppableItems.Length)];
        Vector2 offset = UnityEngine.Random.insideUnitCircle * maxDistance;
        Instantiate(itemToDrop, new Vector2(transform.position.x + offset.x, transform.position.y), Quaternion.identity);
    }
}
