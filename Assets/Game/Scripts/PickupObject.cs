using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PickupObject : MonoBehaviour
{
    public Transform playerHandle;
    public Transform playerLHandHandle;
    public Transform playerRHandHandle;
    public Transform playerHand;
    Vector3 position = new Vector3();
    Quaternion rotation = new Quaternion();
    bool isPlaying = false;
    bool isEquipped = false;
    GameObject player = null;

    private void Awake()
    {
        position = this.transform.position;
        rotation = this.transform.rotation;
    }

    private void Update()
    {
        if (player != null && !player.CompareTag("Weapon"))
        {
            if (player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Attack") && player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 0.5f)
            {
                // audioSrc = this.GetComponent<AudioSource>();
                if (!this.GetComponent<AudioSource>().isPlaying && !isPlaying)
                {
                    isPlaying = true;
                    this.GetComponent<AudioSource>().Play();
                }
            }

            else if(player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Shoot") && player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f)
            {
                if (!this.GetComponent<AudioSource>().isPlaying && !isPlaying)
                {
                    isPlaying = true;
                    this.GetComponent<AudioSource>().PlayOneShot(this.GetComponent<AudioSource>().clip);
                }
            }
            else
            {
                isPlaying = false;
            }
        }

        if(Input.GetButtonUp("Jump") && isEquipped)
        {
            player.GetComponent<IKControl>().rightHandObj = null;
            player.GetComponent<IKControl>().leftHandObj = null;
            isEquipped = false;
            this.transform.SetParent(null);
            this.transform.position = position;
            this.transform.rotation = rotation;
        }

        //Debug.Log(position);

    }

    private void OnTriggerStay(Collider other)
    {
        if(other.name == "Player")
        {
            player = other.gameObject;
            if (Input.GetButtonDown("Fire1"))
            {
                player.GetComponent<Animator>().SetTrigger("pickUp");
                if(playerRHandHandle != null)
                {
                    player.GetComponent<IKControl>().rightHandObj = playerRHandHandle;
                }

                if (playerLHandHandle != null)
                {
                    player.GetComponent<IKControl>().leftHandObj = playerLHandHandle;
                }

                player.gameObject.transform.position = playerHandle.position;
                player.gameObject.transform.rotation = playerHandle.rotation;
                isEquipped = true;
            }

            if (player.GetComponent<Animator>().GetBool("pickedUp") && isEquipped)
            {
                this.transform.SetParent(playerHand);
                this.transform.position = playerHand.position;
                this.transform.rotation = playerHand.rotation;
            }

        }
    }
}
