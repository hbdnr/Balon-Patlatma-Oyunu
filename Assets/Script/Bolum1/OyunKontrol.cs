using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OyunKontrol : MonoBehaviour
{
    public Button button;
    public Button button2;
    public Text zamanText, balonText;
    public float sayacZaman;
    int patlayanBalon;
    public bool bolumSonu = false;
    public bool zamanSay = true;
    public GameObject patlama;
    public int sahneno;
    // Start is called before the first frame update
    void Start()
    {
        //Sahnenin build kısmındaki sıra numarasıdır.
        sahneno = SceneManager.GetActiveScene().buildIndex;

        switch (sahneno)
        {
            case 1:
                sayacZaman = 80f;
                patlayanBalon = 30;
                break;
            case 2:
                sayacZaman = 70f;
                patlayanBalon = 40;
                break;
            case 3:
                sayacZaman = 60f;
                patlayanBalon = 50;
                break;
            case 4:
                sayacZaman = 50f;
                patlayanBalon = 48;
                break;
        }

        /*
           if (sahneno == 1)
           {
               sayacZaman = 80f;
               patlayanBalon = 30;
           }
           else if (sahneno == 2)
           {
               sayacZaman = 70f;
               patlayanBalon = 40;
           }
           else if (sahneno == 3)
           {
               sayacZaman = 60f;
               patlayanBalon = 50;
           }
           else if (sahneno == 4)
           {
               sayacZaman = 50f;
               patlayanBalon = 48;
           }
       */

        balonText.text = "BALON: " + patlayanBalon;
    }

    // Update is called once per frame
    void Update()
    {
        if (sayacZaman > 0 && zamanSay)
        {
            sayacZaman -= Time.deltaTime;
            zamanText.text = "ZAMAN: " + (int)sayacZaman;
        }
        else
        {
            //ekradaki balon objelerinin hepsinin bulunması
            GameObject[] go = GameObject.FindGameObjectsWithTag("balon");
            for (int i = 0; i < go.Length; i++)
                Destroy(go[i]);
            // GameObject.FindGameObjectWithTag("button").gameObject.SetActive(true);
            button.gameObject.SetActive(true);
        }

        if (patlayanBalon <= 0)
        {
            bolumSonu = true;
            button2.gameObject.SetActive(true);
            zamanSay = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("balon"))
        {
            GameObject[] go = GameObject.FindGameObjectsWithTag("balon");
            for (int i = 0; i < go.Length; i++)
                Destroy(go[i]);

            button.gameObject.SetActive(true);
            bolumSonu = true;
            zamanSay = false;
        }
    }

    public void BalonCikar()
    {
        patlayanBalon -= 1;
        balonText.text = "BALON: " + patlayanBalon;
    }

    public void YenidenOyna()
    {
        SceneManager.LoadScene("Bolum1");
    }
    public void yeniBolum()
    {
        switch (sahneno)
        {
            case 1:
                SceneManager.LoadScene("Bolum2");
                break;
            case 2:
                SceneManager.LoadScene("Bolum3");
                break;
            case 3:
                SceneManager.LoadScene("Bolum4");
                break;
            case 4:
                SceneManager.LoadScene("Kazandiniz");
                break;
        }
/*
        if (sahneno == 1)
        {
            SceneManager.LoadScene("Bolum2");
        }
        else if(sahneno == 2)
        {
            SceneManager.LoadScene("Bolum3");
        }
        else if (sahneno == 3)
        {
            SceneManager.LoadScene("Bolum4");
        }
        else if (sahneno == 4)
        {
            SceneManager.LoadScene("Kazandiniz");
        }
*/
    }
}
