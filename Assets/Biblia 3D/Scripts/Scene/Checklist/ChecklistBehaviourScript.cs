using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Serve para trabalhar com o checklist para que possa exibir em caso de as mesmas estarem satisfeitas
 */
namespace Biblia3D.Scene.Checklist
{
    public class ChecklistBehaviourScript : MonoBehaviour
    {
        private Animator anim;
        public GameObject[] ticks;

        // Start is called before the first frame update
        void Start()
        {
            
            anim = GetComponent<Animator>();
            PlaySound();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void     Disable()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            if (!gameObject.activeSelf)
            {
                anim.SetTrigger("Change");
                gameObject.SetActive(true);
            }
            else
            {
                anim.SetTrigger("Change");
            }
        }

        public void PlaySound()
        {
            GetComponent<AudioSource>().Play();
        }
        public void PlaySoundTick1()
        {
            if (ticks[0].activeSelf)
            GetComponent<AudioSource>().Play();
        }
        public void PlaySoundTick2()
        {
            if (ticks[1].activeSelf)
                GetComponent<AudioSource>().Play();
        }
        public void PlaySoundTick3()
        {
            if (ticks[2].activeSelf)
                GetComponent<AudioSource>().Play();
        }
        public void PlaySoundTick4()
        {
            if (ticks[3].activeSelf)
                GetComponent<AudioSource>().Play();
        }
    }
}