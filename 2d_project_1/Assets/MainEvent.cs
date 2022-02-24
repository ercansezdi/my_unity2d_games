using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainEvent : MonoBehaviour
{

    public Text gameStory;
    public Durum nextStory;

    Durum nowStory;
    void Start()
    {
        nowStory = nextStory;
        gameStory.text = nowStory.durumHikayesiAl();
    }

    void Update()
    {
        Durum[] next = nowStory.sonrakiDurumuAl();
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            nowStory = next[0];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            nowStory = next[1];
        }
        gameStory.text = nowStory.durumHikayesiAl();
    }
}
