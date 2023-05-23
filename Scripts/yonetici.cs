using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yonetici : MonoBehaviour
{
    private int yerlestirilen_parça = 0;

    private int toplam_puzzel = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void sayi_arttir()
    {
        yerlestirilen_parça++;
        if (yerlestirilen_parça == toplam_puzzel)
        {
            Debug.Log("Kilit açıldı diğer odaya geç");
        }
    }

    private void OnParticleTrigger()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
