using UnityEngine;
using UnityEngine.UI;

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 

public class DeepTextScript : MonoBehaviour
{
    void Update()
    {
        // the text will change every the frame
        GetComponent<Text>().text = GameObject.FindGameObjectWithTag( tag: "GameController").GetComponent<GameManager>().AsMuchDeep.ToString();
    }
}

//  There were paws Felix Only (felixdeveloperkettle@gmail.com)
//  Author :    Felix Only (felixdeveloperkettle@gmail.com) 
//  Date   :    13 Sentember 2021 