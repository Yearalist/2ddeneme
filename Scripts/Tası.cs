using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tası : MonoBehaviour
{
    private Camera kamera;
    private Vector3 başlangıç_pozisyonu;
    private GameObject[] Kutu_dizisi;
    private yonetici yonet;
    private bool beniHareketEttiriyor;
    private bool tabloTamam;
    
    private void OnMouseDrag()
    {
        beniHareketEttiriyor = true;
        Vector3 pozisyon = kamera.ScreenToWorldPoint(Input.mousePosition);
        pozisyon.z = 0;
        transform.position = pozisyon;
    }


    void Start()
    {
        kamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        başlangıç_pozisyonu = transform.localPosition;
        Kutu_dizisi = GameObject.FindGameObjectsWithTag("Kutu");
        //yonet = GameObject.Find("yonetici").GetComponent<yonetici>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0) && beniHareketEttiriyor)
        {
            beniHareketEttiriyor = false;
            foreach (GameObject kutu in Kutu_dizisi)
            {
                if (kutu.name == gameObject.name)
                {
                    float mesafe = Vector3.Distance(kutu.transform.position, transform.position);

                    if (mesafe <= 1)
                    {
                        transform.position = kutu.transform.position;
                    }
                    else
                    {
                        transform.localPosition= başlangıç_pozisyonu;
                    }
                }
            }
        }
    }
}