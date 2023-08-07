using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParents {

    [SerializeField] private Transform counterTopPoint;


    private kitchenObject kitchenObject;


    public virtual void Interect(Player player) {
        Debug.LogError("BaseCounter.Interact() triggered");
    }

    public virtual void InterectAlternate(Player player) {
        //Debug.LogError("BaseCounter.Interact() triggered");
    }


    public Transform GetKitchenObjectFollowTransfrom() {
        return counterTopPoint;
    }

    public void SetKitchenObject(kitchenObject kitchenObject) {
        this.kitchenObject = kitchenObject;
    }

    public kitchenObject GetKitchenObject() {
        return kitchenObject;
    }

    public void ClearKitchenObject() {
        kitchenObject = null;
    }

    public bool HasKitchenObject() {
        return kitchenObject != null;
    }

}
