using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float carSpeed;
    [SerializeField] float maxSpeed;


    //Max d�nme a��m�z
    [SerializeField] float maxAngle;

    //S�rt�nmeyi transform �zerinden de yapabiliriz
    float dragAmo = 0.998f;

    //Arkadan �eki� de�i�kenimiz
    [SerializeField] float Traction;

    

    //�n tekerlerin d�nme i�lemi i�in vekt�r tan�ml�yoruz
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

        //y ekseninde de�i�iklik yap�caz bunu da anlamak i�in kullan�c�dan input ald���m�zda yap�caz. 
        rotationVector += new Vector3(0, Input.GetAxis("Horizontal"), 0);

        //Clamp fonksiyonu istedi�imiz bir de�eri s�n�rland�rmam�z� sa�l�yor
        moveVector = Vector3.ClampMagnitude(moveVector, maxSpeed);

        //Daha ger�ek�i bir s�rt�nme i�in yapt���m�z i�lem
        moveVector = Vector3.Lerp(moveVector.normalized, transform.forward, Traction) * moveVector.magnitude;


        rotationVector = Vector3.ClampMagnitude(rotationVector, maxAngle);

        //Quaternion.Euler fonksiyonu vekt�re g�re a�� vermemizi sa�l�yor rotation da kullan�labilir.
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
