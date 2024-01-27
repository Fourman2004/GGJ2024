using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine.AI;
using UnityEngine;
using UnityEditorInternal;
using UnityEditor;

public class AI_Behaviour : MonoBehaviour
{
    public Ai_stats stats;
    public Rigidbody body;
    public Vector3 Location;
    public float XEnd, steps, ZEnd;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        steps = stats.speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        randomMove();
    }

    void randomMove()
    {
        Location = transform.position;
        Vector3 pos = transform.position;
        pos = new Vector3(pos.x, pos.y, pos.z);
        pos.x = Random.Range(1,XEnd);
        //pos.y = Random.Range(1,YEnd);
        pos.z = Random.Range(1,ZEnd);
        transform.position = Vector3.MoveTowards(Location,pos, steps);
        
    }
}
