using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Biblia3D.Scene.Subtitle
{
    public class SubtitleLoadSceneBehaviour : MonoBehaviour
    {
        public SubtitleSceneRequest request;
        public System.Action<SubtitleSceneResponse> callback;

        // Start is called before the first frame update
        void Start()
        {
            if (request != null)
            {
                SubtitleSceneComponent.LoadScene(request, callback);
            }

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnDestroy()
        {
            if (SubtitleSceneComponent.IsLoaded) SubtitleSceneComponent.CloseSceneLoaded();
        }
    }
}