using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameControl : MonoBehaviour
{
    private int min = 1;
    private int max = 200;
    private int estimatedNum;
    [SerializeField] Text tahminMetni;

    public int Min { get => min; set => min = value; }
    public int Max { get => max; set => max = value; }
    public int EstimatedNum { get => estimatedNum; set => estimatedNum = value; }

    void Start()
    {
        reset();
    }

    
    public void reset()
    {
        Min = 1;
        Max = 200;
        EstimatedNum = estimatedNumberFunc();
        tahminMetni.text = estimatedNumberFunc().ToString();
    }

    public int estimatedNumberFunc()
    {
        EstimatedNum = Random.Range(Min, Max);
        tahminMetni.text = estimatedNum.ToString();
        return EstimatedNum;
    }
    public void decrease()
    {
        Max = EstimatedNum;
        estimatedNumberFunc();

    }
    public void increase()
    {
        Min = EstimatedNum;
        estimatedNumberFunc();
    }

    public void nextPage()
    {
        int nowScene = SceneManager.GetActiveScene().buildIndex;

        if (nowScene + 1 > 2)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(nowScene + 1);

    }

    public void quitFunc()
    {
        Application.Quit();
    }
    public void playAgain()
    {
        SceneManager.LoadScene(1);
        reset();
    }
}
