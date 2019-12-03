using UnityEngine;
using UnityEngine.AI;

public class BombMan_Script : MonoBehaviour
{
    public Transform goal;
    [SerializeField]
    int hitPoints = 2;
    Animator anim;

    private void Awake()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }
    private void Start()
    {
        anim.SetBool("Walk", true);
    }
    void Update()
    {

        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            anim.SetBool("Attack", true);
        }
    }
    void takehit()
    {

        if (hitPoints > 0)
        {
            hitPoints--;
            anim.SetBool("TakeDamage", true);
        }
        else
        {
            anim.SetBool("Die", true);
        }
    }
}
