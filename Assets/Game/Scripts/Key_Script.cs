using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Script : MonoBehaviour
{

    private void OnTriggerEnter(Collider col)
    {
        if(col.name == "Player")
        {
            //col.gameObject.GetComponent<playerScript>().hasKey = true;
            Destroy(this.gameObject);
        }
    }

}
