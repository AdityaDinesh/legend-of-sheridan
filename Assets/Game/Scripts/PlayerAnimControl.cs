using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimControl : MonoBehaviour
{
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
        if(Input.GetButtonDown("Fire3"))
        {
            playerAnim.SetTrigger("attack");
        }

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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            playerAnim.SetBool("death", true);
        }
    }
}
