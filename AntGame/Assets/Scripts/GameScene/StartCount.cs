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

   //  9~0���� Ÿ���� �ش�
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
                // ī���Ͱ� 0�� �Ǹ� 0�� �������
                tmp_text.gameObject.SetActive(false);        
                break;
                
            }
        }

    }

    //// ī���Ͱ� �� �� 
    //public void CountAfter()
    //{
    //    // ������ ���۵ȴ�.(���̰� ��Ÿ����.)
    //    GameObject tempobj = ObjectPoollingManager.Instance.PoolPop();
    //    tempobj.transform.localPosition = new Vector3(-560f, 420f, 0f);
    //    tempobj.SetActive(true);
    //}


}
