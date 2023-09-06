using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 빌드 순서대로 씬 전환
        //if (Input.GetMouseButton(0))
        //{
        //    GameManager.Instance.ChangeScene();
        //}

        // 씬 이름으로 불러오기
        if (Input.GetMouseButton(1))
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

    private void OnGUI()
    {
        if(GUI.Button(new Rect(100,200,200,30), "씬 변경"))
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
