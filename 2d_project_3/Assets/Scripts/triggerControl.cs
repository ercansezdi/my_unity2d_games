using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerControl : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject player;

    private void OnTriggerEnter2D(Collider2D collision) // eklediğimiz trigger yere değdiğinde bunun içerisine girer. 0->1
    {
        player.GetComponent<playerController>().onGround = true;
    }
    private void OnTriggerExit2D(Collider2D collision) // eklediğimiz trigger yere değmediğinde bunun içerisine girer. 1->0
    {
        player.GetComponent<playerController>().onGround = false; ;
    }
}
