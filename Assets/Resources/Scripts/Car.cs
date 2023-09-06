using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public float rotateSpeed = 30.0f;
    public float moveSpeed = 5.0f;

    // wheel (바퀴 회전)
    public GameObject[] wheel;
    private float angle;

    // raycast (충돌)
    Vector3 rayOrigin1, rayOrigin2;
    Vector3 rayDirection1, rayDirection2;
    private RaycastHit ray1, ray2;
    [Range(0, 50)]
    public float distance = 10.0f;

    Vector3 diff1 = new Vector3(0, 0, 0);
    Vector3 diff2 = new Vector3(0, 0, 0);


    // 설정한 바퀴만 돌게끔 만들기
    public static int goalCount = 0;


    void Start()
    {

    }

    void Update()
    {
        //Move1();
        Move2();
    }
   
    // 차 바퀴 회전
    void Move1()
    {
        // 보기용 ray
        // 바퀴
        for (int i = 0; i < 2; i++)
        {
            rayOrigin1 = wheel[i].transform.position;
            rayDirection1 = wheel[i].transform.forward;
            Debug.DrawRay(rayOrigin1, rayDirection1 * 10.0f, Color.red);
        }
        // 몸통
        rayOrigin2 = transform.position;
        rayDirection2 = transform.forward;
        Debug.DrawRay(rayOrigin2, rayDirection2 * 10.0f, Color.blue);
        //

        float UD = Input.GetAxis("Vertical");   // 상하 > 이동
        float LR = Input.GetAxis("Horizontal"); // 좌우 > 회전

        float moveUD = UD * Time.deltaTime * moveSpeed;
        float rotateLR = LR * Time.deltaTime * rotateSpeed;
        float rotateUD = UD * Time.deltaTime * rotateSpeed * 10;

        //// 바퀴
        float xRotate = wheel[0].transform.eulerAngles.x + rotateUD; // 앞으로 회전하기
        float yRotate = wheel[0].transform.eulerAngles.y + rotateLR;   // 옆으로 회전하기


        // 바퀴와 몸통 벡터 사이의 각도 
        if (LR > 0)
            angle = Vector3.SignedAngle(transform.forward, wheel[0].transform.forward, transform.forward);
        else if(LR < 0)
            angle = Vector3.SignedAngle(transform.forward, wheel[0].transform.forward, -transform.forward);

        Debug.Log(angle);


        // 회전 각도 조절
        if (yRotate > 30 && yRotate < 180)
            yRotate = 30;
        else if (yRotate > 180 && yRotate < 330)
            yRotate = 330;

        var quaternion = Quaternion.Euler(0, yRotate, 0); // yRotate 값 형식 변환 float > var

       
        //transform.Rotate(Vector3.up * 10 * Time.deltaTime * UD); > y축 회전
        //wheel[0].transform.Rotate(Vector3.up * 10 * Time.deltaTime * UD);
        wheel[0].transform.eulerAngles = new Vector3(0, yRotate, 90); // xRotate
        wheel[1].transform.eulerAngles = new Vector3(0, yRotate, 90);


        //// 몸통
        Vector3 directionB = transform.up * moveSpeed;

        if(UD != 0)
        {
            if(Mathf.Abs(angle) > 1 && Mathf.Abs(angle) != 1)
                transform.Rotate(quaternion * directionB * rotateLR);
        }

        transform.Translate(Vector3.forward * moveUD);
    }

    // 자동으로 벽을 피해 경주하는 자동차
    void Move2()
    {
        float UD = Input.GetAxis("Vertical");   // 상하 > 이동
        float LR = Input.GetAxis("Horizontal"); // 좌우 > 회전

        //// 충돌 체크
        // ray 그리기 - 왼쪽
        rayOrigin1 = transform.position;
        Quaternion rotate = Quaternion.Euler(0, -30, 0);
        rayDirection1 = rotate * transform.forward;
        Debug.DrawRay(rayOrigin1, rayDirection1 * distance, Color.blue);

        // 오른쪽
        Quaternion rotate1 = Quaternion.Euler(0, 30, 0);
        rayDirection2 = rotate1 * transform.forward;
        Debug.DrawRay(rayOrigin1, rayDirection2 * distance, Color.blue);

        if (Physics.Raycast(rayOrigin1, rayDirection1, out ray1, distance))
        {
            // 오른쪽으로 꺾기
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * (1));
            diff1 = ray1.point - transform.position;
        }

        if (Physics.Raycast(rayOrigin1, rayDirection2, out ray2, distance))
        {
            // 왼쪽으로 꺾기
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * (-1));
            diff2 = ray2.point - transform.position;
        }

       // Debug.Log("1 : " + diff1.magnitude + " / 2 : " + diff2.magnitude);

        /// raycast 닿은 지점 ~ 몸통 지점까지의 길이를 비교하기
        if (diff1.magnitude < diff2.magnitude)
        {
            // 오른쪽 꺾기
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * (1));
        }
        else if (diff1.magnitude > diff2.magnitude)
        {
            // 왼쪽 꺾기
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * (-1));
        }

        // 벽과 너무 가까울때 속도값을 조절해 확 꺾이게하기
        if (diff1.magnitude <= 3)
        {
            moveSpeed = 1;
            rotateSpeed = 40;
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * (1));
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }
        if (diff2.magnitude <= 3)
        {
            moveSpeed = 1;
            rotateSpeed = 40;
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed * (-1));
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);
        }

        Debug.Log(moveSpeed);
        moveSpeed = 5.0f;
        rotateSpeed = 30;
        // 이동
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);


        // 2바퀴 돌면 멈추게하기

        if (goalCount >= 1)
        {
            moveSpeed = 0;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        // is trigger가 체크돼있어야함
        GameObject hitObject = other.gameObject;
        print("Trigger 충돌 " + hitObject.name + "와 충돌시작");
        goalCount++;
        print("goalcount : " + goalCount);
    }
    private void OnGUI()
    {
        if (GUI.Button(new Rect(100, 200, 200, 30), "씬 변경"))
        {
            if (GameManager.Instance.changeScene == 0)
            {
                GameManager.Instance.ChangeScene("99_End");
                GameManager.Instance.changeScene++;
            }
            else if (GameManager.Instance.changeScene == 1)
            {
                GameManager.Instance.ChangeScene("03_Collision");
                GameManager.Instance.changeScene++;
            }
        }

    }


}
