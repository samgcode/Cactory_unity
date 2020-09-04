using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryService : MonoBehaviour
{
    public Inventory inventory;
    
    public void addItem(string item, int amount) {
        switch(item) {
            case "cactus":
                inventory.cactus += amount;
            break;
            case "iron":
                inventory.iron += amount;
            break;
            case "cactus juice":
                inventory.juice += amount;
            break;
            case "crystal":
                inventory.crystals += amount;
            break;
            case "beacon":
                inventory.beacons += amount;
            break;
            case "cactus juicer":
                inventory.cactusJuicers += amount;
            break;
            case "conveyor":
                inventory.conveyors += amount;
            break;
            case "miner":
                inventory.miners += amount;
            break;
            case "cactus miner":
                inventory.miners += amount;
            break;
            case "collector":
                inventory.collectors += amount;
            break;
            case "laser drill":
                inventory.drills += amount;
            break;
            case "generator":
                inventory.generators += amount;
            break;
            case "power pole":
                inventory.poles += amount;
            break;
        }
    }

    public bool checkItem(string item, int amount) {
        int inventoryAmount = getItemCount(item);

        if(inventoryAmount < amount) {
            return false;
        } else {
            return true;
        }
    }

    public int getItemCount(string item) {
        int inventoryAmount = 0;
        switch(item) {
            case "cactus":
                inventoryAmount = inventory.cactus;
            break;
            case "iron":
                inventoryAmount = inventory.iron;
            break;
            case "cactus juice":
                inventoryAmount = inventory.juice;
            break;
            case "crystal":
                inventoryAmount = inventory.crystals;
            break;
            case "beacon":
                inventoryAmount = inventory.beacons;
            break;
            case "cactus juicer":
                inventoryAmount = inventory.cactusJuicers;
            break;
            case "conveyor":
                inventoryAmount = inventory.conveyors;
            break;
            case "miner":
                inventoryAmount = inventory.miners;
            break;
            case "collector":
                inventoryAmount = inventory.collectors;
            break;
            case "laser drill":
                inventoryAmount = inventory.drills;
            break;
            case "generator":
                inventoryAmount = inventory.generators;
            break;
            case "power pole":
                inventoryAmount = inventory.poles;
            break;
        }

        return inventoryAmount;
    }

    public void removeItem(string item, int amount) {
        switch(item) {
            case "cactus":
                inventory.cactus -= amount;
            break;
            case "iron":
                inventory.iron -= amount;
            break;
            case "cactus juice":
                inventory.juice -= amount;
            break;
            case "crystal":
                inventory.crystals -= amount;
            break;
            case "beacon":
                inventory.beacons -= amount;
            break;
            case "cactus juicer":
                inventory.cactusJuicers -= amount;
            break;
            case "conveyor":
                inventory.conveyors -= amount;
            break;
            case "miner":
                inventory.miners -= amount;
            break;
            case "cactus miner":
                inventory.miners -= amount;
            break;
            case "collector":
                inventory.collectors -= amount;
            break;
            case "laser drill":
                inventory.drills -= amount;
            break;
            case "generator":
                inventory.generators -= amount;
            break;
            case "power pole":
                inventory.poles -= amount;
            break;
        }
    }

    public string getItemType(string item) {
        switch(item) {
            case "cactus juice":
                return "juice";
            case "beacon":
                return "machine";
            case "cactus juicer":
                return "machine";
            case "conveyor":
                return "machine";
            case "miner":
                return "machine";
            case "cactus miner":
                return "machine";
            case "collector":
                return "machine";
            case "laser drill":
                return "machine";
            case "generator":
                return "machine";
            case "power pole":
                return "machine";
        }
        return "item";
    }
}
