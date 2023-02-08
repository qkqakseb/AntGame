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
  

    // ���������� ����� ���� ����
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


    // ������ ������ ã��
    public void antPosFind()
    {
        
        float shortDistance = 500;

        for (int i = 0; i < GameManager.Instance.Ants.Count; i++)
        { 
            float distance = Vector3.Distance(transform.localPosition, GameManager.Instance.Ants[i].transform.localPosition);
            //Debug.Log($"distance :  {distance}");

            // ����� ���� ã��
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

    // �Ѿ� �����ϱ�
    
    IEnumerator bulletShoot()
    {
        while (true)
        {
            if (GameManager.Instance.Start_bulletShoot == true) 
            {
                // �Ѿ� Ȱ��ȭ
                GameObject bulletTmpObj = ObjectPoollingManager.Instance.bulletPoolPop();
                bulletTmpObj.transform.localPosition = transform.localPosition;
                bulletTmpObj.transform.rotation = transform.rotation;
                bulletTmpObj.SetActive(true);

            }
                yield return new WaitForSeconds(2f);
            
        }
       

    }

}
