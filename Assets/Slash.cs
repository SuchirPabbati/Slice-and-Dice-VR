using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EzySlice;
using UnityEngine.UI;
using TMPro;
public class Slash : MonoBehaviour
{
    GameObject objectToSlice;
    public Material inside;
    public TextMeshPro scoreText;
    public int score = 0;
    public ParticleSystem particles;
    public ParticleSystem particles2;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.tag);
       if (other.gameObject.tag == "Fruit")
       {
            objectToSlice = other.gameObject;
            SlicedHull sliced = Slice(objectToSlice.transform.position, this.transform.forward);
            GameObject upperHullGameobject = sliced.CreateUpperHull(objectToSlice, inside);
            GameObject lowerHullGameobject = sliced.CreateLowerHull(objectToSlice, inside);
            int random = Random.Range(0, 2);
            ParticleSystem picked = random == 0 ? particles : particles2;
            ParticleSystem particle = Instantiate(picked, objectToSlice.transform.position, Quaternion.identity);
            Destroy(particle, 0.25f);
            Destroy(objectToSlice);
            upperHullGameobject.AddComponent<BoxCollider>();
            lowerHullGameobject.AddComponent<BoxCollider>();
            upperHullGameobject.AddComponent<Rigidbody>();
            lowerHullGameobject.AddComponent<Rigidbody>();
            upperHullGameobject.GetComponent<Rigidbody>().AddForce(Vector3.right * 10, ForceMode.Impulse);
            lowerHullGameobject.GetComponent<Rigidbody>().AddForce(Vector3.left * 10, ForceMode.Impulse);
            Destroy(upperHullGameobject, 2);
            Destroy(lowerHullGameobject, 2);
            score += 1;
            scoreText.text = "Score: " + score;
       }
    }
    public SlicedHull Slice(Vector3 planeWorldPosition, Vector3 planeWorldDirection)
    {
        return objectToSlice.Slice(planeWorldPosition, planeWorldDirection);
    }

}
