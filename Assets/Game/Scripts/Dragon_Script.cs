﻿using System.Collections;
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
    bool isAttack = false;
    int fireBallCount = 0;

    private void Awake()
    {
        anim = this.gameObject.GetComponent<Animator>();
        //fireBall = GameObject.Find("FireBall");
    }
    private void Start()
    {
        anim.SetBool("Fly", true);
    }
    void Update()
    {

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            Attack(); 
        }
        else
        {
            fireBallCount = 0;
        }

        
    }

    private void OnTriggerEnter(Collider col)
    {
         isAttack = true;

        if (col.gameObject.name == "Player")
        {
            anim.SetBool("Attack", true);
        }
    
    }
    private void OnTriggerExit(Collider other)
    {
        isAttack = false;
    }
    void Attack()
    {
        if(fireBallCount < 1)
        {
            GameObject fireball = (GameObject)Instantiate(fireBall, this.gameObject.transform.position, this.gameObject.transform.rotation);
            fireball.gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3 (0,0,500));
            fireball.gameObject.GetComponent<Rigidbody>().AddRelativeForce(this.transform.up * -80);
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
