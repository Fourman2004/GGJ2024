using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleAnimation : MonoBehaviour
{
    private Animator animator;
    private int isWalkingHash;
    private int isRunningHash;
    private int isKnockedHash;

    public bool isWalking;
    public bool isRunning;
    public bool isKnocked;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        GetHashes();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
