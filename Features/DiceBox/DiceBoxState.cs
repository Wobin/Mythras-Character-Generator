using BlazorState;
using MythrasCharacterGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MythrasCharacterGenerator.Features.DiceBox
{
    public partial class DiceBoxState :State<DiceBoxState>
    {
        public DicePool TargetPool { get; private set; }
        public override void Initialize() => TargetPool = new();        
    }
    
}
