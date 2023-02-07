using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartCount : MonoBehaviour
{
    public int startCount = 9;

    public TMP_Text tmp_text = default;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Count());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   //  9~0까지 타임을 준다
    IEnumerator Count()
    {
        while (true)
        {
            tmp_text.text = ""+startCount;
            yield return new WaitForSeconds(0.5f);
            startCount--;
            if (startCount == -1)
            {
                GameManager.Instance.gameStart();
                // 카운터가 0이 되면 0이 사라진다
                tmp_text.gameObject.SetActive(false);        
                break;
                
            }
        }

    }

    //// 카운터가 된 후 
    //public void CountAfter()
    //{
    //    // 게임이 시작된다.(개미가 나타난다.)
    //    GameObject tempobj = ObjectPoollingManager.Instance.PoolPop();
    //    tempobj.transform.localPosition = new Vector3(-560f, 420f, 0f);
    //    tempobj.SetActive(true);
    //}


}
