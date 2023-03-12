using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Unit : MonoBehaviour
{
    
    public float speed = 1.0f;


    
    private GameObject selectedGObj;
    private bool isSelected;
    public bool IsSelected { get { return isSelected; } }

    //public OverlayTile standingOnTile = MapManager.Instance.map.ElementAt(0).Value;
    private OverlayTile tileNaKtorymStoi;


    // Start is called before the first frame update
    void Start()
    {
        //ActiveCircle zaznaczenie aktywnej jednostki w grze 
        selectedGObj = transform.Find("ActiveCircle").gameObject;
        PodswietlWybranaJednostke(false);
        
        isSelected= false;
        //Vector2Int position = new Vector2Int((int)this.transform.position.x, (int)this.transform.position.y);
        //standingOnTile = MapManager.Instance.map[position ];


    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetMouseButtonDown(1)&& isSelected)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);*/
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

    public OverlayTile GetTileNaKtorymStoi()
    {
        /*if(tileNaKtorymStoi== null)
        {
            tileNaKtorymStoi = MapManager.Instance.map.ElementAt(0).Value;
            transform.position = tileNaKtorymStoi.transform.position; 
        }*/
        Vector2Int position = new Vector2Int((int)this.transform.position.x, (int)this.transform.position.y);
        OverlayTile standingOnTile = MapManager.Instance.map[position ];
        Debug.Log($"stojê na {standingOnTile.gridLocation.ToString()}");
        return standingOnTile;
    }


}
