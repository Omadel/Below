using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [Header("ScriptableObject")]
    [SerializeField]
    public SpikeParametre spikeParametre;
    [HideInInspector]
    public GameObject activateur;
    [Header("SceneReference")]
    [SerializeField]
    Animator animatorTrap;
    public bool active = false;
    bool playOnce = false;
    float animationSpeed = 1;
    [HideInInspector]
    public bool multipleBool=false;
    bool utilityBoolenDown=false;
    bool trasitionBoolen=false;

    void Start()
    {
        animationSpeed = spikeParametre.initialSpeed;
        animatorTrap.speed = 1;
    }
    void Update()
    {
        if (spikeParametre.spikeType==SpikeType.Solo)
        {
            if (spikeParametre.oneTimeSwing == true)
            {
                if (active == true && playOnce == false)
                {
                    playOnce = true;
                    StopCoroutine(SwingDelayed(spikeParametre.timeBeforeActivation));
                    StartCoroutine(SwingDelayed(spikeParametre.timeBeforeActivation));
                    animatorTrap.speed = animationSpeed;
                }
            }
            else
            {
                
                VerifyActivationAndSpeed();
            }
        }
        else if(spikeParametre.spikeType==SpikeType.Multiple)
        {

            if (utilityBoolenDown == true)
            {
                animatorTrap.Play("wait");
            }
        }

    }
    private void VerifyActivationAndSpeed()
    {
        if(active==true)
        {
            animatorTrap.speed=spikeParametre.initialSpeed;
            if(utilityBoolenDown==false&&trasitionBoolen==false)
            {
                StartCoroutine(UpWait(spikeParametre.timeDown));
            }
            else if(utilityBoolenDown == true && trasitionBoolen == false)
            {
                StartCoroutine(DownWait(1));
            }
            if(utilityBoolenDown == true)
            {
                animatorTrap.Play("wait");
            }
        }
        else
        {
            animatorTrap.speed=0;

        }
    }

    IEnumerator UpWait(float time)
    {
        trasitionBoolen = true;
        utilityBoolenDown = true;
        yield return new WaitForSeconds(time);
        

        trasitionBoolen = false;
    }
    public IEnumerator DownWait(float time)
    {
        animatorTrap.Play("attack");
        trasitionBoolen = true;
        utilityBoolenDown = false;
        yield return new WaitForSeconds(time);
        trasitionBoolen = false;
    }
    public float GetAnimationSpeed()
    {
        return animationSpeed;
    }
    public void ActualiseRotationSpeed(int purcent)
    {
        animationSpeed = spikeParametre.initialSpeed * ((float)purcent / 100f);
    }
    IEnumerator SwingDelayed(float time)
    {
        yield return new WaitForSeconds(time);
        animatorTrap.Play("attackOnTime");
    }
}
