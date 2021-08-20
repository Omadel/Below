using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    [Header("ScriptableObject")]
    [SerializeField]
    public ArrowParametre arrowParametre;
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
        animationSpeed = arrowParametre.initialSpeed;
        animatorTrap.speed = 1;
    }
    void Update()
    {
        if (arrowParametre.arrowType==ArrowType.Solo)
        {
            if (arrowParametre.oneTimeSwing == true)
            {
                if (active == true && playOnce == false)
                {
                    playOnce = true;
                    StopCoroutine(SwingDelayed(arrowParametre.timeBeforeActivation));
                    StartCoroutine(SwingDelayed(arrowParametre.timeBeforeActivation));
                    animatorTrap.speed = animationSpeed;
                }
            }
            else
            {
                
                VerifyActivationAndSpeed();
            }
        }
        else if(arrowParametre.arrowType==ArrowType.Multiple)
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
            animatorTrap.speed= arrowParametre.initialSpeed;
            if(utilityBoolenDown==false&&trasitionBoolen==false)
            {
                StartCoroutine(UpWait(arrowParametre.timeDown));
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
        animationSpeed = arrowParametre.initialSpeed * ((float)purcent / 100f);
    }
    IEnumerator SwingDelayed(float time)
    {
        yield return new WaitForSeconds(time);
        animatorTrap.Play("attackOnTime");
    }
}
