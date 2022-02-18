using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class type_attempt : MonoBehaviour
{
    [SerializeField]
    float typeSpeed = 0.05f;
    [SerializeField]
    int pos;

    string curPut = "&&\\WFor its maker trusts^2 in its own creation;&^2he makes idols that cannot speak.^6&&Woe to him who says to wood,^3&\\R\'Awake!\'^5&\\WOr to silent stone,^3&\\R\'Arise!\'^3&&\\WBehold,^2 it is overlaid&with gold and silver,^4&yet there is no breath in it^3&at all.^6&&But the LORD^4 is in his&holy temple,^2&let all the earth be&silent before Him.";
   
    string rawShown = "";
  
    TextMeshProUGUI textmesh;
    // Start is called before the first frame update
    void Start()
    {
        textmesh = GetComponent<TextMeshProUGUI>();
        StartCoroutine(typeLoop());
    }


    IEnumerator typeLoop()
    {
        pos = 0;
        int offset = 0;
        while(true)
        {
            int combo = pos + offset;
            if(combo >= curPut.Length) { break; }

            char c = curPut[combo];
            if(c=='^')
            {
                float new_speed = float.Parse(curPut[combo+1].ToString());
                yield return new WaitForSeconds(new_speed / 8);
                offset += 2;
                continue;
            }
            if (c == '&')
            {
                offset += 1;
                rawShown += "\n";
                continue;
            }

            if (c =='\\')
            {
                char color = curPut[combo + 1];
                offset += 2;
                rawShown += "<color=\"";
                string cs = "white";
                switch(color)
                {
                    case 'R':
                        cs = "red";
                        break;
                    case 'G':
                        cs = "green";
                        break;
                    case 'Y':
                        cs = "yellow";
                        break;

                }
               
                rawShown += cs;
                rawShown += "\">";
                continue;
            }


            pos++;
            rawShown += c;
            textmesh.text = rawShown;
            yield return new WaitForSeconds(typeSpeed);

        }
     
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
