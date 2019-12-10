using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball_Script : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        this.gameObject.GetComponent<Rigidbody>().AddForce((player.transform.position - this.transform.position) * 75);
       ///GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject , 2.0f);
        }
    }

}
