using UnityEngine;
using Vuforia;

public class CustomObserverHandler : DefaultTrackableEventHandler
{
    protected override void OnTrackingLost()
    {
        // Deixa propositalmente vazio
        // Assim, o objeto nunca é desativado quando o target some
        Debug.Log("Target perdido, mas mantendo objeto ativo.");
    }
}
