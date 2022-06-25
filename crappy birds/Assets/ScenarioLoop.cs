using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Object = System.Object;
using Random = UnityEngine.Random;

public class ScenarioLoop : MonoBehaviour
{
    [SerializeField] private Transform obstacle;
    [SerializeField] private Transform player;
    
    private Vector2 _lastChildPos;
    private Vector2 _newChildPos;
    private float _random;
    private float _deleteDistance = 12f;
    

    private void Awake()
    {
        for (int i = 0; i < 10; i++)
        {
            CreateNewColumn();
        }
    }

    private void Update()
    {
        var playerXPos = player.transform.position.x;
        var firstChildXPos = transform.GetChild(0).transform.position.x;
        var lastChildXPos = GetLastChild().transform.position.x;
        
        
        if ( playerXPos -  firstChildXPos > _deleteDistance)
        {
            Destroy(transform.GetChild(0).gameObject);
            CreateNewColumn();
        }
        
        
        
    }

    private Transform GetLastChild()
    {
        var lastChild = transform.GetChild(transform.childCount - 1);
        return lastChild;
    }

    private void CreateNewColumn()
    {
        _random = Random.Range(-2, 3); 
         Transform newColumn;
        
        if (transform.childCount > 0)
        {
            _lastChildPos= GetLastChild().transform.position;
            _newChildPos = new Vector2(_lastChildPos.x + 5,_random);
            newColumn = Instantiate(obstacle,_newChildPos, quaternion.identity);
        }
        else
        {
            Vector2 firstColumnPos = new Vector3(6, _random);
            newColumn = Instantiate(obstacle, firstColumnPos , quaternion.identity);
        }

        newColumn.transform.parent = gameObject.transform;
    }
}
