using System.Collections;
using UnityEngine;

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 

public class TextAnimation : MonoBehaviour
{  
    /* This is the parameter the text which will be animated */
    [SerializeField, TextArea] private string _content;

    /* This is the parameter as much quickly will writing word */
    [SerializeField] private float _textDelay;

    /* This is the parameter about time which will waiting before start the animation */
    [SerializeField] private float _startDelay;
    
    IEnumerator Start()
    {
        // The game waiting as was in the parameter
        yield return new WaitForSeconds(_startDelay);

        // This is the text in which will writing 
        UnityEngine.UI.Text textComponent = GetComponent<UnityEngine.UI.Text>();
        

        // loop
        for (int i = 0; i < _content.Length; i++)
        {
            // waiting
            yield return new WaitForSeconds(_textDelay);

            // Writing the symbol 
            textComponent.text += _content[i];
        }
    }
}

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 