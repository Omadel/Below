using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {
    public bool CanSprint => currentStamina > 0;

    [SerializeField] private InputAction debugLooseLife, debugGainLife;

    [SerializeField] private CMF.AdvancedWalkerController playerWalker;
    [SerializeField] private int maxHP = 100, maxStamina = 100;
    private float currentHP, currentStamina;
    [SerializeField] private float staminaGain = 2f, staminaUsage = 1f;
    [SerializeField] private Slider HPBar, StaminaBar;

    private void Awake() {
        playerWalker ??= GetComponent<CMF.AdvancedWalkerController>();
        playerWalker.StartSprinting += () => loseStamina = true;
        playerWalker.StopSprinting += () => loseStamina = false;

        debugGainLife.performed += _ => {
            currentHP += 5;
            HPBar.value = currentHP;
        };
        debugGainLife.Enable();
        debugLooseLife.Enable();
        debugLooseLife.performed += _ => {
            currentHP -= 5;
            HPBar.value = currentHP;
        };
    }

    private void Start() {
        currentHP = maxHP;
        HPBar.maxValue = maxHP;
        HPBar.value = maxHP;
        StartCoroutine(HandleStamina());
    }

    private void Update() {
        if(!CanSprint) {
            //todo recuperation
        }
    }

    private IEnumerator HandleStamina() {
        currentStamina = maxStamina;
        StaminaBar.maxValue = maxStamina;
        StaminaBar.value = maxStamina;

        while(true) {
            yield return new WaitForSeconds(.1f);
            if(loseStamina) {
                currentStamina -= staminaUsage * .1f;
            } else {
                currentStamina += staminaGain * .1f;
            }
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
            StaminaBar.value = currentStamina;
        }
    }

    private bool loseStamina;

}
