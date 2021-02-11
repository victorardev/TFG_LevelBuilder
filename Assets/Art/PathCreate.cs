using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathCreate : MonoBehaviour
{
    public GameObject jeff;
    private LineRenderer lines;
    static public bool play = false, pathReady = false;
    public GameObject enemySpawn, basePlayer;
    public Transform posSpawn;

    void Start()
    {
        lines = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if(!play)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                pathReady = true;
            }
            if (!pathReady)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        Instantiate(jeff, hit.point, jeff.transform.rotation);
                        GameManager.pointList.Add(hit.point);
                    }
                    lines.positionCount = GameManager.pointList.ToArray().Length;
                    lines.SetPositions(GameManager.pointList.ToArray());
                }
            }
            
        } 
        else
        {
            Instantiate(enemySpawn, posSpawn.position, enemySpawn.transform.rotation);
            int index = GameManager.pointList.Count - 1;
            Instantiate(basePlayer, GameManager.pointList[index], base.transform.rotation);
            Destroy(this);
        }
        
    }
}
