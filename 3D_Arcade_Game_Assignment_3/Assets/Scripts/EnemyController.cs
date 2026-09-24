using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    public Transform player;
    public float chaseDistance = 10f;

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //Debug.Log(agent.isOnNavMesh);
    }

    // Update is called once per frame
    void Update()
    {
        // calculates distance between enemy and player
        float distance = Vector3.Distance(
            transform.position,
            player.position
        );
        // checks if the player is close enough
        if (distance < chaseDistance)
        {
            // move enemy towards player position
            agent.SetDestination(player.position);
        }
    }
}
