using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YaklasmaKontrolu : MonoBehaviour
{
    public Transform hedef;
    public float minimumUzaklik = 1f;
    public GameObject metin;
    public Transform portre, kutular;
    
    private bool metinGosteriliyor = false;
    private bool animasyonOynuyor;
    
    private void Update()
    {
        float uzaklik = Vector2.Distance(transform.position, hedef.position);

        if (uzaklik < minimumUzaklik && !metinGosteriliyor)
        {
            metin.SetActive(true);
            metinGosteriliyor = true;
        }
        else if (uzaklik >= minimumUzaklik && metinGosteriliyor)
        {
            metin.SetActive(false);
            metinGosteriliyor = false;
        }
        else if (Input.GetKey(KeyCode.E )&& !animasyonOynuyor)
        {
            animasyonOynuyor = true;
            StartCoroutine(AçılmaAnimasyonu());
        }
    }

    private IEnumerator AçılmaAnimasyonu()
    {
        var portreEskiPos = portre.position;
        var kutularEskiPos = kutular.position;
        
        portre.position = transform.position;
        kutular.position = transform.position;
        portre.localScale = Vector3.zero;
        kutular.localScale = Vector3.zero;
        portre.gameObject.SetActive(true);
        kutular.gameObject.SetActive(true);
        float elapsedTime = 0;
        while (elapsedTime <= 1)
        {
            elapsedTime += Time.deltaTime;
            portre.position = Vector3.Lerp(transform.position, portreEskiPos, elapsedTime);
            kutular.position = Vector3.Lerp(transform.position, kutularEskiPos, elapsedTime);
            portre.localScale = Vector3.Lerp(Vector3.zero, Vector3.one,  elapsedTime);
            kutular.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, elapsedTime);
            yield return null;
        }
    }
}
