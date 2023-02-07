using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ObjectPoollingManager : SingletonBase<ObjectPoollingManager>
{
    private Stack<GameObject> Pool;
    public GameObject ObjPrefab;
    public int count = default;

    // instance ����ϰ� �ϱ�
    public new void Awake()
    {
        base.Awake();
        // stack �ʱ�ȭ
        Pool = new Stack<GameObject>();
        //// stack�� �ֱ�
        //Pool.Push(gameObject);
        //// stack���� ����
        //Pool.Pop();

        // ��������Ʈ
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

    // ���� �ε� ������ �����Ѵ�.
    public void RodingScene(Scene scene, LoadSceneMode loadSceneMode)
    {
        if(scene.name == "GameScene")
        {
            PoolCreator();
        }
    }

    

    
}
