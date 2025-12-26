using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckPLacesClick : MonoBehaviour
{
    public int index = 0;
    public GameObject SpacesImage;
    public string vege = "---------------------------";

    //public GameObject Pages = null;

    public void PLaceClick()
    {
        if(SpacesImage.GetComponent<SpriteRenderer>().sprite != DeckPanelScript.X&& SpacesImage.GetComponent<SpriteRenderer>().sprite != DeckPanelScript.PLusz)
        {
            DeckPanelScript.SetactiveFalse(0);
            SpacesImage.GetComponent<SpriteRenderer>().sprite = DeckPanelScript.X;
            SpacesImage.GetComponent<SpriteRenderer>().size = new Vector2(1,1);
        }
        else
          if (SpacesImage.GetComponent<SpriteRenderer>().sprite == DeckPanelScript.X)
        {
            if (DeckPanelScript.TowerPlaces)
            {
                database.DEC[index] = 0;
                DeckPanelScript.BackPanelElrendezes(DeckPanelScript.TowerInPlaceDaks[index],index);
                DeckPanelScript.TowerInPlaceDaks[index] = null;
            }
            else
            {
                database.DEC[index+3] = 0;
                DeckPanelScript.BackPanelElrendezes(DeckPanelScript.SpawnerInPlaceDaks[index],index);
                DeckPanelScript.SpawnerInPlaceDaks[index] = null;
            }
            FajlDatabase.WriteIntoTxtFile();
            SpacesImage.GetComponent<SpriteRenderer>().sprite = DeckPanelScript.PLusz;
            SpacesImage.GetComponent<SpriteRenderer>().size = new Vector2(1, 1);
            DeckPanelScript.SetactiveFalse(0);
        }
        else
        {
            DeckPanelScript.SetactiveFalse(0);
        }

    }

}
