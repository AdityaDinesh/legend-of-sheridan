using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hysterysis : MonoBehaviour
{
    public GameObject DestObj;
    public Animator anim;
    public float kh;    // springyness coeff
    bool picked = false;
    private void Awake()
    {
        anim = this.gameObject.GetComponent<Animator>();
    }
    public void SetTgt(GameObject tgtObj)
    {
        DestObj = tgtObj;
    }
    public void HysteresisUpdate()
    {
        if (DestObj != null)
            this.transform.position += kh * (DestObj.transform.position - this.transform.position);
            //this.transform.position = DestObj.transform.position;
            this.transform.rotation = DestObj.transform.rotation;
    }
    void Update()
    {
        HysteresisUpdate();
    }
    
}
