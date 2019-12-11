using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public SceneAsset scene;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Player" && scene != null)
        {
            this.GetComponent<AudioSource>().Play();
            SceneManager.LoadScene(scene.name);
        }
    }
}
