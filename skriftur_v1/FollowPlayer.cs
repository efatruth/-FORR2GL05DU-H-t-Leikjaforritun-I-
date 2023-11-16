using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 5, -7);

    // Start is called before the first frame update
    // Start er kallað fyrir fyrstu rammauppfærslu
    void Start()
    {
        
    }

    // Update is called once per frame
    // Uppfærsla er kölluð einu sinni í hvern ramma
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
