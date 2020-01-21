using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Eagle : MonoBehaviour
{
    PlayerController PlayerController;
    SpriteRenderer spriteRenderer;

    //이글 스텟
    float eagle_hp;
    float  eagle_speed;
    public float eagle_damage;

    //상태 판정
    public bool canAttack;
    bool isUnbeatTime;

    // Start is called before the first frame update
    void Start()
    {
        eagle_hp = 20;
        eagle_speed = 5;
        eagle_damage = 1;

        PlayerController = GameObject.Find("Character").GetComponent<PlayerController>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //좌측 이동
        transform.Translate(Vector3.left * eagle_speed * Time.deltaTime);

        if(eagle_hp < 0)
        {
            Debug.Log("eagle 사망");
            //eagle 사망 처리
            Destroy(this.gameObject);
        }
    }
    
    //플레이어 공격시 호출
    public void player_hit()
    {
        //(움직이는 값, 길이)
        this.transform.DOMoveX( this.transform.position.x + 2f , 0.5f);
    }

    public void eagle_hit()
    {
        if (isUnbeatTime == false)
        {
            Debug.Log("공격성공");
            this.transform.DOMoveX(this.transform.position.x + 2f, 0.5f);
            this.eagle_hp -= PlayerController.player_dmg;
            isUnbeatTime = true;
            StartCoroutine("UnBeatTime");
        }
    }

    IEnumerator UnBeatTime()
    {
        int countTime = 0;
        
        while(countTime < 4)
        {
            if (countTime % 2 == 0)
            {
                spriteRenderer.color = new Color32(255, 255, 255, 90);
            }
            else
                spriteRenderer.color = new Color32(255, 255, 255, 180);

            countTime++;

            yield return new WaitForSeconds(0.1f);
        }

        spriteRenderer.color = new Color32(255, 255, 255, 255);
        isUnbeatTime = false;

        yield return null;
    }



}
