using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimation : MonoBehaviour
{
    private Animator animator;
    private int isWalkingHash;
    private int isRunningHash;
    private int isKnockedHash;

    public bool isWalking;
    public bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        GetHashes();
        //IsKnocked();
        //IsWalking(isWalking);
        //IsRunning(isRunning);
    }

    // Update is called once per frame
    void Update()
    {
        IsWalking(isWalking);
        IsRunning(isRunning);
    }

    void GetHashes()
    {
        const string isWalkingString = "isWalking";
        const string isRunningString = "isRunning";
        const string isKnockedString = "isKnocked";
        isWalkingHash = Animator.StringToHash(isWalkingString);
        isRunningHash = Animator.StringToHash(isRunningString);
        isKnockedHash = Animator.StringToHash(isKnockedString);
    }

    public void IsKnocked()
    {
        animator.SetTrigger(isKnockedHash);
    }


    void IsWalking(bool currentState)
    {
        animator.SetBool(isWalkingHash, currentState);
    }

    void IsRunning(bool currentState)
    {
        animator.SetBool(isRunningHash, currentState);
    }
}
