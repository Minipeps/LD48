using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public Text item1;
    public Text or1;
    public Text hell;
    public Text heaven;
    public Text item2;
    public Text or2;
    public Text isHell;
    public Text or3;
    public Text isHeaven;
    public Text item3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateWording(bool isFrench)
    {
        if (isFrench)
        {
            item1.text = "Juge la Vie des gens\n&\nChoisis leur Destin !";
            or1.text = "ou";
            hell.text = "Enfer";
            heaven.text = "Paradis";
            item2.text = "Mais reste attentif !";
            or2.text = "ou";
            isHell.text = "= Enfer";
            or3.text = "ou";
            isHeaven.text = "= Paradis";
            item3.text = "Jusqu'où iras-tu ?";
        }
        else
        {
            item1.text = "Review people's Life\n&\nChoose their Fate!";
            or1.text = "or";
            hell.text = "Hell";
            heaven.text = "Heaven";
            item2.text = "But stay sharp!";
            or2.text = "or";
            isHell.text = "= Hell";
            or3.text = "or";
            isHeaven.text = "= Heaven";
            item3.text = "How Deep will you go?";
        }
    }
}
