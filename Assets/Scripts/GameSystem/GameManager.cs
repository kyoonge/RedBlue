using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public int score;
    public UIManager uiManager;
    public SoundManager soundManager;

    //public MovingMap movingMap;

    // �ٸ� ��ũ��Ʈ���� GameManager�� �����ϱ� ���� ������Ƽ
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                // ���� �Ŵ��� �ν��Ͻ��� ���� ��� ���� ����
                instance = FindObjectOfType<GameManager>();

                // ���� �Ŵ��� �ν��Ͻ��� ���� ��� ���ο� ���� ������Ʈ�� �߰�
                if (instance == null)
                {
                    GameObject singletonObject = new GameObject();
                    instance = singletonObject.AddComponent<GameManager>();
                    singletonObject.name = "GameManager (Singleton)";

                    // ���� �Ŵ��� �ν��Ͻ� ����
                    DontDestroyOnLoad(singletonObject);
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        // �̹� �ٸ� ���� �Ŵ��� �ν��Ͻ��� �����ϴ� ��� ���� �ν��Ͻ� �ı�
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