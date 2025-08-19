using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Biblia3D.Scene.Revista;

[Obsolete("Tentei ser organizado, mas o jogo não deixa")]
public class RevistaTrackableEventHandler : Biblia3dTrackableEventHandler {

    public float waitForSeconds = 10;

    private bool found = false;

    protected override void OnTrackingFound()
    {
        base.OnTrackingFound();
        found = true;
    }

    protected override void OnTrackingLost()
    {
        base.OnTrackingLost();

        found = false;

        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(waitForSeconds);

        if (!found)
            Biblia3D.Scene.Revista.RevistaSceneComponent.LoadScene(new RevistaSceneRequest(), (outcome) => { });
    }
}
