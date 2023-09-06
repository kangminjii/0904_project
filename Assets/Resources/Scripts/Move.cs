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
        // # 초기 위치 설정
        // world(절대) 좌표 기준으로 이동함 > 0.5가 5.0으로
        //this.transform.position = new Vector3(0.0f, 5.0f, 0.0f); 
        // local 기준으로 이동함 > 0.5가 5.5로
        this.transform.Translate(new Vector3(0.0f, 0.0f, 0.0f));
    }

    // Update is called once per frame
    void Update()
    {
        //Move_1();
        //Move_2();
        float UD = Input.GetAxis("Vertical");   // 상하 > 이동
        transform.Rotate(Vector3.up * 10 * Time.deltaTime*UD);
    }

    void Move_1() // z값이 증가
    {
        float moveDelta = this.moveSpeed * (Time.deltaTime);
        Vector3 pos = this.transform.position;
        pos.z += moveDelta;
        this.transform.position = pos;
    }
    void Move_2() // 전방으로 증가(z값)
    {
        float moveDelta = this.moveSpeed * (Time.deltaTime);
        this.transform.Translate(Vector3.forward * moveDelta);
    }
    
}
