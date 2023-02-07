using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : SingletonBase<GameManager>
{
    public int antCount = 6;
    

    public new void Awake()
    {
        base.Awake();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.name== "initScene")
        {
            SceneManager.LoadScene("TittleScene");
        }
        
    }

    public void gameStart()
    {
        StartCoroutine(antNumberMove());
    }

    IEnumerator antNumberMove()
    {
        // 개미 활성화
        for (int i = 0; i < antCount; i++)
        {
            GameObject tempobj = ObjectPoollingManager.Instance.PoolPop();
            tempobj.transform.localPosition = new Vector3(-560f, 420f, 0f);
            tempobj.SetActive(true);

            // 0.5초 딜레이를 주고
            yield return new WaitForSeconds(3f);
        }

    }






    
}
