using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure_Chest_script : MonoBehaviour
{
    [SerializeField]
    GameObject key;
    private void Awake()
    {
        
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.name == "2H_Sword")
        {
            Destroy(this.gameObject);
            Instantiate(key , this.gameObject.transform.position, this.gameObject.transform.rotation);
        }
    }

}
