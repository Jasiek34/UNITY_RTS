using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Assets.Scripts.Utils;

public class ObszarZaznaczenia : MonoBehaviour
{
    private LineRenderer lineRenderer;
    
    private Vector2 startowaPozycjaMyszy, obecnaPozycjaMyszy;

    // Start is called before the first frame update
    void Start()
    {
        
        lineRenderer= GetComponent<LineRenderer>();
        lineRenderer.positionCount=0;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startowaPozycjaMyszy = Utils.GetPozycjaMyszy();
            

            lineRenderer.positionCount = 4;
            lineRenderer.SetPosition(0, new Vector2(startowaPozycjaMyszy.x, startowaPozycjaMyszy.y));
            lineRenderer.SetPosition(1, new Vector2(startowaPozycjaMyszy.x, startowaPozycjaMyszy.y));
            lineRenderer.SetPosition(2, new Vector2(startowaPozycjaMyszy.x, startowaPozycjaMyszy.y));
            lineRenderer.SetPosition(3, new Vector2(startowaPozycjaMyszy.x, startowaPozycjaMyszy.y));


        }
        if (Input.GetMouseButton(0))
        {
            
            obecnaPozycjaMyszy = Utils.GetPozycjaMyszy();
            lineRenderer.SetPosition(0, new Vector2(startowaPozycjaMyszy.x, startowaPozycjaMyszy.y));
            lineRenderer.SetPosition(1, new Vector2(startowaPozycjaMyszy.x, obecnaPozycjaMyszy.y));
            lineRenderer.SetPosition(2, new Vector2(obecnaPozycjaMyszy.x, obecnaPozycjaMyszy.y));
            lineRenderer.SetPosition(3, new Vector2(obecnaPozycjaMyszy.x, startowaPozycjaMyszy.y));
        }

        if (Input.GetMouseButtonUp(0))
        {
            
            lineRenderer.SetPosition(0, new Vector2(startowaPozycjaMyszy.x, startowaPozycjaMyszy.y));
            lineRenderer.SetPosition(1, new Vector2(startowaPozycjaMyszy.x, startowaPozycjaMyszy.y));
            lineRenderer.SetPosition(2, new Vector2(startowaPozycjaMyszy.x, startowaPozycjaMyszy.y));
            lineRenderer.SetPosition(3, new Vector2(startowaPozycjaMyszy.x, startowaPozycjaMyszy.y));


        }

    }
}
