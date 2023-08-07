using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IKitchenObjectParents{

    public Transform GetKitchenObjectFollowTransfrom();

    public void SetKitchenObject(kitchenObject kitchenObject);

    public kitchenObject GetKitchenObject();

    public void ClearKitchenObject();

    public bool HasKitchenObject();
}
