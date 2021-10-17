using System.Collections;
using UnityEngine;

[DefaultExecutionOrder(0)]
public class TrapSequencer : MonoBehaviour {
    [SerializeField] private TrapSequenceParameter parameters;
    [SerializeField] private Trap[] traps;
    private Coroutine coroutine;

    private void Awake() {
        traps = GetComponentsInChildren<Trap>();
        TrapParameter trapParameter = ScriptableObject.CreateInstance<TrapParameter>();
        trapParameter.Initialize(parameters);
        foreach(Trap trap in traps) {
            trap.SetParameters(trapParameter);
        }
    }
    private void Start() {
        coroutine = StartCoroutine(Sequence());
    }
    private void OnDisable() {
        StopCoroutine(coroutine);
    }

    protected IEnumerator Sequence() {
        foreach(Trap trap in traps) {
            trap.StartSequence();
            yield return new WaitForSeconds(parameters.TimeBetweenTraps);
        }
    }
}
