using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimControl : MonoBehaviour
{
    public GameObject arrowhandle;
    GameObject arrow;
    Animator playerAnim;                        // Player Animator
    float x = 0;                                // Horizontal inputs for the Player from the User
    float y = 0;                                // Vertical inputs for the Player from the User

    public bool hasKey = false;
    void Start()
    {
        playerAnim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Skybox Rotator
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * 1.0f);

        // Get horizontal and vertical inputs
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        // Set the horizontal and vertical values in the animator
        playerAnim.SetFloat("H", x);
        playerAnim.SetFloat("V", y);

        // Attack
        if(Input.GetButtonDown("Fire3") && playerAnim.GetBool("pickedUp"))
        {
            playerAnim.SetTrigger("attack");
        }

        // Shoot
        if(Input.GetButtonDown("Fire2") && playerAnim.GetBool("pickedUp"))
        {
            playerAnim.SetTrigger("shoot");
        }

        // Death
        if(playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Die"))
        {
            playerAnim.SetBool("death", false);
        }
    }

    void grabObject()
    {
        GetComponent<Animator>().SetBool("pickedUp", true);
        GetComponent<IKControl>().ikActive = true;
    }

    void createArrow(GameObject obj)
    {
       arrow = Instantiate(obj, arrowhandle.transform.position, arrowhandle.transform.rotation);
       arrow.transform.SetParent(arrowhandle.transform);
    }

    void releaseArrow()
    {
       arrow.transform.SetParent(null);
       arrow.GetComponent<Rigidbody>().isKinematic = false;
       arrow.GetComponent<Rigidbody>().useGravity = true;
       //arrow.GetComponent<BoxCollider>().enabled = true;
       arrow.GetComponent<Rigidbody>().AddForce(transform.forward * 3000);
       arrow.GetComponent<Rigidbody>().AddForce(transform.up * 1000);
        Destroy(arrow, 1.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            playerAnim.SetBool("death", true);
        }
    }
}
