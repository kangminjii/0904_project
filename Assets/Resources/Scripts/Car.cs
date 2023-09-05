using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float rotateSpeed = 10.0f;
    public float moveSpeed = 10.0f;
    Vector3 rayOrigin;
    Vector3 rayDirection;

    public GameObject[] wheel;

    void Start()
    {
        transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

    }

    void Update()
    {
        for(int i = 0; i < 2; i++)
        {
            rayOrigin = wheel[i].transform.position;
            rayDirection = wheel[i].transform.forward;
            Ray ray = new Ray(rayOrigin, rayDirection);
            Debug.DrawRay(ray.origin, ray.direction * 10.0f, Color.red);
        }
       
        Move2();
    }

    //void Move1() // Ű�� ������ �����̰Բ�
    //{
    //    float moveLR = Input.GetAxis("Horizontal"); // �¿� > ȸ��
    //    float moveUD = Input.GetAxis("Vertical");   // ���� > �̵�

    //    //// ����
    //    Debug.Log(wheel[0].transform.eulerAngles.y);

    //    // ���� ȸ�� ���� ���� ����
    //    if (wheel[0].transform.eulerAngles.y <= 30.0f || wheel[0].transform.eulerAngles.y >= 330.0f)
    //    {
    //        wheel[0].transform.Rotate(Vector3.right * rotateSpeed * moveLR);
    //        wheel[1].transform.Rotate(Vector3.right * rotateSpeed * moveLR);
    //    }
    //    else if (wheel[0].transform.eulerAngles.y > 30.0f && wheel[0].transform.eulerAngles.y <= 90.0f)
    //    {
    //        wheel[0].transform.eulerAngles = new Vector3(0, 30, 0);
    //        wheel[1].transform.eulerAngles = new Vector3(0, 30, 0);

    //        //wheel[0].transform.rotation = Quaternion.Euler(0.0f, 30.0f, 90.0f);
    //        //wheel[1].transform.rotation = Quaternion.Euler(0.0f, 30.0f, 90.0f);
    //        if(moveLR != 0)
    //        {
    //            wheel[0].transform.Rotate(Vector3.right * rotateSpeed * moveLR);
    //            wheel[1].transform.Rotate(Vector3.right * rotateSpeed * moveLR);
    //        }
    //    }
    //    else if (wheel[0].transform.eulerAngles.y < 330.0f)
    //    {
    //        wheel[0].transform.rotation = Quaternion.Euler(0.0f, 330.0f, 90.0f);
    //        wheel[1].transform.rotation = Quaternion.Euler(0.0f, 330.0f, 90.0f);
    //        if (moveLR != 0)
    //        {
    //            wheel[0].transform.Rotate(Vector3.right * rotateSpeed * moveLR);
    //            wheel[1].transform.Rotate(Vector3.right * rotateSpeed * moveLR);
    //        }
    //    }

    //    Quaternion targetRot = Quaternion.LookRotation(wheel[0].transform.eulerAngles, Vector3.up);

    //    //���� ���� ������
    //    if (moveUD != 0)
    //    {
    //        wheel[0].transform.Rotate(Vector3.up * rotateSpeed * moveUD * (-1));
    //       // wheel[0].transform.rotation *= Quaternion.AngleAxis(rotateSpeed, Vector3.up * moveUD);
    //        //transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
    //    }

    //    //// ���� 
    //    // �̵�
    //    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * moveUD);

    //    // ȸ��
    //    //transform.Rotate(Vector3.right * rotateSpeed * moveLR);
    //    if (moveLR != 0)
    //    {
    //        //moveLR = 0;
    //        transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, Time.deltaTime * moveLR);

    //    }

    //}

    void Move2()
    {
        float UD = Input.GetAxis("Vertical");   // ���� > �̵�
        float LR = Input.GetAxis("Horizontal"); // �¿� > ȸ��

        float rotateUD = UD * Time.deltaTime * rotateSpeed;
        float rotateLR = LR * Time.deltaTime * rotateSpeed;

        // ����
        //float xRotate = wheel[0].transform.eulerAngles.x + rotateUD;
        float yRotate = wheel[0].transform.eulerAngles.y + rotateLR;

        //if (xRotate > 90) xRotate -= 90;
        Debug.Log(yRotate);

        Vector3 wheel0 = wheel[0].transform.forward;
        Vector3 wheel1 = wheel[1].transform.forward;

        // ȸ�� ���� ����
        if (yRotate > 30 && yRotate < 180)
            yRotate = 30;
        else if (yRotate > 180 && yRotate < 330)
            yRotate = 330;

        wheel[0].transform.eulerAngles = new Vector3(0, yRotate, 90);// + wheel0;
        wheel[1].transform.eulerAngles = new Vector3(0, yRotate, 90);// + wheel1;

        float moveUD = UD * Time.deltaTime * moveSpeed;
        //float moveLR = LR * Time.deltaTime * moveSpeed;

        // ����
        Vector3 direction = transform.up;
        var quaternion = Quaternion.Euler(0, yRotate, 0);

        if(UD != 0)
            transform.Rotate(quaternion * direction * rotateLR);

        transform.Translate(Vector3.forward * moveUD);
        
        
    }


}
