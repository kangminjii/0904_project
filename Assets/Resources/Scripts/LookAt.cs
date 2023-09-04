using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    public GameObject target = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //LookAt_1();
        LookAt_2();
        //LookAt_3();
    }
    void LookAt_1()
    {
        Vector3 dirToTarget = target.transform.position - this.transform.position; // 타겟을 바라보는 방향벡터
        this.transform.forward = dirToTarget.normalized; // 방향벡터는 항상 normalized 시켜야함
    }
    void LookAt_2()
    {
        transform.LookAt(target.transform.position); // LookAt은 normalized 안해도 상관없음
    }
    void LookAt_3()
    {
        Vector3 dirToTarget = target.transform.position - this.transform.position;
        transform.rotation = Quaternion.LookRotation(dirToTarget, Vector3.up); // rotation값을 직접 변화
    }
}
