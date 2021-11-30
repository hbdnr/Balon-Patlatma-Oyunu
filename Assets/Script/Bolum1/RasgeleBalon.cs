using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RasgeleBalon : MonoBehaviour
{
    public GameObject balon;
    float olusturmaSuresi = 1f;
    float sayac=0;
    OyunKontrol oyunKontrol;
    // Start is called before the first frame update
    void Start()
    {
        oyunKontrol = this.gameObject.GetComponent<OyunKontrol>();
    }

    // Update is called once per frame
    void Update()
    {
        int hiz = (int)(oyunKontrol.sayacZaman / 10f) - 8;
        hiz *= -1;
        sayac -= Time.deltaTime;
        if (sayac < 0 && oyunKontrol.sayacZaman>0 && !oyunKontrol.bolumSonu)
        {
            GameObject go = Instantiate(balon, new Vector3(Random.Range(-2.85f, 2.85f), -5.34f, 0f), Quaternion.Euler(0, 0, 0));
            go.GetComponent<Rigidbody2D>().AddForce(new Vector3(0f, Random.Range(25f*hiz,52f*hiz), 0f));
            sayac = olusturmaSuresi;
        }
        
    }
}
