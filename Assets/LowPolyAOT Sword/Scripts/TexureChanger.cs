using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TexureChanger : MonoBehaviour
{
    private int matNumber = 0;
    //
    [SerializeField] Material[] texures;
    [SerializeField] Slider slider;
    //
    [Range(0, 10)]
    private float rotSpeed; 
    private MeshRenderer mr;
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }  
    void Update()
    {
        ChangeRotViaSlider();
    }
    private void ChangeRotViaSlider()
    {
        transform.Rotate(0, rotSpeed * 30 * Time.deltaTime, 0);
        rotSpeed = slider.value;
    }
    public void NextMaterial()
    {
        matNumber++;
        if (matNumber > 2)
            matNumber = 0;
        mr.material = texures[matNumber];
      
    }
    public void PreviousMaterial()
    {
        matNumber--;
        if (matNumber < 0)
            matNumber = 2;
        mr.material = texures[matNumber];

    }
}
