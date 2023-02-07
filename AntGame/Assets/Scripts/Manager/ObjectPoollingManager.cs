using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ObjectPoollingManager : SingletonBase<ObjectPoollingManager>
{
    private Stack<GameObject> Pool;
    public GameObject ObjPrefab;
    public int count = default;

    // instance 사용하게 하기
    public new void Awake()
    {
        base.Awake();
        // stack 초기화
        Pool = new Stack<GameObject>();
        //// stack에 넣기
        //Pool.Push(gameObject);
        //// stack에서 빼기
        //Pool.Pop();

        // 델리게이트
        SceneManager.sceneLoaded += RodingScene;
    }

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
        Pool.Push(tempObj);
    }

    public GameObject PoolPop()
    {
        if (Pool.Count == 0) return null;
        return Pool.Pop();
    }

    // 씬이 로드 됬을때 동작한다.
    public void RodingScene(Scene scene, LoadSceneMode loadSceneMode)
    {
        if(scene.name == "GameScene")
        {
            PoolCreator();
        }
    }

    

    
}
