using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager sInstance;
    public static GameManager Instance
    {
        get
        {
            if (sInstance == null)
            {
                GameObject newGameObject = new GameObject("_GameManager");
                sInstance = newGameObject.AddComponent<GameManager>();
            }
            return sInstance;
        }
    }
    
    public int changeScene = 0;



    private void Awake()
    {
        if(sInstance != null && sInstance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        sInstance = this;

        DontDestroyOnLoad(this.gameObject); // PlayerInfo 같은 정보들을 저장함, 다음씬에서도 가져가게끔

    }

    public void ChangeScene()
    {
        int sceneIndex = changeScene++ % 2;
        SceneManager.LoadScene(sceneIndex);
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
