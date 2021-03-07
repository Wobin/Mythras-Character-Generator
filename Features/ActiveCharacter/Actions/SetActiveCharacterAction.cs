using BlazorState;
using MythrasCharacterGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MythrasCharacterGenerator.Features.ActiveCharacter
{
    public partial class ActiveCharacterState { 
    public class SetActiveCharacterAction : IAction
    {
            public Player TargetPlayer { get; set; }
    }
    }
}
