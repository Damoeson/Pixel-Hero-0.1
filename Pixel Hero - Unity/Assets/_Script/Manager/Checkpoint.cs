using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Transform PlayerSpawn;

    private void Awake()
    {
        PlayerSpawn = GameObject.FindGameObjectWithTag("PlayerSpawn").transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("New Checkpoint");
            PlayerSpawn.position = transform.position;
        }
    }
}
