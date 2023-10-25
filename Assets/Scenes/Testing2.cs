using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using TMPro;

public class Testing2 : MonoBehaviourPunCallbacks
{
    public TMP_InputField createname;
public TMP_InputField joinename;


public void Create()
{
    PhotonNetwork.CreateRoom(createname.text);

}
public void join()
{
    PhotonNetwork.JoinRoom(joinename.text);
}
public override void OnJoinedRoom()
{
    PhotonNetwork.LoadLevel(2);
}
}
