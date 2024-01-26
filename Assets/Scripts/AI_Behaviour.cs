using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine.AI;
using UnityEngine;
using UnityEditorInternal;

public class AI_Behaviour : MonoBehaviour
{
    public Ai_stats stats;
    public Rigidbody body;
    public float XEnd, YEnd, ZEnd;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        randomMove();
    }

    void randomMove()
    {
        Vector3 pos = transform.position;
        pos = new Vector3(pos.x, pos.y, pos.z);
        pos.x = Random.Range(1,XEnd);
        pos.y = Random.Range(1,YEnd);
        pos.z = Random.Range(1,ZEnd);
        body.MovePosition(pos);
    }
}
