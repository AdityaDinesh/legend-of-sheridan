using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key_Script : MonoBehaviour
{
    bool isPlaying = false;
    bool hasColided = false;
    float time = 0.0f;

    private void Update()
    {

    }
    private void OnTriggerEnter(Collider col)
    {
        if(col.name == "Player")
        {
           this.GetComponent<AudioSource>().Play();
            col.GetComponent<PlayerAnimControl>().hasKey = true;
            StartCoroutine(waitbeforedestroy());
        }
    }

    IEnumerator waitbeforedestroy()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(this.gameObject);
    }

}
