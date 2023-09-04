using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotateSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.Translate(new Vector3(0.0f, 0.0f, 0.0f));
    }

    // Update is called once per frame
    void Update()
    {
        Move_Control();
    }

    void Move_Control() // 키를 누르면 움직이게끔
    {
        float moveX = Input.GetAxis("Vertical"); // x축 좌우
        float moveY = Input.GetAxis("Horizontal"); // y축 상하

        // 이동
       // transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * moveX);

        // 회전
        GameObject wheel = transform.Find("Wheel").gameObject;
        float rotate = wheel.transform.eulerAngles.y;
        Debug.Log(rotate);

        //GameObject body = transform.Find("Cube").gameObject;
        for(int i =0; i < transform.childCount; i++)
        {
            if( transform.GetChild(i).name == "Wheel")
            {
                continue;
            }
            else
            {
                if(transform.GetChild(i).eulerAngles.y != rotate)
                {
                    transform.GetChild(i).Rotate(Vector3.up * rotateSpeed * Time.deltaTime * moveY);
                }
                else
                    transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * moveX);

            }

        }
        

    }

}
