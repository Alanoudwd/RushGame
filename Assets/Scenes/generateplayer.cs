using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class generateplayers : MonoBehaviourPunCallbacks
{
    public float MinX, MaxX, MinZ, MaxZ;
    public GameObject PlayerPrefab;


    void Start()
    {
        Vector3 Places = new Vector3(Random.Range(MinX, MaxX), 2 , Random.Range(MinZ, MaxZ));
        PhotonNetwork.Instantiate(PlayerPrefab.name, Places, Quaternion.identity);
    }

  

}
