using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class make_Transparent_script : MonoBehaviour
{
    [SerializeField]
    GameObject[] transparentObj;

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.name == "Player")
        {
            foreach (var go in transparentObj)
            {
                go.SetActive(false);
            }
        }
        
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.name == "Player")
        {
            foreach (var go in transparentObj)
            {
                go.SetActive(true);
            }
        }
    }


}
