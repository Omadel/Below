using System.Collections;
using UnityEngine;


public class AxeTrap : Trap {
    [Header("ScriptableObject")]
    [SerializeField]

    public AxeParametre axeParametre;
    [HideInInspector]
    public GameObject activateur;
    [Header("SceneReference")]
    [SerializeField]
    private GameObject TrapPivot;
    private Animator animatorTrap;
    public bool active = false;
    private bool playOnce = false;
    private float animationSpeed = 1;

    private void Start() {
        animationSpeed = axeParametre.initialSpeed;
        animatorTrap = TrapPivot.GetComponent<Animator>();
        animatorTrap.speed = 0;
    }

    private void Update() {
        if(axeParametre.oneTimeSwing == true) {
            if(active == true && playOnce == false) {
                playOnce = true;
                StopCoroutine(SwingDelayed(axeParametre.timeBeforeActivation));
                StartCoroutine(SwingDelayed(axeParametre.timeBeforeActivation));
                animatorTrap.speed = animationSpeed;
            }
        } else {
            animatorTrap.Play("AxeTrap");
            VerifyActivationAndSpeed();
        }

    }

    private void VerifyActivationAndSpeed() {
        if(active == true) {
            if(animatorTrap.speed != animationSpeed) {
                animatorTrap.speed = animationSpeed;
            }
        } else {
            if(animatorTrap.speed != 0) {
                animatorTrap.speed = 0;
            }
        }
    }

    public float GetAnimationSpeed() {
        return animationSpeed;
    }
    public void ActualiseRotationSpeed(int purcent) {
        animationSpeed = axeParametre.initialSpeed * (purcent / 100f);
    }

    private IEnumerator SwingDelayed(float time) {
        yield return new WaitForSeconds(time);
        animatorTrap.Play("OneSwing");
    }

    public void Collide(Collision collision) {
        if(collision.transform.CompareTag("Player")) {
            PlayerStats player = collision.transform.GetComponent<PlayerStats>();
            player.LooseLife(axeParametre.dommage);
        }
    }
}
