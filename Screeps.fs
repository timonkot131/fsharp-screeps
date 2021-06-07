module Screeps

open System
open System.Collections.Generic
open Fable.Core

[<StringEnum>]
type Order =
    | Sell
    | Buy

type Density =
    | Low = 1
    | Moderate = 2
    | High = 3
    | Ultra = 4

type Color =
    | Cyan = 4
    | Green = 5
    | Yellow = 6
    | Orange = 7
    | Brown = 8
    | Grey = 9
    | White = 10

[<StringEnum>]
type PowerClass =
    | Operator

type ScreepCode =
    | Ok = 0
    | NotOwner = -1
    | NoPath = -2
    | NameExists = -3
    | Busy = -4
    | NotFound = -5
    | NotEnoughEnergy = -6
    | NotEnoughResources = -6
    | InvalidTarget = -7
    | Full = -8
    | NotInRange = -9
    | InvalidArgs = -10
    | Tired = -11
    | NoBodyPart = -12
    | NotEnoughExtensions = -6
    | RCLNotEnough = -14
    | GCLNotEnough = -15

type EventType =    
    | Attack = 1
    | ObjectDestroyed = 2
    | AttackController = 3
    | Build = 4
    | Harvest = 5
    | Heal = 6
    | Repair = 7
    | ReserveController = 8
    | UpgradeController = 9
    | Exit = 10
    | Power = 11
    | Transfer = 12

type HealType = 
    | Melee = 1
    | Ranged = 2

type AttackType =
    | Melee = 1
    | Ranged = 2
    | RangedMass = 3
    | Dismantle = 4
    | HitBack = 5
    | Nuke = 6
   
[<StringEnum>]
type DestroyedType =
    | Creep    
    | [<CompiledName("spawn")>] DestroyedSpawn
    | [<CompiledName("extension")>] DestroyedExtension
    | [<CompiledName("road")>] DestroyedRoad
    | [<CompiledName("constructedWall")>] DestroyedWall
    | [<CompiledName("rampart")>] DestroyedRampart
    | [<CompiledName("keeperLair")>] DestroyedKeeperLair
    | [<CompiledName("portal")>] DestroyedPortal
    | [<CompiledName("controller")>] DestroyedController
    | [<CompiledName("link")>] DestroyedLink
    | [<CompiledName("storage")>] DestroyedStorage
    | [<CompiledName("tower")>] DestroyedTower
    | [<CompiledName("observer")>] DestroyedObserver
    | [<CompiledName("powerBank")>] DestroyedPowerBank
    | [<CompiledName("powerSpawn")>] DestroyedPowerSpawn
    | [<CompiledName("extractor")>] DestroyedExtractor
    | [<CompiledName("lab")>] DestroyedLab
    | [<CompiledName("terminal")>] DestroyedTerminal
    | [<CompiledName("container")>] DestroyedContainer
    | [<CompiledName("nuker")>] DestroyedNuker
    | [<CompiledName("factory")>] DestroyedFactory
    | [<CompiledName("invaderCore")>] DestroyedInvaderCore



type EventTypeData = interface end

type EventObject =
    {
        event: EventType
        objectId: string
        data: EventTypeData
    }

type EventAttackRecord =
    {
        targetId: string
        damage: int
    }
    interface EventTypeData
       
type EventDestroyedRecord =
    {
        Type: DestroyedType
    }
    interface EventTypeData

type EventBuildRecord =
    {
        targetId: String
        amount: int
        energySpent: int
    }
    interface EventTypeData

type EventHarvestRecord = 
    {
        targetId: String
        amount: int
    }
    interface EventTypeData
 
type EventHealRecord = 
    {
        targetId: String
        amount: int
        HealType: HealType
    }
    interface EventTypeData

type EventRepairRecord =
    {
        targetId: String
        amount: int
        energySpent: int
    }
    interface EventTypeData

type EventReserveControllerRecord =
    {
        amount: int
    }
    interface EventTypeData

type EventUpgradeControllerRecord = 
    {
        amount: int
        energySpent: int
    }    
    interface EventTypeData

type EventExitRecord =
    {
       room: string
       x: int; y: int
    }
    interface EventTypeData

type PowerType = 
    | GenerateOps = 1
    | OperateSpawn = 2
    | OperateTower = 3
    | OperateStorage = 4
    | OperateLab = 5
    | OperateExtension = 6
    | OperateObserver = 7
    | OperateTerminal = 8
    | DisruptSpawn = 9
    | DisruptTower = 10
    | DisruptSource = 11
    | Shield = 12
    | RegenSource = 13
    | RegenMineral = 14
    | DisruptTerminal = 15
    | OperatePower = 16
    | Fortify = 17
    | OperateController = 18
    | OperateFactory = 19

type EffectType = 
    | Invulnerability = 1001
    | CollapseTimer = 1002
    | GenerateOps = 1
    | OperateSpawn = 2
    | OperateTower = 3
    | OperateStorage = 4
    | OperateLab = 5
    | OperateExtension = 6
    | OperateObserver = 7
    | OperateTerminal = 8
    | DisruptSpawn = 9
    | DisruptTower = 10
    | DisruptSource = 11
    | Shield = 12
    | RegenSource = 13
    | RegenMineral = 14
    | DisruptTerminal = 15
    | OperatePower = 16
    | Fortify = 17
    | OperateController = 18
    | OperateFactory = 19

type TerrainMask = 
    | MaskNotExist = 0
    | MaskWall = 1
    | MaskSwamp = 2
    | MaskLava = 4  


[<StringEnum>]
type ResourceType =
    | [<CompiledName("energy")>] Energy
    | [<CompiledName("power")>] Power
    | [<CompiledName("H")>] Hydrogen
    | [<CompiledName("O")>] Oxygen
    | [<CompiledName("U")>] Utrium
    | [<CompiledName("L")>] Lemergium
    | [<CompiledName("K")>] Keanium
    | [<CompiledName("Z")>] Zynthium
    | [<CompiledName("X")>] Catalyst
    | [<CompiledName("G")>] Ghodium
    | [<CompiledName("silicon")>] Silicon
    | [<CompiledName("metal")>] Metal
    | [<CompiledName("biomass")>] Biomass
    | [<CompiledName("mist")>] Mist
    | [<CompiledName("OH")>] Hydroxide
    | [<CompiledName("ZK")>] ZynthiumKeanite
    | [<CompiledName("UL")>] UtriumLemergite
    | [<CompiledName("UH")>] UtriumHydride
    | [<CompiledName("UO")>] UtriumOxide
    | [<CompiledName("KH")>] KeaniumHydride
    | [<CompiledName("KO")>] KeaniumOxide
    | [<CompiledName("LH")>] LemergiumHydride
    | [<CompiledName("LO")>] LemergiumOxide
    | [<CompiledName("ZH")>] ZynthiumHydride
    | [<CompiledName("ZO")>] ZynthiumOxide
    | [<CompiledName("GH")>] GhodiumHydride
    | [<CompiledName("GO")>] GhodiumOxide
    | [<CompiledName("UH2O")>] UtriumAcid
    | [<CompiledName("UHO2")>] UtriumAlkalide
    | [<CompiledName("KH2O")>] KeaniumAcid
    | [<CompiledName("KHO2")>] KeaniumAlkalide
    | [<CompiledName("LH2O")>] LemergiumAcid
    | [<CompiledName("LHO2")>] LemergiumAlkalide
    | [<CompiledName("ZH2O")>] ZynthiumAcid
    | [<CompiledName("ZHO2")>] ZynthiumAlkalide
    | [<CompiledName("GH2O")>] GhodiumAcid
    | [<CompiledName("GHO2")>] GhodiumAlkalide
    | [<CompiledName("XUH2O")>] CatalyzedUtriumAcid
    | [<CompiledName("XUHO2")>] CatalyzedUtriumAlkalide
    | [<CompiledName("XKH2O")>] CatalyzedKeaniumAcid
    | [<CompiledName("XKHO2")>] CatalyzedKeaniumAlkalide
    | [<CompiledName("XLH2O")>] CatalyzedLemergiumAcid
    | [<CompiledName("XLHO2")>] CatalyzedLemergiumAlkalide
    | [<CompiledName("XZH2O")>] CatalyzedZynthiumAcid
    | [<CompiledName("XZHO2")>] CatalyzedZynthiumAlkalide
    | [<CompiledName("XGH2O")>] CatalyzedGhodiumAcid
    | [<CompiledName("XGHO2")>] CatalyzedGhodiumAlkalide
    | [<CompiledName("ops")>] Ops
    | [<CompiledName("utrium_bar")>] UtriumBar
    | [<CompiledName("lemergium_bar")>] LemergiumBar
    | [<CompiledName("zynthium_bar")>] ZynthiumBar
    | [<CompiledName("keanium_bar")>] KeaniumBar
    | [<CompiledName("ghodium_melt")>] GhodiumMelt
    | [<CompiledName("oxidant")>] Oxidant
    | [<CompiledName("reductant")>] Reductant
    | [<CompiledName("purifier")>] Purifier
    | [<CompiledName("battery")>] Battery
    | [<CompiledName("composite")>] Composite
    | [<CompiledName("crystal")>] Crystal
    | [<CompiledName("liquid")>] Liquid
    | [<CompiledName("wire")>] Wire
    | [<CompiledName("switch")>] Switch
    | [<CompiledName("transistor")>] Transistor
    | [<CompiledName("microchip")>] Microchip
    | [<CompiledName("circuit")>] Circuit
    | [<CompiledName("device")>] Device
    | [<CompiledName("cell")>] Cell
    | [<CompiledName("phlegm")>] Phlegm
    | [<CompiledName("tissue")>] Tissue
    | [<CompiledName("muscle")>] Muscle
    | [<CompiledName("organoid")>] Organoid
    | [<CompiledName("organism")>] Organism
    | [<CompiledName("alloy")>] Alloy
    | [<CompiledName("tube")>] Tube
    | [<CompiledName("fixtures")>] Fixtures
    | [<CompiledName("frame")>] Frame
    | [<CompiledName("hydraulics")>] Hydraulics
    | [<CompiledName("machine")>] Machine
    | [<CompiledName("condensate")>] Condensate
    | [<CompiledName("concentrate")>] Concentrate
    | [<CompiledName("extract")>] Extract
    | [<CompiledName("spirit")>] Spirit
    | [<CompiledName("emanation")>] Emanation
    | [<CompiledName("essence")>] Essence

type EventTransferRecord = 
    {
        targetId: string
        resourceType: ResourceType
        amount: int
    }
    interface EventTypeData

[<StringEnum>]
type Terrain =
    | Plain
    | Swamp
    | Wall

type Find = 
    | ExitTop = 1
    | ExitRight = 3
    | ExitBottom = 5
    | ExitLeft = 7
    | Exit = 10
    | Creeps = 101
    | MyCreeps = 102
    | HostileCreeps = 103
    | SourcesActive = 104
    | Sources = 105
    | DroppedResources = 106
    | Structures = 107
    | MyStructures = 108
    | HostileStructures = 109
    | Flags = 110
    | ConstructionSites = 111
    | MySpawns = 112
    | HostileSpawns = 113
    | MyConstructionSites = 114
    | HostileConstructionSites = 115
    | Minerals = 116
    | Nukes = 117
    | Tombstones = 118
    | PowerCreeps = 119
    | MyPowerCreeps = 120
    | HostilePowerCreeps = 121
    | Deposits = 122
    | Ruins = 123

[<StringEnum>]
type Look =
    | [<CompiledName("creep")>] Creeps
    | [<CompiledName("energy")>] Energy
    | [<CompiledName("resource")>] Resources
    | [<CompiledName("source")>] Sources
    | [<CompiledName("mineral")>] Minerals
    | [<CompiledName("deposit")>] Deposits
    | [<CompiledName("structure")>] Structures
    | [<CompiledName("flag")>] Flags
    | [<CompiledName("constructionSite")>] ConstructionSites
    | [<CompiledName("nuke")>] Nukes
    | [<CompiledName("terrain")>] Terrain
    | [<CompiledName("tombstone")>] Tombstones
    | [<CompiledName("powerCreep")>] PowerCreeps
    | [<CompiledName("ruin")>] Ruins

type Direction =
    | Top = 1
    | TopRight = 2
    | Right = 3
    | BottomRight = 4
    | Bottom = 5
    | BottomLeft = 6
    | Left = 7
    | TopLeft = 8

[<StringEnum>]
type StructureType = 
    | [<CompiledName("spawn")>] Spawn
    | [<CompiledName("extension")>] Extension
    | [<CompiledName("road")>] Road
    | [<CompiledName("constructedWall")>] Wall
    | [<CompiledName("rampart")>] Rampart
    | [<CompiledName("keeperLair")>] KeeperLair
    | [<CompiledName("portal")>] Portal
    | [<CompiledName("controller")>] Controller
    | [<CompiledName("link")>] Link
    | [<CompiledName("storage")>] Storage
    | [<CompiledName("tower")>] Tower
    | [<CompiledName("observer")>] Observer
    | [<CompiledName("powerBank")>] PowerBank
    | [<CompiledName("powerSpawn")>] PowerSpawn
    | [<CompiledName("extractor")>] Extractor
    | [<CompiledName("lab")>] Lab
    | [<CompiledName("terminal")>] Terminal
    | [<CompiledName("container")>] Container
    | [<CompiledName("nuker")>] Nuker
    | [<CompiledName("factory")>] Factory
    | [<CompiledName("invaderCore")>] InvaderCore


[<StringEnum>]
type BodyPart =
    | [<CompiledName("move")>] Move
    | [<CompiledName("work")>] Work
    | [<CompiledName("carry")>] Carry
    | [<CompiledName("attack")>] Attack
    | [<CompiledName("ranged_attack")>] RangedAttack
    | [<CompiledName("tough")>] Tough
    | [<CompiledName("heal")>] Heal
    | [<CompiledName("claim")>] Claim


type Effect = 
    abstract effect: EffectType
    abstract level: int option
    abstract ticksRemaining: int32

type Event = 
    | Attack = 1
    | ObjectDestroyed = 2
    | AttackController = 3
    | Build = 4
    | Harvest = 5
    | Heal = 6
    | Repair = 7
    | ReserveController = 8
    | UpgradeController = 9
    | Exit = 10
    | Power = 11
    | Transfer = 12
    | AttackTypeMelee = 1
    | AttackTypeRanged = 2
    | AttackTypeRangedMass = 3
    | AttackTypeDismantle = 4
    | AttackTypeHitBack = 5
    | AttackTypeNuke = 6
    | HealTypeMelee = 1
    | HealTypeRanged = 2

type PathSegment = {x: int; y: int; dx: int; dy: int; direction: Direction}

///<summary>A remnant of dead creeps. This is a walkable object.</summary>
type Tombstone =
    inherit RoomObject


    ///<summary>The amount of game ticks before this tombstone decays.</summary>
    abstract ticksToDecay:  Int32
    ///<summary>A Store object that contains cargo of this structure.</summary>
    abstract store:  Store
    ///<summary>A unique object identificator. You can use Game.getObjectById method to retrieve an object instance by its id.</summary>
    abstract id:  String
    ///<summary>Time of death. </summary>
    abstract deathTime:  Int64
    ///<summary>An object containing the deceased creep or power creep.</summary>
    abstract creep:  U2<Creep, PowerCreep>
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list
///<summary>Blocks movement of all creeps. Players can build destructible walls in controlled rooms. Some rooms also contain indestructible walls separating novice and respawn areas from the rest of the world or dividing novice / respawn areas into smaller sections. Indestructible walls have no hits property.Blocks movement of all creeps. Players can build destructible walls in controlled rooms. Some rooms also contain indestructible walls separating novice and respawn areas from the rest of the world or dividing novice / respawn areas into smaller sections. Indestructible walls have no hitshits property.</summary>
and StructureWall =
    inherit RoomObject
    inherit Structure


    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary>Remotely attacks or heals creeps, or repairs structures. Can be targeted to any object in the room. However, its effectiveness linearly depends on the distance. Each action consumes energy.Remotely attacks or heals creeps, or repairs structures. Can be targeted to any object in the room. However, its effectiveness linearly depends on the distance. Each action consumes energy.</summary>
and StructureTower =
    inherit RoomObject
    inherit Structure
    inherit OwnedStructure

    ///<summary>Remotely repair any structure in the room.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this structure.</description></item>
    ///<item><term>NotEnoughEnergy</term><description>The tower does not have enough energy.</description></item>
    ///<item><term>InvalidTarget</term><description>The target is not a valid repairable object.</description></item>
    ///<item><term>RclNotEnough</term><description>Room Controller Level insufficient to use this structure.</description></item>
    ///</list></returns>

    ///<param name="target">The target structure.</param>
    abstract repair: target: Structure -> ScreepCode
    ///<summary>Remotely heal any creep or power creep in the room.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this structure.</description></item>
    ///<item><term>NotEnoughEnergy</term><description>The tower does not have enough energy.</description></item>
    ///<item><term>InvalidTarget</term><description>The target is not a valid creep object.</description></item>
    ///<item><term>RclNotEnough</term><description>Room Controller Level insufficient to use this structure.</description></item>
    ///</list></returns>

    ///<param name="target">The target creep.</param>
    abstract heal: target: U2<Creep, PowerCreep> -> ScreepCode    
    ///<summary>Remotely attack any creep, power creep or structure in the room.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this structure.</description></item>
    ///<item><term>NotEnoughEnergy</term><description>The tower does not have enough energy.</description></item>
    ///<item><term>InvalidTarget</term><description>The target is not a valid attackable object.</description></item>
    ///<item><term>RclNotEnough</term><description>Room Controller Level insufficient to use this structure.</description></item>
    ///</list></returns>

    ///<param name="target">The target creep.</param>
    abstract attack: target: U3<Creep, PowerCreep, Structure> -> ScreepCode
    ///<summary>A Store object that contains cargo of this structure.</summary>
    abstract store:  Store
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary>Sends any resources to a Terminal in another room. The destination Terminal can belong to any player. Each transaction requires additional energy (regardless of the transfer resource type) that can be calculated using Game.market.calcTransactionCost method. For example, sending 1000 mineral units from W0N0 to W10N5 will consume 742 energy units. You can track your incoming and outgoing transactions using the Game.market object. Only one Terminal per room is allowed that can be addressed by Room.terminal property.Sends any resources to a Terminal in another room. The destination Terminal can belong to any player. Each transaction requires additional energy (regardless of the transfer resource type) that can be calculated using Game.market.calcTransactionCostGame.market.calcTransactionCostGame.market.calcTransactionCost method. For example, sending 1000 mineral units from W0N0 to W10N5 will consume 742 energy units. You can track your incoming and outgoing transactions using the Game.marketGame.marketGame.market object. Only one Terminal per room is allowed that can be addressed by Room.terminalRoom.terminalRoom.terminal property.Terminals are used in the Market system.Terminals are used in the Market systemMarket system.</summary>
and StructureTerminal =
    inherit RoomObject
    inherit Structure
    inherit OwnedStructure

    ///<summary>Sends resource to a Terminal in another room with the specified name.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this structure.</description></item>
    ///<item><term>NotEnoughResources</term><description>The structure does not have the required amount of resources.</description></item>
    ///<item><term>InvalidArgs</term><description>The arguments provided are incorrect.</description></item>
    ///<item><term>Tired</term><description>The terminal is still cooling down.</description></item>
    ///</list></returns>

    ///<param name="resourceType">One of the RESOURCE_* constants.</param>
    ///<param name="amount">The amount of resources to be sent.</param>
    ///<param name="destination">The name of the target room. You don't have to gain visibility in this room.</param>
    ///<param name="description">The description of the transaction. It is visible to the recipient. The maximum length is 100 characters.</param>
    abstract send: resourceType: ResourceType * amount: Int32 * destination: String * ?description: String -> ScreepCode
    ///<summary>A Store object that contains cargo of this structure.</summary>
    abstract store:  Store
    ///<summary>The remaining amount of ticks while this terminal cannot be used to make StructureTerminal.send or Game.market.deal calls.</summary>
    abstract cooldown:  Int32
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary>A structure that can store huge amount of resource units. Only one structure per room is allowed that can be addressed by Room.storage property.A structure that can store huge amount of resource units. Only one structure per room is allowed that can be addressed by Room.storageRoom.storageRoom.storage property.</summary>
and StructureStorage =
    inherit RoomObject
    inherit Structure
    inherit OwnedStructure


    ///<summary>A Store object that contains cargo of this structure.</summary>
    abstract store:  Store
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary>Details of the creep being spawned currently that can be addressed by the StructureSpawn.spawning property.Details of the creep being spawned currently that can be addressed by the StructureSpawn.spawningStructureSpawn.spawningStructureSpawn.spawning property.</summary>
and StructureSpawnSpawning =

    ///<summary>Set desired directions where the creep should move when spawned.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this spawn.</description></item>
    ///<item><term>InvalidArgs</term><description>The directions is array is invalid.</description></item>
    ///</list></returns>

    ///<param name="directions">An array with the direction constants:</param>
    abstract setDirections: directions:  Direction array -> ScreepCode 
    ///<summary>Cancel spawning immediately. Energy spent on spawning is not returned. </summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this spawn.</description></item>
    ///</list></returns>

    abstract cancel: unit -> ScreepCode
    ///<summary>A link to the spawn.</summary>
    abstract spawn:  StructureSpawn
    ///<summary>Remaining time to go.</summary>
    abstract remainingTime:  Int32
    ///<summary>Time needed in total to complete the spawning.</summary>
    abstract needTime:  Int32
    ///<summary>The name of a new creep.</summary>
    abstract name:  String
    ///<summary>An array with the spawn directions, see StructureSpawn.Spawning.setDirections.</summary>
    abstract directions: Direction array 
///<summary></summary>
and StructureSpawnspawnCreepOpts =


    ///<summary>Memory of the new creep. If provided, it will be immediately stored into Memory.creeps[name].</summary>
    abstract memory: obj option

    ///<summary>Array of spawns/extensions from which to draw energy for the spawning process. Structures will be used according to the array order.</summary>
    abstract energyStructures: U2<StructureSpawn, StructureExtension> array option

    ///<summary>If dryRun is true, the operation will only check if it is possible to create a creep.</summary>
    abstract dryRun:  Boolean option

    ///<summary>Set desired directions where the creep should move when spawned. An array with the direction constants: TOPTOP_RIGHTRIGHTBOTTOM_RIGHTBOTTOMBOTTOM_LEFTLEFTTOP_LEFT</summary>
    abstract directions: Direction array option

///<summary>Spawn is your colony center. This structure can create, renew, and recycle creeps. All your spawns are accessible through Game.spawns hash list. Spawns auto-regenerate a little amount of energy each tick, so that you can easily recover even if all your creeps died.Spawn is your colony center. This structure can create, renew, and recycle creeps. All your spawns are accessible through Game.spawnsGame.spawnsGame.spawns hash list. Spawns auto-regenerate a little amount of energy each tick, so that you can easily recover even if all your creeps died.</summary>
and StructureSpawn =
    inherit RoomObject
    inherit Structure
    inherit OwnedStructure

    ///<summary>Increase the remaining time to live of the target creep. The target should be at adjacent square. The target should not have CLAIM body parts. The spawn should not be busy with the spawning process. Each execution increases the creep's timer by amount of ticks according to this formula: </summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of the spawn, or the creep.</description></item>
    ///<item><term>Busy</term><description>The spawn is spawning another creep.</description></item>
    ///<item><term>NotEnoughEnergy</term><description>The spawn does not have enough energy.</description></item>
    ///<item><term>InvalidTarget</term><description>The specified target object is not a creep, or the creep has CLAIM body part.</description></item>
    ///<item><term>Full</term><description>The target creep's time to live timer is full.</description></item>
    ///<item><term>NotInRange</term><description>The target creep is too far away.</description></item>
    ///<item><term>RclNotEnough</term><description>Your Room Controller level is insufficient to use this spawn.</description></item>
    ///</list></returns>

    ///<param name="target">The target creep object.</param>
    abstract renewCreep: target: Creep -> ScreepCode   
    ///<summary>Kill the creep and drop up to 100% of resources spent on its spawning and boosting depending on remaining life time. The target should be at adjacent square. Energy return is limited to 125 units per body part.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this spawn or the target creep.</description></item>
    ///<item><term>InvalidTarget</term><description>The specified target object is not a creep.</description></item>
    ///<item><term>NotInRange</term><description>The target creep is too far away.</description></item>
    ///<item><term>RclNotEnough</term><description>Your Room Controller level is insufficient to use this spawn.</description></item>
    ///</list></returns>

    ///<param name="target">The target creep object.</param>
    abstract recycleCreep: target: Creep -> ScreepCode
    ///<summary>Start the creep spawning process. The required energy amount can be withdrawn from all spawns and extensions in the room.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this spawn.</description></item>
    ///<item><term>NameExists</term><description>There is a creep with the same name already.</description></item>
    ///<item><term>Busy</term><description>The spawn is already in process of spawning another creep.</description></item>
    ///<item><term>NotEnoughEnergy</term><description>The spawn and its extensions contain not enough energy to create a creep with the given body.</description></item>
    ///<item><term>InvalidArgs</term><description>Body is not properly described or name was not provided.</description></item>
    ///<item><term>RclNotEnough</term><description>Your Room Controller level is insufficient to use this spawn.</description></item>
    ///</list></returns>

    ///<param name="body">An array describing the new creep’s body. Should contain 1 to 50 elements with one of these constants:WORKMOVECARRYATTACKRANGED_ATTACKHEALTOUGHCLAIM</param>
    ///<param name="name">The name of a new creep. The name length limit is 100 characters. It must be a unique creep name, i.e. the Game.creeps object should not contain another creep with the same name (hash key).</param>
    ///<param name="opts">An object with additional options for the spawning process.memoryany Memory of the new creep. If provided, it will be immediately stored into Memory.creeps[name]. energyStructuresarrayArray of spawns/extensions from which to draw energy for the spawning process. Structures will be used according to the array order.dryRunboolean If dryRun is true, the operation will only check if it is possible to create a creep. directions array Set desired directions where the creep should move when spawned. An array with the direction constants:</param>
    abstract spawnCreep: body: BodyPart array * name: String * ?opts: StructureSpawnspawnCreepOpts -> ScreepCode
    ///<summary>A Store object that contains cargo of this structure.</summary>
    abstract store:  Store
    ///<summary>If the spawn is in process of spawning a new creep, this object will contain a StructureSpawn.Spawning object, or null otherwise.</summary>
    abstract spawning:  StructureSpawnSpawning
    ///<summary>Spawn’s name. You choose the name upon creating a new spawn, and it cannot be changed later. This name is a hash key to access the spawn via the Game.spawns object.</summary>
    abstract name:  String
    ///<summary>A shorthand to Memory.spawns[spawn.name]. You can use it for quick access the spawn’s specific memory data object. Learn more about memory</summary>
    abstract memory:   obj with get, set
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary>Decreases movement cost to 1. Using roads allows creating creeps with less MOVE body parts. You can also build roads on top of natural terrain walls which are otherwise impassable.Decreases movement cost to 1. Using roads allows creating creeps with less MOVEMOVE body parts. You can also build roads on top of natural terrain walls which are otherwise impassable.</summary>
and StructureRoad =
    inherit RoomObject
    inherit Structure


    ///<summary>The amount of game ticks when this road will lose some hit points.</summary>
    abstract ticksToDecay:  Int32
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary>Blocks movement of hostile creeps, and defends your creeps and structures on the same tile. Can be used as a controllable gate.Blocks movement of hostile creeps, and defends your creeps and structures on the same tile. Can be used as a controllable gate.</summary>
and StructureRampart =
    inherit RoomObject
    inherit Structure
    inherit OwnedStructure

    ///<summary>Make this rampart public to allow other players' creeps to pass through.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this structure.</description></item>
    ///</list></returns>

    ///<param name="isPublic">Whether this rampart should be public or non-public.</param>
    abstract setPublic: isPublic: Boolean -> ScreepCode
    ///<summary>The amount of game ticks when this rampart will lose some hit points.</summary>
    abstract ticksToDecay:  Int32
    ///<summary>If false (default), only your creeps can step on the same square. If true, any hostile creeps can pass through.</summary>
    abstract isPublic:  Boolean
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary>A non-player structure. Instantly teleports your creeps to a distant room acting as a room exit tile. Portals appear randomly in the central room of each sector.A non-player structure. Instantly teleports your creeps to a distant room acting as a room exit tile. Portals appear randomly in the central room of each sector.</summary>
and StructurePortal =
    inherit RoomObject
    inherit Structure


    ///<summary>The amount of game ticks when the portal disappears, or undefined when the portal is stable.</summary>
    abstract ticksToDecay:  Int32
    ///<summary>If this is an inter-room portal, then this property contains a RoomPosition object leading to the point in the destination room.</summary>
    abstract destination:  U2<RoomPosition,  {|shard: String; room: String|}>
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary>Processes power into your account, and spawns power creeps with special unique powers (in development). Learn more about power from this article.Processes power into your account, and spawns power creeps with special unique powers (in development). Learn more about power from this articlethis article.</summary>
and StructurePowerSpawn =
    inherit RoomObject
    inherit Structure
    inherit OwnedStructure

    ///<summary>Register power resource units into your account. Registered power allows to develop power creeps skills. </summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this structure.</description></item>
    ///<item><term>NotEnoughResources</term><description>The structure does not have enough energy or power resource units.</description></item>
    ///<item><term>RclNotEnough</term><description>Room Controller Level insufficient to use this structure.</description></item>
    ///</list></returns>

    abstract processPower: unit -> ScreepCode
    ///<summary>A Store object that contains cargo of this structure.</summary>
    abstract store:  Store
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary>Non-player structure. Contains power resource which can be obtained by destroying the structure. Hits the attacker creep back on each attack. Learn more about power from this article.Non-player structure. Contains power resource which can be obtained by destroying the structure. Hits the attacker creep back on each attack. Learn more about power from this articlethis article.</summary>
and StructurePowerBank =
    inherit RoomObject
    inherit Structure


    ///<summary>The amount of game ticks when this structure will disappear.</summary>
    abstract ticksToDecay:  Int32
    ///<summary>The amount of power containing.</summary>
    abstract power:  int32
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary>Provides visibility into a distant room from your script.Provides visibility into a distant room from your script.</summary>
and StructureObserver =
    inherit RoomObject
    inherit Structure
    inherit OwnedStructure

    ///<summary>Provide visibility into a distant room from your script. The target room object will be available on the next tick.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this structure.</description></item>
    ///<item><term>NotInRange</term><description>Room roomName is not in observing range.</description></item>
    ///<item><term>InvalidArgs</term><description>roomName argument is not a valid room name value.</description></item>
    ///<item><term>RclNotEnough</term><description>Room Controller Level insufficient to use this structure.</description></item>
    ///</list></returns>

    ///<param name="roomName">The name of the target room.</param>
    abstract observeRoom: roomName: String -> ScreepCode
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary>Launches a nuke to another room dealing huge damage to the landing area. Each launch has a cooldown and requires energy and ghodium resources. Launching creates a Nuke object at the target room position which is visible to any player until it is landed. Incoming nuke cannot be moved or cancelled. Nukes cannot be launched from or to novice rooms. Resources placed into a StructureNuker cannot be withdrawn.Launches a nuke to another room dealing huge damage to the landing area. Each launch has a cooldown and requires energy and ghodium resources. Launching creates a NukeNuke object at the target room position which is visible to any player until it is landed. Incoming nuke cannot be moved or cancelled. Nukes cannot be launched from or to novice rooms. Resources placed into a StructureNuker cannot be withdrawn.</summary>
and StructureNuker =
    inherit RoomObject
    inherit Structure
    inherit OwnedStructure

    ///<summary>Launch a nuke to the specified position.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this structure.</description></item>
    ///<item><term>NotEnoughResources</term><description>The structure does not have enough energy and/or ghodium.</description></item>
    ///<item><term>InvalidTarget</term><description>The nuke can't be launched to the specified RoomPosition (see Start Areas).</description></item>
    ///<item><term>NotInRange</term><description>The target room is out of range.</description></item>
    ///<item><term>InvalidArgs</term><description>The target is not a valid RoomPosition.</description></item>
    ///<item><term>Tired</term><description>This structure is still cooling down.</description></item>
    ///<item><term>RclNotEnough</term><description>Room Controller Level insufficient to use this structure.</description></item>
    ///</list></returns>

    ///<param name="pos">The target room position.</param>
    abstract launchNuke: pos: RoomPosition -> ScreepCode
    ///<summary>A Store object that contains cargo of this structure.</summary>
    abstract store:  Store
    ///<summary>The amount of game ticks until the next launch is possible.</summary>
    abstract cooldown:  int32
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary>Remotely transfers energy to another Link in the same room.Remotely transfers energy to another Link in the same room.</summary>
and StructureLink =
    inherit RoomObject
    inherit Structure
    inherit OwnedStructure

    ///<summary>Remotely transfer energy to another link at any location in the same room.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this link.</description></item>
    ///<item><term>NotEnoughResources</term><description>The structure does not have the given amount of energy.</description></item>
    ///<item><term>InvalidTarget</term><description>The target is not a valid StructureLink object.</description></item>
    ///<item><term>Full</term><description>The target cannot receive any more energy.</description></item>
    ///<item><term>NotInRange</term><description>The target is too far away.</description></item>
    ///<item><term>InvalidArgs</term><description>The energy amount is incorrect.</description></item>
    ///<item><term>Tired</term><description>The link is still cooling down.</description></item>
    ///<item><term>RclNotEnough</term><description>Room Controller Level insufficient to use this link.</description></item>
    ///</list></returns>

    ///<param name="target">The target object.</param>
    ///<param name="amount">The amount of energy to be transferred. If omitted, all the available energy is used.</param>
    abstract transferEnergy: target: StructureLink * ?amount: Int32 -> ScreepCode
    ///<summary>A Store object that contains cargo of this structure.</summary>
    abstract store:  Store
    ///<summary>The amount of game ticks the link has to wait until the next transfer is possible.</summary>
    abstract cooldown:  int32
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary>Produces mineral compounds from base minerals, boosts and unboosts creeps. Learn more about minerals from this article.Produces mineral compounds from base minerals, boosts and unboosts creeps. Learn more about minerals from this articlethis article.</summary>
and StructureLab =
    inherit RoomObject
    inherit Structure
    inherit OwnedStructure

    ///<summary>Immediately remove boosts from the creep and drop 50% of the mineral compounds used to boost it onto the ground regardless of the creep's remaining time to live. The creep has to be at adjacent square to the lab. Unboosting requires cooldown time equal to the total sum of the reactions needed to produce all the compounds applied to the creep.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this lab, or the target creep.</description></item>
    ///<item><term>NotFound</term><description>The target has no boosted parts.</description></item>
    ///<item><term>InvalidTarget</term><description>The target is not a valid Creep object.</description></item>
    ///<item><term>NotInRange</term><description>The target is too far away.</description></item>
    ///<item><term>Tired</term><description>The lab is still cooling down.</description></item>
    ///<item><term>RclNotEnough</term><description>Room Controller Level insufficient to use this structure.</description></item>
    ///</list></returns>

    ///<param name="creep">The target creep.</param>
    abstract unboostCreep: creep: Creep -> ScreepCode
    
    ///<summary>Produce mineral compounds using reagents from two other labs. The same input labs can be used by many output labs.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this lab.</description></item>
    ///<item><term>NotEnoughResources</term><description>The source lab do not have enough resources.</description></item>
    ///<item><term>InvalidTarget</term><description>The targets are not valid lab objects.</description></item>
    ///<item><term>Full</term><description>The target cannot receive any more resource.</description></item>
    ///<item><term>NotInRange</term><description>The targets are too far away.</description></item>
    ///<item><term>InvalidArgs</term><description>The reaction cannot be run using this resources.</description></item>
    ///<item><term>Tired</term><description>The lab is still cooling down.</description></item>
    ///<item><term>RclNotEnough</term><description>Room Controller Level insufficient to use this structure.</description></item>
    ///</list></returns>

    ///<param name="lab1">The first source lab.</param>
    ///<param name="lab2">The second source lab.</param>
    abstract runReaction: lab1: StructureLab * lab2: StructureLab -> ScreepCode 
    ///<summary>Breaks mineral compounds back into reagents. The same output labs can be used by many source labs.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this lab.</description></item>
    ///<item><term>NotEnoughResources</term><description>The source lab do not have enough resources.</description></item>
    ///<item><term>InvalidTarget</term><description>The targets are not valid lab objects.</description></item>
    ///<item><term>Full</term><description>One of targets cannot receive any more resource.</description></item>
    ///<item><term>NotInRange</term><description>The targets are too far away.</description></item>
    ///<item><term>InvalidArgs</term><description>The reaction cannot be reversed into this resources.</description></item>
    ///<item><term>Tired</term><description>The lab is still cooling down.</description></item>
    ///<item><term>RclNotEnough</term><description>Room Controller Level insufficient to use this structure.</description></item>
    ///</list></returns>

    ///<param name="lab1">The first result lab.</param>
    ///<param name="lab2">The second result lab.</param>
    abstract reverseReaction: lab1: StructureLab * lab2: StructureLab -> ScreepCode    ///<summary>Boosts creep body parts using the containing mineral compound. The creep has to be at adjacent square to the lab. </summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this lab.</description></item>
    ///<item><term>NotFound</term><description>The mineral containing in the lab cannot boost any of the creep's body parts.</description></item>
    ///<item><term>NotEnoughResources</term><description>The lab does not have enough energy or minerals.</description></item>
    ///<item><term>InvalidTarget</term><description>The targets is not valid creep object.</description></item>
    ///<item><term>NotInRange</term><description>The targets are too far away.</description></item>
    ///<item><term>RclNotEnough</term><description>Room Controller Level insufficient to use this structure.</description></item>
    ///</list></returns>

    ///<param name="creep">The target creep.</param>
    ///<param name="bodyPartsCount">The number of body parts of the corresponding type to be boosted. Body parts are always counted left-to-right for TOUGH, and right-to-left for other types. If undefined, all the eligible body parts are boosted.</param>
    abstract boostCreep: creep: Creep * ?bodyPartsCount: Int32 -> ScreepCode
    ///<summary>A Store object that contains cargo of this structure.</summary>
    abstract store:  Store
    ///<summary>The type of minerals containing in the lab. Labs can contain only one mineral type at the same time.</summary>
    abstract mineralType:  ResourceType
    ///<summary>The amount of game ticks the lab has to wait until the next reaction or unboost operation is possible.</summary>
    abstract cooldown:  int32
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary>Non-player structure. Spawns NPC Source Keepers that guards energy sources and minerals in some rooms. This structure cannot be destroyed.Non-player structure. Spawns NPC Source Keepers that guards energy sources and minerals in some rooms. This structure cannot be destroyed.</summary>
and StructureKeeperLair =
    inherit RoomObject
    inherit Structure
    inherit OwnedStructure


    ///<summary>Time to spawning of the next Source Keeper.</summary>
    abstract ticksToSpawn:  int32
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary>This NPC structure is a control center of NPC Strongholds, and also rules all invaders in the sector. It spawns NPC defenders of the stronghold, refill towers, repairs structures. While it's alive, it will spawn invaders in all rooms in the same sector. It also contains some valuable resources inside, which you can loot from its ruin if you destroy the structure.This NPC structure is a control center of NPC Strongholds, and also rules all invaders in the sector. It spawns NPC defenders of the stronghold, refill towers, repairs structures. While it's alive, it will spawn invaders in all rooms in the same sector. It also contains some valuable resources inside, which you can loot from its ruin if you destroy the structure.An Invader Core has two lifetime stages: deploy stage and active stage. When it appears in a random room in the sector, it has ticksToDeploy property, public ramparts around it, and doesn't perform any actions. While in this stage it's invulnerable to attacks (has EFFECT_INVULNERABILITY enabled). When the ticksToDeploy timer is over, it spawns structures around it and starts spawning creeps, becomes vulnerable, and receives EFFECT_COLLAPSE_TIMER which will remove the stronghold when this timer is over. An Invader Core has two lifetime stages: deploy stage and active stage. When it appears in a random room in the sector, it has ticksToDeployticksToDeploy property, public ramparts around it, and doesn't perform any actions. While in this stage it's invulnerable to attacks (has EFFECT_INVULNERABILITYEFFECT_INVULNERABILITY enabled). When the ticksToDeployticksToDeploy timer is over, it spawns structures around it and starts spawning creeps, becomes vulnerable, and receives EFFECT_COLLAPSE_TIMEREFFECT_COLLAPSE_TIMER which will remove the stronghold when this timer is over. An active Invader Core spawns level-0 Invader Cores in neutral neighbor rooms inside the sector. These lesser Invader Cores are spawned near the room controller and don't perform any activity except reserving/attacking the controller. One Invader Core can spawn up to 42 lesser Cores during its lifetime. An active Invader Core spawns level-0 Invader Cores in neutral neighbor rooms inside the sector. These lesser Invader Cores are spawned near the room controller and don't perform any activity except reserving/attacking the controller. One Invader Core can spawn up to 42 lesser Cores during its lifetime. </summary>
and StructureInvaderCore =
    inherit RoomObject
    inherit Structure
    inherit OwnedStructure


    ///<summary>If the core is in process of spawning a new creep, this object will contain a StructureSpawn.Spawning object, or null otherwise.</summary>
    abstract spawning:  StructureSpawnSpawning option
    ///<summary>Shows the timer for a ot yet deployed stronghold, undefined otherwise. </summary>
    abstract ticksToDeploy:  int32
    ///<summary>The level of the stronghold. The amount and quality of the loot depends on the level.</summary>
    abstract level:  Int32
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary>Produces trade commodities from base minerals and other commodities. Learn more about commodities from this article. Produces trade commodities from base minerals and other commodities. Learn more about commodities from this articlethis article. </summary>
and StructureFactory =
    inherit RoomObject
    inherit Structure
    inherit OwnedStructure

    ///<summary>Produces the specified commodity. All ingredients should be available in the factory store.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this structure.</description></item>
    ///<item><term>Busy</term><description>The factory is not operated by the PWR_OPERATE_FACTORY power.</description></item>
    ///<item><term>NotEnoughResources</term><description>The structure does not have the required amount of resources.</description></item>
    ///<item><term>InvalidTarget</term><description>The factory cannot produce the commodity of this level.</description></item>
    ///<item><term>Full</term><description>The factory cannot contain the produce.</description></item>
    ///<item><term>InvalidArgs</term><description>The arguments provided are incorrect.</description></item>
    ///<item><term>Tired</term><description>The factory is still cooling down.</description></item>
    ///<item><term>RclNotEnough</term><description>Your Room Controller level is insufficient to use the factory.</description></item>
    ///</list></returns>

    ///<param name="resourceType">One of the RESOURCE_* constants.</param>
    abstract produce: resourceType: ResourceType -> ScreepCode
    ///<summary>A Store object that contains cargo of this structure.</summary>
    abstract store:  Store
    ///<summary>The factory's level. Can be set by applying the PWR_OPERATE_FACTORY power to a newly built factory. Once set, the level cannot be changed. </summary>
    abstract level:  Int32
    ///<summary>The amount of game ticks the factory has to wait until the next production is possible.</summary>
    abstract cooldown:  int32
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary>Allows to harvest a mineral deposit. Learn more about minerals from this article.Allows to harvest a mineral deposit. Learn more about minerals from this articlethis article.</summary>
and StructureExtractor =
    inherit RoomObject
    inherit Structure
    inherit OwnedStructure


    ///<summary>The amount of game ticks until the next harvest action is possible.</summary>
    abstract cooldown:  int32
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary>Contains energy which can be spent on spawning bigger creeps. Extensions can be placed anywhere in the room, any spawns will be able to use them regardless of distance.Contains energy which can be spent on spawning bigger creeps. Extensions can be placed anywhere in the room, any spawns will be able to use them regardless of distance.</summary>
and StructureExtension =
    inherit RoomObject
    inherit Structure
    inherit OwnedStructure


    ///<summary>A Store object that contains cargo of this structure.</summary>
    abstract store:  Store
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list
///<summary></summary>
and StructureControllersignResult =


    ///<summary>The name of a player who signed this controller.</summary>
    abstract username:  String

    ///<summary>The sign text.</summary>
    abstract text:  String

    ///<summary>The sign time in game ticks.</summary>
    abstract time:  int64

    ///<summary>The sign real date.</summary>
    abstract datetime:  DateTime
///<summary></summary>
and StructureControllerreservationResult =


    ///<summary>The name of a player who reserved this controller.</summary>
    abstract username:  String

    ///<summary>The amount of game ticks when the reservation will end.</summary>
    abstract ticksToEnd: int32

///<summary>Claim this structure to take control over the room. The controller structure cannot be damaged or destroyed. Claim this structure to take control over the room. The controller structure cannot be damaged or destroyed. It can be addressed by Room.controller property.It can be addressed by Room.controllerRoom.controllerRoom.controller property.</summary>
and StructureController =
    inherit RoomObject
    inherit Structure
    inherit OwnedStructure

    ///<summary>Make your claimed controller neutral again.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this controller.</description></item>
    ///</list></returns>

    abstract unclaim: unit -> ScreepCode    ///<summary>Activate safe mode if available.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this controller.</description></item>
    ///<item><term>Busy</term><description>There is another room in safe mode already.</description></item>
    ///<item><term>NotEnoughResources</term><description>There is no safe mode activations available.</description></item>
    ///<item><term>Tired</term><description>The previous safe mode is still cooling down, or the controller is upgradeBlocked, or the controller is downgraded for 50% plus 5000 ticks or more.</description></item>
    ///</list></returns>

    abstract activateSafeMode: unit -> ScreepCode
    ///<summary>The amount of game ticks while this controller cannot be upgraded due to attack. Safe mode is also unavailable during this period.</summary>
    abstract upgradeBlocked:  Int32
    ///<summary>The amount of game ticks when this controller will lose one level. This timer is set to 50% on level upgrade or downgrade, and it can be increased by using Creep.upgradeController. Must be full to upgrade the controller to the next level.</summary>
    abstract ticksToDowngrade:  Int32
    ///<summary>An object with the controller sign info if present:</summary>
    abstract sign:  StructureControllersignResult
    ///<summary>During this period in ticks new safe mode activations will be blocked, undefined if cooldown is inactive.</summary>
    abstract safeModecooldown:  int32
    ///<summary>Safe mode activations available to use.</summary>
    abstract safeModeAvailable:  Int32
    ///<summary>How many ticks of safe mode remaining, or undefined.</summary>
    abstract safeMode:  Int32 option
    ///<summary>An object with the controller reservation info if present:</summary>
    abstract reservation:  StructureControllerreservationResult
    ///<summary>The progress needed to reach the next level.</summary>
    abstract progressTotal:  Int32
    ///<summary>The current progress of upgrading the controller to the next level.</summary>
    abstract progress:  Int32
    ///<summary>Current controller level, from 0 to 8.</summary>
    abstract level:  Int32
    ///<summary>Whether using power is enabled in this room. Use PowerCreep.enableRoom to turn powers on.</summary>
    abstract isPowerEnabled:  Boolean
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary>A small container that can be used to store resources. This is a walkable structure. All dropped resources automatically goes to the container at the same tile.A small container that can be used to store resources. This is a walkable structure. All dropped resources automatically goes to the container at the same tile.</summary>
and StructureContainer =
    inherit RoomObject
    inherit Structure


    ///<summary>The amount of game ticks when this container will lose some hit points.</summary>
    abstract ticksToDecay:  Int32
    ///<summary>A Store object that contains cargo of this structure.</summary>
    abstract store:  Store
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary>The base prototype object of all structures.The base prototype object of all structures.</summary>
and Structure =
    inherit RoomObject

    ///<summary>Toggle auto notification when the structure is under attack. The notification will be sent to your account email. Turned on by default.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this structure.</description></item>
    ///<item><term>InvalidArgs</term><description>enable argument is not a boolean value.</description></item>
    ///</list></returns>

    ///<param name="enabled">Whether to enable notification or disable.</param>
    abstract notifyWhenAttacked: enabled: Boolean -> ScreepCode    
    ///<summary>Check whether this structure can be used. If room controller level is insufficient, then this method will return false, and the structure will be highlighted with red in the game.</summary>
    ///<returns>A boolean value.</returns>
    abstract isActive: unit -> bool  
    ///<summary>Destroy this structure immediately.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this structure, and it's not in your room.</description></item>
    ///<item><term>Busy</term><description>Hostile creeps are in the room.</description></item>
    ///</list></returns>

    abstract destroy: unit -> ScreepCode
    ///<summary>One of the STRUCTURE_* constants.</summary>
    abstract structureType:  StructureType
    ///<summary>A unique object identificator. You can use Game.getObjectById method to retrieve an object instance by its id.</summary>
    abstract id:  String
    ///<summary>The total amount of hit points of the structure.</summary>
    abstract hitsMax:  Int32
    ///<summary>The current amount of hit points of the structure.</summary>
    abstract hits:  Int32
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary>An object that can contain resources in its cargo.An object that can contain resources in its cargo.There are two types of stores in the game: general purpose stores and limited stores.There are two types of stores in the game: general purpose stores and limited stores.General purpose stores can contain any resource within its capacity (e.g. creeps, containers, storages, terminals).Limited stores can contain only a few types of resources needed for that particular object (e.g. spawns, extensions, labs, nukers).General purpose stores can contain any resource within its capacity (e.g. creeps, containers, storages, terminals).General purpose stores can contain any resource within its capacity (e.g. creeps, containers, storages, terminals).General purpose stores can contain any resource within its capacity (e.g. creeps, containers, storages, terminals).Limited stores can contain only a few types of resources needed for that particular object (e.g. spawns, extensions, labs, nukers).Limited stores can contain only a few types of resources needed for that particular object (e.g. spawns, extensions, labs, nukers).Limited stores can contain only a few types of resources needed for that particular object (e.g. spawns, extensions, labs, nukers).The Store prototype is the same for both types of stores, but they have different behavior depending on the resource argument in its methods.The StoreStore prototype is the same for both types of stores, but they have different behavior depending on the resourceresource argument in its methods.You can get specific resources from the store by addressing them as object properties:You can get specific resources from the store by addressing them as object properties:console.log(creep.store[RESOURCE_ENERGY]);console.log(creep.store[RESOURCE_ENERGY]);console..loglog((creep..store[[RESOURCE_ENERGYRESOURCE_ENERGY]]));;</summary>
and Store =

    ///<summary>Returns the capacity used by the specified resource. For a general purpose store, it returns total used capacity if resource is undefined. </summary>
    ///<param name="resource">The type of the resource.</param>
    ///<returns>Returns used capacity number, or null in case of a not valid resource for this store type.</returns>
    abstract getUsedCapacity: ?resource: ResourceType -> int option   
    ///<summary>Returns free capacity for the store. For a limited store, it returns the capacity available for the specified resource if resource is defined and valid for this store. </summary>
    ///<param name="resource">The type of the resource.</param>
    ///<returns>Returns available capacity number, or null in case of an invalid resource for this store type.</returns>
    abstract getFreeCapacity: ?resource: ResourceType -> int option
    ///<summary>Returns capacity of this store for the specified resource. For a general purpose store, it returns total capacity if resource is undefined.</summary>
    ///<param name="resource">The type of the resource.</param>
    ///<returns>Returns capacity number, or null in case of an invalid resource for this store type.</returns>
    abstract getCapacity: ?resource: ResourceType -> int option

///<summary>An energy source object. Can be harvested by creeps with a WORK body part.An energy source object. Can be harvested by creeps with a WORKWORK body part.</summary>
and Source =
    inherit RoomObject


    ///<summary>The remaining time after which the source will be refilled.</summary>
    abstract ticksToRegeneration:  int32
    ///<summary>A unique object identificator. You can use Game.getObjectById method to retrieve an object instance by its id.</summary>
    abstract id:  String
    ///<summary>The total amount of energy in the source.</summary>
    abstract energyCapacity:  int32
    ///<summary>The remaining amount of energy.</summary>
    abstract energy:  int32
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary>A destroyed structure. This is a walkable object. A destroyed structure. This is a walkable object. </summary>
and Ruin =
    inherit RoomObject


    ///<summary>The amount of game ticks before this ruin decays.</summary>
    abstract ticksToDecay:  Int32
    ///<summary>An object containing basic data of the destroyed structure.</summary>
    abstract structure:  U2<Structure, OwnedStructure>
    ///<summary>A Store object that contains resources of this structure.</summary>
    abstract store:  Store
    ///<summary>A unique object identificator. You can use Game.getObjectById method to retrieve an object instance by its id.</summary>
    abstract id:  String
    ///<summary>The time when the structure has been destroyed. </summary>
    abstract destroyTime:  Int64
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list
and [<StringEnum>] LineStyle =
    | Dashed
    | Dotted
///<summary></summary>
and RoomVisualtextstyleOpts =

    ///<summary>Font color in any web format, default is #ffffff (white).</summary>
    abstract color:  String option

    ///<summary>Either a number or a string in one of the following forms: 0.7 - relative size in game coordinates20px - absolute size in pixels0.7 serifbold italic 1.5 Times New Roman</summary>
    abstract font:  U2<double, String> option

    ///<summary>Stroke color in any web format, default is undefined (no stroke).</summary>
    abstract stroke:  String option

    ///<summary>Stroke width, default is 0.15.</summary>
    abstract strokeWidth:  double option

    ///<summary>Background color in any web format, default is undefined (no background). When background is enabled, text vertical align is set to middle (default is baseline).</summary>
    abstract backgroundColor:  String option

    ///<summary>Background rectangle padding, default is 0.3.</summary>
    abstract backgroundPadding:  double option

    ///<summary>Text align, either center, left, or right. Default is center.</summary>
    abstract align:  VisualTextAlign option

    ///<summary>Opacity value, default is 1.0.</summary>
    abstract opacity:  double option
///<summary></summary>
and RoomVisualpolystyleOpts =


    ///<summary>Fill color in any web format, default is undefined (no fill).</summary>
    abstract fill:  String option

    ///<summary>Opacity value, default is 0.5.</summary>
    abstract opacity:  double option

    ///<summary>Stroke color in any web format, default is #ffffff (white).</summary>
    abstract stroke:  String option

    ///<summary>Stroke line width, default is 0.1.</summary>
    abstract strokeWidth:  double option

    ///<summary>Either undefined (solid line), dashed, or dotted. Default is undefined.</summary>
    abstract lineStyle:  LineStyle option
///<summary></summary>
and RoomVisualrectstyleOpts =


    ///<summary>Fill color in any web format, default is #ffffff (white).</summary>
    abstract fill:  String option

    ///<summary>Opacity value, default is 0.5.</summary>
    abstract opacity:  double option

    ///<summary>Stroke color in any web format, default is undefined (no stroke).</summary>
    abstract stroke:  String option

    ///<summary>Stroke line width, default is 0.1.</summary>
    abstract strokeWidth:  double option

    ///<summary>Either undefined (solid line), dashed, or dotted. Default is undefined.</summary>
    abstract lineStyle:  LineStyle option
///<summary></summary>
and RoomVisualcirclestyleOpts =


    ///<summary>Circle radius, default is 0.15.</summary>
    abstract radius:  double option

    ///<summary>Fill color in any web format, default is #ffffff (white).</summary>
    abstract fill:  String option

    ///<summary>Opacity value, default is 0.5.</summary>
    abstract opacity:  double option

    ///<summary>Stroke color in any web format, default is undefined (no stroke).</summary>
    abstract stroke:  String option

    ///<summary>Stroke line width, default is 0.1.</summary>
    abstract strokeWidth:  double option

    ///<summary>Either undefined (solid line), dashed, or dotted. Default is undefined.</summary>
    abstract lineStyle:  LineStyle option
///<summary></summary>
and RoomVisuallinestyleOpts =


    ///<summary>Line width, default is 0.1.</summary>
    abstract width:  double option

    ///<summary>Line color in any web format, default is #ffffff (white).</summary>
    abstract color:  String option

    ///<summary>Opacity value, default is 0.5.</summary>
    abstract opacity:  double option

    ///<summary>Either undefined (solid line), dashed, or dotted. Default is undefined.</summary>
    abstract lineStyle:  LineStyle option

///<summary>Room visuals provide a way to show various visual debug info in game rooms. You can use the RoomVisual object to draw simple shapes that are visible only to you. Every existing Room object already contains the visual property, but you also can create new RoomVisual objects for any room (even without visibility) using the constructor.Room visuals provide a way to show various visual debug info in game rooms. You can use the RoomVisualRoomVisual object to draw simple shapes that are visible only to you. Every existing RoomRoom object already contains the visualvisualvisual property, but you also can create new RoomVisualRoomVisual objects for any room (even without visibility) using the constructorconstructor.Room visuals are not stored in the database, their only purpose is to display something in your browser. All drawings will persist for one tick and will disappear if not updated. All RoomVisual API calls have no added CPU cost (their cost is natural and mostly related to simple JSON.serialize calls). However, there is a usage limit: you cannot post more than 500 KB of serialized data per one room (see getSize method).Room visuals are not stored in the database, their only purpose is to display something in your browser. All drawings will persist for one tick and will disappear if not updated. All RoomVisualRoomVisual API calls have no added CPU cost (their cost is natural and mostly related to simple JSON.serializeJSON.serialize calls). However, there is a usage limit: you cannot post more than 500 KB of serialized data per one room (see getSizegetSizegetSize method).All draw coordinates are measured in game coordinates and centered to tile centers, i.e. (10,10) will point to the center of the creep at x:10; y:10 position. Fractional coordinates are allowed.All draw coordinates are measured in game coordinates and centered to tile centers, i.e. (10,10) will point to the center of the creep at x:10; y:10x:10; y:10 position. Fractional coordinates are allowed.</summary>
and RoomVisual =

    ///<summary>Add previously exported (with RoomVisual.export) room visuals to the room visual data of the current tick. </summary>
    ///<param name="value">The string returned from RoomVisual.export.</param>
    ///<returns>The RoomVisual object itself, so that you can chain calls.</returns>
    abstract import: value: String -> RoomVisual 
    ///<summary>Returns a compact representation of all visuals added in the room in the current tick.</summary>
    ///<returns>A string with visuals data. There's not much you can do with the string besides store them for later.</returns>
    abstract export: unit -> string   
    ///<summary>Get the stored size of all visuals added in the room in the current tick. It must not exceed 512,000 (500 KB).</summary>
    ///<returns>The size of the visuals in bytes.</returns>
    abstract getSize: unit -> int32
    ///<summary>Remove all visuals from the room.</summary>
    ///<returns>The RoomVisual object itself, so that you can chain calls.</returns>
    abstract clear: unit -> RoomVisual 
    ///<summary>Draw a text label. You can use any valid Unicode characters, including emoji.</summary>
    ///<param name="text">The text message.</param>
    ///<param name="x">The X coordinate of the label baseline point.</param>
    ///<param name="y">The Y coordinate of the label baseline point.</param>
    ///<param name="style">An object with the following properties:</param>
    ///<returns>The RoomVisual object itself, so that you can chain calls.</returns>
    abstract text: text: String * x: Int32 * y: Int32 * ?style: RoomVisualtextstyleOpts -> RoomVisual
 
    ///<summary>Draw a text label. You can use any valid Unicode characters, including emoji.</summary>
    ///<param name="text">The text message.</param>
    ///<param name="pos">The position object of the label baseline.</param>
    ///<param name="style">An object with the following properties:</param>
    ///<returns>The RoomVisual object itself, so that you can chain calls.</returns>
    abstract text: text: String * pos: RoomPosition * ?style: RoomVisualtextstyleOpts -> RoomVisual    
    ///<summary>Draw a polyline.</summary>
    ///<param name="points">An array of points. Every item should be either an array with 2 numbers (i.e. [10,15]), or a RoomPosition object.</param>
    ///<param name="style">An object with the following properties:</param>
    ///<returns>The RoomVisual object itself, so that you can chain calls.</returns>
    abstract poly: points:  RoomPosition array * ?style: RoomVisualpolystyleOpts ->RoomVisual
    ///<summary>Draw a rectangle.</summary>
    ///<param name="x">The X coordinate of the top-left corner.</param>
    ///<param name="y">The Y coordinate of the top-left corner.</param>
    ///<param name="width">The width of the rectangle.</param>
    ///<param name="height">The height of the rectangle.</param>
    ///<param name="style">An object with the following properties:fillstring Fill color in any web format, default is #ffffff (white). opacitynumberOpacity value, default is 0.5.strokestringStroke color in any web format, default is undefined (no stroke).strokeWidthnumberStroke line width, default is 0.1.lineStylestring Either undefined (solid line), dashed, or dotted. Default is undefined.</param>
    ///<returns>The RoomVisual object itself, so that you can chain calls.</returns>
    abstract rect: x: Int32 * y: Int32 * width: Int32 * height: Int32 * ?style: RoomVisualrectstyleOpts -> RoomVisual
 
    ///<summary>Draw a rectangle.</summary>
    ///<param name="topLeftPos">The position object of the top-left corner.</param>
    ///<param name="width">The width of the rectangle.</param>
    ///<param name="height">The height of the rectangle.</param>
    ///<param name="style">An object with the following properties:fillstring Fill color in any web format, default is #ffffff (white). opacitynumberOpacity value, default is 0.5.strokestringStroke color in any web format, default is undefined (no stroke).strokeWidthnumberStroke line width, default is 0.1.lineStylestring Either undefined (solid line), dashed, or dotted. Default is undefined.</param>
    ///<returns>The RoomVisual object itself, so that you can chain calls.</returns>
    abstract rect: topLeftPos: RoomPosition * width: Int32 * height: Int32 * ?style: RoomVisualrectstyleOpts -> RoomVisual 
    ///<summary>Draw a circle.</summary>
    ///<param name="x">The X coordinate of the center.</param>
    ///<param name="y">The Y coordinate of the center.</param>
    ///<param name="style">An object with the following properties:radiusnumberCircle radius, default is 0.15.fillstring Fill color in any web format, default is #ffffff (white). opacitynumberOpacity value, default is 0.5.strokestringStroke color in any web format, default is undefined (no stroke).strokeWidthnumberStroke line width, default is 0.1.lineStylestring Either undefined (solid line), dashed, or dotted. Default is undefined.</param>
    ///<returns>The RoomVisual object itself, so that you can chain calls.</returns>
    abstract circle: x: Int32 * y: Int32 * ?style: RoomVisualcirclestyleOpts -> RoomVisual 
 
    ///<summary>Draw a circle.</summary>
    ///<param name="pos">The position object of the center.</param>
    ///<param name="style">An object with the following properties:radiusnumberCircle radius, default is 0.15.fillstring Fill color in any web format, default is #ffffff (white). opacitynumberOpacity value, default is 0.5.strokestringStroke color in any web format, default is undefined (no stroke).strokeWidthnumberStroke line width, default is 0.1.lineStylestring Either undefined (solid line), dashed, or dotted. Default is undefined.</param>
    ///<returns>The RoomVisual object itself, so that you can chain calls.</returns>
    abstract circle: pos: RoomPosition * ?style: RoomVisualcirclestyleOpts -> RoomVisual
    ///<summary>Draw a line.</summary>
    ///<param name="x1">The start X coordinate.</param>
    ///<param name="y1">The start Y coordinate.</param>
    ///<param name="x2">The finish X coordinate.</param>
    ///<param name="y2">The finish Y coordinate.</param>
    ///<param name="style">An object with the following properties:widthnumberLine width, default is 0.1.colorstring Line color in any web format, default is #ffffff (white). opacitynumberOpacity value, default is 0.5.lineStylestring Either undefined (solid line), dashed, or dotted. Default is undefined.</param>
    ///<returns>The RoomVisual object itself, so that you can chain calls.</returns>
    abstract line: x1: Int32 * y1: Int32 * x2: Int32 * y2: Int32 * ?style: RoomVisuallinestyleOpts -> RoomVisual 
    ///<summary>Draw a line.</summary>
    ///<param name="pos1">The start position object.</param>
    ///<param name="pos2">The finish position object.</param>
    ///<param name="style">An object with the following properties:widthnumberLine width, default is 0.1.colorstring Line color in any web format, default is #ffffff (white). opacitynumberOpacity value, default is 0.5.lineStylestring Either undefined (solid line), dashed, or dotted. Default is undefined.</param>
    ///<returns>The RoomVisual object itself, so that you can chain calls.</returns>
    abstract line: pos1: RoomPosition * pos2: RoomPosition * ?style: RoomVisuallinestyleOpts -> RoomVisual
    ///<summary>The name of the room.</summary>
    abstract roomName:  String
///<summary></summary>
and RoomPositionfindClosestByRangeOpts<'T> =


    ///<summary>Only the objects which pass the filter using the Lodash.filter method will be used.</summary>
    abstract filter: ('T -> bool) option
///<summary></summary>
and RoomPositionfindClosestByPathOpts<'T> =


    ///<summary>Only the objects which pass the filter using the Lodash.filter method will be used.</summary>
    abstract filter:   ('T -> bool)  option

    ///<summary>One of the following constants: astar is faster when there are relatively few possible targets;dijkstra is faster when there are a lot of possible targets or when the closest target is nearby. The default value is determined automatically using heuristics.</summary>
    abstract algorithm:  String option

and RoomPositionUnion = 
    {
       Type: String;
       Creep: Creep; 
       Flag: Flag; 
       Mineral: Mineral; 
       Deposit: Deposit; 
       Nuke: Nuke; 
       Resource: Resource; 
       Energy: Resource;
       Source: Source;
       Structure: Structure;
       Terrain: Terrain;
       Tombstone: Tombstone;
       PowerCreep: PowerCreep;
       Ruin: Ruin
     }
and RoomPositionCreateFlagResult =
    | CreateFlag of string
    | CannotCreateFlag of ScreepCode
///<summary>An object representing the specified position in the room. Every RoomObject in the room contains RoomPosition as the pos property. The position object of a custom location can be obtained using the Room.getPositionAt method or using the constructor.An object representing the specified position in the room. Every RoomObjectRoomObject in the room contains RoomPositionRoomPosition as the pospos property. The position object of a custom location can be obtained using the Room.getPositionAtRoom.getPositionAtRoom.getPositionAt method or using the constructor.</summary>
and RoomPosition =

    ///<summary>Get an object with the given type at the specified room position.</summary>
    ///<param name="sType">One of the LOOK_* constants.</param>
    ///<returns>An array of objects of the given type at the specified position if found.</returns>
    abstract lookFor<'T when 'T :> RoomObject> : sType: Look -> 'T list
    ///<summary>Get an object with the given type at the specified room position.</summary>
    ///<returns>An array of objects of the given type at the specified position if found.</returns>
    [<Emit("$0.lookFor(LOOK_TERRAIN)")>]
    abstract lookForTerrain : unit -> Terrain array  
    ///<summary>Get the list of objects at the specified room position.</summary>
    abstract look: unit -> RoomPositionUnion array 
    ///<summary>Check whether this position is on the adjacent square to the specified position. The same as inRangeTo(target, 1).</summary>
    ///<param name="x">X position in the room.</param>
    ///<param name="y">Y position in the room.</param>
    ///<returns>A boolean value</returns>
    abstract isNearTo: x: Int32 * y: Int32 -> bool 
 
    ///<summary>Check whether this position is on the adjacent square to the specified position. The same as inRangeTo(target, 1).</summary>
    ///<param name="target">Can be a RoomPosition object or any object containing RoomPosition.</param>
    ///<returns>A boolean value</returns>
    abstract isNearTo: target:  U2<RoomPosition, RoomObject> -> bool
     ///<summary>Check whether this position is the same as the specified position.</summary>
    ///<param name="x">X position in the room.</param>
    ///<param name="y">Y position in the room.</param>
    ///<returns>A boolean value</returns>
    abstract isEqualTo: x: Int32 * y: Int32 -> bool
 
    ///<summary>Check whether this position is the same as the specified position.</summary>
    ///<param name="target">Can be a RoomPosition object or any object containing RoomPosition.</param>
    ///<returns>A boolean value</returns>
    abstract isEqualTo: target:  U2<RoomPosition, RoomObject>  -> bool
    ///<summary>Check whether this position is in the given range of another position.</summary>
    ///<param name="x">X position in the same room.</param>
    ///<param name="y">Y position in the same room.</param>
    ///<param name="range">The range distance.</param>
    ///<returns>A boolean value</returns>
    abstract inRangeTo: x: Int32 * y: Int32 * range: Int32 -> bool
 
    ///<summary>Check whether this position is in the given range of another position.</summary>
    ///<param name="target">The target position.</param>
    ///<param name="range">The range distance.</param>
    ///<returns>A boolean value</returns>
    abstract inRangeTo: target: RoomPosition * range: Int32 -> bool
    ///<summary>Get linear range to the specified position.</summary>
    ///<param name="x">X position in the room.</param>
    ///<param name="y">Y position in the room.</param>
    ///<returns>A number of squares to the given position.</returns>
    abstract getRangeTo: x: Int32 * y: Int32 -> int 
 
    ///<summary>Get linear range to the specified position.</summary>
    ///<param name="target">Can be a RoomPosition object or any object containing RoomPosition.</param>
    ///<returns>A number of squares to the given position.</returns>
    abstract getRangeTo: target: U2<RoomPosition, RoomObject> -> int 
    ///<summary>Get linear direction to the specified position.</summary>
    ///<param name="x">X position in the room.</param>
    ///<param name="y">Y position in the room.</param>
    ///<returns>A number representing one of the direction constants.</returns>
    abstract getDirectionTo: x: Int32 * y: Int32 -> Direction
 
    ///<summary>Get linear direction to the specified position.</summary>
    ///<param name="target">Can be a RoomPosition object or any object containing RoomPosition.</param>
    ///<returns>A number representing one of the direction constants.</returns>
    abstract getDirectionTo: target:  U2<RoomPosition, RoomObject> -> Direction 
    ///<summary>Find an optimal path to the specified position using Jump Point Search algorithm. This method is a shorthand for Room.findPath. If the target is in another room, then the corresponding exit will be used as a target.</summary>
    ///<param name="x">X position in the room.</param>
    ///<param name="y">Y position in the room.</param>
    ///<param name="opts">An object containing pathfinding options flags (see Room.findPath for more details).</param>
    abstract findPathTo: x: Int32 * y: Int32 * ?opts:  RoomfindPathOpts -> PathSegment array 
 
    ///<summary>Find an optimal path to the specified position using Jump Point Search algorithm. This method is a shorthand for Room.findPath. If the target is in another room, then the corresponding exit will be used as a target.</summary>
    ///<param name="target">Can be a RoomPosition object or any object containing RoomPosition.</param>
    ///<param name="opts">An object containing pathfinding options flags (see Room.findPath for more details).</param>
    ///<returns>An array with path steps</returns>
    abstract findPathTo: target: U2<RoomPosition, RoomObject> * ?opts:  RoomfindPathOpts  -> PathSegment array    ///<summary>Find all objects in the specified linear range.</summary>
    ///<param name="sType">See Room.find.</param>
    ///<param name="range">The range distance.</param>
    ///<param name="opts">See Room.find.</param>
    ///<returns>An array with the objects found.</returns>
    abstract findInRange<'T when 'T :> RoomObject> : sType: Find * range: Int32 * ?opts:  RoomfindOpts<'T> -> 'T array 
 
    ///<summary>Find all objects in the specified linear range.</summary>
    ///<param name="objects">An array of room's objects or RoomPosition objects that the search should be executed against.</param>
    ///<param name="range">The range distance.</param>
    ///<param name="opts">See Room.find.</param>
    ///<returns>An array with the objects found.</returns>
    abstract findInRange: objects:  U2<RoomPosition array, RoomObject array>  * range: Int32 * ?opts:  RoomfindOpts<'T> -> RoomObject list
    ///<summary>Find an object with the shortest linear distance from the given position.</summary>
    ///<param name="sType">See Room.find.</param>
    ///<param name="opts">An object containing one of the following options:</param>
    ///<returns>The closest object if found, null otherwise.</returns>
    abstract findClosestByRange<'T when 'T :> RoomObject> : sType: Find * ?opts: RoomPositionfindClosestByRangeOpts<'T> -> 'T option 
 
    ///<summary>Find an object with the shortest linear distance from the given position.</summary>
    ///<param name="objects">An array of room's objects or RoomPosition objects that the search should be executed against.</param>
    ///<param name="opts">An object containing one of the following options:</param>
    ///<returns>The closest object if found, null otherwise.</returns>
    abstract findClosestByRange<'T> : objects:  U2<RoomPosition array, RoomObject array> * ?opts: RoomPositionfindClosestByRangeOpts<'T> -> RoomObject option ///<summary>Find an object with the shortest path from the given position. Uses Jump Point Search algorithm and Dijkstra's algorithm.</summary>
    ///<param name="sType">See Room.find.</param>
    ///<param name="opts">An object containing pathfinding options (see Room.findPath), or one of the following:</param>
    ///<returns>The closest object if found, null otherwise.</returns>
    abstract findClosestByPath<'T when 'T :> RoomObject> : sType: Find * ?opts: RoomPositionfindClosestByPathOpts<'T> -> 'T option 
    ///<summary>Find an object with the shortest path from the given position. Uses Jump Point Search algorithm and Dijkstra's algorithm.</summary>
    ///<param name="objects">An array of room's objects or RoomPosition objects that the search should be executed against.</param>
    ///<param name="opts">An object containing pathfinding options (see Room.findPath), or one of the following:</param>
    ///<returns>The closest object if found, null otherwise.</returns>
    abstract findClosestByPath<'T> : objects:  U2<RoomPosition array, RoomObject array>  * ?opts: RoomPositionfindClosestByPathOpts<'T> -> RoomObject option 
    ///<summary>Create new Flag at the specified location.</summary>
    ///<returns> The name of a new flag, or one of the following error codes:
    ///<list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>NameExists</term><description>There is a flag with the same name already.</description></item>
    ///<item><term>InvalidArgs</term><description>The location or the color constant is incorrect.</description></item>
    ///</list></returns>

    ///<param name="name">The name of a new flag. It should be unique, i.e. the Game.flags object should not contain another flag with the same name (hash key). If not defined, a random name will be generated.</param>
    ///<param name="color">The color of a new flag. Should be one of the COLOR_* constants. The default value is COLOR_WHITE.</param>
    ///<param name="secondaryColor">The secondary color of a new flag. Should be one of the COLOR_* constants. The default value is equal to color.</param>
    abstract createFlag: ?name: String * ?color: Color * ?secondaryColor: Color -> RoomPositionCreateFlagResult
    ///<summary>Create new ConstructionSite at the specified location.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>InvalidTarget</term><description>The structure cannot be placed at the specified location.</description></item>
    ///<item><term>Full</term><description>You have too many construction sites. The maximum number of construction sites per player is 100.</description></item>
    ///<item><term>InvalidArgs</term><description>The location is incorrect.</description></item>
    ///<item><term>RclNotEnough</term><description>Room Controller Level insufficient. Learn more</description></item>
    ///</list></returns>

    ///<param name="structureType">One of the STRUCTURE_* constants.</param>
    ///<param name="name">The name of the structure, for structures that support it (currently only spawns).</param>
    abstract createConstructionSite: structureType: StructureType * ?name: String -> ScreepCode
    ///<summary>Y position in the room.</summary>
    abstract y:  Int32
    ///<summary>X position in the room.</summary>
    abstract x:  Int32
    ///<summary>The name of the room.</summary>
    abstract roomName:  String

///<summary>Any object with a position in a room. Almost all game objects prototypes are derived from RoomObject.Any object with a position in a room. Almost all game objects prototypes are derived from RoomObjectRoomObject.</summary>
and RoomObject =


    ///<summary>The link to the Room object. May be undefined in case if an object is a flag or a construction site and is placed in a room that is not visible to you.</summary>
    abstract room:  Room option
    ///<summary>An object representing the position of this object in the room.</summary>
    abstract pos:  RoomPosition
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary>An object which provides fast access to room terrain data. These objects can be constructed for any room in the world even if you have no access to it.An object which provides fast access to room terrain data. These objects can be constructed for any room in the world even if you have no access to it.Technically every Room.Terrain object is a very lightweight adapter to underlying static terrain buffers with corresponding minimal accessors.Technically every Room.TerrainRoom.Terrain object is a very lightweight adapter to underlying static terrain buffers with corresponding minimal accessors.</summary>
and RoomTerrain  =
    ///<summary>Get copy of underlying static terrain buffer. Current underlying representation is Uint8Array.</summary>
    ///<returns>
    /// <para>Copy of underlying room terrain representations as a new Uint8Array typed array of size 2500.</para>
    /// <para>Each element is an integer number, terrain type can be obtained by applying bitwise AND operator with appropriate TERRAIN_MASK_* constant. Room tiles are stored row by row.</para>
    /// <para>If destinationArray is specified, function returns reference to this filled destinationArray if coping succeeded, or error code otherwise:</para>
    ///<list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>InvalidArgs</term><description>destinationArray type is incompatible.</description></item>
    ///</list></returns>
    ///<param name="destinationArray">A typed array view in which terrain will be copied to.</param>
    abstract getRawBuffer: ?destinationArray: uint8 array -> ScreepCode
    ///<summary>Get terrain type at the specified room position by (x,y) coordinates. Unlike the Game.map.getTerrainAt(...) method, this one doesn't perform any string operations and returns integer terrain type values (see below).</summary>
    ///<param name="x">X position in the room.</param>
    ///<param name="y">Y position in the room.</param>
    ///<returns><list type="bullet"><listheader><term>constant</term><description></description></listheader>
    ///<item><term>MaskNotExist</term><description>terrain is plain</description></item>
    ///<item><term>MaskWall</term><description>terrain is wall</description></item>
    ///<item><term>MaskSwamp</term><description>terrain is swamp</description></item>
    ///</list></returns>
    abstract get: x: Int32 * y: Int32 -> RoomTerrain
///<summary></summary>
and RoomfindPathOpts =


    ///<summary>Treat squares with creeps as walkable. Can be useful with too many moving creeps around or in some other cases. The default value is false.</summary>
    abstract ignoreCreeps:  Boolean option

    ///<summary>Treat squares with destructible structures (constructed walls, ramparts, spawns, extensions) as walkable. The default value is false.</summary>
    abstract ignoreDestructibleStructures:  Boolean option

    ///<summary>Ignore road structures. Enabling this option can speed up the search. The default value is false. This is only used when the new PathFinder is enabled.</summary>
    abstract ignoreRoads:  Boolean option

    ///<summary>You can use this callback to modify a CostMatrix for any room during the search. The callback accepts two arguments, roomName and costMatrix. Use the costMatrix instance to make changes to the positions costs. If you return a new matrix from this callback, it will be used instead of the built-in cached one. This option is only used when the new PathFinder is enabled.</summary>
    abstract costCallback:   ((String* PathFinderCostMatrix) -> U2<PathFinderCostMatrix, unit>) option

    ///<summary>An array of the room's objects or RoomPosition objects which should be treated as walkable tiles during the search. This option cannot be used when the new PathFinder is enabled (use costCallback option instead).</summary>
    abstract ignore:   U2<RoomObject array, RoomPosition array>  option

    ///<summary>An array of the room's objects or RoomPosition objects which should be treated as obstacles during the search. This option cannot be used when the new PathFinder is enabled (use costCallback option instead).</summary>
    abstract avoid: U2<RoomObject array, RoomPosition array> option

    ///<summary>The maximum limit of possible pathfinding operations. You can limit CPU time used for the search based on ratio 1 op ~ 0.001 CPU. The default value is 2000.</summary>
    abstract maxOps:  Int32 option

    ///<summary>Weight to apply to the heuristic in the A formula F = G + weight  H. Use this option only if you understand the underlying A* algorithm mechanics! The default value is 1.2.</summary>
    abstract heuristicWeight:  double option

    ///<summary>If true, the result path will be serialized using Room.serializePath. The default is false.</summary>
    abstract serialize:  Boolean option

    ///<summary>The maximum allowed rooms to search. The default (and maximum) is 16. This is only used when the new PathFinder is enabled.</summary>
    abstract maxRooms:  Int32 option

    ///<summary>Find a path to a position in specified linear range of target. The default is 0.</summary>
    abstract range:  Int32 option

    ///<summary>Cost for walking on plain positions. The default is 1.</summary>
    abstract plainCost:  Int32 option

    ///<summary>Cost for walking on swamp positions. The default is 5.</summary>
    abstract swampCost:  Int32 option
///<summary></summary>
and RoomfindOpts<'T> =


    ///<summary>The result list will be filtered using the Lodash.filter method.</summary>
    abstract filter:   ('T -> bool) option

///<summary>An object representing the room in which your units and structures are in. It can be used to look around, find paths, etc. Every RoomObject in the room contains its linked Room instance in the room property.An object representing the room in which your units and structures are in. It can be used to look around, find paths, etc. Every RoomObjectRoomObject in the room contains its linked RoomRoom instance in the roomroom property.</summary>
and LookAtAreaArrayResult<'T when 'T :> RoomObject> = 
    abstract member x: int
    abstract member y: int
    abstract member item: 'T
and RoomLookAtUnion = 
      {
         X: int; Y: int;
         Type: String;
         Creep: Creep; 
         Flag: Flag; 
         Mineral: Mineral; 
         Deposit: Deposit; 
         Nuke: Nuke; 
         Resource: Resource; 
         Energy: Resource;
         Source: Source;
         Structure: Structure;
         Terrain: Terrain;
         Tombstone: Tombstone;
         PowerCreep: PowerCreep;
         Ruin: Ruin
       }
and RoomLookAtAreaResult = 
    | ArrayRes of RoomLookAtUnion list
    | MatrixResult of obj
and RoomLookAtResult = 
    | ArrayRes of RoomLookAtUnion 
    | MatrixResult of obj
and RoomFindExitResult = 
    | ExitFounded of Find
    | ExitFoundErr of ScreepCode
and Room =
    ///<summary>Get the list of objects with the given type at the specified room area.</summary>
    ///<param name="sType">One of the LOOK_* constants.</param>
    ///<param name="top">The top Y boundary of the area.</param>
    ///<param name="left">The left X boundary of the area.</param>
    ///<param name="bottom">The bottom Y boundary of the area.</param>
    ///<param name="right">The right X boundary of the area.</param>
    ///<returns>If asArray is set to false or undefined, the method returns an object with all the objects of the given type</returns>
    abstract lookForAtArea: sType: Look * top: Int32 * left: Int32 * bottom: Int32 * right: Int32 -> RoomLookAtAreaResult
    ///<summary>Get an object with the given type at the specified room position.</summary>
    ///<param name="sType">One of the LOOK_* constants.</param>
    ///<param name="x">X position in the room.</param>
    ///<param name="y">Y position in the room.</param>
    ///<returns>An array of objects of the given type at the specified position if found.</returns>
    abstract lookForAt<'T when 'T :> RoomObject> : sType: Look * x: Int32 * y: Int32 -> 'T []
    ///<summary>Get a terraint with the given type at the specified room position.</summary>
    ///<param name="x">X position in the room.</param>
    ///<param name="y">Y position in the room.</param>
    ///<returns>An array of objects of the given type at the specified position if found.</returns>
    [<Emit("$0.lookForAt(LOOK_TERRAIN, $1, $2)")>]
    abstract lookForTerrainAt : x: Int32 * y: Int32 -> Terrain []
    ///<summary>Get an object with the given type at the specified room position.</summary>
    ///<param name="sType">One of the LOOK_* constants.</param>
    ///<param name="target">Can be a RoomPosition object or any object containing RoomPosition.</param>
    ///<returns>An array of objects of the given type at the specified position if found.</returns>
    abstract lookForAt<'T when 'T :> RoomObject> : sType: Look * target:  U2<RoomPosition, RoomObject> -> 'T []
    ///<summary>Get an object with the given type at the specified room position.</summary>
    ///<param name="target">Can be a RoomPosition object or any object containing RoomPosition.</param>
    ///<returns>An array of objects of the given type at the specified position if found.</returns>
    [<Emit("$0.lookForAt(LOOK_TERRAIN, $1)")>]
    abstract lookForTerrainAt:  target:  U2<RoomPosition, RoomObject> -> Terrain []
    ///<summary>Get the list of objects at the specified room area.</summary>
    ///<param name="top">The top Y boundary of the area.</param>
    ///<param name="left">The left X boundary of the area.</param>
    ///<param name="bottom">The bottom Y boundary of the area.</param>
    ///<param name="right">The right X boundary of the area.</param>
    ///<param name="asArray">Set to true if you want to get the result as a plain array.</param>
    ///<returns>If asArray is set to true. Returns ArrayRes case, else MatrixResult</returns>
    abstract lookAtArea: top: Int32 * left: Int32 * bottom: Int32 * right: Int32 * ?asArray: Boolean -> RoomLookAtAreaResult
    ///<summary>Get the list of objects at the specified room position.</summary>
    ///<param name="x">X position in the room.</param>
    ///<param name="y">Y position in the room.</param>
    ///<returns>An array with objects at the specified position </returns>
    abstract lookAt: x: Int32 * y: Int32 -> RoomLookAtUnion
    ///<summary>Get the list of objects at the specified room position.</summary>
    ///<param name="target">Can be a RoomPosition object or any object containing RoomPosition.</param>
    ///<returns>An array with objects at the specified position </returns>
    abstract lookAt: target:  U2<RoomPosition, RoomObject> -> RoomLookAtUnion 
    ///<summary>Get a Room.Terrain object which provides fast access to static terrain data. This method works for any room in the world even if you have no access to it.</summary>
    ///<returns>Returns new Room.Terrain object</returns>
    abstract getTerrain: unit -> RoomTerrain 
    ///<summary>Creates a RoomPosition object at the specified location.</summary>
    ///<param name="x">The X position.</param>
    ///<param name="y">The Y position.</param>
    ///<returns>A RoomPosition object or null if it cannot be obtained.</returns>
    abstract getPositionAt: x: Int32 * y: Int32 -> RoomPosition
    ///<summary>Returns an array of events happened on the previous tick in this room. </summary>
    ///<param name="raw">If this parameter is false or undefined, the method returns an object parsed using JSON.parse which incurs some CPU cost on the first access (the return value is cached on subsequent calls). If raw is truthy, then raw JSON in string format is returned.</param>
    abstract getEventLog: raw: Boolean -> EventObject array 
        ///<summary>Find an optimal path inside the room between fromPos and toPos using Jump Point Search algorithm.</summary>
    ///<param name="fromPos">The start position.</param>
    ///<param name="toPos">The end position.</param>
    ///<param name="opts">An object containing additonal pathfinding flags:ignoreCreepsbooleanTreat squares with creeps as walkable. Can be useful with too many moving creeps around or in some other cases. The default value is false.ignoreDestructibleStructuresbooleanTreat squares with destructible structures (constructed walls, ramparts, spawns, extensions) as walkable. The default value is false.ignoreRoadsboolean Ignore road structures. Enabling this option can speed up the search. The default value is false. This is only used when the new PathFinder is enabled. costCallbackfunction(string, CostMatrix) You can use this callback to modify a CostMatrix for any room during the search. The callback accepts two arguments, roomName and costMatrix. Use the costMatrix instance to make changes to the positions costs. If you return a new matrix from this callback, it will be used instead of the built-in cached one. This option is only used when the new PathFinder is enabled. ignorearray An array of the room's objects or RoomPosition objects which should be treated as walkable tiles during the search. This option cannot be used when the new PathFinder is enabled (use costCallback option instead). avoidarray An array of the room's objects or RoomPosition objects which should be treated as obstacles during the search. This option cannot be used when the new PathFinder is enabled (use costCallback option instead). maxOpsnumberThe maximum limit of possible pathfinding operations. You can limit CPU time used for the search based on ratio 1 op ~ 0.001 CPU. The default value is 2000.heuristicWeightnumber Weight to apply to the heuristic in the A formula F = G + weight H. Use this option only if you understand the underlying A* algorithm mechanics! The default value is 1.2. serializeboolean If true, the result path will be serialized using Room.serializePath. The default is false. maxRoomsnumber The maximum allowed rooms to search. The default (and maximum) is 16. This is only used when the new PathFinder is enabled. rangenumberFind a path to a position in specified linear range of target. The default is 0.plainCostnumberCost for walking on plain positions. The default is 1.swampCostnumberCost for walking on swamp positions. The default is 5.</param>
    ///<returns>An array with path steps</returns>
    abstract findPath: fromPos: RoomPosition * toPos: RoomPosition * ?opts: RoomfindPathOpts -> PathSegment array 
    ///<summary>Find the exit direction en route to another room. Please note that this method is not required for inter-room movement, you can simply pass the target in another room into Creep.moveTo method.</summary>
    ///<returns> if success. Returns case with Exit Find constants, else Case with ScreepCode
    ///<list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>NoPath</term><description>Path can not be found.</description></item>
    ///<item><term>InvalidArgs</term><description>The location is incorrect.</description></item>
    ///</list></returns>

    ///<param name="room">Another room name or room object.</param>
    abstract findExitTo: room: U2<String, Room> -> RoomFindExitResult 
    ///<summary>Find all objects of the specified type in the room. Results are cached automatically for the specified room and type before applying any custom filters. This automatic cache lasts until the end of the tick.</summary>
    ///<param name="sType">One of the FIND_* constants.</param>
    ///<param name="opts">An object with additional options:</param>
    abstract find<'T> : sType: Find * ?opts: RoomfindOpts<'T> -> RoomObject array
    ///<summary>Create new Flag at the specified location.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>NameExists</term><description>There is a flag with the same name already.</description></item>
    ///<item><term>Full</term><description>You have too many flags. The maximum number of flags per player is 10000.</description></item>
    ///<item><term>InvalidArgs</term><description>The location or the name or the color constant is incorrect.</description></item>
    ///</list></returns>
    ///<param name="x">The X position.</param>
    ///<param name="y">The Y position.</param>
    ///<param name="name">The name of a new flag. It should be unique, i.e. the Game.flags object should not contain another flag with the same name (hash key). If not defined, a random name will be generated. The maximum length is 100 characters.</param>
    ///<param name="color">The color of a new flag. Should be one of the COLOR_* constants. The default value is COLOR_WHITE.</param>
    ///<param name="secondaryColor">The secondary color of a new flag. Should be one of the COLOR_* constants. The default value is equal to color.</param>
    abstract createFlag: x: Int32 * y: Int32 * ?name: String * ?color: Color * ?secondaryColor: Color -> RoomPositionCreateFlagResult
 
    ///<summary>Create new Flag at the specified location.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>NameExists</term><description>There is a flag with the same name already.</description></item>
    ///<item><term>Full</term><description>You have too many flags. The maximum number of flags per player is 10000.</description></item>
    ///<item><term>InvalidArgs</term><description>The location or the name or the color constant is incorrect.</description></item>
    ///</list></returns>
    ///<param name="pos">Can be a RoomPosition object or any object containing RoomPosition.</param>
    ///<param name="name">The name of a new flag. It should be unique, i.e. the Game.flags object should not contain another flag with the same name (hash key). If not defined, a random name will be generated. The maximum length is 100 characters.</param>
    ///<param name="color">The color of a new flag. Should be one of the COLOR_* constants. The default value is COLOR_WHITE.</param>
    ///<param name="secondaryColor">The secondary color of a new flag. Should be one of the COLOR_* constants. The default value is equal to color.</param>
    abstract createFlag: pos:  U2<RoomPosition, RoomObject> * ?name: String * ?color: String * ?secondaryColor: Color -> ScreepCode
    ///<summary>Create new ConstructionSite at the specified location.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>The room is claimed or reserved by a hostile player.</description></item>
    ///<item><term>InvalidTarget</term><description>The structure cannot be placed at the specified location.</description></item>
    ///<item><term>Full</term><description>You have too many construction sites. The maximum number of construction sites per player is 100.</description></item>
    ///<item><term>InvalidArgs</term><description>The location is incorrect.</description></item>
    ///<item><term>RclNotEnough</term><description>Room Controller Level insufficient. Learn more</description></item>
    ///</list></returns>
    ///<param name="x">The X position.</param>
    ///<param name="y">The Y position.</param>
    ///<param name="structureType">One of the STRUCTURE_* constants.</param>
    ///<param name="name">The name of the structure, for structures that support it (currently only spawns). The name length limit is 100 characters.</param>
    abstract createConstructionSite: x: Int32 * y: Int32 * structureType: StructureType * ?name: String -> ScreepCode
 
    ///<summary>Create new ConstructionSite at the specified location.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>The room is claimed or reserved by a hostile player.</description></item>
    ///<item><term>InvalidTarget</term><description>The structure cannot be placed at the specified location.</description></item>
    ///<item><term>Full</term><description>You have too many construction sites. The maximum number of construction sites per player is 100.</description></item>
    ///<item><term>InvalidArgs</term><description>The location is incorrect.</description></item>
    ///<item><term>RclNotEnough</term><description>Room Controller Level insufficient. Learn more</description></item>
    ///</list></returns>

    ///<param name="pos">Can be a RoomPosition object or any object containing RoomPosition.</param>
    ///<param name="structureType">One of the STRUCTURE_* constants.</param>
    ///<param name="name">The name of the structure, for structures that support it (currently only spawns). The name length limit is 100 characters.</param>
    abstract createConstructionSite: pos:  U2<RoomPosition, RoomObject> * structureType: String * ?name: String -> ScreepCode    
    
    ///<summary>A RoomVisual object for this room. You can use this object to draw simple shapes (lines, circles, text labels) in the room.</summary>
    abstract visual:  RoomVisual
    ///<summary>The Terminal structure of this room, if present, otherwise undefined.</summary>
    abstract terminal:  StructureTerminal
    ///<summary>The Storage structure of this room, if present, otherwise undefined.</summary>
    abstract storage:  StructureStorage
    ///<summary>The name of the room.</summary>
    abstract name:  String
    ///<summary>A shorthand to Memory.rooms[room.name]. You can use it for quick access the room’s specific memory data object. Learn more about memory</summary>
    abstract memory:   obj with get, set
    ///<summary>Total amount of energyCapacity of all spawns and extensions in the room.</summary>
    abstract energyCapacityAvailable:  Int32
    ///<summary>Total amount of energy available in all spawns and extensions in the room.</summary>
    abstract energyAvailable:  Int32
    ///<summary>The Controller structure of this room, if present, otherwise undefined.</summary>
    abstract controller:  StructureController

///<summary>A dropped piece of resource. It will decay after a while if not picked up. Dropped resource pile decays for ceil(amount/1000) units per tick. A dropped piece of resource. It will decay after a while if not picked up. Dropped resource pile decays for ceil(amount/1000)ceil(amount/1000) units per tick. </summary>
and Resource =
    inherit RoomObject


    ///<summary>One of the RESOURCE_* constants.</summary>
    abstract resourceType:  ResourceType
    ///<summary>A unique object identificator. You can use Game.getObjectById method to retrieve an object instance by its id.</summary>
    abstract id:  String
    ///<summary>The amount of resource units containing.</summary>
    abstract amount:  Int32
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list
and PowerCreepmoveToOpts =
    inherit RoomfindPathOpts

      ///<summary>This option enables reusing the path found along multiple game ticks. It allows to save CPU time, but can result in a slightly slower creep reaction behavior. The path is stored into the creep's memory to the _move property. The reusePath value defines the amount of ticks which the path should be reused for. The default value is 5. Increase the amount to save more CPU, decrease to make the movement more consistent. Set to 0 if you want to disable path reusing.</summary>
    abstract reusePath:  Int32 option

    ///<summary>If reusePath is enabled and this option is set to true, the path will be stored in memory in the short serialized form using Room.serializePath. The default value is true.</summary>
    abstract serializeMemory:  Boolean option

    ///<summary>If this option is set to true, moveTo method will return ERR_NOT_FOUND if there is no memorized path to reuse. This can significantly save CPU time in some cases. The default value is false.</summary>
    abstract noPathFinding:  Boolean option

    ///<summary>Draw a line along the creep’s path using RoomVisual.poly. You can provide either an empty object or custom style parameters. The default style is equivalent to: {
    ///fill: 'transparent', stroke: '#fff', lineStyle: 'dashed', strokeWidth: .15, opacity: .1 }</summary>
    abstract visualizePathStyle:   RoomVisualpolystyleOpts option
///<summary></summary>
and PowerCreeppowersResult =


    ///<summary>Current level of the power.</summary>
    abstract level:  Int32

    ///<summary>Cooldown ticks remaining, or undefined if the power creep is not spawned in the world.</summary>
    abstract cooldown:  int32

///<summary>Power Creeps are immortal "heroes" that are tied to your account and can be respawned in any PowerSpawn after death. You can upgrade their abilities ("powers") up to your account Global Power Level (see Game.gpl).Power Creeps are immortal "heroes" that are tied to your account and can be respawned in any PowerSpawnPowerSpawn after death. You can upgrade their abilities ("powers") up to your account Global Power Level (see Game.gplGame.gplGame.gpl).</summary>
and Owner = {username: String}
and PowerCreep =
    inherit RoomObject

    ///<summary>Withdraw resources from a structure or tombstone. The target has to be at adjacent square to the creep. Multiple creeps can withdraw from the same object in the same tick. Your creeps can withdraw resources from hostile structures/tombstones as well, in case if there is no hostile rampart on top of it.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep, or there is a hostile rampart on top of the target.</description></item>
    ///<item><term>Busy</term><description>The power creep is not spawned in the world.</description></item>
    ///<item><term>NotEnoughResources</term><description>The target does not have the given amount of resources.</description></item>
    ///<item><term>InvalidTarget</term><description>The target is not a valid object which can contain the specified resource.</description></item>
    ///<item><term>Full</term><description>The creep's carry is full.</description></item>
    ///<item><term>NotInRange</term><description>The target is too far away.</description></item>
    ///<item><term>InvalidArgs</term><description>The resourceType is not one of the RESOURCE_* constants, or the amount is incorrect.</description></item>
    ///</list></returns>

    ///<param name="target">The target object.</param>
    ///<param name="resourceType">One of the RESOURCE_* constants.</param>
    ///<param name="amount">The amount of resources to be transferred. If omitted, all the available amount is used.</param>
    abstract withdraw: target: U2<Structure, Tombstone> * resourceType: ResourceType * ?amount: Int32 -> ScreepCode
    ///<summary>Apply one the creep's powers on the specified target. You can only use powers in rooms either without a controller, or with a power-enabled controller. Only one power can be used during the same tick, each usePower call will override the previous one. If the target has the same effect of a lower or equal level, it is overridden. If the existing effect level is higher, an error is returned.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of the creep.</description></item>
    ///<item><term>Busy</term><description>The creep is not spawned in the world.</description></item>
    ///<item><term>NotEnoughResources</term><description>The creep doesn't have enough resources to use the power.</description></item>
    ///<item><term>InvalidTarget</term><description>The specified target is not valid.</description></item>
    ///<item><term>Full</term><description>The target has the same active effect of a higher level.</description></item>
    ///<item><term>NotInRange</term><description>The specified target is too far away.</description></item>
    ///<item><term>InvalidArgs</term><description>Using powers is not enabled on the Room Controller.</description></item>
    ///<item><term>Tired</term><description>The power ability is still on cooldown.</description></item>
    ///<item><term>NoBodypart</term><description>The creep doesn't have the specified power ability.</description></item>
    ///</list></returns>

    ///<param name="power">The power ability to use, one of the PWR_* constants.</param>
    ///<param name="target">A target object in the room.</param>
    abstract usePower: power: PowerType * target: RoomObject -> ScreepCode 
    ///<summary>Upgrade the creep, adding a new power ability to it or increasing level of the existing power. You need one free Power Level in your account to perform this action. </summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of the creep.</description></item>
    ///<item><term>NotEnoughResources</term><description>You account Power Level is not enough.</description></item>
    ///<item><term>Full</term><description>The specified power cannot be upgraded on this creep's level, or the creep reached the maximum level.</description></item>
    ///<item><term>InvalidArgs</term><description>The specified power ID is not valid.</description></item>
    ///</list></returns>

    ///<param name="power">The power ability to upgrade, one of the PWR_* constants.</param>
    abstract upgrade: power: PowerType -> ScreepCode
        ///<summary>Transfer resource from the creep to another object. The target has to be at adjacent square to the creep.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The power creep is not spawned in the world.</description></item>
    ///<item><term>NotEnoughResources</term><description>The creep does not have the given amount of resources.</description></item>
    ///<item><term>InvalidTarget</term><description>The target is not a valid object which can contain the specified resource.</description></item>
    ///<item><term>Full</term><description>The target cannot receive any more resources.</description></item>
    ///<item><term>NotInRange</term><description>The target is too far away.</description></item>
    ///<item><term>InvalidArgs</term><description>The resourceType is not one of the RESOURCE_* constants, or the amount is incorrect.</description></item>
    ///</list></returns>

    ///<param name="target">The target object.</param>
    ///<param name="resourceType">One of the RESOURCE_* constants.</param>
    ///<param name="amount">The amount of resources to be transferred. If omitted, all the available carried amount is used.</param>
    abstract transfer: target: U2<Creep, Structure> * resourceType: ResourceType * ?amount: Int32 -> ScreepCode
    ///<summary>Kill the power creep immediately. It will not be destroyed permanently, but will become unspawned, so that you can spawn it again.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The power creep is not spawned in the world.</description></item>
    ///</list></returns>

    abstract suicide: unit -> ScreepCode    ///<summary>Spawn this power creep in the specified Power Spawn.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of the creep or the spawn.</description></item>
    ///<item><term>Busy</term><description>The power creep is already spawned in the world.</description></item>
    ///<item><term>InvalidTarget</term><description>The specified object is not a Power Spawn.</description></item>
    ///<item><term>Tired</term><description>The power creep cannot be spawned because of the cooldown.</description></item>
    ///<item><term>RclNotEnough</term><description>Room Controller Level insufficient to use the spawn.</description></item>
    ///</list></returns>

    ///<param name="powerSpawn">Your Power Spawn structure.</param>
    abstract spawn: powerSpawn: StructurePowerSpawn -> ScreepCode 

    ///<summary>Display a visual speech balloon above the creep with the specified message. The message will be available for one tick. You can read the last message using the saying property. Any valid Unicode characters are allowed, including emoji.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The power creep is not spawned in the world.</description></item>
    ///</list></returns>
    ///<param name="message">The message to be displayed. Maximum length is 10 characters.</param>
    ///<param name="isPublic">Set to true to allow other players to see this message. Default is false.</param>
    abstract say: message: String * ?isPublic: bool -> ScreepCode 
    ///<summary>Instantly restore time to live to the maximum using a Power Spawn or a Power Bank nearby. It has to be at adjacent tile. </summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The power creep is not spawned in the world.</description></item>
    ///<item><term>InvalidTarget</term><description>The target is not a valid power bank object.</description></item>
    ///<item><term>NotInRange</term><description>The target is too far away.</description></item>
    ///</list></returns>
    ///<param name="target">The target structure.</param>
    abstract renew: target: U2<StructurePowerBank, StructurePowerSpawn> -> ScreepCode
    ///<summary>Rename the power creep. It must not be spawned in the world.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of the creep.</description></item>
    ///<item><term>NameExists</term><description>A power creep with the specified name already exists.</description></item>
    ///<item><term>Busy</term><description>The power creep is spawned in the world.</description></item>
    ///</list></returns>

    ///<param name="name">The new name of the power creep.</param>
    abstract rename: name: String -> ScreepCode
    ///<summary>Pick up an item (a dropped piece of energy). The target has to be at adjacent square to the creep or at the same square.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The power creep is not spawned in the world.</description></item>
    ///<item><term>InvalidTarget</term><description>The target is not a valid object to pick up.</description></item>
    ///<item><term>Full</term><description>The creep cannot receive any more resource.</description></item>
    ///<item><term>NotInRange</term><description>The target is too far away.</description></item>
    ///</list></returns>

    ///<param name="target">The target object to be picked up.</param>
    abstract pickup: target: Resource -> ScreepCode    
    ///<summary>Toggle auto notification when the creep is under attack. The notification will be sent to your account email. Turned on by default.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The power creep is not spawned in the world.</description></item>
    ///<item><term>InvalidArgs</term><description>enable argument is not a boolean value.</description></item>
    ///</list></returns>

    ///<param name="enabled">Whether to enable notification or disable.</param>
    abstract notifyWhenAttacked: enabled: Boolean -> ScreepCode    
    ///<summary>Find the optimal path to the target within the same room and move to it. A shorthand to consequent calls of pos.findPathTo() and move() methods. If the target is in another room, then the corresponding exit will be used as a target. </summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>NoPath</term><description>No path to the target could be found.</description></item>
    ///<item><term>Busy</term><description>The power creep is not spawned in the world.</description></item>
    ///<item><term>NotFound</term><description>The creep has no memorized path to reuse.</description></item>
    ///<item><term>InvalidTarget</term><description>The target provided is invalid.</description></item>
    ///<item><term>Tired</term><description>The fatigue indicator of the creep is non-zero.</description></item>
    ///</list></returns>

    ///<param name="x">X position of the target in the same room.</param>
    ///<param name="y">Y position of the target in the same room.</param>
    ///<param name="opts">An object containing additional options:</param>
    abstract moveTo: x: Int32 * y: Int32 * ?opts: PowerCreepmoveToOpts -> ScreepCode
 
    ///<summary>Find the optimal path to the target within the same room and move to it. A shorthand to consequent calls of pos.findPathTo() and move() methods. If the target is in another room, then the corresponding exit will be used as a target. </summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>NoPath</term><description>No path to the target could be found.</description></item>
    ///<item><term>Busy</term><description>The power creep is not spawned in the world.</description></item>
    ///<item><term>NotFound</term><description>The creep has no memorized path to reuse.</description></item>
    ///<item><term>InvalidTarget</term><description>The target provided is invalid.</description></item>
    ///<item><term>Tired</term><description>The fatigue indicator of the creep is non-zero.</description></item>
    ///</list></returns>

    ///<param name="target">Can be a RoomPosition object or any object containing RoomPosition. The position doesn't have to be in the same room with the creep.</param>
    ///<param name="opts">An object containing additional options:</param>
    abstract moveTo: target:  U2<RoomPosition, RoomObject> * ?opts: PowerCreepmoveToOpts -> ScreepCode
        ///<summary>Move the creep using the specified predefined path. </summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The power creep is not spawned in the world.</description></item>
    ///<item><term>NotFound</term><description>The specified path doesn't match the creep's location.</description></item>
    ///<item><term>InvalidArgs</term><description>path is not a valid path array.</description></item>
    ///<item><term>Tired</term><description>The fatigue indicator of the creep is non-zero.</description></item>
    ///</list></returns>

    ///<param name="path">A path value as returned from Room.findPath, RoomPosition.findPathTo, or PathFinder.search methods. Both array form and serialized string form are accepted.</param>
    abstract moveByPath: path: U3<PathSegment list, RoomPosition list, String> -> ScreepCode
    ///<summary>Move the creep one square in the specified direction. </summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The power creep is not spawned in the world.</description></item>
    ///<item><term>NotInRange</term><description>The target creep is too far away</description></item>
    ///<item><term>InvalidArgs</term><description>The provided direction is incorrect.</description></item>
    ///<item><term>Tired</term><description>The fatigue indicator of the creep is non-zero.</description></item>
    ///</list></returns>

    ///<param name="direction">A creep nearby, or one of the following constants</param>
    abstract move: direction: U2<Creep, Direction> -> ScreepCode    
    ///<summary>Enable powers usage in this room. The room controller should be at adjacent tile.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>InvalidTarget</term><description>The target is not a controller structure.</description></item>
    ///<item><term>NotInRange</term><description>The target is too far away.</description></item>
    ///</list></returns>

    ///<param name="controller">The room controller.</param>
    abstract enableRoom: controller: StructureController -> ScreepCode    
    ///<summary>Drop this resource on the ground.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The power creep is not spawned in the world.</description></item>
    ///<item><term>NotEnoughResources</term><description>The creep does not have the given amount of energy.</description></item>
    ///<item><term>InvalidArgs</term><description>The resourceType is not a valid RESOURCE_* constants.</description></item>
    ///</list></returns>
    ///<param name="resourceType">One of the RESOURCE_* constants.</param>
    ///<param name="amount">The amount of resource units to be dropped. If omitted, all the available carried amount is used.</param>
    abstract drop: resourceType: ResourceType * ?amount: Int32 -> ScreepCode    
    ///<summary>Delete the power creep permanently from your account. It should NOT be spawned in the world. The creep is not deleted immediately, but a 24-hours delete timer is started instead (see deleteTime). You can cancel deletion by calling delete(true).</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of the creep.</description></item>
    ///<item><term>Busy</term><description>The power creep is spawned in the world.</description></item>
    ///</list></returns>

    ///<param name="cancel">Set this to true to cancel previously scheduled deletion.</param>
    abstract delete: cancel: Boolean -> ScreepCode
    ///<summary>Cancel the order given during the current game tick.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term> </term><description>The operation has been cancelled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of the creep.</description></item>
    ///<item><term>Busy</term><description>The power creep is not spawned in the world.</description></item>
    ///<item><term>NotFound</term><description>The order with the specified name is not found.</description></item>
    ///</list></returns>

    ///<param name="methodName">The name of a creep's method to be cancelled.</param>
    abstract cancelOrder: methodName: String -> ScreepCode
    ///<summary>The remaining amount of game ticks after which the creep will die and become unspawned. Undefined if the creep is not spawned in the world. </summary>
    abstract ticksToLive:  Int32
    ///<summary>The timestamp when spawning or deleting this creep will become available. Undefined if the power creep is spawned in the world.</summary>
    abstract spawnCooldownTime:  Int32
    ///<summary>The name of the shard where the power creep is spawned, or undefined.</summary>
    abstract shard:  String
    ///<summary>The text message that the creep was saying at the last tick.</summary>
    abstract saying:  String
    ///<summary>Available powers, an object with power ID as a key, and the following properties:</summary>
    abstract powers:  PowerCreeppowersResult
    ///<summary>A Store object that contains cargo of this creep.</summary>
    abstract store:  Store
    ///<summary>An object with the creep’s owner info containing the following properties:</summary>
    abstract owner:   Owner 
    ///<summary>Power creep’s name. You can choose the name while creating a new power creep, and it cannot be changed later. This name is a hash key to access the creep via the Game.powerCreeps object.</summary>
    abstract name:  String
    ///<summary>Whether it is your creep or foe.</summary>
    abstract my:  Boolean
    ///<summary>A shorthand to Memory.powerCreeps[creep.name]. You can use it for quick access the creep’s specific memory data object. Learn more about memory</summary>
    abstract memory:   obj with get, set
    ///<summary>The power creep's level.</summary>
    abstract level:  Int32
    ///<summary>A unique object identificator. You can use Game.getObjectById method to retrieve an object instance by its id.</summary>
    abstract id:  String
    ///<summary>The maximum amount of hit points of the creep.</summary>
    abstract hitsMax:  Int32
    ///<summary>The current amount of hit points of the creep.</summary>
    abstract hits:  Int32
    ///<summary>A timestamp when this creep is marked to be permanently deleted from the account, or undefined otherwise.</summary>
    abstract deleteTime:  Int64
    ///<summary>The power creep's class, one of the POWER_CLASS constants.</summary>
    abstract className:  String
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect array    
    

///<summary>Container for custom navigation cost data. By default PathFinder will only consider terrain data (plain, swamp, wall) — if you need to route around obstacles such as buildings or creeps you must put them into a CostMatrix. Generally you will create your CostMatrix from within roomCallback. If a non-0 value is found in a room's CostMatrix then that value will be used instead of the default terrain cost. You should avoid using large values in your CostMatrix and terrain cost flags. For example, running PathFinder.search with { plainCost: 1, swampCost: 5 } is faster than running it with {plainCost: 2, swampCost: 10 } even though your paths will be the same.Container for custom navigation cost data. By default PathFinderPathFinder will only consider terrain data (plain, swamp, wall) — if you need to route around obstacles such as buildings or creeps you must put them into a CostMatrixCostMatrix. Generally you will create your CostMatrixCostMatrix from within roomCallbackroomCallback. If a non-0 value is found in a room's CostMatrix then that value will be used instead of the default terrain cost. You should avoid using large values in your CostMatrix and terrain cost flags. For example, running PathFinder.searchPathFinder.search with { plainCost: 1, swampCost: 5 }{ plainCost: 1, swampCost: 5 } is faster than running it with {plainCost: 2, swampCost: 10 }{plainCost: 2, swampCost: 10 } even though your paths will be the same.</summary>
and PathFinderCostMatrix =
    
    ///<summary>Returns a compact representation of this CostMatrix which can be stored via JSON.stringify.</summary>
    ///<returns>An array of numbers. There's not much you can do with the numbers besides store them for later.</returns>
    abstract serialize: unit -> int array
    ///<summary>Copy this CostMatrix into a new CostMatrix with the same data.</summary>
    abstract clone: unit -> PathFinderCostMatrix 
    ///<summary>Get the cost of a position in this CostMatrix.</summary>
    ///<param name="x">X position in the room.</param>
    ///<param name="y">Y position in the room.</param>
    abstract get: x: Int32 * y: Int32 -> int  
    ///<summary>Set the cost of a position in this CostMatrix.</summary>
    ///<param name="x">X position in the room.</param>
    ///<param name="y">Y position in the room.</param>
    ///<param name="cost">Cost of this position. Must be a whole number. A cost of 0 will use the terrain cost for that tile. A cost greater than or equal to 255 will be treated as unwalkable.</param>
    abstract set: x: Int32 * y: Int32 * cost: Int32 -> unit
///<summary></summary>
and OwnedStructureownerResult =


    ///<summary>The name of the owner user.</summary>
    abstract username:  String

///<summary>The base prototype for a structure that has an owner. Such structures can be found using FIND_MY_STRUCTURES and FIND_HOSTILE_STRUCTURES constants.The base prototype for a structure that has an owner. Such structures can be found using FIND_MY_STRUCTURESFIND_MY_STRUCTURES and FIND_HOSTILE_STRUCTURESFIND_HOSTILE_STRUCTURES constants.</summary>
and OwnedStructure =
    inherit RoomObject
    inherit Structure


    ///<summary>An object with the structure’s owner info containing the following properties:</summary>
    abstract owner:  OwnedStructureownerResult
    ///<summary>Whether this is your own structure.</summary>
    abstract my:  Boolean
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary>A nuke landing position. This object cannot be removed or modified. You can find incoming nukes in the room using the FIND_NUKES constant.A nuke landing position. This object cannot be removed or modified. You can find incoming nukes in the room using the FIND_NUKESFIND_NUKES constant.</summary>
and Nuke =
    inherit RoomObject


    ///<summary>The remaining landing time.</summary>
    abstract timeToLand:  Int32
    ///<summary>The name of the room where this nuke has been launched from.</summary>
    abstract launchRoomName:  String
    ///<summary>A unique object identificator. You can use Game.getObjectById method to retrieve an object instance by its id.</summary>
    abstract id:  String
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary>A mineral deposit. Can be harvested by creeps with a WORK body part using the extractor structure. Learn more about minerals from this article.A mineral deposit. Can be harvested by creeps with a WORKWORK body part using the extractor structure. Learn more about minerals from this articlethis article.</summary>
and Mineral =
    inherit RoomObject


    ///<summary>The remaining time after which the deposit will be refilled.</summary>
    abstract ticksToRegeneration:  Int32
    ///<summary>A unique object identificator. You can use Game.getObjectById method to retrieve an object instance by its id.</summary>
    abstract id:  String
    ///<summary>The resource type, one of the RESOURCE_* constants.</summary>
    abstract mineralType:  ResourceType
    ///<summary>The remaining amount of resources.</summary>
    abstract mineralAmount:  Int32
    ///<summary>The density that this mineral deposit will be refilled to once ticksToRegeneration reaches 0. This is one of the DENSITY_* constants.</summary>
    abstract density:  Int32
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary>A flag. Flags can be used to mark particular spots in a room. Flags are visible to their owners only. You cannot have more than 10,000 flags.A flag. Flags can be used to mark particular spots in a room. Flags are visible to their owners only. You cannot have more than 10,000 flags.</summary>
and Flag =
    inherit RoomObject

    ///<summary>Set new position of the flag.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>InvalidTarget</term><description>The target provided is invalid.</description></item>
    ///</list></returns>

    ///<param name="x">The X position in the room.</param>
    ///<param name="y">The Y position in the room.</param>
    abstract setPosition: x: Int32 * y: Int32 -> ScreepCode
    ///<summary>Set new position of the flag.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>InvalidTarget</term><description>The target provided is invalid.</description></item>
    ///</list></returns>
    ///<param name="pos">Can be a RoomPosition object or any object containing RoomPosition.</param>
    abstract setPosition: pos:  U2<RoomPosition, RoomObject> -> ScreepCode 
    ///<summary>Set new color of the flag.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>InvalidArgs</term><description>color or secondaryColor is not a valid color constant.</description></item>
    ///</list></returns>
    ///<param name="color">Primary color of the flag. One of the COLOR_* constants.</param>
    ///<param name="secondaryColor">Secondary color of the flag. One of the COLOR_* constants.</param>
    abstract setColor: color: Color * ?secondaryColor: Color -> ScreepCode
    ///<summary>Remove the flag.</summary>
    ///<returns>Always returns OK. </returns>
    abstract remove: unit -> ScreepCode 
    ///<summary>Flag secondary color. One of the COLOR_* constants.</summary>
    abstract secondaryColor:  Color
    ///<summary>Flag’s name. You can choose the name while creating a new flag, and it cannot be changed later. This name is a hash key to access the flag via the Game.flags object. The maximum name length is 100 charactes.</summary>
    abstract name:  String
    ///<summary>A shorthand to Memory.flags[flag.name]. You can use it for quick access the flag's specific memory data object.</summary>
    abstract memory:   obj with get, set
    ///<summary>Flag primary color. One of the COLOR_* constants.</summary>
    abstract color:  Color
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary>A rare resource deposit needed for producing commodities. Can be harvested by creeps with a WORK body part. Each harvest operation triggers a cooldown period, which becomes longer and longer over time.A rare resource deposit needed for producing commodities. Can be harvested by creeps with a WORKWORK body part. Each harvest operation triggers a cooldown period, which becomes longer and longer over time.Learn more about deposits from this article. Learn more about deposits from this articlethis article. </summary>
and Deposit =
    inherit RoomObject


    ///<summary>The amount of game ticks when this deposit will disappear.</summary>
    abstract ticksToDecay:  int32
    ///<summary>The cooldown of the last harvest operation on this deposit.</summary>
    abstract lastcooldown:  int32
    ///<summary>A unique object identificator. You can use Game.getObjectById method to retrieve an object instance by its id.</summary>
    abstract id:  String
    ///<summary>The deposit type, one of the following constants: Mist; Biomass; Metal; Silicon</summary>
    abstract depositType:  ResourceType
    ///<summary>The amount of game ticks until the next harvest action is possible.</summary>
    abstract cooldown:  int32
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list
///<summary></summary>
and CreepmoveToOpts =
    inherit RoomfindPathOpts

     ///<summary>This option enables reusing the path found along multiple game ticks. It allows to save CPU time, but can result in a slightly slower creep reaction behavior. The path is stored into the creep's memory to the _move property. The reusePath value defines the amount of ticks which the path should be reused for. The default value is 5. Increase the amount to save more CPU, decrease to make the movement more consistent. Set to 0 if you want to disable path reusing.</summary>
    abstract reusePath:  Int32 option

    ///<summary>If reusePath is enabled and this option is set to true, the path will be stored in memory in the short serialized form using Room.serializePath. The default value is true.</summary>
    abstract serializeMemory:  Boolean option

    ///<summary>If this option is set to true, moveTo method will return ERR_NOT_FOUND if there is no memorized path to reuse. This can significantly save CPU time in some cases. The default value is false.</summary>
    abstract noPathFinding:  Boolean option

    ///<summary>Draw a line along the creep’s path using RoomVisual.poly. You can provide either an empty object or custom style parameters. The default style is equivalent to: {
    ///fill: 'transparent', stroke: '#fff', lineStyle: 'dashed', strokeWidth: .15, opacity: .1 }</summary>
    abstract visualizePathStyle:   RoomVisualpolystyleOpts option
///<summary></summary>
and CreepownerResult =


    ///<summary>The name of the owner user.</summary>
    abstract username:  String

///<summary>Creeps are your units. Creeps can move, harvest energy, construct structures, attack another creeps, and perform other actions. Each creep consists of up to 50 body parts with the following possible types: Creeps are your units. Creeps can move, harvest energy, construct structures, attack another creeps, and perform other actions. Each creep consists of up to 50 body parts with the following possible types: </summary>
and Creep =
    inherit RoomObject

    ///<summary>Withdraw resources from a structure or tombstone. The target has to be at adjacent square to the creep. Multiple creeps can withdraw from the same object in the same tick. Your creeps can withdraw resources from hostile structures/tombstones as well, in case if there is no hostile rampart on top of it.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep, or there is a hostile rampart on top of the target.</description></item>
    ///<item><term>Busy</term><description>The creep is still being spawned.</description></item>
    ///<item><term>NotEnoughResources</term><description>The target does not have the given amount of resources.</description></item>
    ///<item><term>InvalidTarget</term><description>The target is not a valid object which can contain the specified resource.</description></item>
    ///<item><term>Full</term><description>The creep's carry is full.</description></item>
    ///<item><term>NotInRange</term><description>The target is too far away.</description></item>
    ///<item><term>InvalidArgs</term><description>The resourceType is not one of the RESOURCE_* constants, or the amount is incorrect.</description></item>
    ///</list></returns>
    ///<param name="target">The target object.</param>
    ///<param name="resourceType">One of the RESOURCE_* constants.</param>
    ///<param name="amount">The amount of resources to be transferred. If omitted, all the available amount is used.</param>
    abstract withdraw: target: U3<Structure, Tombstone, Ruin> * resourceType: ResourceType * ?amount: Int32 -> ScreepCode
    ///<summary>Upgrade your controller to the next level using carried energy. Upgrading controllers raises your Global Control Level in parallel. Requires WORK and CARRY body parts. The target has to be within 3 squares range of the creep. </summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep or the target controller.</description></item>
    ///<item><term>Busy</term><description>The creep is still being spawned.</description></item>
    ///<item><term>NotEnoughResources</term><description>The creep does not have any carried energy.</description></item>
    ///<item><term>InvalidTarget</term><description>The target is not a valid controller object, or the controller upgrading is blocked.</description></item>
    ///<item><term>NotInRange</term><description>The target is too far away.</description></item>
    ///<item><term>NoBodypart</term><description>There are no WORK body parts in this creep’s body.</description></item>
    ///</list></returns>

    ///<param name="target">The target controller object to be upgraded.</param>
    abstract upgradeController: target: StructureController -> ScreepCode 
    ///<summary>Transfer resource from the creep to another object. The target has to be at adjacent square to the creep.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The creep is still being spawned.</description></item>
    ///<item><term>NotEnoughResources</term><description>The creep does not have the given amount of resources.</description></item>
    ///<item><term>InvalidTarget</term><description>The target is not a valid object which can contain the specified resource.</description></item>
    ///<item><term>Full</term><description>The target cannot receive any more resources.</description></item>
    ///<item><term>NotInRange</term><description>The target is too far away.</description></item>
    ///<item><term>InvalidArgs</term><description>The resourceType is not one of the RESOURCE_* constants, or the amount is incorrect.</description></item>
    ///</list></returns>

    ///<param name="target">The target object.</param>
    ///<param name="resourceType">One of the RESOURCE_* constants.</param>
    ///<param name="amount">The amount of resources to be transferred. If omitted, all the available carried amount is used.</param>
    abstract transfer: target: U3<Creep, PowerCreep, Structure> * resourceType: ResourceType * ?amount: Int32 -> ScreepCode    
   
    ///<summary>Kill the creep immediately.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The creep is still being spawned.</description></item>
    ///</list></returns>

    abstract suicide: unit -> ScreepCode    ///<summary>Sign a controller with an arbitrary text visible to all players. This text will appear in the room UI, in the world map, and can be accessed via the API. You can sign unowned and hostile controllers. The target has to be at adjacent square to the creep. Pass an empty string to remove the sign.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>Busy</term><description>The creep is still being spawned.</description></item>
    ///<item><term>InvalidTarget</term><description>The target is not a valid controller object.</description></item>
    ///<item><term>NotInRange</term><description>The target is too far away.</description></item>
    ///</list></returns>

    ///<param name="target">The target controller object to be signed.</param>
    ///<param name="text">The sign text. The string is cut off after 100 characters.</param>
    abstract signController: target: StructureController * text: String -> ScreepCode
    ///<summary>Display a visual speech balloon above the creep with the specified message. The message will be available for one tick. You can read the last message using the saying property. Any valid Unicode characters are allowed, including emoji.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The creep is still being spawned.</description></item>
    ///</list></returns>

    ///<param name="message">The message to be displayed. Maximum length is 10 characters.</param>
    ///<param name="isPublic">Set to true to allow other players to see this message. Default is false.</param>
    abstract say: message: String * ?isPublic: Boolean -> ScreepCode    
    ///<summary>Temporarily block a neutral controller from claiming by other players and restore energy sources to their full capacity. Each tick, this command increases the counter of the period during which the controller is unavailable by 1 tick per each CLAIM body part. The maximum reservation period to maintain is 5,000 ticks. The target has to be at adjacent square to the creep.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The creep is still being spawned.</description></item>
    ///<item><term>InvalidTarget</term><description>The target is not a valid neutral controller object.</description></item>
    ///<item><term>NotInRange</term><description>The target is too far away.</description></item>
    ///<item><term>NoBodypart</term><description>There are no CLAIM body parts in this creep’s body.</description></item>
    ///</list></returns>
    ///<param name="target">The target controller object to be reserved.</param>
    
    abstract reserveController: target: StructureController -> ScreepCode
    ///<summary>Repair a damaged structure using carried energy. Requires the WORK and CARRY body parts. The target has to be within 3 squares range of the creep.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The creep is still being spawned.</description></item>
    ///<item><term>NotEnoughResources</term><description>The creep does not carry any energy.</description></item>
    ///<item><term>InvalidTarget</term><description>The target is not a valid structure object.</description></item>
    ///<item><term>NotInRange</term><description>The target is too far away.</description></item>
    ///<item><term>NoBodypart</term><description>There are no WORK body parts in this creep’s body.</description></item>
    ///</list></returns>
    ///<param name="target">The target structure to be repaired.</param>

    abstract repair: target: Structure -> ScreepCode    
    ///<summary>A ranged attack against all hostile creeps or structures within 3 squares range. Requires the RANGED_ATTACK body part. The attack power depends on the range to each target. Friendly units are not affected.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The creep is still being spawned.</description></item>
    ///<item><term>NoBodypart</term><description>There are no RANGED_ATTACK body parts in this creep’s body.</description></item>
    ///</list></returns>

    abstract rangedMassAttack: unit -> ScreepCode    ///<summary>Heal another creep at a distance. It will restore the target creep’s damaged body parts function and increase the hits counter. Requires the HEAL body part. The target has to be within 3 squares range of the creep.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The creep is still being spawned.</description></item>
    ///<item><term>InvalidTarget</term><description>The target is not a valid creep object.</description></item>
    ///<item><term>NotInRange</term><description>The target is too far away.</description></item>
    ///<item><term>NoBodypart</term><description>There are no HEAL body parts in this creep’s body.</description></item>
    ///</list></returns>

    ///<param name="target">The target creep object.</param>
    abstract rangedHeal: target: U2<Creep, PowerCreep> -> ScreepCode    
    ///<summary>A ranged attack against another creep or structure. Requires the RANGED_ATTACK body part. If the target is inside a rampart, the rampart is attacked instead. The target has to be within 3 squares range of the creep.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The creep is still being spawned.</description></item>
    ///<item><term>InvalidTarget</term><description>The target is not a valid attackable object.</description></item>
    ///<item><term>NotInRange</term><description>The target is too far away.</description></item>
    ///<item><term>NoBodypart</term><description>There are no RANGED_ATTACK body parts in this creep’s body.</description></item>
    ///</list></returns>

    ///<param name="target">The target object to be attacked.</param>
    abstract rangedAttack: target: U3<Creep, PowerCreep, Structure> -> ScreepCode    
    ///<summary>Help another creep to follow this creep. The fatigue generated for the target's move will be added to the creep instead of the target. Requires the MOVE body part. The target has to be at adjacent square to the creep. The creep must move elsewhere, and the target must move towards the creep.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The creep is still being spawned.</description></item>
    ///<item><term>InvalidTarget</term><description>The target provided is invalid.</description></item>
    ///<item><term>NotInRange</term><description>The target is too far away.</description></item>
    ///</list></returns>

    ///<param name="target">The target creep.</param>
    abstract pull: target: Creep -> ScreepCode    
    ///<summary>Pick up an item (a dropped piece of energy). Requires the CARRY body part. The target has to be at adjacent square to the creep or at the same square.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The creep is still being spawned.</description></item>
    ///<item><term>InvalidTarget</term><description>The target is not a valid object to pick up.</description></item>
    ///<item><term>Full</term><description>The creep cannot receive any more resource.</description></item>
    ///<item><term>NotInRange</term><description>The target is too far away.</description></item>
    ///</list></returns>

    ///<param name="target">The target object to be picked up.</param>
    abstract pickup: target: Resource -> ScreepCode

    ///<summary>Toggle auto notification when the creep is under attack. The notification will be sent to your account email. Turned on by default.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The creep is still being spawned.</description></item>
    ///<item><term>InvalidArgs</term><description>enable argument is not a boolean value.</description></item>
    ///</list></returns>

    ///<param name="enabled">Whether to enable notification or disable.</param>
    abstract notifyWhenAttacked: enabled: Boolean -> ScreepCode    
    ///<summary>Find the optimal path to the target within the same room and move to it. A shorthand to consequent calls of pos.findPathTo() and move() methods. If the target is in another room, then the corresponding exit will be used as a target. Requires the MOVE body part.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>NoPath</term><description>No path to the target could be found.</description></item>
    ///<item><term>Busy</term><description>The creep is still being spawned.</description></item>
    ///<item><term>NotFound</term><description>The creep has no memorized path to reuse.</description></item>
    ///<item><term>InvalidTarget</term><description>The target provided is invalid.</description></item>
    ///<item><term>Tired</term><description>The fatigue indicator of the creep is non-zero.</description></item>
    ///<item><term>NoBodypart</term><description>There are no MOVE body parts in this creep’s body.</description></item>
    ///</list></returns>

    ///<param name="x">X position of the target in the same room.</param>
    ///<param name="y">Y position of the target in the same room.</param>
    ///<param name="opts">An object containing additional options:</param>
    abstract moveTo: x: Int32 * y: Int32 * ?opts: CreepmoveToOpts -> ScreepCode
 
    ///<summary>Find the optimal path to the target within the same room and move to it. A shorthand to consequent calls of pos.findPathTo() and move() methods. If the target is in another room, then the corresponding exit will be used as a target. Requires the MOVE body part.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>NoPath</term><description>No path to the target could be found.</description></item>
    ///<item><term>Busy</term><description>The creep is still being spawned.</description></item>
    ///<item><term>NotFound</term><description>The creep has no memorized path to reuse.</description></item>
    ///<item><term>InvalidTarget</term><description>The target provided is invalid.</description></item>
    ///<item><term>Tired</term><description>The fatigue indicator of the creep is non-zero.</description></item>
    ///<item><term>NoBodypart</term><description>There are no MOVE body parts in this creep’s body.</description></item>
    ///</list></returns>

    ///<param name="target">Can be a RoomPosition object or any object containing RoomPosition. The position doesn't have to be in the same room with the creep.</param>
    ///<param name="opts">An object containing additional options:</param>
    abstract moveTo: target: U2<RoomPosition, RoomObject> * ?opts: CreepmoveToOpts -> ScreepCode    
    ///<summary>Move the creep using the specified predefined path. Requires the MOVE body part.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The creep is still being spawned.</description></item>
    ///<item><term>NotFound</term><description>The specified path doesn't match the creep's location.</description></item>
    ///<item><term>InvalidArgs</term><description>path is not a valid path array.</description></item>
    ///<item><term>Tired</term><description>The fatigue indicator of the creep is non-zero.</description></item>
    ///<item><term>NoBodypart</term><description>There are no MOVE body parts in this creep’s body.</description></item>
    ///</list></returns>

    ///<param name="path">A path value as returned from Room.findPath, RoomPosition.findPathTo, or PathFinder.search methods. Both array form and serialized string form are accepted.</param>
    abstract moveByPath: path: U3<PathSegment list, RoomPosition array , String> -> ScreepCode    
    ///<summary>Move the creep one square in the specified direction. Requires the MOVE body part, or another creep nearby pulling the creep. In case if you call move on a creep nearby, the ERR_TIRED and the ERR_NO_BODYPART checks will be bypassed; otherwise, the ERR_NOT_IN_RANGE check will be bypassed. </summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The creep is still being spawned.</description></item>
    ///<item><term>NotInRange</term><description>The target creep is too far away</description></item>
    ///<item><term>InvalidArgs</term><description>The provided direction is incorrect.</description></item>
    ///<item><term>Tired</term><description>The fatigue indicator of the creep is non-zero.</description></item>
    ///<item><term>NoBodypart</term><description>There are no MOVE body parts in this creep’s body.</description></item>
    ///</list></returns>

    ///<param name="direction">A creep nearby, or one of the following constants:</param>
    abstract move: direction: U2<Creep, Direction> -> ScreepCode    
    ///<summary>Heal self or another creep. It will restore the target creep’s damaged body parts function and increase the hits counter. Requires the HEAL body part. The target has to be at adjacent square to the creep.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The creep is still being spawned.</description></item>
    ///<item><term>InvalidTarget</term><description>The target is not a valid creep object.</description></item>
    ///<item><term>NotInRange</term><description>The target is too far away.</description></item>
    ///<item><term>NoBodypart</term><description>There are no HEAL body parts in this creep’s body.</description></item>
    ///</list></returns>

    ///<param name="target">The target creep object.</param>
    abstract heal: target: U2<Creep, PowerCreep> -> ScreepCode    
    ///<summary>Harvest energy from the source or resources from minerals and deposits. Requires the WORK body part. If the creep has an empty CARRY body part, the harvested resource is put into it; otherwise it is dropped on the ground. The target has to be at an adjacent square to the creep.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep, or the room controller is owned or reserved by another player.</description></item>
    ///<item><term>Busy</term><description>The creep is still being spawned.</description></item>
    ///<item><term>NotFound</term><description>Extractor not found. You must build an extractor structure to harvest minerals. Learn more</description></item>
    ///<item><term>NotEnoughResources</term><description>The target does not contain any harvestable energy or mineral.</description></item>
    ///<item><term>InvalidTarget</term><description>The target is not a valid source or mineral object.</description></item>
    ///<item><term>NotInRange</term><description>The target is too far away.</description></item>
    ///<item><term>Tired</term><description>The extractor or the deposit is still cooling down.</description></item>
    ///<item><term>NoBodypart</term><description>There are no WORK body parts in this creep’s body.</description></item>
    ///</list></returns>

    ///<param name="target">The object to be harvested.</param>
    abstract harvest: target: U3<Source, Mineral, Deposit> -> ScreepCode    
    ///<summary>Get the quantity of live body parts of the given type. Fully damaged parts do not count.</summary>
    ///<param name="sType">A body part type, one of the following body part constants:</param>
    abstract getActiveBodyparts: sType: BodyPart -> int 
    ///<summary>Add one more available safe mode activation to a room controller. The creep has to be at adjacent square to the target room controller and have 1000 ghodium resource.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The creep is still being spawned.</description></item>
    ///<item><term>NotEnoughResources</term><description>The creep does not have enough ghodium.</description></item>
    ///<item><term>InvalidTarget</term><description>The target is not a valid controller object.</description></item>
    ///<item><term>NotInRange</term><description>The target is too far away.</description></item>
    ///</list></returns>

    ///<param name="target">The target room controller.</param>
    abstract generateSafeMode: target: StructureController -> ScreepCode    
    ///<summary>Drop this resource on the ground.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The creep is still being spawned.</description></item>
    ///<item><term>NotEnoughResources</term><description>The creep does not have the given amount of resources.</description></item>
    ///<item><term>InvalidArgs</term><description>The resourceType is not a valid RESOURCE_* constants.</description></item>
    ///</list></returns>

    ///<param name="resourceType">One of the RESOURCE_* constants.</param>
    ///<param name="amount">The amount of resource units to be dropped. If omitted, all the available carried amount is used.</param>
    abstract drop: resourceType: ResourceType * ?amount: Int32 -> ScreepCode    
    ///<summary>Dismantles any structure that can be constructed (even hostile) returning 50% of the energy spent on its repair. Requires the WORK body part. If the creep has an empty CARRY body part, the energy is put into it; otherwise it is dropped on the ground. The target has to be at adjacent square to the creep.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The creep is still being spawned.</description></item>
    ///<item><term>InvalidTarget</term><description>The target is not a valid structure object.</description></item>
    ///<item><term>NotInRange</term><description>The target is too far away.</description></item>
    ///<item><term>NoBodypart</term><description>There are no WORK body parts in this creep’s body.</description></item>
    ///</list></returns>
    ///<param name="target">The target structure.</param>
    abstract dismantle: target: Structure -> ScreepCode    
    ///<summary>Claims a neutral controller under your control. Requires the CLAIM body part. The target has to be at adjacent square to the creep. You need to have the corresponding Global Control Level in order to claim a new room. If you don't have enough GCL, consider reserving this room instead. Learn more</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The creep is still being spawned.</description></item>
    ///<item><term>InvalidTarget</term><description>The target is not a valid neutral controller object.</description></item>
    ///<item><term>Full</term><description>You cannot claim more than 3 rooms in the Novice Area.</description></item>
    ///<item><term>NotInRange</term><description>The target is too far away.</description></item>
    ///<item><term>NoBodypart</term><description>There are no CLAIM body parts in this creep’s body.</description></item>
    ///<item><term>GclNotEnough</term><description>Your Global Control Level is not enough.</description></item>
    ///</list></returns>

    ///<param name="target">The target controller object.</param>
    abstract claimController: target: StructureController -> ScreepCode    
    ///<summary>Cancel the order given during the current game tick.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term> </term><description>The operation has been cancelled successfully.</description></item>
    ///<item><term>NotFound</term><description>The order with the specified name is not found.</description></item>
    ///</list></returns>

    ///<param name="methodName">The name of a creep's method to be cancelled.</param>
    abstract cancelOrder: methodName: String -> ScreepCode    
    ///<summary>Build a structure at the target construction site using carried energy. Requires WORK and CARRY body parts. The target has to be within 3 squares range of the creep.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The creep is still being spawned.</description></item>
    ///<item><term>NotEnoughResources</term><description>The creep does not have any carried energy.</description></item>
    ///<item><term>InvalidTarget</term><description>The target is not a valid construction site object or the structure cannot be built here (probably because of a creep at the same square).</description></item>
    ///<item><term>NotInRange</term><description>The target is too far away.</description></item>
    ///<item><term>NoBodypart</term><description>There are no WORK body parts in this creep’s body.</description></item>
    ///</list></returns>

    ///<param name="target">The target construction site to be built.</param>
    abstract build: target: ConstructionSite -> ScreepCode    
    ///<summary>Decreases the controller's downgrade timer by 300 ticks per every CLAIM body part, or reservation timer by 1 tick per every CLAIM body part. If the controller under attack is owned, it cannot be upgraded or attacked again for the next 1,000 ticks. The target has to be at adjacent square to the creep.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The creep is still being spawned.</description></item>
    ///<item><term>InvalidTarget</term><description>The target is not a valid owned or reserved controller object.</description></item>
    ///<item><term>NotInRange</term><description>The target is too far away.</description></item>
    ///<item><term>Tired</term><description>You have to wait until the next attack is possible.</description></item>
    ///<item><term>NoBodypart</term><description>There are not enough CLAIM body parts in this creep’s body.</description></item>
    ///</list></returns>

    ///<param name="target">The target controller object.</param>
    abstract attackController: target: StructureController -> ScreepCode    
    ///<summary>Attack another creep, power creep, or structure in a short-ranged attack. Requires the ATTACK body part. If the target is inside a rampart, then the rampart is attacked instead. The target has to be at adjacent square to the creep. If the target is a creep with ATTACK body parts and is not inside a rampart, it will automatically hit back at the attacker.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this creep.</description></item>
    ///<item><term>Busy</term><description>The creep is still being spawned.</description></item>
    ///<item><term>InvalidTarget</term><description>The target is not a valid attackable object.</description></item>
    ///<item><term>NotInRange</term><description>The target is too far away.</description></item>
    ///<item><term>NoBodypart</term><description>There are no ATTACK body parts in this creep’s body.</description></item>
    ///</list></returns>

    ///<param name="target">The target object to be attacked.</param>
    abstract attack: target: U3<Creep, PowerCreep, Structure> -> ScreepCode
    ///<summary>The remaining amount of game ticks after which the creep will die.</summary>
    abstract ticksToLive:  Int32
    ///<summary>A Store object that contains cargo of this creep.</summary>
    abstract store:  Store
    ///<summary>Whether this creep is still being spawned.</summary>
    abstract spawning:  Boolean
    ///<summary>The text message that the creep was saying at the last tick.</summary>
    abstract saying:  String
    ///<summary>An object with the creep’s owner info containing the following properties:</summary>
    abstract owner:  CreepownerResult
    ///<summary>Creep’s name. You can choose the name while creating a new creep, and it cannot be changed later. This name is a hash key to access the creep via the Game.creeps object.</summary>
    abstract name:  String
    ///<summary>Whether it is your creep or foe.</summary>
    abstract my:  Boolean
    ///<summary>A shorthand to Memory.creeps[creep.name]. You can use it for quick access the creep’s specific memory data object. Learn more about memory</summary>
    abstract memory:   obj with get, set
    ///<summary>A unique object identificator. You can use Game.getObjectById method to retrieve an object instance by its id.</summary>
    abstract id:  String
    ///<summary>The maximum amount of hit points of the creep.</summary>
    abstract hitsMax:  Int32
    ///<summary>The current amount of hit points of the creep.</summary>
    abstract hits:  Int32
    ///<summary>The movement fatigue indicator. If it is greater than zero, the creep cannot move.</summary>
    abstract fatigue:  Int32
    ///<summary>An array describing the creep’s body. Each element contains the following properties:</summary>
    abstract body:  BodyPart array 
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list
///<summary></summary>
and ConstructionSiteownerResult =

    ///<summary>The name of the owner user.</summary>
    abstract username:  String

///<summary>A site of a structure which is currently under construction. A construction site can be created using the 'Construct' button at the left of the game field or the Room.createConstructionSite method.A site of a structure which is currently under construction. A construction site can be created using the 'Construct' button at the left of the game field or the Room.createConstructionSiteRoom.createConstructionSiteRoom.createConstructionSite method.To build a structure on the construction site, give a worker creep some amount of energy and perform Creep.build action.To build a structure on the construction site, give a worker creep some amount of energy and perform Creep.buildCreep.buildCreep.build action.You can remove enemy construction sites by moving a creep on it.You can remove enemy construction sites by moving a creep on it.</summary>
and ConstructionSite =
    inherit RoomObject

    ///<summary>Remove the construction site.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of this construction site, and it's not in your room.</description></item>
    ///</list></returns>

    abstract remove: unit -> ScreepCode
    ///<summary>One of the STRUCTURE_* constants.</summary>
    abstract structureType:  StructureType
    ///<summary>The total construction progress needed for the structure to be built.</summary>
    abstract progressTotal:  Int32
    ///<summary>The current construction progress.</summary>
    abstract progress:  Int32
    ///<summary>An object with the structure’s owner info containing the following properties:</summary>
    abstract owner:  ConstructionSiteownerResult
    ///<summary>Whether this is your own construction site.</summary>
    abstract my:  Boolean
    ///<summary>A unique object identificator. You can use Game.getObjectById method to retrieve an object instance by its id.</summary>
    abstract id:  String
    ///<summary>Applied effects, an array of objects with the following properties:</summary>
    abstract effects: Effect list

///<summary></summary>
and RawMemoryRawMemoryForeignSegmentResult =

    ///<summary>Another player's name.</summary>
    abstract username:  String

    ///<summary>The ID of the requested memory segment.</summary>
    abstract id:  Int32

    ///<summary>The segment contents.</summary>
    abstract data:  String

///<summary>RawMemory object allows to implement your own memory stringifier instead of built-in serializer based on JSON.stringify. It also allows to request up to 10 MB of additional memory using asynchronous memory segments feature.RawMemory object allows to implement your own memory stringifier instead of built-in serializer based on JSON.stringifyJSON.stringify. It also allows to request up to 10 MB of additional memory using asynchronous memory segments feature.You can also access memory segments of other players using methods below.You can also access memory segments of other players using methods below.</summary>
and RawMemory =

    ///<summary>Set specified segments as public. Other users will be able to request access to them using setActiveForeignSegment. </summary>
    ///<param name="ids">An array of segment IDs. Each ID should be a number from 0 to 99. Subsequent calls of setPublicSegments override previous ones.</param>
    abstract setPublicSegments: ids:  int array -> unit 
    ///<summary>Set the specified segment as your default public segment. It will be returned if no id parameter is passed to setActiveForeignSegment by another user. 
    ///<para> F# - to pass null value: write !^null </para></summary>
    ///<param name="id">The ID of the memory segment from 0 to 99. Pass null to remove your default public segment.</param>
    abstract setDefaultPublicSegment: id: U2<int32, obj> -> unit    
    ///<summary>Request a memory segment of another user. The segment should be marked by its owner as public using setPublicSegments. The segment data will become available on the next tick in foreignSegment object. You can only have access to one foreign segment at the same time. 
    ///</summary>
    ///<param name="username">The name of another user. Pass null to clear the foreign segment.</param>
    ///<param name="id">The ID of the requested segment from 0 to 99. If undefined, the user's default public segment is requested as set by setDefaultPublicSegment.</param>
    abstract setActiveForeignSegment: username: string * ?id: Int32 -> unit    
    ///<summary>Request memory segments using the list of their IDs. Memory segments will become available on the next tick in segments object.</summary>
    ///<param name="ids">An array of segment IDs. Each ID should be a number from 0 to 99. Maximum 10 segments can be active at the same time. Subsequent calls of setActiveSegments override previous ones.</param>
    abstract setActiveSegments: ids:  int array -> unit 
    ///<summary>Set new Memory value.</summary>
    ///<param name="value">New memory value as a string.</param>
    abstract set: value: String -> unit  
    ///<summary>Get a raw string representation of the Memory object.</summary>
    abstract get: unit -> string
    ///<summary>An object with a memory segment of another player available on this tick. Use setActiveForeignSegment to fetch segments on the next tick. The object consists of the following properties:</summary>
    abstract foreignSegment:  RawMemoryRawMemoryForeignSegmentResult
    ///<summary>An object with asynchronous memory segments available on this tick. Each object key is the segment ID with data in string values. Use setActiveSegments to fetch segments on the next tick. Segments data is saved automatically in the end of the tick. The maximum size per segment is 100 KB.</summary>
    abstract segments: string array 
///<summary></summary>
and PathFinderPathFinderSearchOpts =

     ///<summary>The target.</summary>
    abstract pos:  RoomPosition option

    ///<summary>Range to pos before goal is considered reached. The default is 0.</summary>
    abstract range:  Int32 option

    ///<summary>Request from the pathfinder to generate a CostMatrix for a certain room. The callback accepts one argument, roomName. This callback will only be called once per room per search. If you are running multiple pathfinding operations in a single room and in a single tick you may consider caching your CostMatrix to speed up your code. Please read the CostMatrix documentation below for more information on CostMatrix. If you return false from the callback the requested room will not be searched, and it won't count against maxRooms</summary>
    abstract roomCallback:   (string -> U2<PathFinderCostMatrix, bool>) option

    ///<summary>Cost for walking on plain positions. The default is 1.</summary>
    abstract plainCost:  Int32 option

    ///<summary>Cost for walking on swamp positions. The default is 5.</summary>
    abstract swampCost:  Int32 option

    ///<summary>Instead of searching for a path to the goals this will search for a path away from the goals. The cheapest path that is out of range of every goal will be returned. The default is false.</summary>
    abstract flee:  Boolean option

    ///<summary>The maximum allowed pathfinding operations. You can limit CPU time used for the search based on ratio 1 op ~ 0.001 CPU. The default value is 2000.</summary>
    abstract maxOps:  Int32 option

    ///<summary>The maximum allowed rooms to search. The default is 16, maximum is 64.</summary>
    abstract maxRooms:  Int32 option

    ///<summary>The maximum allowed cost of the path returned. If at any point the pathfinder detects that it is impossible to find a path with a cost less than or equal to maxCost it will immediately halt the search. The default is Infinity.</summary>
    abstract maxCost:  Int32 option

    ///<summary>Weight to apply to the heuristic in the A* formula F = G + weight * H. Use this option only if you understand the underlying A* algorithm mechanics! The default value is 1.2.</summary>
    abstract heuristicWeight:  Int32 option

///<summary> Contains powerful methods for pathfinding in the game world. This module is written in fast native C++ code and supports custom navigation costs and paths which span multiple rooms.  Contains powerful methods for pathfinding in the game world. This module is written in fast native C++ code and supports custom navigation costs and paths which span multiple rooms. </summary>
and PathFinder =

    ///<summary>Find an optimal path between origin and goal.</summary>
    ///<param name="origin">The start position.</param>
    ///<param name="goal">A goal or an array of goals. If more than one goal is supplied then the cheapest path found out of all the goals will be returned. A goal is either a RoomPosition or an object as defined below.Important: Please note that if your goal is not walkable (for instance, a source) then you should set range to at least 1 or else you will waste many CPU cycles searching for a target that you can't walk on.</param>
    ///<param name="opts">An object containing additional pathfinding flags.roomCallbackfunction Request from the pathfinder to generate a CostMatrix for a certain room. The callback accepts one argument, roomName. This callback will only be called once per room per search. If you are running multiple pathfinding operations in a single room and in a single tick you may consider caching your CostMatrix to speed up your code. Please read the CostMatrix documentation below for more information on CostMatrix. If you return false from the callback the requested room will not be searched, and it won't count against maxRoomsplainCostnumberCost for walking on plain positions. The default is 1.swampCostnumberCost for walking on swamp positions. The default is 5.fleeboolean Instead of searching for a path to the goals this will search for a path away from the goals. The cheapest path that is out of range of every goal will be returned. The default is false. maxOpsnumberThe maximum allowed pathfinding operations. You can limit CPU time used for the search based on ratio 1 op ~ 0.001 CPU. The default value is 2000.maxRoomsnumberThe maximum allowed rooms to search. The default is 16, maximum is 64.maxCostnumber The maximum allowed cost of the path returned. If at any point the pathfinder detects that it is impossible to find a path with a cost less than or equal to maxCost it will immediately halt the search. The default is Infinity. heuristicWeightnumber Weight to apply to the heuristic in the A* formula F = G + weight * H. Use this option only if you understand the underlying A* algorithm mechanics! The default value is 1.2.</param>
    abstract PathFinderSearch: origin: RoomPosition * goal:  {|Pos: RoomPosition; Range: int32|} * ?opts: PathFinderPathFinderSearchOpts -> PathFinderSearchResult 
and PathFinderSearchResult =
    ///<summary>An array of RoomPosition objects.</summary>
    abstract path: RoomPosition list
    ///<summary>Total number of operations performed before this path was calculated.</summary>
    abstract ops: int
    ///<summary>The total cost of the path as derived from plainCost, swampCost and any given CostMatrix instances.</summary>
    abstract cost: int
    ///<summary>If the pathfinder fails to find a complete path, this will be true. Note that path will still be populated with a partial path which represents the closest path it could find given the search parameters.</summary>
    abstract incomplete: bool 
///<summary>F#: Feel free to extend this class as you want.</summary>
and Memory = class end
///<summary></summary>
and GameMarketGameMarketCreateOrderparamsOpts =
    
    ///<summary>The order type, either ORDER_SELL or ORDER_BUY.</summary>
    abstract sType:  Order option

    ///<summary>Either one of the RESOURCE_* constants or one of account-bound resources (See INTERSHARD_RESOURCES constant). If your Terminal doesn't have the specified resource, the order will be temporary inactive.</summary>
    abstract resourceType:  ResourceType option

    ///<summary>The price for one resource unit in credits. Can be a decimal number.</summary>
    abstract price:  double option

    ///<summary>The amount of resources to be traded in total.</summary>
    abstract totalAmount:  Int32 option

    ///<summary>The room where your order will be created. You must have your own Terminal structure in this room, otherwise the created order will be temporary inactive. This argument is not used when resourceType is one of account-bound resources (See INTERSHARD_RESOURCES constant).</summary>
    abstract roomName:  String option

and GameMarketOrder = 
    ///<summary>The unique order ID.</summary>
    abstract id: int
    ///<summary>The order creation time in game ticks. This property is absent for orders of the inter-shard market.</summary>
    abstract created: int64 option
    ///<summary>The order creation time in milliseconds since UNIX epoch time. This property is absent for old orders.</summary>
    abstract createdTimeStamp: int64 option
    ///<summary>Either ORDER_SELL or ORDER_BUY.</summary>
    abstract Type: Order
    ///<summary>Either one of the RESOURCE_* constants or one of account-bound resources (See INTERSHARD_RESOURCES constant).</summary>
    abstract resourceType: ResourceType
    ///<summary>The room where this order is placed.</summary>
    abstract roomName: string option
    ///<summary>Currently available amount to trade.</summary>
    abstract amount: int
    ///<summary>How many resources are left to trade via this order.</summary>
    abstract remainingAmount: int
    ///<summary>The current price per unit.</summary>
    abstract price: double
and Transaction = 
    {
        transactionId : string
        time : int64
        sender : Owner
        recipient : Owner
        resourceType : ResourceType
        amount : int
        from : string
        To : string
        description : string
        order: TransactionOrder option
    }
and TransactionOrder = { id: string; Type: Order; price: double; }
///<summary>A global object representing the in-game market. You can use this object to track resource transactions to/from your terminals, and your buy/sell orders.A global object representing the in-game market. You can use this object to track resource transactions to/from your terminals, and your buy/sell orders.Learn more about the market system from this article.Learn more about the market system from this articlethis article.</summary>
and Market =
    ///<summary>Retrieve info for specific market order.</summary>
    ///<param name="id">The order ID.</param>
    abstract getOrderById: id: String -> GameMarketOrder    
    ///<summary>Get daily price history of the specified resource on the market for the last 14 days. </summary>
    ///<param name="resourceType">One of the RESOURCE_* constants. If undefined, returns history data for all resources.</param>
    abstract getHistory: ?resourceType: ResourceType ->
        {|resourceType: ResourceType; date: DateTime; transactions: int; volume: int; avgPrice: double; stddevPrice: double|} list
    ///<summary>Get other players' orders currently active on the market. This method supports internal indexing by resourceType.</summary>
    ///<param name="filter">An object or function that will filter the resulting list using the lodash.filter method.</param>
    abstract getAllOrders: ?filter:  (GameMarketOrder -> bool) -> GameMarketOrder array 
    ///<summary>Add more capacity to an existing order. It will affect remainingAmount and totalAmount properties. You will be charged price*addAmount*0.05 credits.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotEnoughResources</term><description>You don't have enough credits to pay a fee.</description></item>
    ///<item><term>InvalidArgs</term><description>The arguments provided are invalid.</description></item>
    ///</list></returns>
    ///<param name="orderId">The order ID as provided in Game.market.orders.</param>
    ///<param name="addAmount">How much capacity to add. Cannot be a negative value.</param>
    abstract extendOrder: orderId: String * addAmount: Int32 -> ScreepCode    
    ///<summary>Execute a trade deal from your Terminal in yourRoomName to another player's Terminal using the specified buy/sell order. Your Terminal will be charged energy units of transfer cost regardless of the order resource type. You can use Game.market.calcTransactionCost method to estimate it. When multiple players try to execute the same deal, the one with the shortest distance takes precedence. You cannot execute more than 10 deals during one tick.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You don't have a terminal in the target room.</description></item>
    ///<item><term>NotEnoughResources</term><description>You don't have enough credits or resource units.</description></item>
    ///<item><term>Full</term><description>You cannot execute more than 10 deals during one tick.</description></item>
    ///<item><term>InvalidArgs</term><description>The arguments provided are invalid.</description></item>
    ///<item><term>Tired</term><description>The target terminal is still cooling down.</description></item>
    ///</list></returns>
    ///<param name="orderId">The order ID as provided in Game.market.getAllOrders.</param>
    ///<param name="amount">The amount of resources to transfer.</param>
    ///<param name="yourRoomName">The name of your room which has to contain an active Terminal with enough amount of energy. This argument is not used when the order resource type is one of account-bound resources (See INTERSHARD_RESOURCES constant).</param>
    abstract deal: orderId: String * amount: Int32 * ?yourRoomName: String -> ScreepCode    
    ///<summary>Create a market order in your terminal. You will be charged price*amount*0.05 credits when the order is placed. The maximum orders count is 300 per player. You can create an order at any time with any amount, it will be automatically activated and deactivated depending on the resource/credits availability.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of the room's terminal or there is no terminal.</description></item>
    ///<item><term>NotEnoughResources</term><description>You don't have enough credits to pay a fee.</description></item>
    ///<item><term>Full</term><description>You cannot create more than 50 orders.</description></item>
    ///<item><term>InvalidArgs</term><description>The arguments provided are invalid.</description></item>
    ///</list></returns>

    ///<param name="sParams">An object with the following params:typestring The order type, either ORDER_SELL or ORDER_BUY. resourceTypestring Either one of the RESOURCE_* constants or one of account-bound resources (See INTERSHARD_RESOURCES constant). If your Terminal doesn't have the specified resource, the order will be temporary inactive. pricenumberThe price for one resource unit in credits. Can be a decimal number.totalAmountnumberThe amount of resources to be traded in total.roomName (optional)string The room where your order will be created. You must have your own Terminal structure in this room, otherwise the created order will be temporary inactive. This argument is not used when resourceType is one of account-bound resources (See INTERSHARD_RESOURCES constant).</param>
    abstract createOrder: ?sParams: GameMarketGameMarketCreateOrderparamsOpts -> ScreepCode    
    ///<summary>Change the price of an existing order. If newPrice is greater than old price, you will be charged (newPrice-oldPrice)*remainingAmount*0.05 credits.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotOwner</term><description>You are not the owner of the room's terminal or there is no terminal.</description></item>
    ///<item><term>NotEnoughResources</term><description>You don't have enough credits to pay a fee.</description></item>
    ///<item><term>InvalidArgs</term><description>The arguments provided are invalid.</description></item>
    ///</list></returns>
    ///<param name="orderId">The order ID as provided in Game.market.orders.</param>
    ///<param name="newPrice">The new order price.</param>
    abstract changeOrderPrice: orderId: String * newPrice: double -> ScreepCode    
    ///<summary>Cancel a previously created order. The 5% fee is not returned.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>InvalidArgs</term><description>The order ID is not valid.</description></item>
    ///</list></returns>

    ///<param name="orderId">The order ID as provided in Game.market.orders.</param>
    abstract cancelOrder: orderId: String -> ScreepCode
    ///<summary>Estimate the energy transaction cost of StructureTerminal.send and Game.market.deal methods. The formula:</summary>
    ///<param name="amount">Amount of resources to be sent.</param>
    ///<param name="roomName1">The name of the first room.</param>
    ///<param name="roomName2">The name of the second room.</param>
    ///<returns>The amount of energy required to perform the transaction.</returns>
    abstract calcTransactionCost: amount: Int32 * roomName1: String * roomName2: String -> int
    
    ///<summary>An object with your active and inactive buy/sell orders on the market. See getAllOrders for properties explanation.</summary>
    [<Emit("new Map(Object.entries(Game.market.orders))")>]
    abstract orders:   Dictionary<string, GameMarketOrder>
    ///<summary>An array of the last 100 outgoing transactions from your terminals with the following format:</summary>
    abstract outgoingTransactions: Transaction array  
    ///<summary>An array of the last 100 incoming transactions to your terminals with the following format:</summary>
    abstract incomingTransactions: Transaction array  
    ///<summary>Your current credits balance.</summary>
    abstract credits:  double

and [<StringEnum>] VisualTextAlign =
    | Center
    | Left
    | Right
and [<StringEnum>] VisualFontVariant =
    | Normal
    | [<CompiledName("small-caps")>] SmallCaps
and [<StringEnum>] VisualFontStyle =
    | Normal
    | Italic
    | Oblique
and GameMapVisualtextstyleOpts =


    ///<summary>Font color in the following format: #ffffff (hex triplet). Default is #ffffff.</summary>
    abstract color:  String option

    ///<summary>The font family, default is sans-serif</summary>
    abstract fontFamily:  String option

    ///<summary>The font size in game coordinates, default is 10</summary>
    abstract fontSize:  Int32 option

    ///<summary>The font style ('normal', 'italic' or 'oblique')</summary>
    abstract fontStyle:  VisualFontStyle option

    ///<summary>The font variant ('normal' or 'small-caps')</summary>
    abstract fontVariant:  VisualFontVariant option

    ///<summary>Stroke color in the following format: #ffffff (hex triplet). Default is undefined (no stroke).</summary>
    abstract stroke:  String option

    ///<summary>Stroke width, default is 0.15.</summary>
    abstract strokeWidth:  double option

    ///<summary>Background color in the following format: #ffffff (hex triplet). Default is undefined (no background). When background is enabled, text vertical align is set to middle (default is baseline).</summary>
    abstract backgroundColor:  String option

    ///<summary>Background rectangle padding, default is 2.</summary>
    abstract backgroundPadding:  Int32 option

    ///<summary>Text align, either center, left, or right. Default is center.</summary>
    abstract align:  VisualTextAlign option

    ///<summary>Opacity value, default is 0.5.</summary>
    abstract opacity:  double option
///<summary></summary>
and GameMapVisualpolystyleOpts =


    ///<summary>Fill color in the following format: #ffffff (hex triplet). Default is undefined (no fill).</summary>
    abstract fill:  String option

    ///<summary>Opacity value, default is 0.5.</summary>
    abstract opacity:  double option

    ///<summary>Stroke color in the following format: #ffffff (hex triplet). Default is #ffffff.</summary>
    abstract stroke:  String option

    ///<summary>Stroke line width, default is 0.5.</summary>
    abstract strokeWidth:  double option

    ///<summary>Either undefined (solid line), dashed, or dotted. Default is undefined.</summary>
    abstract lineStyle:  LineStyle option
///<summary></summary>
and GameMapVisualrectstyleOpts =


    ///<summary>Fill color in the following format: #ffffff (hex triplet). Default is #ffffff.</summary>
    abstract fill:  String option

    ///<summary>Opacity value, default is 0.5.</summary>
    abstract opacity:  double option

    ///<summary>Stroke color in the following format: #ffffff (hex triplet). Default is undefined (no stroke).</summary>
    abstract stroke:  String option

    ///<summary>Stroke line width, default is 0.5.</summary>
    abstract strokeWidth:  double option

    ///<summary>Either undefined (solid line), dashed, or dotted. Default is undefined.</summary>
    abstract lineStyle:  LineStyle option
///<summary></summary>
and GameMapVisualcirclestyleOpts =


    ///<summary>Circle radius, default is 10.</summary>
    abstract radius:  Int32 option

    ///<summary>Fill color in the following format: #ffffff (hex triplet). Default is #ffffff.</summary>
    abstract fill:  String option

    ///<summary>Opacity value, default is 0.5.</summary>
    abstract opacity:  double option

    ///<summary>Stroke color in the following format: #ffffff (hex triplet). Default is undefined (no stroke).</summary>
    abstract stroke:  String option

    ///<summary>Stroke line width, default is 0.5.</summary>
    abstract strokeWidth:  double option

    ///<summary>Either undefined (solid line), dashed, or dotted. Default is undefined.</summary>
    abstract lineStyle:  LineStyle option
///<summary></summary>
and GameMapVisuallinestyleOpts =


    ///<summary>Line width, default is 0.1.</summary>
    abstract width:  double option

    ///<summary>Line color in the following format: #ffffff (hex triplet). Default is #ffffff.</summary>
    abstract color:  String option

    ///<summary>Opacity value, default is 0.5.</summary>
    abstract opacity:  double option

    ///<summary>Either undefined (solid line), dashed, or dotted. Default is undefined.</summary>
    abstract lineStyle:  LineStyle option


///<summary>Map visuals provide a way to show various visual debug info on the game map. You can use the Game.map.visual object to draw simple shapes that are visible only to you. Map visuals provide a way to show various visual debug info on the game map. You can use the Game.map.visualGame.map.visual object to draw simple shapes that are visible only to you. Map visuals are not stored in the database, their only purpose is to display something in your browser. All drawings will persist for one tick and will disappear if not updated. All Game.map.visual calls have no added CPU cost (their cost is natural and mostly related to simple JSON.serialize calls). However, there is a usage limit: you cannot post more than 1000 KB of serialized data. Map visuals are not stored in the database, their only purpose is to display something in your browser. All drawings will persist for one tick and will disappear if not updated. All Game.map.visualGame.map.visual calls have no added CPU cost (their cost is natural and mostly related to simple JSON.serializeJSON.serialize calls). However, there is a usage limit: you cannot post more than 1000 KB of serialized data. All draw coordinates are measured in global game coordinates (RoomPosition).All draw coordinates are measured in global game coordinates (RoomPositionRoomPositionRoomPosition).</summary>
and GameMapVisual =

    ///<summary>Add previously exported (with Game.map.visual.export) map visuals to the map visual data of the current tick. </summary>
    ///<param name="value">The string returned from Game.map.visual.export.</param>
    ///<returns>The MapVisual object itself, so that you can chain calls.</returns>
    abstract import: value: String -> GameMapVisual    
    ///<summary>Returns a compact representation of all visuals added on the map in the current tick.</summary>
    ///<returns>A string with visuals data. There's not much you can do with the string besides store them for later.</returns>
    abstract export: unit -> string  
    ///<summary>Get the stored size of all visuals added on the map in the current tick. It must not exceed 1024,000 (1000 KB).</summary>
    ///<returns>A string with visuals data. There's not much you can do with the string besides store them for later.</returns>
    abstract getSize: unit -> int32  
    ///<summary>Remove all visuals from the map.</summary>
    ///<returns>The MapVisual object itself, so that you can chain calls.</returns>
    abstract clear: unit -> GameMapVisual
    ///<summary>Draw a text label. You can use any valid Unicode characters, including emoji.</summary>
    ///<param name="text">The text message.</param>
    ///<param name="pos">The position object of the label baseline.</param>
    ///<param name="style">An object with the following properties:</param>
    ///<returns>The MapVisual object itself, so that you can chain calls.</returns>
    abstract text: text: String * pos: RoomPosition * ?style: GameMapVisualtextstyleOpts -> GameMapVisual
    ///<summary>Draw a polyline.</summary>
    ///<param name="points">An array of points. Every item should be a RoomPosition object.</param>
    ///<param name="style">An object with the following properties:</param>
    ///<returns>The MapVisual object itself, so that you can chain calls.</returns>
    abstract poly: points:  RoomPosition array * ?style: GameMapVisualpolystyleOpts -> GameMapVisual
    ///<summary>Draw a rectangle.</summary>
    ///<param name="topLeftPos">The position object of the top-left corner.</param>
    ///<param name="width">The width of the rectangle.</param>
    ///<param name="height">The height of the rectangle.</param>
    ///<param name="style">An object with the following properties:fillstring Fill color in the following format: #ffffff (hex triplet). Default is #ffffff. opacitynumberOpacity value, default is 0.5.strokestring Stroke color in the following format: #ffffff (hex triplet). Default is undefined (no stroke). strokeWidthnumberStroke line width, default is 0.5.lineStylestring Either undefined (solid line), dashed, or dotted. Default is undefined.</param>
    ///<returns>The MapVisual object itself, so that you can chain calls.</returns>
    abstract rect: topLeftPos: RoomPosition * width: Int32 * height: Int32 * ?style: GameMapVisualrectstyleOpts -> GameMapVisual   
    ///<summary>Draw a circle.</summary>
    ///<param name="pos">The position object of the center.</param>
    ///<param name="style">An object with the following properties:radiusnumberCircle radius, default is 10.fillstring Fill color in the following format: #ffffff (hex triplet). Default is #ffffff. opacitynumberOpacity value, default is 0.5.strokestring Stroke color in the following format: #ffffff (hex triplet). Default is undefined (no stroke). strokeWidthnumberStroke line width, default is 0.5.lineStylestring Either undefined (solid line), dashed, or dotted. Default is undefined.</param>
    ///<returns>The MapVisual object itself, so that you can chain calls.</returns>
    abstract circle: pos: RoomPosition * ?style: GameMapVisualcirclestyleOpts -> GameMapVisual 
    ///<summary>Draw a line.</summary>
    ///<param name="pos1">The start position object.</param>
    ///<param name="pos2">The finish position object.</param>
    ///<param name="style">An object with the following properties:widthnumberLine width, default is 0.1.colorstring Line color in the following format: #ffffff (hex triplet). Default is #ffffff. opacitynumberOpacity value, default is 0.5.lineStylestring Either undefined (solid line), dashed, or dotted. Default is undefined.</param>
    ///<returns>The MapVisual object itself, so that you can chain calls.</returns>
    abstract line: pos1: RoomPosition * pos2: RoomPosition * ?style: GameMapVisuallinestyleOpts -> GameMapVisual
///<summary></summary>
and GameMapGameMapFindRouteOpts =


    ///<summary>This callback accepts two arguments: function(roomName, fromRoomName). It can be used to calculate the cost of entering that room. You can use this to do things like prioritize your own rooms, or avoid some rooms. You can return a floating point cost or Infinity to block the room.</summary>
    abstract routeCallback:  ((string * string) -> double)  option
and [<StringEnum>] RoomStatus = 
    | Normal
    | Closed
    | Novice
    | Respawn
and GameMapGetRoomStatusResult =
    ///<summary>One of the following string values: </summary>
    ///<returns><list type="bullet"><listheader><term>string value</term><description></description></listheader>
    ///<item><term>normal</term><description>the room has no restrictions</description></item>
    ///<item><term>closed</term><description>the room is not available</description></item>
    ///<item><term>novice</term><description>the room is part of a novice area</description></item>
    ///<item><term>respawn</term><description>the room is part of a respawn area</description></item>
    ///</list></returns>
    abstract status: RoomStatus
    ///<summary>Status expiration time in milliseconds since UNIX epoch time. This property is null if the status is permanent.  </summary>
    abstract timestamp: int64
///<summary>A global object representing world map. Use it to navigate between rooms.A global object representing world map. Use it to navigate between rooms.</summary>
and GameMapFindRouteResult =
    | FindRouteArray of {|exit: Find; room: string|}
    | FindRouteError of ScreepCode
and GameMapFindExitResult =
    | FindExitConstant of Find
    | FindExitError of ScreepCode
and Map =

    abstract visual: GameMapVisual
    ///<summary>Gets availablity status of the room with the specified name. Learn more about starting areas from this article.</summary>
    ///<param name="roomName">The room name.</param>
    abstract getRoomStatus: roomName: String -> GameMapGetRoomStatusResult     
    ///<summary>Returns the world size as a number of rooms between world corners. For example, for a world with rooms from W50N50 to E50S50 this method will return 102.</summary>
    abstract getWorldSize: unit -> int 
    ///<summary>Get a Room.Terrain object which provides fast access to static terrain data. This method works for any room in the world even if you have no access to it.</summary>
    ///<param name="roomName">The room name.</param>
    abstract getRoomTerrain: roomName: String -> RoomTerrain  
    ///<summary>Get the linear distance (in rooms) between two rooms. You can use this function to estimate the energy cost of sending resources through terminals, or using observers and nukes.</summary>
    ///<param name="roomName1">The name of the first room.</param>
    ///<param name="roomName2">The name of the second room.</param>
    ///<param name="continuous">Whether to treat the world map continuous on borders. Set to true if you want to calculate the trade or terminal send cost. Default is false.</param>
    abstract getRoomLinearDistance: roomName1: String * roomName2: String * ?continuous: Boolean -> int 
    ///<summary>Find route from the given room to another room.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>NoPath</term><description>Path can not be found.</description></item>
    ///</list></returns>
    ///<param name="fromRoom">Start room name or room object.</param>
    ///<param name="toRoom">Finish room name or room object.</param>
    ///<param name="opts">An object with the following options:</param>
    abstract findRoute: fromRoom: U2<String, Room> * toRoom: U2<String, Room> * ?opts: GameMapGameMapFindRouteOpts -> GameMapFindRouteResult    
    ///<summary>Find the exit direction from the given room en route to another room.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>NoPath</term><description>Path can not be found.</description></item>
    ///<item><term>InvalidArgs</term><description>The location is incorrect.</description></item>
    ///</list></returns>

    ///<param name="fromRoom">Start room name or room object.</param>
    ///<param name="toRoom">Finish room name or room object.</param>
    ///<param name="opts">An object with the pathfinding options. See findRoute.</param>
    abstract findExit: fromRoom: U2<String, Room> * toRoom: U2<String, Room> * ?opts:  GameMapGameMapFindRouteOpts -> GameMapFindExitResult    
    ///<summary>List all exits available from the room with the given name.</summary>
    ///<param name="roomName">The room name.</param>
    [<Emit("new Map(Object.entries(Game.map.describeExits($1)))")>]
    abstract describeExits: roomName: String -> Dictionary<Find, string>

///<summary>InterShardMemory object provides an interface for communicating between shards. Your script is executed separatedly on each shard, and their Memory objects are isolated from each other. In order to pass messages and data between shards, you need to use InterShardMemory instead.InterShardMemoryInterShardMemory object provides an interface for communicating between shards. Your script is executed separatedly on each shard, and their MemoryMemoryMemory objects are isolated from each other. In order to pass messages and data between shards, you need to use InterShardMemoryInterShardMemory instead.Every shard can have its own 100 KB of data in string format that can be accessed by all other shards. A shard can write only to its own data, other shards' data is read-only.Every shard can have its own 100 KB of data in string format that can be accessed by all other shards. A shard can write only to its own data, other shards' data is read-only.This data has nothing to do with Memory contents, it's a separate data container. This data has nothing to do with MemoryMemory contents, it's a separate data container. </summary>
and InterShardMemory =

    ///<summary>Returns the string contents of another shard's data.</summary>
    ///<param name="shard">Shard name.</param>
    abstract getRemote: shard: String -> string  
    ///<summary>Replace the current shard's data with the new value.</summary>
    ///<param name="value">New data value in string format.</param>
    abstract setLocal: value: String -> unit    
    ///<summary>Returns the string contents of the current shard's data. </summary>
    abstract getLocal: unit -> string
///<summary></summary>
and GameGameShardResult =


    ///<summary>The name of the shard.</summary>
    abstract name:  String

    ///<summary>Currently always equals to normal.</summary>
    abstract Type:  String

    ///<summary>Whether this shard belongs to the PTR.</summary>
    abstract ptr:  Boolean
///<summary></summary>
and GameGameGplResult =


    ///<summary>The current level.</summary>
    abstract level:  Int32

    ///<summary>The current progress to the next level.</summary>
    abstract progress:  Int32

    ///<summary>The progress required to reach the next level.</summary>
    abstract progressTotal:  Int32
///<summary></summary>
and GameGameGclResult =


    ///<summary>The current level.</summary>
    abstract level:  Int32

    ///<summary>The current progress to the next level.</summary>
    abstract progress:  Int32

    ///<summary>The progress required to reach the next level.</summary>
    abstract progressTotal:  Int32
///<summary></summary>
and CPU =

    ///<summary>Your assigned CPU limit for the current shard.</summary>
    abstract limit:  int32

    ///<summary>An amount of available CPU time at the current game tick. Usually it is higher than Game.cpu.limit. Learn more</summary>
    abstract tickLimit:  int32

    ///<summary>An amount of unused CPU accumulated in your bucket.</summary>
    abstract bucket:  int32

    ///<summary>An object with limits for each shard with shard names as keys. You can use setShardLimits method to re-assign them.</summary>
    [<Emit("new Map(Object.entries(Game.cpu.shardLimits))")>]
    abstract shardLimits: Dictionary<string, int>

    ///<summary>Whether full CPU is currently unlocked for your account.</summary>
    abstract unlocked:  Boolean

    ///<summary>The time in milliseconds since UNIX epoch time until full CPU is unlocked for your account. This property is not defined when full CPU is not unlocked for your account or it's unlocked with a subscription.</summary>
    abstract unlockedTime:  int64

    ///<summary>Generate 1 pixel resource unit for 10000 CPU from your bucket.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotEnoughResources</term><description>Your bucket does not have enough CPU.</description></item>
    ///</list></returns>
    abstract generatePixel: unit -> ScreepCode    
    ///<summary>Unlock full CPU for your account for additional 24 hours. This method will consume 1 CPU unlock bound to your account (See Game.resources). If full CPU is not currently unlocked for your account, it may take some time (up to 5 minutes) before unlock is applied to your account.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NotEnoughResources</term><description>Your account does not have enough cpuUnlock resource.</description></item>
    ///<item><term>Full</term><description>Your CPU is unlocked with a subscription.</description></item>
    ///</list></returns>
    abstract unlock: unit -> ScreepCode   
    ///<summary>Allocate CPU limits to different shards. Total amount of CPU should remain equal to Game.cpu.shardLimits. This method can be used only once per 12 hours.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>Busy</term><description>12-hours cooldown period is not over yet.</description></item>
    ///<item><term>InvalidArgs</term><description>The argument is not a valid shard limits object.</description></item>
    ///</list></returns>

    ///<param name="limits">An object with CPU values for each shard in the same format as Game.cpu.shardLimits.</param>
    abstract setShardLimits: limits:  obj -> ScreepCode    
    ///<summary>This method is only available when Virtual machine is set to Isolated in your account runtime settings.</summary>
    abstract halt: unit -> unit 
    ///<summary>Get amount of CPU time used from the beginning of the current game tick. Always returns 0 in the Simulation mode.</summary>
    ///<returns>Returns currently used CPU time as a float number.</returns>
    abstract getUsed: unit -> double    
    ///<summary>This method is only available when Virtual machine is set to Isolated in your account runtime settings.</summary>
    abstract getHeapStatistics: unit -> HeapStatisctic 

///<summary>The main global game object containing all the game play information.The main global game object containing all the game play information.</summary>
and HeapStatisctic = {
   total_heap_size: int64
   total_heap_size_executable: int64
   total_physical_size: int64
   total_available_size: int64
   used_heap_size: int64
   heap_size_limit: int64
   malloced_memory: int64
   peak_malloced_memory: int64
   does_zap_garbage: int64
   externally_allocated_size: int64
}
and Game =

    ///<summary>Send a custom message at your profile email. This way, you can set up notifications to yourself on any occasion within the game. You can schedule up to 20 notifications during one game tick. Not available in the Simulation Room.</summary>
    ///<param name="message">Custom text which will be sent in the message. Maximum length is 1000 characters.</param>
    ///<param name="groupInterval">If set to 0 (default), the notification will be scheduled immediately. Otherwise, it will be grouped with other notifications and mailed out later using the specified time in minutes.</param>
    abstract notify: message: String * groupInterval: Int32 -> unit    
    ///<summary>Get an object with the specified unique ID. It may be a game object of any type. Only objects from the rooms which are visible to you can be accessed.</summary>
    ///<param name="id">The unique identificator.</param>
    ///<returns>Returns an object instance or null if it cannot be found.</returns>
    abstract getObjectById<'T> : id: String -> 'T option
    ///<summary>System game tick counter. It is automatically incremented on every tick. Learn more</summary>
    abstract time:  Int64
    ///<summary>A hash containing all your structures with structure id as hash keys.</summary>
    [<Emit("new Map(Object.entries(Game.structures))")>]
    abstract structures:  Dictionary<string, Structure>
    ///<summary>A hash containing all your spawns with spawn names as hash keys.</summary>
    [<Emit("new Map(Object.entries(Game.spawns))")>]
    abstract spawns: Dictionary<string, StructureSpawn>
    ///<summary>An object describing the world shard where your script is currently being executed in.</summary>
    abstract shard:  GameGameShardResult
    ///<summary>A hash containing all the rooms available to you with room names as hash keys. A room is visible if you have a creep or an owned structure in it.</summary>
    [<Emit("new Map(Object.entries(Game.rooms))")>]
    abstract rooms:  Dictionary<string, Room>
    ///<summary>An object with your global resources that are bound to the account, like pixels or cpu unlocks. Each object key is a resource constant, values are resources amounts.</summary>
    [<Emit("new Map(Object.entries(Game.resources))")>]
    abstract resources: Dictionary<ResourceType, int>
    ///<summary>A hash containing all your power creeps with their names as hash keys. Even power creeps not spawned in the world can be accessed here. </summary>
    [<Emit("new Map(Object.entries(Game.powerCreeps))")>]
    abstract powerCreeps: Dictionary<string, PowerCreep>
    ///<summary>A global object representing the in-game market. See the documentation below.</summary>
    abstract market:   Market 
    ///<summary>A global object representing world map. See the documentation below.</summary>
    abstract map:   Map 
    ///<summary>Your Global Power Level, an object with the following properties :</summary>
    abstract gpl:  GameGameGplResult
    ///<summary>Your Global Control Level, an object with the following properties :</summary>
    abstract gcl:  GameGameGclResult
    ///<summary>A hash containing all your flags with flag names as hash keys.</summary>
    [<Emit("new Map(Object.entries(Game.flags))")>]
    abstract flags:  Dictionary<string, Flag>
    ///<summary>A hash containing all your creeps with creep names as hash keys.</summary>
    [<Emit("new Map(Object.entries(Game.creeps))")>]
    abstract creeps:  Dictionary<string, Creep>
    ///<summary>An object containing information about your CPU usage with the following properties:</summary>
    abstract cpu:  CPU
    ///<summary>A hash containing all your construction sites with their id as hash keys.</summary>
    [<Emit("new Map(Object.entries(Game.constructionSites))")>]
    abstract constructionSites:  Dictionary<string, ConstructionSite>

let [<Global>] Game: Game = jsNative
let [<Global>] InterShardMemory: InterShardMemory = jsNative
let [<Global>] Memory: Memory = jsNative
let [<Global>] PathFinder: PathFinder = jsNative
let [<Global>] RawMemory: RawMemory = jsNative

type RoomPositionStatic =
    [<EmitConstructor>]
    ///<summary>You can create new RoomPosition object using its constructor.</summary>
    ///<param name="x">X position in the room.</param>
    ///<param name="y">Y position in the room.</param>
    ///<param name="roomName">The room name.</param>
    abstract Create: x: int * y: int * roomName: string -> RoomPosition

let [<Global>] RoomPosition: RoomPositionStatic = jsNative

type PowerCreepStatic =
    ///<summary>A static method to create new Power Creep instance in your account. It will be added in an unspawned state, use spawn method to spawn it in the world.</summary>
    ///<returns><list type="bullet"><listheader><term>code</term><description></description></listheader>
    ///<item><term>OK</term><description>The operation has been scheduled successfully.</description></item>
    ///<item><term>NameExists</term><description>A power creep with the specified name already exists.</description></item>
    ///<item><term>NotEnoughResources</term><description>You don't have free Power Levels in your account.</description></item>
    ///<item><term>InvalidArgs</term><description>The provided power creep name is exceeds the limit, or the power creep class is invalid.</description></item>
    ///</list></returns>
    ///<param name="name">The name of the new power creep. The name length limit is 100 characters.</param>
    ///<param name="className">The class of the new power creep, one of the POWER_CLASS constants.</param>
    abstract create: name: String * className: PowerClass -> ScreepCode

let [<Global>] PowerCreep: PowerCreepStatic = jsNative

type RoomStatic =
    ///<summary>Deserialize a short string path representation into an array form.</summary>
    ///<param name="path">A serialized path string.</param>
    ///<returns>A path array.</returns>
    abstract deserializePath: path: String -> PathSegment list
    ///<summary>Serialize a path array into a short string representation, which is suitable to store in memory.</summary>
    ///<param name="path">A path array retrieved from Room.findPath.</param>
    ///<returns>A serialized string form of the given path.</returns>
    abstract serializePath: path:  PathSegment array  -> string

let [<Global>] Room: RoomStatic = jsNative

type RoomVisualStatic = 
    [<EmitConstructor>]
    ///<summary>You can directly create new RoomVisual object in any room, even if it's invisible to your script.</summary>
    ///<param name="roomName">The room name. If undefined, visuals will be posted to all rooms simultaneously.</param>
    abstract Create: ?roomName: string -> RoomVisual

let [<Global>] RoomVisual: RoomVisualStatic = jsNative

type PathFinderCostMatrixStatic = 
    [<Emit("PathFinder.CostMatrix.deserialize($1)")>]
    ///<summary>Static method which deserializes a new CostMatrix using the return value of serialize.</summary>
    ///<param name="value">Whatever serialize returned</param>
    abstract deserialize: value: int array -> PathFinderCostMatrix  
    [<Emit("new PathFinder.CostMatrix")>]
    ///<summary>Creates a new CostMatrix containing 0's for all positions. </summary>
    abstract Create: unit -> PathFinderCostMatrix

let [<Global>] PathFinderCostMatrix: PathFinderCostMatrixStatic = jsNative

type RoomTerraintStatic = 
    [<Emit("new Room.Terrain($1)")>]
    ///<summary>Creates a new Terrain of room by its name. Terrain objects can be constructed for any room in the world even if you have no access to it.</summary>
    ///<param name="roomName">The room name.</param>
    abstract Create: roomName: String -> RoomTerrain

let [<Global>] RoomTerrain: RoomTerraintStatic = jsNative