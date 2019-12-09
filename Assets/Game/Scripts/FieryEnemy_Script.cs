using UnityEngine;
using UnityEngine.AI;

public class FieryEnemy_Script : MonoBehaviour
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
        anim.SetBool("Run Forward", true);
    }
    void Update()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;
        Attack();

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Die") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            anim.SetBool("Die", true);
            this.GetComponent<CapsuleCollider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Weapon"))
        {
            anim.SetBool("Die", true);
        }

        if (col.gameObject.name == "Player")
        {
            anim.SetBool("PrimaryAttack", true);
        }

        if(col.gameObject.name == "EnemyWeapon")
        {
            pickWeapon(col);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            anim.SetBool("PrimaryAttack", false);
        }
        anim.SetBool("TakeDamage", false);

    }
    void Attack()
    {

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("PrimaryAttack") || anim.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            goal = this.gameObject.transform;
        }
    }

    void takehit()
    {
        
        if(hitPoints > 0)
        {
            hitPoints--;
            anim.SetBool("TakeDamage", true);
        }
        else
        {
            anim.SetBool("Die", true);
        }
    }

    void pickWeapon(Collider col)
    {
        Transform[] swordChildren = this.gameObject.GetComponentsInChildren<Transform>();
        foreach (Transform child in swordChildren)
        {
            if (child.gameObject.name == "RightHandAncore")
            {
                col.gameObject.transform.parent = child.gameObject.transform;
                col.gameObject.transform.position = child.gameObject.transform.position;
                col.gameObject.transform.rotation = child.gameObject.transform.rotation;
            }

        }
        col.gameObject.GetComponent<Collider>().enabled = false;
    }
       
}
