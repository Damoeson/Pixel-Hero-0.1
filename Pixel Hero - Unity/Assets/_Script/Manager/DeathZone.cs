using System.Collections;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private States States { get => states ?? core?.GetCoreComponent(ref states); }
    private States states;

    private Transform PlayerSpawn;
    private Animator fadeSystem;
    private PlayerHealth PH;

    public Collider2D Triggercollider2D;

    private Core core;


    private void Awake()
    {
        PlayerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
        fadeSystem = GameObject.FindGameObjectWithTag("FadeSystem").GetComponent<Animator>();
        core = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Core>();
        Triggercollider2D = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        //core = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Core>();
        //Triggercollider2D = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D Triggercollider2D)
    {
        if (Triggercollider2D.CompareTag("Player"))
        {
            StartCoroutine(ReplacePlayer(Triggercollider2D));
        }
    }

    private IEnumerator ReplacePlayer(Collider2D Triggercollider2D)
    {
        fadeSystem.SetTrigger("FadeIn");
        yield return new WaitForSeconds(1f);
        States.DecreaseHealth(5f);
        Triggercollider2D.transform.position = PlayerSpawn.position;
    }
}
