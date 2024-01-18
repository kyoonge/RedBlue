using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public int score;
    public UIManager uiManager;
    public SoundManager soundManager;

    //public MovingMap movingMap;

    // 다른 스크립트에서 GameManager에 접근하기 위한 프로퍼티
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                // 게임 매니저 인스턴스가 없는 경우 새로 생성
                instance = FindObjectOfType<GameManager>();

                // 게임 매니저 인스턴스가 없는 경우 새로운 게임 오브젝트에 추가
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<GameManager>();
                    singletonObject.name = "GameManager (Singleton)";

                    // 게임 매니저 인스턴스 유지
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        // 이미 다른 게임 매니저 인스턴스가 존재하는 경우 현재 인스턴스 파괴
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        Init();
    }

    private void Init()
    {
        Debug.Log("init");
        this.score = 0;
        Time.timeScale = 1f;
        Debug.Log("initEnd: " + Time.timeScale);
    }


    public void GameOver()
    {
        uiManager.SettingGameover();
        soundManager.bgmAudioSource.Stop();
        Time.timeScale = 0f;
    }

    public void RestartScene()
    {
        Debug.Log("restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }

    public void setScore()
    {      
        score += 1;
        uiManager.SettingScore(score);
    }


}