using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine.AI;
using UnityEngine;
using UnityEditorInternal;
using UnityEditor;
using static UnityEditor.PlayerSettings;
using UnityEngine.UIElements;

public class AI_Behaviour : MonoBehaviour
{
    public Ai_stats stats;
    public Rigidbody body;
    public GameObject Projectile;
    public Collider Hurtbox;
    public Transform actorToHarm;
    Vector3 pos;
    public Health health;
    public float XEnd, ZEnd, minPlayerDist, maxPlayerDist;
    float steps;
    public bool hostile, melee;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        Hurtbox = GetComponent<Collider>();
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (hostile)
        {

            case false:
                {
                    randomMove();
                    break;
                }
            case true:
                {
                    if (melee)
                    {
                        MoveTowardsPlayer();
                    }
                    else
                    {
                        randomMove();
                        LaunchProjectile();
                    }
                    break;

                }
        }
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

        calculate_speed();

        if (Vector3.Distance(transform.position, pos) <= maxPlayerDist)
        {
            pos.x = Random.Range(-XEnd, XEnd);
            pos.z = Random.Range(-ZEnd, ZEnd);
            transform.LookAt(pos);
        }
        else
        {
            transform.position += transform.forward * steps;
        }


    }

    private void LaunchProjectile()
    {
        /*GameObject Clownjectile = Instantiate(Projectile, transform.position, Quaternion.identity);
        Clownjectile.AddComponent<>();*/

    }

    void MoveTowardsPlayer()
    {
        transform.LookAt(actorToHarm);
        calculate_speed();

        if (Vector3.Distance(transform.position, actorToHarm.position) >= minPlayerDist)
        {
            transform.position += transform.forward * steps;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && health.currentHealth != 0)
        {
            health.currentHealth = health.currentHealth - stats.meleeDamage;
            if (health.currentHealth <= 0)
            {
                Destroy(GameObject.FindWithTag("Player"));
            }

        }
        else
        {
            Physics.IgnoreCollision(collision.collider, Hurtbox);
        }
    }
}
