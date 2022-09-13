using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject currentRoad;
    [SerializeField] Transform nextRoad1;
    [SerializeField] Transform nextRoad2;
    [SerializeField] Transform nextRoad3;
    [SerializeField] Transform nextRoad4;
    [SerializeField] Transform nextRoad5;
    [SerializeField] Transform nextRoad6;



    public float changeRoad=-1;

    public float dondurme;

    public bool justOne;
    void Start()
    {
        justOne = true;
    }

    


    private void OnTriggerStay(Collider other)
    {
        currentRoad = other.transform.gameObject;
        
        if (other.tag=="DikeyRoad"&&justOne==true)
        {
            

            changeRoad = Random.Range(0,3);

            switch (changeRoad)
            {
                case 0:
                    //nextRoad1.transform.position = new Vector3(0, 0, currentRoad.transform.GetChild(0).GetComponent<Renderer>().bounds.size.z/5);
                    //nextRoad1.transform.position = currentRoad.transform.GetChild(2).GetComponent<Transform>().position;
                    Instantiate(nextRoad1, currentRoad.transform.GetChild(2).GetComponent<Transform>().position, Quaternion.identity);
                    break;

                case 1:
                    //nextRoad2.transform.position = new Vector3(0, 0, currentRoad.transform.GetChild(0).GetComponent<Renderer>().bounds.size.z/5);
                    //nextRoad2.transform.position = currentRoad.transform.GetChild(2).GetComponent<Transform>().position;
                    Instantiate(nextRoad2, currentRoad.transform.GetChild(2).GetComponent<Transform>().position, Quaternion.identity);
                    break;

                case 2:
                    //nextRoad2.transform.position = new Vector3(0, 0, currentRoad.transform.GetChild(0).GetComponent<Renderer>().bounds.size.z/5);
                    //nextRoad2.transform.position = currentRoad.transform.GetChild(2).GetComponent<Transform>().position;
                    Instantiate(nextRoad3, currentRoad.transform.GetChild(2).GetComponent<Transform>().position, Quaternion.identity);
                    break;
            }

            justOne = false;
        }

        if ( other.tag=="YanYol" && justOne==true)
        {

            changeRoad = Random.Range(0,2);
              
            switch (changeRoad)
            {
                case 0:
                    
                    Instantiate(nextRoad4,currentRoad.transform.GetChild(2).GetComponent<Transform>().position, Quaternion.Euler(0, 90, 0));
                    
                    break;

                case 1:
                    Instantiate(nextRoad5, currentRoad.transform.GetChild(2).GetComponent<Transform>().position, Quaternion.Inverse(Quaternion.Euler(0, 0, 0)));
                    break;
            }    
            //Instantiate(nextRoad1,currentRoad.transform.GetChild(2).gameObject.transform.position, Quaternion.identity);
            
            justOne = false;
        }


        if (other.tag == "YanYolLeft" && justOne == true)
        {

            changeRoad = Random.Range(0, 2);

            switch (changeRoad)
            {
                case 0:
                    Instantiate(nextRoad4, currentRoad.transform.GetChild(2).gameObject.transform.position, Quaternion.Euler(0, -90, 0));
                    break;

                case 1:
                    Instantiate(nextRoad6, currentRoad.transform.GetChild(2).gameObject.transform.position, Quaternion.Inverse(Quaternion.Euler(0, 0, 0)));
                    break;
            }
            //Instantiate(nextRoad1,currentRoad.transform.GetChild(2).gameObject.transform.position, Quaternion.identity);

            justOne = false;
        }


        if (other.tag == "YanYolLeftDuz" && justOne == true)
        {

            changeRoad = Random.Range(0, 3);

            switch (changeRoad)
            {
                case 0:
                    Instantiate(nextRoad1, currentRoad.transform.GetChild(2).gameObject.transform.position, Quaternion.Inverse(Quaternion.Euler(0, 0, 0)));
                    break;

                case 1:
                    Instantiate(nextRoad2, currentRoad.transform.GetChild(2).gameObject.transform.position, Quaternion.Inverse(Quaternion.Euler(0, 0, 0)));
                    break;
                case 2:
                    Instantiate(nextRoad3, currentRoad.transform.GetChild(2).gameObject.transform.position, Quaternion.Inverse(Quaternion.Euler(0, 0, 0)));
                    break;
            }
            //Instantiate(nextRoad1,currentRoad.transform.GetChild(2).gameObject.transform.position, Quaternion.identity);

            justOne = false;
        }


        if (other.tag == "YanYolDuz" && justOne == true)
        {

            changeRoad = Random.Range(0, 3);

            switch (changeRoad)
            {
                case 0:
                    Instantiate(nextRoad1, currentRoad.transform.GetChild(2).gameObject.transform.position, Quaternion.Inverse(Quaternion.Euler(0, 0, 0)));
                    break;

                case 1:
                    Instantiate(nextRoad2, currentRoad.transform.GetChild(2).gameObject.transform.position, Quaternion.Inverse(Quaternion.Euler(0, 0, 0)));
                    break;
                case 2:
                    Instantiate(nextRoad3, currentRoad.transform.GetChild(2).gameObject.transform.position, Quaternion.Inverse(Quaternion.Euler(0, 0, 0)));
                    break;
            }
            //Instantiate(nextRoad1,currentRoad.transform.GetChild(2).gameObject.transform.position, Quaternion.identity);

            justOne = false;
        }


        if (other.tag == "HorizontalRoad" && justOne == true)
        {

            if (other.transform.rotation == Quaternion.Euler(0, 90, 0))
            {
                Instantiate(nextRoad5, currentRoad.transform.GetChild(2).gameObject.transform.position, Quaternion.Inverse(Quaternion.Euler(0, 0, 0)));
                justOne = false;
            }

            else
            {
                Instantiate(nextRoad6, currentRoad.transform.GetChild(2).gameObject.transform.position, Quaternion.Inverse(Quaternion.Euler(0, 0, 0)));
                justOne = false;
            }
            //Instantiate(nextRoad1,currentRoad.transform.GetChild(2).gameObject.transform.position, Quaternion.identity);

            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        justOne = true;
    }
}
