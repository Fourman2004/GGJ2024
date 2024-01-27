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
    public GameObject Projectile, actorToHarm;
    public Collider Meleehurtbox;
    public Vector3 Location;
    public float XEnd, ZEnd;

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
        Location = transform.position;
        Vector3 pos = transform.position;
        pos = new Vector3(pos.x, pos.y, pos.z);
        pos.x = Random.Range(1, XEnd);
        //pos.y = Random.Range(1,YEnd);
        pos.z = Random.Range(1, ZEnd);
        calculate_speed();
        transform.position = Vector3.MoveTowards(Location, pos, steps);

    }

    void MoveTowardsPlayer()
    {
        Location = transform.position;
        Vector3 playerPos = actorToHarm.transform.position;
        calculate_speed();
        transform.position = Vector3.MoveTowards(Location, playerPos, steps);
    }

    private void OnCollisionEnter()
    {
      
    }
}
