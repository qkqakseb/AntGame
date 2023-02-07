using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMove : MonoBehaviour
{
    public float AntSpeed = 50f;
 

    #region Player's component
    private Rigidbody2D AntRigid = default;
    private Animator AntAni = default;
    #endregion

        // 케이크 위치 확인
        Vector3 cakePos = new Vector3(562f, -210f, 0f);
        Vector3 targetPos = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        AntRigid = gameObject.GetComponent<Rigidbody2D>();
        AntAni = transform.GetComponent<Animator>();

        StartCoroutine(targetPosRandomCh());

    }

    // Update is called once per frame
    void Update()
    {
        antMove();
    }

    public void antMove()
    {
        // 케이크포지션을 랜덤으로 확인하기
        

        // 개미가 지정된 위치값에서 나와서 움직인다.(케이크 위치로)
        Vector3 pos = Vector3.MoveTowards(transform.localPosition, targetPos, Time.deltaTime * AntSpeed);
        transform.localPosition = pos;
        transform.LookAt2D(targetPos, 10f);

        
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
                    // 케이크 위치로 간다.
                    targetPos = cakePos;
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

    // 벽과 충돌하면
    //public void Walls()
    //{

    //}
}
