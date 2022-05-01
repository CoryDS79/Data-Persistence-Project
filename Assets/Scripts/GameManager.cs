using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    [SerializeField] Button startBtn;
    [SerializeField] TMP_InputField nameInputField;
    MainManager mainManager;
    public string playerName;
    // public int highScore;
    public TextMeshProUGUI highScoreText;
    public string highScore;
    public static GameManager instance;
    // Start is called before the first frame update

    void Awake()
    {
        if (instance !=null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        LoadPlayerName();
    }

    void Start()
    {
        mainManager = FindObjectOfType<MainManager>();
        // LoadPlayerName();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartBtnClicked()
    {
        playerName = nameInputField.text;
        SavePlayerName();
        SceneManager.LoadScene("main");
    }

    public void QuitButtonClicked()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }

    [System.Serializable]
    class SavaData
    {
        public string playerNameSaved;
        public string highScoreSaved;
    }

    public void SavePlayerName()
    {
        SavaData data = new SavaData();
        data.playerNameSaved = playerName;
        if (data.highScoreSaved != null)
        {
            data.highScoreSaved = mainManager.HighScoreText.text;
        }

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadPlayerName()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavaData data = JsonUtility.FromJson<SavaData>(json);

            highScore = data.highScoreSaved;
            highScoreText.text = highScore;


        }
    }

}
