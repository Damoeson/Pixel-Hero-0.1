using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Damoeson
{
    public class PlayerInteractState : PlayerAbilityState
    {
        public PlayerInteractState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
        {
        }
    }
}
