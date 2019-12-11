using UnityEngine;
using UnityEngine.AI;

public class BombMan_Script : MonoBehaviour
{
    public Transform goal;
    AudioSource audioSrc;
    bool isPlaying = false;
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
        Attack();

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
        {
            Destroy(this.gameObject);
        }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.3f)
        {
            audioSrc = this.GetComponent<AudioSource>();
            if(!audioSrc.isPlaying && !isPlaying)
            {
                isPlaying = true;
                audioSrc.Play();
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Weapon"))
        {
            takehit();
        }

        if (col.gameObject.name == "Player")
        {
            anim.SetBool("Attack", true);
            if(!col.GetComponent<Animator>().GetNextAnimatorStateInfo(0).IsName("Die"))
            {
                col.gameObject.GetComponent<PlayerAnimControl>().hitPoints--;
            }
        }

       
    }

    void Attack()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") || anim.GetCurrentAnimatorStateInfo(0).IsName("damage"))
        {
            goal = this.gameObject.transform;

        }
    }

    void takehit()
    {

      
        anim.SetBool("Damage", true);
        this.GetComponent<CapsuleCollider>().enabled = false;
        goal = this.gameObject.transform;
    }
}
