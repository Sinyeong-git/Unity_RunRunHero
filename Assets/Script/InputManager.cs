using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InputManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    PlayerController PlayerController;

    bool check;

    void Start()
    {
        PlayerController = GameObject.Find("Character").GetComponent<PlayerController>();
    }

    void Update()
    {
        
        if (check)
        {
            PlayerController.PlayerDefense();
            PlayerController.isBlock = true;
        }
        if(Input.GetKey(KeyCode.X))
        {
            check = true;
        }
        
        
        if (!check)
        {
            PlayerController.PlayerDefenseEnd();
            PlayerController.isBlock = false;
        }
        

        if(Input.GetKeyUp(KeyCode.X))
        {
            check = false;
        }


        if (Input.GetKey(KeyCode.Z))
        {
            PlayerController.PlayerAttack();
        }
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        check = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        check = false;
    }



}
