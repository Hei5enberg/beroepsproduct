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
        Debug.Log("Foundplayer: " + arrivedAtPlayer);
        if (arrivedAtPlayer) {
            Debug.Log("Bongo");
            agent.isStopped = true;
        }
        else if (goToPlayer && !arrivedAtPlayer) { 
            Debug.Log("Bingo");
            agent.isStopped = false;
            agent.SetDestination(player.position); 
        }
    }

    void OnTriggerEnter() {
        animator.SetTrigger("Start walking");
        goToPlayer = true;
    }

    void OnTriggerExit() {
        animator.SetTrigger("Stop walking");
        goToPlayer = false;
    }
}
