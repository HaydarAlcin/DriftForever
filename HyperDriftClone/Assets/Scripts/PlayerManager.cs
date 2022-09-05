using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] GameObject currentRoad;
    [SerializeField] Transform  nextRoad1;
    [SerializeField] Transform  nextRoad2;



    public float changeRoad=-1;


    public bool justOne;
    void Start()
    {
        justOne = true;
    }

    void Update()
    {
        
    }


    private void OnTriggerStay(Collider other)
    {
        currentRoad = other.transform.gameObject;
        
        if (other.tag=="DikeyRoad"&&justOne==true)
        {
            

            changeRoad = Random.Range(0, 2);

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
            }

            justOne = false;
        }

        if (justOne==true)
        {
            
            
                Instantiate(nextRoad1,currentRoad.transform.GetChild(2).gameObject.transform.position, Quaternion.identity);
            

            justOne = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        justOne = true;
    }
}
