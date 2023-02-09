using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMove : MonoBehaviour
{
    public float AntSpeed = 200f;
    public bool isDie = false;
    public bool BackPos = false;

    #region Player's component
    private Rigidbody2D AntRigid = default;
    private Animator AntAni = default;
    #endregion

    // 케이크 위치 확인
    Vector3 cakePos = new Vector3(562f, -210f, 0f);
    Vector3 targetPos = new Vector3();

    // 개미 굴 위치 확인
    Vector3 antHollPos = new Vector3(-560f, 420f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        AntRigid = gameObject.GetComponent<Rigidbody2D>();
        AntAni = transform.GetComponent<Animator>();



    }
    public void OnEnable()
    {
        StartCoroutine(targetPosRandomCh());
        isDie = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isDie == false)
        {
            antMove();
        }
    }

    public void antMove()
    {
        // 케이크포지션을 랜덤으로 확인하기


        // 개미가 지정된 위치값에서 나와서 움직인다.(케이크 위치로)
        Vector3 pos = Vector3.MoveTowards(transform.localPosition, targetPos, Time.deltaTime * AntSpeed);
        transform.localPosition = pos;
        transform.LookAt2D(targetPos, 10f);

        if (BackPos == false)
        {
            if (transform.localPosition == cakePos)
            {
                // GFunc 에서 최상위 오브젝트를 찾고, 자식오브젝트를 찾아서 비활성화를 한다.(케이크 비활성화)
                GameObject cake = GFunc.GetRootObj("GameObject").FindChildObj("CakeImage");
                if (cake.activeSelf == true)
                {
                    // 개미의 케이크가 활성화한다.
                    GameObject AntCake = transform.GetChild(0).gameObject;
                    AntCake.SetActive(true);
                    cake.SetActive(false);
                }


                // 케이크에 도착했을때
                BackPos = true;
            }
        }
        else
        {
            if (transform.localPosition == antHollPos)
            {
                // 개미, 케이크가 없어진다.
                ObjectPoollingManager.Instance.PoolPush(gameObject);
            }
        }



    }

    // targetPos를 일정 시간마다 1번씩 랜덤으로 바꾼다.
    IEnumerator targetPosRandomCh()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);

            int randomNm = Random.Range(0, 5);

            // 랜덤 생성
            switch (randomNm)
            {
                case 0:
                    if (BackPos == true)
                    {
                        // 홀 위치로 간다.
                        targetPos = antHollPos;
                    }
                    else
                    {
                        // 케이크 위치로 간다.
                        targetPos = cakePos;

                    }

                    break;
                case 1:
                    // x 좌표로 50 간다
                    targetPos = new Vector3(transform.localPosition.x + 50, transform.localPosition.y, 0);
                    break;
                case 2:
                    // y 좌표로 50 간다
                    targetPos = new Vector3(transform.localPosition.x, transform.localPosition.y + 50, 0);
                    break;
                case 3:
                    // x 좌표로 -50 간다
                    targetPos = new Vector3(transform.localPosition.x - 50, transform.localPosition.y, 0);
                    break;
                case 4:
                    // y 좌표로 -50 간다
                    targetPos = new Vector3(transform.localPosition.x, transform.localPosition.y - 50, 0);
                    break;


            }
        }
    }

    // 개미가 총알에 맞으면 죽는다.
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"OnTriggerEnter2D {collision}");

        if (collision.tag == "Bullet")
        {
            AntDie();
            ObjectPoollingManager.Instance.bulletPoolPush(collision.gameObject);
        }
    }

    public void AntDie()
    {
        AntAni.SetTrigger("Die");

        StartCoroutine(DieDelay());
        // 개미가 움직이지 않게 한다.
        isDie = true;


    }

    IEnumerator DieDelay()
    {
        yield return new WaitForSeconds(1f);
        // 개미 죽으면 사라진다.
        ObjectPoollingManager.Instance.PoolPush(gameObject);
    }
}
