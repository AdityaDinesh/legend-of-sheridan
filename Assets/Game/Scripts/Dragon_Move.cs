using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dragon_Move : MonoBehaviour
{
    public Transform goal;
    [SerializeField]
    int hitPoints = 2;
    public Animator anim;

    void Update()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Weapon")
        {
            Transform[] child = GetComponentsInChildren<Transform>();
            foreach (var transform in child)
            {
                if(transform.GetComponent<Animator>())
                {
                    transform.GetComponent<Animator>().SetBool("Die", true);
                    this.GetComponent<AudioSource>().Play();
                    Destroy(this.gameObject, 1);
                    break;
                }
            }
        }
    }
}
