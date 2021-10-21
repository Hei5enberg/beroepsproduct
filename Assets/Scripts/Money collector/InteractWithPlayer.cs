using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractWithPlayer : MonoBehaviour
{
    Animator animator;

    public Transform player;
    public UnityEngine.AI.NavMeshAgent agent;
    public GameObject otherCollector;
    public bool foundPlayer = false;

    void Start() {
        animator = GetComponent<Animator>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update() {
        Vector3 targetPostition = new Vector3( player.position.x, 
                                        this.transform.position.y, 
                                        player.position.z ) ;

        if (foundPlayer) {
            transform.LookAt(targetPostition);
        }
    }

    void OnTriggerEnter() {
        otherCollector.SetActive(false);
        foundPlayer = true;
        animator.SetTrigger("Stop walking");
    }
}
