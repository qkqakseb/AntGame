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

    // Exit버튼을 누르면 종료하게 하는 함수
    public void ExitButton()
    {
        //Debug.Log("ExitButton()");
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // PlayStart 버튼을 클릭하면 PlayStartScene 이름의 씬으로 넘어간다.
    public void GameSceneButton()
    {
        SceneManager.LoadScene("GameScene");
    }



    
}
