using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    public Transform playerHandle;
    public Transform playerLHandHandle;
    public Transform playerRHandHandle;
    public Transform playerRightHand;


    GameObject player;


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
