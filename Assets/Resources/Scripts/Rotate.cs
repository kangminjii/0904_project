using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    GameObject target = null;
    public float speed = 10.0f;
    public float rotateSpeed = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //Rotate_1();
        //Rotate_2();
        //Rotate_3();
        //Rotate_4();
        //Rotate_Around();
    }

    void Rotate_Around()
    {
        float rot = speed * Time.deltaTime;
        //transform.RotateAround(new Vector3(0, 0.0f, 0), Vector3.up, rot); // Ư�� ��ǥ �ֺ��� ȸ��
        transform.RotateAround(target.transform.position, Vector3.up, rot); // Ÿ�� �ֺ��� ȸ��
    }

    void Rotate_1() // ȸ������ ����
    {
        Quaternion target = Quaternion.Euler(0.0f, 45.0f, 0.0f);
        this.transform.rotation = target;
    }
    void Rotate_2() // ȸ������ ��� ��ȭ
    {
        this.transform.Rotate(Vector3.up * 45.0f);
    }
    void Rotate_3() // ���� ��ǥ(World)
    {
        float rot = speed * Time.deltaTime;
        transform.rotation *= Quaternion.AngleAxis(rot, Vector3.up);
    }
    void Rotate_4() // ��� ��ǥ(Local)
    {
        float rot = speed * Time.deltaTime;
        transform.Rotate(Vector3.up * rot);
    }

}
