using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    
    public float speed = 1.0f;


    private Vector2 target;
    private GameObject selectedGObj;
    private bool isSelected;
    public bool IsSelected { get { return isSelected; } }

    // Start is called before the first frame update
    void Start()
    {
        //ActiveCircle zaznaczenie aktywnej jednostki w grze 
        selectedGObj = transform.Find("ActiveCircle").gameObject;
        PodswietlWybranaJednostke(false);
        target= transform.position;
        isSelected= false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)&& isSelected)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    public void PodswietlWybranaJednostke(bool podswietlona)
    {
        selectedGObj.SetActive(podswietlona);
        if(podswietlona)
        {
            isSelected= true;
        }
        else
        {
            isSelected= false;
        }
    }

}
