using AllosiusDevCore;
using AllosiusDevUtilities.Audio;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AllosiusDevCore
{
    [Serializable]
    public class FeedbackPlaySound : BaseFeedback
    {
        [InfoBox("Play a clip audio")]
        public AudioData audioData;

        public override IEnumerator Execute(FeedbacksReader _owner)
        {
	        if (IsActive && _owner.activeEffects){
	        	Debug.Log("Play Sound");
	        	AudioController.Instance.PlayAudio(audioData);
	        }
	        else
	        {
	        	Debug.Log("Not Can Play Sound");
	        }
                
            return base.Execute(_owner);
        }
    }
}
