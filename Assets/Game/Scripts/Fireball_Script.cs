using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(transform.forward * 8);
        this.gameObject.GetComponent<Rigidbody>().AddRelativeForce(transform.up * -50);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player")
        {

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
