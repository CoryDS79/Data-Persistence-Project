using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    [SerializeField] Button startBtn;
    [SerializeField] TMP_InputField nameInputField;
    public string playerName;
    public TextMeshProUGUI highScoreText;
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

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartBtnClicked()
    {
        playerName = nameInputField.text;
        // Debug.Log(playerName);
        SceneManager.LoadScene("main");
    }

    public void QuitButtonClicked()
    {
        LoadPlayerName();
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

            highScoreText.text = data.playerNameSaved;
        }
    }

}
