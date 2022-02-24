using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 [CreateAssetMenu(menuName = "Durum")]
public class Durum : ScriptableObject
{

    [TextArea(12, 10)] [SerializeField] string hikayeMetni;

    [SerializeField] Durum[] sonrakiDurumlar;

    public string durumHikayesiAl()
    {
        return hikayeMetni;
    }
    public Durum[] sonrakiDurumuAl()
    {
        return sonrakiDurumlar;
    }

}

