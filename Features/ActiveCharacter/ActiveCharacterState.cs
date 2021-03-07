using Blazored.LocalStorage;
using BlazorState;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MythrasCharacterGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MythrasCharacterGenerator.Features.ActiveCharacter
{
    public partial class ActiveCharacterState : State<ActiveCharacterState>
    {        
        public Player ActiveCharacter { get; private set; }
        public override void Initialize() => ActiveCharacter = null;
    }
}
