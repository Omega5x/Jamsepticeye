using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    [SerializeField]
    private int time = 120;

    public TMP_Text text;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timer = time;

    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime; 
            int seconds = Mathf.CeilToInt(timer); 
            text.text = seconds.ToString(); 
        }
        else
        {
            text.text = "0";
            // Logic of the end game
            SceneManager.LoadScene("MainScene");
        }
    }
}
