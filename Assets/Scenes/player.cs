using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player  : MonoBehaviour
{

    public Rigidbody rb;
public PhotonView view;

// Start is called before the first frame update
void Start()
{
    rb = GetComponent<Rigidbody>();
    view = GetComponent<PhotonView>();
}

// Update is called once per frame
void Update()
{
    if (view.IsMine)
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), -0.5f, Input.GetAxis("Vertical"));
        rb.velocity = movement * 5;
    }
}
}


   