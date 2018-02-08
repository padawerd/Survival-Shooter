using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {
    
    private Transform playerTransform;
    private PlayerHealth playerHealth;
    private EnemyHealth enemyHealth;
    private UnityEngine.AI.NavMeshAgent nav;


    void Awake ()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        playerHealth = playerTransform.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update ()
    {
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0) {
            nav.SetDestination(playerTransform.position);
        } else {
            nav.enabled = false;
        }
    }
}
