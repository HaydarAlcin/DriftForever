using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float carSpeed;
    [SerializeField] float maxSpeed;


    //Max dönme açýmýz
    [SerializeField] float maxAngle;

    //Sürtünmeyi transform üzerinden de yapabiliriz
    float dragAmo = 0.998f;

    //Arkadan çekiþ deðiþkenimiz
    [SerializeField] float Traction;

    

    //Ön tekerlerin dönme iþlemi için vektör tanýmlýyoruz
    Vector3 rotationVector;
    public Transform leftWheel, rightWheel;

    Vector3 moveVector;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveVector * Time.deltaTime;
    }

    private void FixedUpdate()
    {

        moveVector += transform.forward * carSpeed;
        
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * maxAngle * Time.deltaTime * moveVector.magnitude);

        moveVector *= dragAmo;

        //y ekseninde deðiþiklik yapýcaz bunu da anlamak için kullanýcýdan input aldýðýmýzda yapýcaz. 
        rotationVector += new Vector3(0, Input.GetAxis("Horizontal"), 0);

        //Clamp fonksiyonu istediðimiz bir deðeri sýnýrlandýrmamýzý saðlýyor
        moveVector = Vector3.ClampMagnitude(moveVector, maxSpeed);

        //Daha gerçekçi bir sürtünme için yaptýðýmýz iþlem
        moveVector = Vector3.Lerp(moveVector.normalized, transform.forward, Traction) * moveVector.magnitude;


        rotationVector = Vector3.ClampMagnitude(rotationVector, maxAngle);

        //Quaternion.Euler fonksiyonu vektöre göre açý vermemizi saðlýyor rotation da kullanýlabilir.
        leftWheel.localRotation = Quaternion.Euler(rotationVector);
        rightWheel.localRotation = Quaternion.Euler(rotationVector);







        if (Input.GetAxis("Horizontal") == 0)
        {
            
            //if (rotationVector.y >= -2 && rotationVector.y <= 2)
            //{
            //    rotationVector = Vector3.ClampMagnitude(rotationVector, 0);
            //}
            rotationVector = Vector3.Lerp(rotationVector, Vector3.zero, 0.1f);
        }
    }


}
