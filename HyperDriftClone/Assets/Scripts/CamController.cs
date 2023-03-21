using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{

    public Transform araba; // Hareketi takip edilecek araba
    public Vector3 mesafe; // Kamera ile arasindaki mesafe
    public float hiz = 5f; // Kameranin hareket hizi

    private Vector3 hedefPos; // Hedef pozisyon
    private Vector3 hedefRot; // Hedef rotasyon

    void Start()
    {
        // Kameranin baþlangic pozisyonunu ve rotasyonunu belirle
        hedefPos = araba.position + mesafe;
        hedefRot = transform.eulerAngles;
    }

    void Update()
    {
        // Arabanin pozisyonuna gore kameranin pozisyonunu guncelle
        Vector3 yeniPos = Vector3.Lerp(transform.position, hedefPos, 5f * Time.deltaTime);
        transform.position = yeniPos;

        // Arabanin yonune dogru bak
        Quaternion yeniRot = Quaternion.Lerp(transform.rotation, Quaternion.Euler(hedefRot), hiz * Time.deltaTime);
        transform.rotation = yeniRot;

        // Kamera kontrolu icin inputlari al
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");


        // Kameranin konumunu ve rotasyonunu guncelle
        hedefRot.y += horizontal * 2f;
        hedefRot.x -= vertical * 2f;
        hedefRot.x = Mathf.Clamp(hedefRot.x, -10f, 60f);
        hedefPos = Quaternion.Euler(hedefRot) * new Vector3(0f, 2f, -mesafe.magnitude) + araba.position;

        if (horizontal==0)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation,araba.rotation,0.01f);
            hedefRot.x = Mathf.Clamp(hedefRot.x, -10f, 60f);
        }
    }
}

