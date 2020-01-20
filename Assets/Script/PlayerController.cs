using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{

    //타 스크립트,게임오브젝트 참조 선언
    Eagle Eagle;
    public Animator sword_ani;
    WeaponController WeaponController;

    //상태 BOOL 값
    public bool isBlock;
    public bool isAttacking;
   


    //플레이어 스텟 선언
    float plyayer_speed = 1.0f;
    public float player_dmg = 5.0f;
    float player_defense = 0.5f;
    float attack_cool = 0.6f;
    float attack_timer = 3;

    

    //공격시 호출 "z or 오른쪽 버튼"
    public void PlayerAttack()
    {
        //공격중이 아닐 시 공격 시퀀스
        if (!isAttacking && attack_timer > attack_cool)
        {
            isAttacking = true;
            Debug.Log("공격");
            sword_ani.SetBool("sword_attack", true);
            attack_timer = 0;
        }


        Collider2D[] colls = Physics2D.OverlapBoxAll(transform.position, new Vector2(2, 1), 0);


        foreach(var coll in colls)
        {
            if (coll.gameObject.tag == "enemy_crow")
            {
                Eagle = coll.GetComponent<Eagle>();
                Eagle.eagle_hit();
            }
        }
    }



    //방어시 호출 "x or 왼쪽 버튼"
    public void PlayerDefense()
    {
        sword_ani.SetBool("sword_defense", true);
        isBlock = true;
    }
    
    //방어 종료시 호출
    public void PlayerDefenseEnd()
    {
       sword_ani.SetBool("sword_defense", false);
        isBlock = false;
    }

    //게임 시작시 호출
    void Start()
    {
        //타 게임오브젝트 참조 바인딩
        sword_ani = GameObject.Find("sword").GetComponent<Animator>();
        WeaponController = GameObject.Find("sword").GetComponent<WeaponController>();
        
    }

    // 매 프레임바다 호출
    void Update()
    {
        //플레이어 위치값 보정
       if(this.transform.position.x < -1.72)
        {
            this.transform.Translate(Vector3.right * plyayer_speed * Time.deltaTime);
        }

       //공격 쿨타임 타이머
        attack_timer += Time.deltaTime;
    }
    
    //트리거 관련 함수
    void OnTriggerEnter2D(Collider2D coll)
    {
        //까마귀에 닿았을때
        if (coll.gameObject.tag == "enemy_crow")
        {
            //트리거 들어온 적의 스크립트 가져오기
            Eagle = coll.gameObject.GetComponent<Eagle>();
         
            //방어시
            if (isBlock)
            {
                //(움직이는 값 (적 데미지 + 플레이어 방어력, 길이)
                Debug.Log("방어성공");
                this.transform.DOMoveX(-Eagle.eagle_damage + player_defense, 0.5f);
            }
            //방어 실패시
            else if(!isBlock)
            {
                Debug.Log("피격");
                this.transform.DOMoveX(-Eagle.eagle_damage, 0.5f);
            }

            //까마귀 공격 판정 함수 호출
            Eagle.player_hit();
        }
    }




}
