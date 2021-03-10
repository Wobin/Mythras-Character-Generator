using BlazorState;
using MythrasCharacterGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MythrasCharacterGenerator.Features.DiceBox
{
    public partial class DiceBoxState { 
    public class SetActiveDiceBoxAction : IAction
    {
            public DicePool TargetPool { get; set; }
    }
    }
}
