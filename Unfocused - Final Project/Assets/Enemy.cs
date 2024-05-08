using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aoiti.Pathfinding; 

public class Enemy : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] public float baseDamage = 10f;
    [SerializeField] public float damage = 0f;
    [SerializeField] public float speed = 3f;

    [SerializeField] public float damageCooldown = 2f;
    public Transform enemyTransform;
    [SerializeField] public Vector2 currentPosition;
    
    [Header("Pathfinder")]
    [SerializeField] PlayerScript player;
    [SerializeField] float gridSize = 0.5f;
    Pathfinder<Vector2> pathfinder; 
    [SerializeField] LayerMask obstacles;
    [SerializeField] bool searchShortcut =false; 
    [SerializeField] bool snapToGrid =false; 
    Vector2 targetNode; 
    List <Vector2> path;
    List<Vector2> pathLeftToGo= new List<Vector2>();
    [SerializeField] bool drawDebugLines;

    [Header("Day/Night")]
    [SerializeField] DayNightCycle checkTOD;

    // Start is called before the first frame update
    void Start()
    {
        pathfinder = new Pathfinder<Vector2>(GetDistance, GetNeighbourNodes, 1000);
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = enemyTransform.localPosition;
        GetMoveCommand(player.currentPosition);
        if (pathLeftToGo.Count > 0) //if the target is not yet reached
        {
            Vector3 dir =  (Vector3)pathLeftToGo[0]-transform.position ;
            transform.position += dir.normalized * speed * Time.deltaTime;
            if (((Vector2)transform.position - pathLeftToGo[0]).sqrMagnitude <speed*speed*Time.deltaTime) 
            {
                transform.position = pathLeftToGo[0];
                pathLeftToGo.RemoveAt(0);
            }
        }

        if (drawDebugLines)
        {
            for (int i=0;i<pathLeftToGo.Count-1;i++) //visualize your path in the sceneview
            {
                Debug.DrawLine(pathLeftToGo[i], pathLeftToGo[i+1]);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.GetComponent<PlayerScript>() != null){
            other.GetComponent<PlayerScript>().HealthTracker(damage);
            for(int i = 0; i < damageCooldown * Time.deltaTime; i++){
                damage = 0;
            }
            damage = baseDamage;

            
            //other.GetComponent<PlayerScript>().DamageCooldown();
        }
    }

    void GetMoveCommand(Vector2 target)
    {
        Vector2 closestNode = GetClosestNode(transform.position);
        if (pathfinder.GenerateAstarPath(closestNode, GetClosestNode(target), out path)) //Generate path between two points on grid that are close to the transform position and the assigned target.
        {
            if (searchShortcut && path.Count>0)
                pathLeftToGo = ShortenPath(path);
            else
            {
                pathLeftToGo = new List<Vector2>(path);
                if (!snapToGrid) pathLeftToGo.Add(target);
            }

        }
        
    }


    /// <summary>
    /// Finds closest point on the grid
    /// </summary>
    /// <param name="target"></param>
    /// <returns></returns>
    Vector2 GetClosestNode(Vector2 target) 
    {
        return new Vector2(Mathf.Round(target.x/gridSize)*gridSize, Mathf.Round(target.y / gridSize) * gridSize);
    }

    /// <summary>
    /// A distance approximation. 
    /// </summary>
    /// <param name="A"></param>
    /// <param name="B"></param>
    /// <returns></returns>
    float GetDistance(Vector2 A, Vector2 B) 
    {
        return (A - B).sqrMagnitude; //Uses square magnitude to lessen the CPU time.
    }

    /// <summary>
    /// Finds possible conenctions and the distances to those connections on the grid.
    /// </summary>
    /// <param name="pos"></param>
    /// <returns></returns>
    Dictionary<Vector2,float> GetNeighbourNodes(Vector2 pos) 
    {
        Dictionary<Vector2, float> neighbours = new Dictionary<Vector2, float>();
        for (int i=-1;i<2;i++)
        {
            for (int j=-1;j<2;j++)
            {
                if (i == 0 && j == 0) continue;

                Vector2 dir = new Vector2(i, j)*gridSize;
                if (!Physics2D.Linecast(pos,pos+dir, obstacles))
                {
                    neighbours.Add(GetClosestNode( pos + dir), dir.magnitude);
                }
            }

        }
        return neighbours;
    }

    
    List<Vector2> ShortenPath(List<Vector2> path)
    {
        List<Vector2> newPath = new List<Vector2>();
        
        for (int i=0;i<path.Count;i++)
        {
            newPath.Add(path[i]);
            for (int j=path.Count-1;j>i;j-- )
            {
                if (!Physics2D.Linecast(path[i],path[j], obstacles))
                {
                    
                    i = j;
                    break;
                }
            }
            newPath.Add(path[i]);
        }
        newPath.Add(path[path.Count - 1]);
        return newPath;
    }

}
