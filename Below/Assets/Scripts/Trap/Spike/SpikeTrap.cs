using DG.Tweening;
using System.Collections;
using UnityEngine;

public class SpikeTrap : MonoBehaviour {
    [Header("ScriptableObject")]
    [SerializeField]
    public SpikeParametre spikeParametre;
    [HideInInspector]
    public GameObject activateur;
    [Header("SceneReference")]
    [SerializeField]
    private Animator animatorTrap;
    [SerializeField] private AnimationCurve curve;
    public bool active = false;
    private bool playOnce = false;
    private float animationSpeed = 1;
    [HideInInspector]
    public bool multipleBool = false;
    private bool utilityBoolenDown = false;
    private bool trasitionBoolen = false;
    private GameObject spikes;

    private void Start() {
        animationSpeed = spikeParametre.initialSpeed;
        if(animatorTrap != null) {
            animatorTrap.speed = 1;
        }
        spikes = transform.GetChild(1).gameObject;
    }

    private void Update() {
        if(spikeParametre.spikeType == SpikeType.Solo) {
            if(spikeParametre.oneTimeSwing == true) {
                if(active == true && playOnce == false) {
                    playOnce = true;
                    StopCoroutine(SwingDelayed(spikeParametre.timeBeforeActivation));
                    StartCoroutine(SwingDelayed(spikeParametre.timeBeforeActivation));
                    animatorTrap.speed = animationSpeed;
                }
            } else {

                VerifyActivationAndSpeed();
            }
        } else if(spikeParametre.spikeType == SpikeType.Multiple) {

            if(utilityBoolenDown == true) {
                animatorTrap.Play("wait");
            }
        }

    }
    private void VerifyActivationAndSpeed() {
        if(active == true) {
            if(animatorTrap != null) {
                animatorTrap.speed = spikeParametre.initialSpeed;
            }
            if(utilityBoolenDown == false && trasitionBoolen == false) {
                StartCoroutine(UpWait(spikeParametre.timeDown));
            } else if(utilityBoolenDown == true && trasitionBoolen == false) {
                StartCoroutine(DownWait(1));
            }
            if(utilityBoolenDown == true) {
                if(animatorTrap == null) {
                    spikes.transform.DOMoveY(0, animationSpeed).SetEase(curve);
                } else {
                    animatorTrap.Play("wait");
                }
            }
        } else {
            if(animatorTrap != null) {
                animatorTrap.speed = 0;
            }

        }
    }

    private IEnumerator UpWait(float time) {
        trasitionBoolen = true;
        utilityBoolenDown = true;
        yield return new WaitForSeconds(time);


        trasitionBoolen = false;
    }
    public IEnumerator DownWait(float time) {
        if(animatorTrap == null) {
            spikes.transform.DOMoveY(1, animationSpeed).SetEase(curve);
        } else {
            animatorTrap.Play("attack");
        }
        trasitionBoolen = true;
        utilityBoolenDown = false;
        yield return new WaitForSeconds(time);
        trasitionBoolen = false;
    }
    public float GetAnimationSpeed() {
        return animationSpeed;
    }
    public void ActualiseRotationSpeed(int purcent) {
        animationSpeed = spikeParametre.initialSpeed * (purcent / 100f);
    }

    private IEnumerator SwingDelayed(float time) {
        yield return new WaitForSeconds(time);
        if(animatorTrap != null) {
            animatorTrap.Play("attackOnTime");
        }
    }
}
