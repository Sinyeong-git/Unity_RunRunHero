using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    PlayerController PlayerController;
    Eagle Eagle;

    public Animator sword_ani;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController = GameObject.Find("Character").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackEnd()
    {
        Debug.Log("공격종료");
        sword_ani.Play("sword_idle");
        PlayerController.isAttacking = false;
        sword_ani.SetBool("sword_attack", false);
    }

}
