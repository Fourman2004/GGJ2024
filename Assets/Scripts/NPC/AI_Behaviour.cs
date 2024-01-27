using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine.AI;
using UnityEngine;
using UnityEditorInternal;
using UnityEditor;
using static UnityEditor.PlayerSettings;

public class AI_Behaviour : MonoBehaviour
{
    public Ai_stats stats;
    public Rigidbody body;
    public GameObject Projectile;
    public Transform actorToHarm;
    public Collider Meleehurtbox;
    public float XEnd, ZEnd, minPlayerDist, maxPlayerDist;

    [SerializeField]
    float steps;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
    }

    public void calculate_speed()
    {
        if (stats.health < 50)
        {
            steps = (stats.speed * stats.SprintMultiplier) * Time.deltaTime;
        }
        else
        {
            steps = stats.speed * Time.deltaTime;
        }
    }
    void randomMove()
    {
        Vector3 pos = transform.position;
        pos = new Vector3(pos.x, pos.y, pos.z);
        pos.x = Random.Range(1, XEnd);
        //pos.y = Random.Range(1,YEnd);
        pos.z = Random.Range(1, ZEnd);
        calculate_speed();
        transform.position = Vector3.MoveTowards(transform.position, pos, steps);

    }

    void MoveTowardsPlayer()
    {
        transform.LookAt(actorToHarm);

        if (Vector3.Distance(transform.position, actorToHarm.position) >= minPlayerDist)
        {
            transform.position += transform.forward * steps * Time.deltaTime;
        }
        
        if(Vector3.Distance(transform.position, actorToHarm.position) <= maxPlayerDist)
        {
            Debug.Log("yay!");
        }
    }

    private void OnCollisionEnter()
    {
      
    }
}
