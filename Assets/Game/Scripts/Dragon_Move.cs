using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dragon_Move : MonoBehaviour
{
    public Transform goal;
    [SerializeField]
    int hitPoints = 2;
    Animator anim;

    private void Awake()
    {
      //  anim = this.gameObject.GetComponent<Animator>();
    }
    private void Start()
    {
       // anim.SetBool("Walk", true);
    }
    void Update()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }
}
