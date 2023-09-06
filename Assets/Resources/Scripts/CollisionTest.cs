using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    float speedMove = 10.0f;
    float speedRotate = 100.0f;

    Rigidbody rigidbody;


    void Start()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        //float rot = Input.GetAxis("Horizontal");
        //float mov = Input.GetAxis("Vertical");

        //rot = rot * speedRotate * Time.deltaTime;
        //mov = mov * speedMove * Time.deltaTime;

        //this.gameObject.transform.Rotate(Vector3.up * rot);
        //this.gameObject.transform.Translate(Vector3.forward * mov);


    }

    // Rotate와 Translate은 충돌을 막는데 한계가 있다
    private void FixedUpdate()
    {
        float rot = Input.GetAxis("Horizontal");
        float mov = Input.GetAxis("Vertical");

        // 회전
        Quaternion deltaRot = Quaternion.Euler(new Vector3(0, rot, 0) * speedRotate * Time.deltaTime);
        rigidbody.MoveRotation(rigidbody.rotation * deltaRot);

        // 이동
        Vector3 move = transform.forward * mov;
        Vector3 newPos = rigidbody.position + move * speedMove * Time.deltaTime;
        rigidbody.MovePosition(newPos);
    }


    // Collision
    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        print("Collider 충돌 " + hitObject.name + "와 충돌시작");
    }

    private void OnCollisionStay(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        print("Collider 충돌 " + hitObject.name + "와 충돌 중 ~ing");
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        print("Collider 충돌 " + hitObject.name + "와 충돌 끝");
    }

    // Trigger
    // is trigger : 이벤트는 발생하되 물리적인 법칙은 적용되지 않게끔 하는 기능
    // 둘 중 하나에 rigidbody가 있어야함
    private void OnTriggerEnter(Collider other)
    {
        // is trigger가 체크돼있어야함
        GameObject hitObject = other.gameObject;
        print("Trigger 충돌 " + hitObject.name + "와 충돌시작");
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject hitObject = other.gameObject;
        print("Trigger 충돌 " + hitObject.name + "와 충돌 중 ~ing");
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject hitObject = other.gameObject;
        print("Trigger 충돌 " + hitObject.name + "와 충돌 끝");
    }
}
