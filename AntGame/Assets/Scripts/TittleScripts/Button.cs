using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Exit��ư�� ������ �����ϰ� �ϴ� �Լ�
    public void ExitButton()
    {
        //Debug.Log("ExitButton()");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // PlayStart ��ư�� Ŭ���ϸ� PlayStartScene �̸��� ������ �Ѿ��.
    public void GameSceneButton()
    {
        SceneManager.LoadScene("GameScene");
    }



    
}
