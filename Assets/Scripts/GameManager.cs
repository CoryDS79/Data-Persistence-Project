using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] Button startBtn;
    [SerializeField] TextMeshProUGUI nameInputField;

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
        SceneManager.LoadScene("main");
    }
}
