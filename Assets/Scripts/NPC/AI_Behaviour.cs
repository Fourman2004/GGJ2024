using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneTemplate;
using UnityEngine.AI;
using UnityEngine;
using UnityEditorInternal;
using UnityEditor;
using static UnityEditor.PlayerSettings;
using UnityEngine.UIElements;
using System.Buffers;

public class AI_Behaviour : MonoBehaviour
{
    //regular variables
    public Ai_stats stats;
    public Rigidbody body;
    Vector3 pos;

    //Movement Variables
    //XEnd/ZEnd gets random -x,x/-z,z positions
    //minPlayerDist/maxPlayerDist determine the distance the player needs to be in/out of for either attacks or determining new position
    //steps determines speed
    [Header("Ai Movement ranges")]
    public float XEnd, ZEnd, minPlayerDist, maxPlayerDist;
    float steps;

    //Enenmy variables
    //hostile determines if the NPC is aggressive
    //Melee determines if it will use ranged attacks
    //GameObjects are for (in this order) Projectile to fire and where it will spawn
    //collider for melee attacks
    //floats determine arc and speed of prjectile when launched
    //transform for player location
    //playerHealth gets the player health script for damage
    //int to not have the projectile shoot off every second
    [Header("AI hostility")]
    public bool hostile, melee;
    public GameObject Projectile, projectSpawnObj;
    public Collider Hurtbox;
    public float clownProjectForcefulness, clownProjectileUp, timeFrame;
    public Transform actorToHarm;
    public Health playerHealth;
    public AudioClip Shoot;
    public AudioClip[] Death;
    int cooldown;


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
                        

                    }
                    break;

                }
        }
    }

    /// <summary>
    /// calculates sprint/walk speed
    /// </summary>
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

    /// <summary>
    /// find random location, calculates speed, if the distance is less than or equal to the maximum player distance, choose new location.
    /// if hostile and ranged, shoot projectile (or decreases cooldown).
    /// else it will move to it's new location.
    ///</summary>
    void randomMove()
    {

        calculate_speed();

        if (Vector3.Distance(transform.position, pos) <= maxPlayerDist)
        {
            if(!melee && hostile)
            { LaunchProjectile();  }

            pos.x = Random.Range(-XEnd, XEnd);
            pos.z = Random.Range(-ZEnd, ZEnd);
            transform.LookAt(pos);
        }
        else
        {
            transform.position += transform.forward * steps;
        }


    }

    /// <summary>
    /// if the cooldown is not complete, will increment it until it can.
    /// will the spawn porojectile, with arc and force, towards the player.
    /// sets cooldown to 0
    /// </summary>
    private void LaunchProjectile()
    {
        if (cooldown != timeFrame)
        {
            cooldown++;
            Debug.Log(cooldown);
        }
        else
        {
            transform.LookAt(actorToHarm.position);
            AudioSource.PlayClipAtPoint(Shoot, transform.position);
            GameObject Clownjectile = Instantiate(Projectile, projectSpawnObj.transform.position, projectSpawnObj.transform.rotation);
            Rigidbody clownBody = Clownjectile.GetComponent<Rigidbody>();
            Vector3 clownForce = (projectSpawnObj.transform.forward * clownProjectForcefulness) + (transform.up * clownProjectileUp);
            clownBody.AddForce(clownForce, ForceMode.Impulse);
            
            cooldown = 0;
        }
    }

 /// <summary>
 /// gets player position
 /// if distance is greater than minimum, will move towards player.
 /// </summary>
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
        if (collision.gameObject.tag == "Player" && playerHealth.currentHealth != 0)
        {
            playerHealth.currentHealth = playerHealth.currentHealth - stats.meleeDamage;
            if (playerHealth.currentHealth <= 0)
            {
                Destroy(GameObject.FindWithTag("Player"));
            }

        }
        else
        {
            Physics.IgnoreCollision(collision.collider, Hurtbox);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("Collision detected");
        if (!other.gameObject.CompareTag("Projectile")) { return; }
        //Debug.Log("Projectile detected");
        if(!gameObject.GetComponent<Ai_stats>()) { return; }

        stats.health -= WhoopiePieCannon.instance.weaponDamage;
    }

    private void OnDestroy()
    {
        AudioSource.PlayClipAtPoint(Death[Random.Range(1,4)], transform.position);
    }
}
