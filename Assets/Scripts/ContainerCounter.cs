using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : BaseCounter, IKitchenObjectParents {


    public event EventHandler OnPlayerGrabbedObject;


    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public override void Interect(Player player) {
        if (!player.HasKitchenObject()) {
            // Player is not carrying anything
            kitchenObject.spawnKitchenObject(kitchenObjectSO, player);
             
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }
}
