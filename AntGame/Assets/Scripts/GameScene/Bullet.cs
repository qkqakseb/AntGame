using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // �Ѿ� ���ǵ�
    float bulletSpeed = 5f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    // �Ѿ��� �������� ����
    void Update()
    {
        // �Ѿ��� ������ �����ӿ� ���� ������.
        transform.Translate(Vector2.up*bulletSpeed*Time.deltaTime);
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"OnTriggerEnter2D{collision.tag}");

        if (collision.tag == "Walls")
        {
            ObjectPoollingManager.Instance.bulletPoolPush(gameObject);
        }
    }

}
