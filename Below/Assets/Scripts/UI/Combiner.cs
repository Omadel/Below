using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Combiner : MonoBehaviour {


    [SerializeField] private Slot[] itemsToCombine = new Slot[2];
    [SerializeField] private Slot output;

    private void Awake() {
        button = GetComponent<Button>();
        button.interactable = false;

        itemsToCombine[0].OnDropEvent += _ => SetAndCheckCanCombine(0, true);
        itemsToCombine[0].OnClearedEvent += () => SetAndCheckCanCombine(0, false);
        itemsToCombine[1].OnDropEvent += _ => SetAndCheckCanCombine(1, true);
        itemsToCombine[1].OnClearedEvent += () => SetAndCheckCanCombine(1, false);
    }

    private void SetAndCheckCanCombine(int index, bool canCombine) {
        this.canCombine[index] = canCombine;
        button.interactable = CanCombine;
    }

    public void Combine() {
        if(CanCombine) {
            Debug.Log($"Combine {itemsToCombine[0].Draggable.name} and {itemsToCombine[1].Draggable.name}");
            for(int i = 0; i < 2; i++) {
                GameObject.Destroy(itemsToCombine[i].Draggable.gameObject);
                itemsToCombine[i].CleanSlot();
            }
        }
    }

    private Button button;
    private bool CanCombine => canCombine[0] && canCombine[1];
    private bool[] canCombine = new bool[2] { false, false };
}
