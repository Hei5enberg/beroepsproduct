using UnityEngine;
using UnityEngine.AI;

public class WalkToPlayer : MonoBehaviour
{   
    Animator animator;
    InteractWithPlayer interactWithPlayer;

    public GameObject npc;
    public NavMeshAgent agent;
    public Transform player;

    bool goToPlayer = false;
    bool arrivedAtPlayer;
    
    void Start() {
        agent = npc.GetComponent<NavMeshAgent>();
        animator = npc.GetComponent<Animator>();
        interactWithPlayer = npc.GetComponent<InteractWithPlayer>();
    }

    void Update() {
        arrivedAtPlayer = interactWithPlayer.foundPlayer;
        if (arrivedAtPlayer) {
            agent.isStopped = true;
        }
        else if (goToPlayer && !arrivedAtPlayer) { 
            agent.isStopped = false;
            agent.SetDestination(player.position); 
        }
    }

    void OnTriggerEnter() {
        goToPlayer = true;
    }

    void OnTriggerExit() {
        goToPlayer = false;
    }
}
