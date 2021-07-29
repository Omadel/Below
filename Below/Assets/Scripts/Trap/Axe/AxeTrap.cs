using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AxeTrap : Trap
{
    [Header("ScriptableObject")]
    [SerializeField]
    public AxeParametre axeParametre;
    [HideInInspector]
    public GameObject activateur;
    [Header("SceneReference")]
    [SerializeField]
    GameObject TrapPivot;
    Animator animatorTrap;
    public bool active =false;
    bool playOnce = false;
    float animationSpeed=1;
    void Start()
    {
        animationSpeed = axeParametre.initialSpeed;
        animatorTrap = TrapPivot.GetComponent<Animator>();
        animatorTrap.speed = 0;
    }

    void Update()
    {
        if (axeParametre.oneTimeSwing == true)
        {
            if (active == true && playOnce == false)
            {
                playOnce = true;
                StopCoroutine(SwingDelayed(axeParametre.timeBeforeActivation));
                StartCoroutine(SwingDelayed(axeParametre.timeBeforeActivation));
                animatorTrap.speed = animationSpeed;
            }
        }
        else
        {
            animatorTrap.Play("AxeTrap");
            VerifyActivationAndSpeed();
        }

    }

    private void VerifyActivationAndSpeed()
    {
        if (active == true)
        {
            if (animatorTrap.speed != animationSpeed)
            {
                animatorTrap.speed = animationSpeed;
            }
        }
        else
        {
            if (animatorTrap.speed != 0)
            {
                animatorTrap.speed = 0;
            }
        }
    }

    public float GetAnimationSpeed()
    {
        return animationSpeed;
    }
    public void ActualiseRotationSpeed(int purcent)
    {
        animationSpeed =axeParametre.initialSpeed*((float)purcent/100f);
    }
    IEnumerator SwingDelayed(float time)
    {
        yield return new WaitForSeconds(time);
        animatorTrap.Play("OneSwing");
    }
}
