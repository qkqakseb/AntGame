using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
//using static UnityEngine.GraphicsBuffer;

public class Cannon : MonoBehaviour
{

    public int cannonSpeed;
  

    // 전역변수로 가까운 개미 선언
    public Transform target_Ant;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(bulletShoot());

    }

    // Update is called once per frame
    void Update()
    {
        antPosFind();
    }


    // 개미의 포지션 찾기
    public void antPosFind()
    {
        
        float shortDistance = 500;

        for (int i = 0; i < GameManager.Instance.Ants.Count; i++)
        { 
            float distance = Vector3.Distance(transform.localPosition, GameManager.Instance.Ants[i].transform.localPosition);
            //Debug.Log($"distance :  {distance}");

            // 가까운 개미 찾기
            if (distance < shortDistance)
            {
                shortDistance = distance;
                target_Ant = GameManager.Instance.Ants[i].transform;
            }

        }
        if(target_Ant != null)
        {
            transform.LookAt2D(target_Ant.localPosition, 10f);
        }
        

    }

    // 총알 생성하기
    
    IEnumerator bulletShoot()
    {
        while (true)
        {
            if (GameManager.Instance.Start_bulletShoot == true) 
            {
                // 총알 활성화
                GameObject bulletTmpObj = ObjectPoollingManager.Instance.bulletPoolPop();
                bulletTmpObj.transform.localPosition = transform.localPosition;
                bulletTmpObj.transform.rotation = transform.rotation;
                bulletTmpObj.SetActive(true);

            }
                yield return new WaitForSeconds(2f);
            
        }
       

    }

}
