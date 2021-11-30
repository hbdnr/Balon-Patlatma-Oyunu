using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalonPatlatma : MonoBehaviour
{
    public GameObject patlama;
    OyunKontrol oyunKontrol;
    void Start()
    {
        oyunKontrol = GameObject.Find("GameObject").GetComponent<OyunKontrol>();    
    }

    void OnMouseDown()
    {
        GameObject go = Instantiate(patlama, transform.position, transform.rotation) as GameObject;
        Destroy(this.gameObject);
        Destroy(go,0.175f);
        oyunKontrol.BalonCikar();
    }
}
