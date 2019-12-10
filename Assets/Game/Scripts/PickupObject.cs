using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public Transform playerHandle;
    public Transform playerLHandHandle;
    public Transform playerRHandHandle;
    public Transform playerRightHand;
    bool isPlaying = false;
    GameObject player = null;
    


    private void Update()
    {
        if (player != null)
        {
            if (player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack") && player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 0.3f)
            {
                // audioSrc = this.GetComponent<AudioSource>();
                if (!this.GetComponent<AudioSource>().isPlaying && !isPlaying)
                {
                    isPlaying = true;
                    this.GetComponent<AudioSource>().Play();
                }
                else
                {
                    isPlaying = false;
                }
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.name == "Player")
        {
            player = other.gameObject;

            if (Input.GetButtonDown("Fire1"))
            {
                player.GetComponent<Animator>().SetTrigger("pickUp");
                player.GetComponent<IKControl>().rightHandObj = playerRHandHandle;
                player.GetComponent<IKControl>().leftHandObj = playerLHandHandle;
                player.gameObject.transform.position = playerHandle.position;
                player.gameObject.transform.rotation = playerHandle.rotation;
            }

            if (player.GetComponent<Animator>().GetBool("pickedUp"))
            {
                this.transform.SetParent(playerRightHand);
                this.transform.position = playerRightHand.position;
                this.transform.rotation = playerRightHand.rotation;
            }

        }
    }
}
