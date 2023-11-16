using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 5, -7);

    // Start is called before the first frame update
    // Start er kalla� fyrir fyrstu rammauppf�rslu
    void Start()
    {
        
    }

    // Update is called once per frame
    // Uppf�rsla er k�llu� einu sinni � hvern ramma
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
