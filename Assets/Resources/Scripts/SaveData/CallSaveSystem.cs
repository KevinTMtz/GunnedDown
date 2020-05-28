using UnityEngine;
using UnityEngine.UI;

public class CallSaveSystem : MonoBehaviour {
    public GameObject slotsPanel; 
    public GameObject levelPanel;
    
    public void SetActiveLevel(int activeLevel) {
        SaveSystem.ActiveLevel = activeLevel;
    }

    public void SetActiveSlot(int activeSlot) {
        SaveSystem.ActiveSaveSlot = activeSlot;
    }

    public void CheckSaveSlots () {
        for (int i = 1; i <= 3; i++) {
            if (SaveSystem.LoadGameData(i) != null) {
                slotsPanel.transform.Find($"Slot {i}").GetComponent<Image>().color = Color.white;
                slotsPanel.transform.Find($"Slot {i}").transform.Find("DeleteButton").GetComponent<Button>().interactable = true;
            } else {
                slotsPanel.transform.Find($"Slot {i}").GetComponent<Image>().color = new Color(0.2F, 0.2F, 0.2F, 1);
                slotsPanel.transform.Find($"Slot {i}").transform.Find("DeleteButton").GetComponent<Button>().interactable = false;
            }
        }
    }

    public void CheckSaveLevel () {
        GameData gameData = SaveSystem.LoadGameData(SaveSystem.ActiveSaveSlot);
        if (gameData != null) {
            for (int i = 1; i <= 3; i++) {
                levelPanel.transform.Find($"Level{i}").transform.Find("Button").GetComponent<Button>().interactable = gameData.level >= i;
            }
        } else {
            for (int i = 1; i <= 3; i++) {
                levelPanel.transform.Find($"Level{i}").transform.Find("Button").GetComponent<Button>().interactable = false;
            }
        }
    }

    public void DeleteSlot (int slotToDelete) {
        SaveSystem.DeleteFile(slotToDelete);
    }
}
