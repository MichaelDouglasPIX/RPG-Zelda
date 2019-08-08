using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    GameObject playertag;
    Transform player;
    NavMeshAgent nav;
    public bool follow;
    Animator anim;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<NavMeshAgent>();
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {
      nav.SetDestination(player.position); 
    }
}
