using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotateSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        // # �ʱ� ��ġ ����
        // world(����) ��ǥ �������� �̵��� > 0.5�� 5.0����
        //this.transform.position = new Vector3(0.0f, 5.0f, 0.0f); 
        // local �������� �̵��� > 0.5�� 5.5��
        this.transform.Translate(new Vector3(0.0f, 0.0f, 0.0f));
    }

    // Update is called once per frame
    void Update()
    {
        //Move_1();
        //Move_2();
        float UD = Input.GetAxis("Vertical");   // ���� > �̵�
        transform.Rotate(Vector3.up * 10 * Time.deltaTime*UD);
    }

    void Move_1() // z���� ����
    {
        float moveDelta = this.moveSpeed * (Time.deltaTime);
        Vector3 pos = this.transform.position;
        pos.z += moveDelta;
        this.transform.position = pos;
    }
    void Move_2() // �������� ����(z��)
    {
        float moveDelta = this.moveSpeed * (Time.deltaTime);
        this.transform.Translate(Vector3.forward * moveDelta);
    }
    
}
