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

    // Rotate�� Translate�� �浹�� ���µ� �Ѱ谡 �ִ�
    private void FixedUpdate()
    {
        float rot = Input.GetAxis("Horizontal");
        float mov = Input.GetAxis("Vertical");

        // ȸ��
        Quaternion deltaRot = Quaternion.Euler(new Vector3(0, rot, 0) * speedRotate * Time.deltaTime);
        rigidbody.MoveRotation(rigidbody.rotation * deltaRot);

        // �̵�
        Vector3 move = transform.forward * mov;
        Vector3 newPos = rigidbody.position + move * speedMove * Time.deltaTime;
        rigidbody.MovePosition(newPos);
    }


    // Collision
    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        print("Collider �浹 " + hitObject.name + "�� �浹����");
    }

    private void OnCollisionStay(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        print("Collider �浹 " + hitObject.name + "�� �浹 �� ~ing");
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        print("Collider �浹 " + hitObject.name + "�� �浹 ��");
    }

    // Trigger
    // is trigger : �̺�Ʈ�� �߻��ϵ� �������� ��Ģ�� ������� �ʰԲ� �ϴ� ���
    // �� �� �ϳ��� rigidbody�� �־����
    private void OnTriggerEnter(Collider other)
    {
        // is trigger�� üũ���־����
        GameObject hitObject = other.gameObject;
        print("Trigger �浹 " + hitObject.name + "�� �浹����");
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject hitObject = other.gameObject;
        print("Trigger �浹 " + hitObject.name + "�� �浹 �� ~ing");
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject hitObject = other.gameObject;
        print("Trigger �浹 " + hitObject.name + "�� �浹 ��");
    }
}
