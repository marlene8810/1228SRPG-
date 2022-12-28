using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMap : MonoBehaviour
{
    private GridCell[,] map;
    private GridCell hoverCell;
    
    void Start()
    {
        InitGridMap();
    }

    // Update is called once per frame
    void Update()
    {
        HoverCell();
    }

    void HoverCell()
    {
        
        int cellLayer = LayerMask.GetMask("MapCell"); 
        if (Physics.Raycast(
            Camera . main.ScreenPointToRay(Input.mousePosition),out RaycastHit hitinfo ,200, cellLayer
))
        {
           
            if(hitinfo.collider.tag == "MapCell")
            {
                
                GridCell cell = hitinfo.collider.GetComponent<GridCell>();

               
                if (hoverCell)
                {
                  
                    if (hoverCell == cell) return;

                   
                    else if (hoverCell != cell)
                    {
                        
                        hoverCell.hoverDisplay.SetActive(false);

                       
                        cell.hoverDisplay.SetActive(true);
                        hoverCell = cell;
                    }
                }
            }
        }
}

 void InitGridMap()
    {
        map = new GridCell[8, 15];

        for (int y = 0; y < 8 ; y++ )
        {
            for (int x = 0; x < 15 ; x++ )
            {
                
                float px = x * 10;
                float py = y  * -10;

                Ray ray = new Ray(new Vector3(px, 100, py), new Vector3(0, -1, 0));
                int cellLayer = LayerMask.GetMask("MapCell");
                if (Physics.Raycast (ray , out RaycastHit hitinfo, 200, cellLayer))
                {

                    if (hitinfo.collider.tag == "MapCell")
                    {
                        
                        GridCell cell = hitinfo.collider.GetComponent<GridCell>();

                        
                        cell.SetGridXY(x, y);

                       
                        map[y, x] = cell;
                    }
                }
            }
        }
    }
}
