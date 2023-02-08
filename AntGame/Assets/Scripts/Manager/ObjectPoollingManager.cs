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

    // instance ����ϰ� �ϱ�
    public new void Awake()
    {
        base.Awake();
        // stack �ʱ�ȭ
        Pool = new Stack<GameObject>();
        // bulletPool �ʱ�ȭ
        bulletPool = new Stack<GameObject>();   

        //// stack�� �ֱ�
        //Pool.Push(gameObject);
        //// stack���� ����
        //Pool.Pop();

        // ��������Ʈ
        SceneManager.sceneLoaded += RodingScene;
    }

    // ���� Ǯ��
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

    

    // �Ѿ� Ǯ�� 
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



    // ���� �ε� ������ �����Ѵ�.
    public void RodingScene(Scene scene, LoadSceneMode loadSceneMode)
    {
        if(scene.name == "GameScene")
        {
            PoolCreator();
            bulletPoolCreator();
        }
    }

    

    
}
