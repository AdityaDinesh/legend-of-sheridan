using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_ScriptWithoutKey : MonoBehaviour
{

    float time = 0.0f;
    GameObject playerPos;
    [SerializeField]
    GameObject key;
    GameObject Key;
    GameObject doorknob;
    GameObject player;
    Transform playerLeftHandObj;
    bool OpenDoor = false;
    void Start()
    {
        player = GameObject.Find("Player");

        Transform[] doorChildren = this.GetComponentsInChildren<Transform>();

        foreach (Transform child in doorChildren)
        {
            if (child.gameObject.name == "playerPos")
            {
                playerPos = child.gameObject;
            }
            if(child.gameObject.name == "doorKnob")
            {
                doorknob = child.gameObject;
            }
        }
    }

    void Update()
    {
        
        if (player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("openDoor"))
        {
            player.GetComponent<Animator>().SetBool("openDoor", false);
            time += Time.deltaTime;
        }
        if (player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("openDoor") && (time > 1.2 ))
       {
            this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, this.transform.eulerAngles.y + (50 * Time.deltaTime), this.transform.eulerAngles.z);
            OpenDoor = true;
       }

    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.name == "Player")
        {
                col.GetComponent<Animator>().SetBool("openDoor", true);
                this.GetComponent<Collider>().enabled = false;
                col.transform.position = playerPos.transform.position;
                col.transform.rotation = playerPos.transform.rotation;

                Transform[] doorChildren = col.GetComponentsInChildren<Transform>();

                foreach (Transform child in doorChildren)
                {
                    if (child.gameObject.name == "KeyHand")
                    {
                        Key = Instantiate(key);
                        Key.transform.parent = child.transform;
                        Key.transform.position = child.transform.position;
                        Key.transform.rotation = child.transform.rotation;
                    }
                }
        }
    }
}
