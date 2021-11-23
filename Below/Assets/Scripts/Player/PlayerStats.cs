using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStats : MonoBehaviour {
    public bool CanSprint => currentStamina > 0;
    public float MaxHP => maxHP;
    public float CurrentHP => currentHP;
    public float MaxStamina => maxStamina;
    public float CurrentStamina => currentStamina;

    [SerializeField] private InputAction debugLooseLife, debugGainLife;
    [SerializeField] private CMF.AdvancedWalkerController playerWalker;
    [SerializeField] private int maxHP = 100, maxStamina = 100;
    [SerializeField] private float staminaGain = 2f, staminaUsage = 1f, invincibilityTimer = 1f;
    [SerializeField] private UIHandeler uIHandeler;

    private float currentHP, currentStamina;
    private bool isInvincible = false;
    private bool loseStamina;

    private void Awake() {
        playerWalker ??= GetComponent<CMF.AdvancedWalkerController>();
        playerWalker.StartSprinting += () => loseStamina = true;
        playerWalker.StopSprinting += () => loseStamina = false;
        uIHandeler ??= GetComponentInChildren<UIHandeler>();
    }

    private void Start() {
        currentHP = maxHP;
        StartCoroutine(HandleStamina());
    }

    private void Update() {
        if(!CanSprint) {
            //todo recuperation
        }
    }

    private IEnumerator HandleStamina() {
        currentStamina = maxStamina;

        while(true) {
            yield return new WaitForSeconds(.1f);
            if(loseStamina) currentStamina -= staminaUsage * .1f;
            else currentStamina += staminaGain * .1f;
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
            uIHandeler.UpdateStamina();
        }
    }



    public void LooseLife(int amount, Vector3 direction) {
        if(isInvincible) {
            Debug.Log("Is invicible");
            return;
        }
        Debug.Log("Looose Life");
        currentHP -= amount;
        uIHandeler.UpdateHP();
        if(currentHP <= 0) {
            Die();
            return;
        }
        uIHandeler.PlayHurtAnimation();
        LaunchInvincibility();
    }

    private async void Die() {
        Time.timeScale = .3f;
        await uIHandeler.Die();
        Time.timeScale = 1f;
        int index = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        Debug.Log(index);
        DG.Tweening.DOTween.KillAll();
        Etienne.SceneLoader.Instance.UnloadLevels(index).LoadLevels(index).StartLoading();
    }

    private async void LaunchInvincibility() {
        isInvincible = true;
        await System.Threading.Tasks.Task.Delay((int)(invincibilityTimer * 1000));
        isInvincible = false;
    }
}
