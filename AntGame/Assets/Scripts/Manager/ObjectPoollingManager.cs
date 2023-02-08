using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ObjectPoollingManager : SingletonBase<ObjectPoollingManager>
{
    private Stack<GameObject> Pool;
    private Stack<GameObject> bulletPool;

    public GameObject ObjPrefab;
    public GameObject BulletPrefab;

    public int count = default;
    public int bulletCount = default;

    // instance 사용하게 하기
    public new void Awake()
    {
        base.Awake();
        // stack 초기화
        Pool = new Stack<GameObject>();
        // bulletPool 초기화
        bulletPool = new Stack<GameObject>();   

        //// stack에 넣기
        //Pool.Push(gameObject);
        //// stack에서 빼기
        //Pool.Pop();

        // 델리게이트
        SceneManager.sceneLoaded += RodingScene;
    }

    // 개미 풀링
    public void PoolCreator()
    {
        for(int i=0; i < count; i++)
        {
            GameObject tempObj = Instantiate(ObjPrefab,GFunc.GetRootObj("GameObject").transform);
            Pool.Push(tempObj);
        }
    }

    public void PoolPush(GameObject tempObj)
    {
        tempObj.SetActive(false);
        Pool.Push(tempObj);
    }

    public GameObject PoolPop()
    {
        if (Pool.Count == 0) return null;
        return Pool.Pop();
    }

    

    // 총알 풀링 
    public void bulletPoolCreator()
    {
        for (int i = 0; i < bulletCount; i++)
        {
            GameObject bulletTmpObj = Instantiate(BulletPrefab, GFunc.GetRootObj("GameObject").transform);
            bulletPool.Push(bulletTmpObj);
        }
        
    }

    public void bulletPoolPush(GameObject bulletTmpObj)
    {
        bulletTmpObj.SetActive(false);
        bulletPool.Push(bulletTmpObj);
    }

    public GameObject bulletPoolPop()
    {
        if(bulletPool.Count == 0) return null;
        return bulletPool.Pop();
    }



    // 씬이 로드 됬을때 동작한다.
    public void RodingScene(Scene scene, LoadSceneMode loadSceneMode)
    {
        if(scene.name == "GameScene")
        {
            PoolCreator();
            bulletPoolCreator();
        }
    }

    

    
}
