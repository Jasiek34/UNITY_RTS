using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Assets.Scripts
{
    public class Mouse : MonoBehaviour
    {

        //public GameObject cursor;
        //public float speed;
        //public GameObject unitPrefab;
        private List<Unit> units;

        private Pathfinder pathFinder;
        private List<OverlayTile> path;
        private List<List<OverlayTile>> unitPaths;

        private void Start()
        {
            pathFinder = new Pathfinder();
            path = new List<OverlayTile>();
            unitPaths = new List<List<OverlayTile>>();
        }

        void LateUpdate()
        {
            units = UnitManager.Instance.SelectedUnitsList;
            
            RaycastHit2D? hit = GetFocusedOnTile();
            
            if (hit.HasValue)
            {
                Debug.Log("works");
                OverlayTile tile = hit.Value.collider.gameObject.GetComponent<OverlayTile>();
                //Debug.Log(tile.gridLocation.ToString());
                //cursor.transform.position = tile.transform.position;
                //cursor.gameObject.GetComponent<SpriteRenderer>().sortingOrder = tile.transform.GetComponent<SpriteRenderer>().sortingOrder;
                if (Input.GetMouseButtonDown(1))
                {
                    unitPaths = new List<List<OverlayTile>>();
                    //if (unit == null)
                    //{
                    //unit = Instantiate(unitPrefab).GetComponent<Unit>();
                    // PositionCharacterOnLine(tile);
                    //unit.standingOnTile = tile;
                    //}
                    foreach (var unit in units)
                    {
                        
                            path = pathFinder.FindPath(unit.GetTileNaKtorymStoi(), tile);
                            unitPaths.Add(path);
                        
                        
                    }

                    //path = pathFinder.FindPath(unit.GetTileNaKtorymStoi(), tile);

                    /*foreach( OverlayTile tile2 in path)
                    {
                        Debug.Log(tile2.gridLocation.ToString());
                    }*/
                }
            }
            int i = 0;
            foreach (var unitPath in unitPaths)
            {

                if (unitPath.Count > 0)
                {
                    /*foreach(OverlayTile o in unitPath)
                    {
                        Debug.Log($"path: {o.gridLocation.ToString()}");
                    }*/
                    MoveAlongPath(i, unitPath);
                }
                i++;
            }
            
        }

        private void MoveAlongPath(int i, List<OverlayTile> unitPath)
        {
            

            //Debug.Log("moved");
            var step = units[i].speed * Time.deltaTime;

            float zIndex = unitPath[0].transform.position.z;
            units[i].transform.position = Vector2.MoveTowards(units[i].transform.position, unitPath[0].transform.position, step);
            //units[i].transform.position = new Vector3(units[i].transform.position.x, units[i].transform.position.y, zIndex);


            if (Vector2.Distance(units[i].transform.position, unitPath[0].transform.position) < 0.1f)
            {
                PositionCharacterOnLine(unitPath[0], i);
                unitPath.RemoveAt(0);
            }

            /*if ((units[i].transform.position.x- unitPath[0].transform.position.x) < 0.01f)
            {
                PositionCharacterOnLine(unitPath[0], i);
                unitPath.RemoveAt(0);
            }
            else if ((units[i].transform.position.y- unitPath[0].transform.position.y) < 0.01f)
            {
                PositionCharacterOnLine(unitPath[0], i);
                unitPath.RemoveAt(0);
            }*/

        }

        private void PositionCharacterOnLine(OverlayTile tile, int i)
        {
            units[i].transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y + 0.0001f, tile.transform.position.z);
            //units[i].GetComponent<SpriteRenderer>().sortingOrder = tile.GetComponent<SpriteRenderer>().sortingOrder;
            //unit.standingOnTile = tile;
        }

        private static RaycastHit2D? GetFocusedOnTile()
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos2D, Vector2.zero);

            if (hits.Length > 0)
            {
                return hits.OrderByDescending(i => i.collider.transform.position.z).First();
            }

            return null;
        }
    }
}