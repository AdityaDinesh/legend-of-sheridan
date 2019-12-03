using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField]
    GameObject FierySpawnPoint;
    [SerializeField]
    GameObject BombManSpawnPoint;

    [SerializeField]
    GameObject Fiery;
    [SerializeField]
    GameObject BombMan;


    [SerializeField]
    GameObject followPlayer;
    private void Awake()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.name == "SpawnPointTrigger1")
        {
            GameObject goBombMan = (GameObject)Instantiate(BombMan, BombManSpawnPoint.transform.position, BombManSpawnPoint.transform.rotation);
            goBombMan.GetComponent<BombMan_Script>().goal = followPlayer.transform;
        }
        if (this.gameObject.name == "SpawnPointTrigger2")
        {
            GameObject goFiery = (GameObject)Instantiate(Fiery, FierySpawnPoint.transform.position, FierySpawnPoint.transform.rotation);
            goFiery.GetComponent<FieryEnemy_Script>().goal = followPlayer.transform;
        }
        if (this.gameObject.name == "SpawnPointTriggerDragon")
        {
            GameObject goFiery = (GameObject)Instantiate(Fiery, FierySpawnPoint.transform.position, FierySpawnPoint.transform.rotation);
            goFiery.GetComponent<Dragon_Move>().goal = followPlayer.transform;
        }
  
    }
}
