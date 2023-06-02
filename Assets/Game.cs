using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
//import tmp



public class Game : MonoBehaviour
{

    public GameObject sword;
    // controller
    public GameObject[] fruits;
    bool isRotating = true;
    public GameObject controller;
    //make public text tmp
   



    void pickedUpSword()
    {
        disableSword();
        // set controller as parent
        sword.transform.SetParent(controller.transform);
        
        //rotate sword 90 degrees
        // sword.transform.Rotate(new Vector3(0, 0, 90));

    }

    void disableSword()
    {
        // sword.GetComponent<MeshRenderer>().enabled = false;
        isRotating = false;
        sword.GetComponent<Rigidbody>().isKinematic = false;

    }
    void Start()
    {
        InvokeRepeating("SpawnFruit", 0, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            sword.transform.Rotate(new Vector3(1, 1, 1) * Time.deltaTime * 100);
        } else {
            sword.transform.position = controller.transform.position;
            sword.transform.rotation = controller.transform.rotation * Quaternion.Euler(0, 90, 90);
        }

    }

    void SpawnFruit()
    {
        if (isRotating)
        {
            return;
        }

        GameObject randomFruit = fruits[Random.Range(0, fruits.Length)];
        Quaternion randomRotation = Quaternion.Euler(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));
        Vector3 randomPosition = new Vector3(10, Random.Range(47, 50), Random.Range(-1, 2));
        GameObject spawnedFruit = Instantiate(randomFruit, randomPosition, randomRotation);
        spawnedFruit.GetComponent<Rigidbody>().AddForce(Vector3.right * Random.Range(11, 13), ForceMode.Impulse);

        Destroy(spawnedFruit, 5);
    }

}
