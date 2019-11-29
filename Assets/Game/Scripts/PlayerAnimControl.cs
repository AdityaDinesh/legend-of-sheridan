using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimControl : MonoBehaviour
{
    Animator playerAnim;                        // Player Animator
    float x = 0;                                // Horizontal inputs for the Player from the User
    float y = 0;                                // Vertical inputs for the Player from the User
    void Start()
    {
        playerAnim = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get horizontal and vertical inputs
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        // Set the horizontal and vertical values in the animator
        playerAnim.SetFloat("H", x);
        playerAnim.SetFloat("V", y);
    }
}
