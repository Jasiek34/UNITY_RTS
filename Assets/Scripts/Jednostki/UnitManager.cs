using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Assets.Scripts.Utils;


public class UnitManager : MonoBehaviour
{
    


    private Vector2 pozycjaMyszy;
    private List<Unit> selectedUnitsList;

    

    // Start is called before the first frame update
    void Start()
    {
        selectedUnitsList = new List<Unit>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            pozycjaMyszy = Utils.GetPozycjaMyszy();
            
        }
        

        if (Input.GetMouseButtonUp(0))
        {
            
            Collider2D[] zaznaczoneCollidery = Physics2D.OverlapAreaAll(pozycjaMyszy, Utils.GetPozycjaMyszy());

            foreach (Unit unit in selectedUnitsList)
            {
                unit.PodswietlWybranaJednostke(false);
            }
            selectedUnitsList.Clear();
            foreach (Collider2D collider2D in zaznaczoneCollidery)
            {
                Unit unit = collider2D.GetComponent<Unit>();
                if (unit != null)
                {
                    unit.PodswietlWybranaJednostke(true);
                    selectedUnitsList.Add(unit);
                }
            }
            Debug.Log(selectedUnitsList.Count);
        }
    }
}
