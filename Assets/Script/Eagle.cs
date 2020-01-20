using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Eagle : MonoBehaviour
{
    PlayerController PlayerController;
    SpriteRenderer spriteRenderer;

    //이글 스텟
    float eagle_hp = 10;
    float  eagle_speed = 5;
    public float eagle_damage = 4;

    //상태 판정
    public bool canAttack;
    bool isUnbeatTime;

    // Start is called before the first frame update
    void Start()
    {

        PlayerController = GameObject.Find("Character").GetComponent<PlayerController>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
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
        this.transform.DOMoveX(1, 0.5f);
    }

    public void eagle_hit()
    {
        Debug.Log("공격성공");
        this.transform.DOMoveX(2, 0.5f);
        this.eagle_hp -= PlayerController.player_dmg;
        isUnbeatTime = true;
        StartCoroutine("UnBeatTime");
    }

    IEnumerator UnBeatTime()
    {
        int countTime = 0;
        
        while(countTime < 5)
        {
            if (countTime % 2 == 0)
            {
                spriteRenderer.color = new Color32(255, 255, 255, 90);
            }
            else
                spriteRenderer.color = new Color32(255, 255, 255, 180);

            yield return new WaitForSeconds(0.2f);

            countTime++;
        }

        spriteRenderer.color = new Color32(255, 255, 255, 255);
        isUnbeatTime = false;

        yield return null;
    }



}
