using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if(other.name == "Player")
        {
            if(Input.GetButtonDown("Fire1"))
            {
                other.GetComponent<Animator>().SetTrigger("pickUp");
            }
        }
    }
}
