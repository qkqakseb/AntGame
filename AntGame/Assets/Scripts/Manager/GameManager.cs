using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : SingletonBase<GameManager>
{
    public int antCount = 50;

    public List<GameObject> Ants = default;

    public bool Start_bulletShoot = false;

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
        if (scene.name == "initScene")
        {
            SceneManager.LoadScene("TittleScene");
        }
        if (scene.name == "GameScene")
        {
            Ants = new List<GameObject>();

        }

    }

    public void gameStart()
    {
        // ����Ʈ �ʱ�ȭ
        StartCoroutine(antNumberMove());
        Start_bulletShoot = true;
    }

    IEnumerator antNumberMove()
    {
        // ���� Ȱ��ȭ
        for (int i = 0; i < antCount; i++)
        {
            GameObject tempobj = ObjectPoollingManager.Instance.PoolPop();
            tempobj.transform.localPosition = new Vector3(-560f, 420f, 0f);
            tempobj.SetActive(true);
            Ants.Add(tempobj);

            // 3�� �����̸� �ְ�
            yield return new WaitForSeconds(1f);
        }

    }









}
