using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;


public class RandomMovement : MonoBehaviour
{
    #region Editor Variables
    [SerializeField]
    [Tooltip("how long the object would wait until searching for next destination")]
    private float m_timeForNew;

    #endregion

    #region Private Variables


    private NavMeshAgent navMeshAgent;
    private NavMeshPath path;

    private bool inCoRoutine;
    private Vector3 target;
    private bool validPath;

    #endregion

    #region Initialization
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        path = new NavMeshPath();
    }

    #endregion

    #region

    private void Update()
    {
        if (!inCoRoutine)
            StartCoroutine(searchAndMove());
    }
    private Vector3 getNewRandomPosition()
    {
        float x = Random.Range(-300, 300);
        //   float y = Random.Range(-20, 20);
        float z = Random.Range(-300, 300);
        Vector3 pos = new Vector3(x, 0, z);
        return pos;

    }



    #endregion

    #region
    private IEnumerator searchAndMove()
    {
        inCoRoutine = true;
        yield return new WaitForSeconds(m_timeForNew);
        GetNewPath();
        if (navMeshAgent.isOnNavMesh)
        {
            validPath = navMeshAgent.CalculatePath(target, path);
            while (!validPath)
            {
                yield return new WaitForSeconds(0.01f);
                GetNewPath();
                validPath = navMeshAgent.CalculatePath(target, path);
            }
        }
 
        

        inCoRoutine = false;
    }

    private void GetNewPath()
    {
        target = getNewRandomPosition();
        if (navMeshAgent.isOnNavMesh)
            navMeshAgent.SetDestination(target);
    }
}
    #endregion

