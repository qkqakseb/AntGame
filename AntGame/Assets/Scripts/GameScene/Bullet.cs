using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // 총알 스피드
    float bulletSpeed = 5f; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    // 총알의 움직임을 구현
    void Update()
    {
        // 총알이 대포가 움직임에 따라 나간다.
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
