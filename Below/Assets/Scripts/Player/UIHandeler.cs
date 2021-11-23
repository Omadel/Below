using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class UIHandeler : MonoBehaviour {
    [SerializeField] private Slider HPBar, StaminaBar;
    [SerializeField, Range(0, 2)] private float barAnimtaionTime = .2f;
    [SerializeField] private Image bloodImage;
    [SerializeField, Range(0, 2)] private float bloodAnimtaionTime = .2f;
    [SerializeField] private Image deathScreen;
    [SerializeField, Range(0, 2)] private float deathAnimtaionTime = .2f;
    [SerializeField, Range(0, 10)] private float deathTimeBeforeRestart = 3f;

    private PlayerStats player;

    private void Start() {
        player = GetComponentInParent<PlayerStats>();

        HPBar.maxValue = player.MaxHP;
        HPBar.value = player.MaxHP;
        StaminaBar.maxValue = player.MaxStamina;
        StaminaBar.value = player.MaxStamina;
        deathScreen.gameObject.SetActive(false);
    }

    public void PlayHurtAnimation() {
        bloodImage.DOComplete();
        bloodImage.DOFade(1, bloodAnimtaionTime / 2f).SetLoops(2, LoopType.Yoyo);
    }
    public void UpdateHP() {
        HPBar.DOKill();
        HPBar.DOValue(player.CurrentHP, barAnimtaionTime);
    }
    public void UpdateStamina() {
        StaminaBar.DOKill();
        StaminaBar.DOValue(player.CurrentStamina, barAnimtaionTime);
    }

    public async Task Die() {
        deathScreen.gameObject.SetActive(true);
        Image[] images = deathScreen.GetComponentsInChildren<Image>();
        for(int i = 1; i < images.Length; i++) images[i].DOFade(0, 0);
        TMPro.TextMeshProUGUI[] texts = deathScreen.GetComponentsInChildren<TMPro.TextMeshProUGUI>();
        for(int i = 0; i < texts.Length; i++) texts[i].DOFade(0, 0);
        float targetAlpha = deathScreen.color.a;
        deathScreen.DOFade(0, 0);

        Sequence sequence = DOTween.Sequence();
        sequence.SetUpdate(true);
        sequence.SetDelay(.5f);
        sequence.Append(deathScreen.DOFade(targetAlpha, deathAnimtaionTime).SetUpdate(true));
        sequence.AppendInterval(deathAnimtaionTime);
        for(int i = 1; i < images.Length; i++) sequence.Join(images[i].DOFade(1, 0).SetUpdate(true));
        for(int i = 0; i < texts.Length; i++) sequence.Join(texts[i].DOFade(1, 0).SetUpdate(true));

        sequence.AppendInterval(deathTimeBeforeRestart);
        await sequence.AsyncWaitForCompletion();
    }
}
