using Assets.Scripts;
using Assets.Scripts.Utils;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Unit : MonoBehaviour
{
    
    

    private IMovePosition movePosition;
    
    private GameObject podswietlenie;
    private bool isSelected;
    public bool IsSelected { get { return isSelected; } }

   

    private void Awake()
    {
        movePosition = GetComponent<MovePosition>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //ActiveCircle zaznaczenie aktywnej jednostki w grze 
        podswietlenie = transform.Find("ActiveCircle").gameObject;
        PodswietlWybranaJednostke(false);
        
        isSelected= false;
        


    }
    public void MoveTo(Vector3 targetPos)
    {
        movePosition.SetMovePosition(targetPos, () => { });
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSelected)
        {
            if(Input.GetMouseButtonDown(1)) 
            {
                MoveTo(Utils.GetPozycjaMyszy());
            }
        }

    }

    public void PodswietlWybranaJednostke(bool podswietlona)
    {
        podswietlenie.SetActive(podswietlona);
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
