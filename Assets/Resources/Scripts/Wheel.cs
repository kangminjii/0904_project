using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public float rotateSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Move_Rotate();
    }

    void Move_Rotate()
    {
        float moveX = Input.GetAxis("Horizontal"); // x축
        float moveY = Input.GetAxis("Vertical"); // y축
        float rot = rotateSpeed * Time.deltaTime;

        //바퀴 전진 구르기
        if (moveY != 0)
        {
            transform.rotation *= Quaternion.AngleAxis(rot, Vector3.up * moveY * (-1));
            transform.rotation = Quaternion.Euler(0.0f, 0.0f, 90.0f);
        }

        GameObject parent = transform.parent.gameObject;
        float rotate = parent.transform.eulerAngles.y;


        // 바퀴 회전 각도 범위 설정
        if (transform.eulerAngles.y <= 30.0f || transform.eulerAngles.y >= 330.0f)
            transform.Rotate(Vector3.right * rot * moveX);
        else if (transform.eulerAngles.y > 30.0f && transform.eulerAngles.y <= 90.0f)
            transform.rotation = Quaternion.Euler(0.0f, 30.0f, 90.0f);
            //transform.Rotate(Vector3.right * 45.0f);
        else if (transform.eulerAngles.y < 330.0f)
            transform.rotation = Quaternion.Euler(0.0f, 330.0f, 90.0f);
            //transform.Rotate(Vector3.right * 315.0f);


    }
}
