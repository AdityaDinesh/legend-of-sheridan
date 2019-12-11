using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RideScript : MonoBehaviour
{
    public Transform playerHandle;
    public Transform playerLeftHandHandle;
    public Transform playerRightHandHandle;
    public Transform playerLeftLegHandle;
    public Transform playerRightLegHandle;
    bool isRiding = false;
    public float speed = 0;
    public float torque = 0;
    protected float x = 0;
    protected float y = 0;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isRiding)
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");

            rb.velocity = transform.forward * y * speed;
            this.transform.Rotate(0.0f, x * torque, 0.0f);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.name == "Player")
        {
            if (Input.GetButtonDown("RB"))
            {
                if (!isRiding)
                {
                    other.GetComponent<Animator>().SetBool("ride", true);
                    if (playerLeftHandHandle != null)
                    {
                        other.GetComponent<IKControl>().leftHandObj = playerLeftHandHandle;
                    }

                    if (playerRightHandHandle != null)
                    {
                        other.GetComponent<IKControl>().rightHandObj = playerRightHandHandle;
                    }

                    if (playerLeftLegHandle != null)
                    {
                        other.GetComponent<IKControl>().leftLegObj = playerLeftLegHandle;
                    }

                    if (playerRightLegHandle != null)
                    {
                        other.GetComponent<IKControl>().rightLegObj = playerRightLegHandle;
                    }

                    other.transform.SetParent(this.transform);
                    other.gameObject.transform.position = playerHandle.position;
                    other.gameObject.transform.rotation = playerHandle.rotation;

                    other.GetComponent<Hysterysis>().enabled = true;
                    other.GetComponent<Rigidbody>().isKinematic = true;

                    isRiding = true;
                }
                else
                {
                    other.GetComponent<Animator>().SetBool("ride", false);
                    other.GetComponent<IKControl>().rightHandObj = null;
                    other.GetComponent<IKControl>().leftHandObj = null;
                    other.GetComponent<IKControl>().leftLegObj = null;
                    other.GetComponent<IKControl>().rightLegObj = null;
                    other.transform.SetParent(null);

                    other.GetComponent<Hysterysis>().enabled = false;
                    other.GetComponent<Rigidbody>().isKinematic = false;


                    isRiding = false;
                }
            }
        }
    }
}
