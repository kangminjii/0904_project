using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastEx : MonoBehaviour
{
    [Range(0,50)] // �Ʒ��� ���� ������ ����
    public float distance = 10.0f;
    private RaycastHit rayHit;
    private Ray ray;
    private RaycastHit[] rayHits;

    void Start()
    {
        ray = new Ray();
        ray.origin = this.transform.position;
        ray.direction = this.transform.forward;
        //ray = new Ray(this.transform.position, this.transform.forward); // > 3���� 1�ٷ� ���
    }

    // Update is called once per frame
    void Update()
    {
        Ray_4();
    }

    void Ray_4() // layer & tag �� �ִ� ��ü üũ
    {
        ray.origin = this.transform.position;
        ray.direction = this.transform.forward;

        rayHits = Physics.RaycastAll(ray, distance);

        for (int index = 0; index < rayHits.Length; index++)
        {
            if(rayHits[index].collider.gameObject.layer == LayerMask.NameToLayer("Cube"))
                Debug.Log(rayHits[index].collider.gameObject.name + " hit! - Layer");

            if (rayHits[index].collider.gameObject.tag == "Sphere")
                Debug.Log(rayHits[index].collider.gameObject.name + " hit! - Tag");
        }
    }

    void Ray_3() // �������� �ִ� ��ü üũ
    {
        rayHits = Physics.SphereCastAll(ray, 2.0f, distance);
        string objName = "";
        foreach (RaycastHit hit in rayHits)
            objName += hit.collider.name + ",  ";
        print(objName);
    }

    void Ray_2() // ray�� ��� ��ü ������ üũ
    {
        rayHits = Physics.RaycastAll(ray, distance);

        for(int index = 0; index < rayHits.Length; index++)
        {
            Debug.Log(rayHits[index].collider.gameObject.name + " hit!");
        }
    }
    
    void Ray_1() // ray�� ��� ��ü 1���� üũ
    {
        if(Physics.Raycast(ray.origin, ray.direction, out rayHit, distance))
        {
            Debug.Log(rayHit.collider.gameObject.name);
        }
    }

    private void OnDrawGizmos() // ���� ���ӿ��� �Ⱥ��̰�, �����Ϳ��� ����
    {
        //Debug.DrawRay(ray.origin, ray.direction * distance, Color.red);   // update�� �δ°� ���� ��������
        Gizmos.DrawLine(ray.origin, ray.direction * distance + ray.origin); // ���� �ǹ�

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(ray.origin, 0.1f); // ���� ��� ��ġ(Player)

        if(this.rayHits != null)
        {
            for(int i = 0; i < this.rayHits.Length; i++)
            {
                // collision point, �ε��� ��ġ�� ���� �׸�
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(this.rayHits[i].point, 0.1f);
                

                // draw line
                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(this.transform.position, transform.forward * rayHits[i].distance + ray.origin);


                // normal vector 
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(this.rayHits[i].point, this.rayHits[i].point + this.rayHits[i].normal);


                // reflection vector
                Gizmos.color = new Color(1.0f, 0.0f, 1.0f);
                Vector3 reflect = Vector3.Reflect(this.transform.forward, this.rayHits[i].normal); // �������Ϳ� �븻 ������ �ݻ簢
                Gizmos.DrawLine(this.rayHits[i].point, rayHits[i].point + reflect);

            }
        }

    }
}
