using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject Player;
    Transform PT;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        PT = Player.transform;   
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 PlayerPosition_temp = PT.position();
        transform.position = Vector3.Lerp(transform.position, PT.position, 2f * Time.deltaTime);
        transform.Translate(0, 0, -1);     
    }
}
