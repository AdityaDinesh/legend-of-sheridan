using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Dragon_Script : MonoBehaviour
{
   // public Transform goal;
    [SerializeField]
    int hitPoints = 2;
    Animator anim;
    [SerializeField]
    GameObject fireBall;
    [SerializeField]
    GameObject player;
    bool isAttack = false;
    int fireBallCount = 0;

    private void Awake()
    {
        anim = this.gameObject.GetComponent<Animator>();
        player = GameObject.Find("Player");

        //fireBall = GameObject.Find("FireBall");
    }
    private void Start()
    {
        anim.SetBool("Fly", true);
    }
    void Update()
    {

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack") && !player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            Attack();

        }
        else
        {
            fireBallCount = 0;
        }

  

                
    }

    //IEnumerator fireBalldelay()
    //{
    //   // yield return new WaitForSeconds(5);

    //}

    //private void OnTriggerEnter(Collider col)
    //{
    //    //isAttack = true;
    //    if (col.gameObject.name == "Player")
    //    {
    //        anim.SetBool("Attack", true);
    //    }

    //}
    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            anim.SetBool("Attack", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("Attack", false);
        // isAttack = false;
    }

    void Attack()
    {
        if(fireBallCount < 1)
        {
            GameObject fireball = (GameObject)Instantiate(fireBall, this.gameObject.transform.position, this.gameObject.transform.rotation);
            fireBallCount++;
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
