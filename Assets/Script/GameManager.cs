using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Eagle_prefab;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
       timer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 5)
        {
            Instantiate(Eagle_prefab, new Vector3(10, -1.34f, 0), Quaternion.identity);
            timer = 0;
        }

        
    }
}
