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
            if(Input.GetButtonDown("Fire1"))
            {
                player = other.gameObject;
                player.GetComponent<Animator>().SetTrigger("pickUp");
                player.GetComponent<IKControl>().rightHandObj = playerRHandHandle;
                player.GetComponent<IKControl>().leftHandObj = playerLHandHandle;
            }

            if(other.GetComponent<Animator>().GetBool("pickedUp"))
            {
                other.gameObject.transform.position = playerHandle.position;
                this.transform.SetParent(playerRightHand);
                this.transform.position = playerRightHand.position;
                this.transform.rotation = playerRightHand.rotation;
            }
        }
    }
}
