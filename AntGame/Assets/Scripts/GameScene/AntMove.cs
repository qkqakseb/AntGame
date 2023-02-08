using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMove : MonoBehaviour
{
    public float AntSpeed = 200f;


    public bool isDie = false;

    #region Player's component
    private Rigidbody2D AntRigid = default;
    private Animator AntAni = default;
    #endregion

        // ����ũ ��ġ Ȯ��
        Vector3 cakePos = new Vector3(562f, -210f, 0f);
        Vector3 targetPos = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        AntRigid = gameObject.GetComponent<Rigidbody2D>();
        AntAni = transform.GetComponent<Animator>();

        

    }
    public void OnEnable()
    {
        StartCoroutine(targetPosRandomCh());
        isDie = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isDie == false)
        {
            antMove();
        }
    }

    public void antMove()
    {
        // ����ũ�������� �������� Ȯ���ϱ�
        

        // ���̰� ������ ��ġ������ ���ͼ� �����δ�.(����ũ ��ġ��)
        Vector3 pos = Vector3.MoveTowards(transform.localPosition, targetPos, Time.deltaTime * AntSpeed);
        transform.localPosition = pos;
        transform.LookAt2D(targetPos, 10f);

        
    }

    // targetPos�� ���� �ð����� 1���� �������� �ٲ۴�.
    IEnumerator targetPosRandomCh()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);

            int randomNm = Random.Range(0, 5);

            // ���� ����
            switch (randomNm)
            {
                case 0:
                    // ����ũ ��ġ�� ����.
                    targetPos = cakePos;
                    break;
                case 1:
                    // x ��ǥ�� 50 ����
                    targetPos = new Vector3(transform.localPosition.x + 50, transform.localPosition.y, 0);
                    break;
                case 2:
                    // y ��ǥ�� 50 ����
                    targetPos = new Vector3(transform.localPosition.x, transform.localPosition.y + 50, 0);
                    break;
                case 3:
                    // x ��ǥ�� -50 ����
                    targetPos = new Vector3(transform.localPosition.x - 50, transform.localPosition.y, 0);
                    break;
                case 4:
                    // y ��ǥ�� -50 ����
                    targetPos = new Vector3(transform.localPosition.x, transform.localPosition.y - 50, 0);
                    break;


            }
        }
    }

    // ���̰� �Ѿ˿� ������ �״´�.
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"OnTriggerEnter2D {collision}");

        if (collision.tag == "Bullet")
        {
            AntDie();
            ObjectPoollingManager.Instance.bulletPoolPush(collision.gameObject);
        }
    }

    public void AntDie()
    {
        AntAni.SetTrigger("Die");

        StartCoroutine(DieDelay());
        // ���̰� �������� �ʰ� �Ѵ�.
        isDie = true;
       

    }
    
    IEnumerator DieDelay()
    {
        yield return new WaitForSeconds(1f);
        // ���� ������ �������.
        ObjectPoollingManager.Instance.PoolPush(gameObject);
    }
}
