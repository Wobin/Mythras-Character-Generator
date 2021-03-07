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

namespace MythrasCharacterGenerator.Features.CharacterList
{
    public partial class CharacterListState : State<CharacterListState>
    {        
        public List<Player> SavedList { get; private set; }
        public override void Initialize() => SavedList = new();
        public event Action UpdatedList;
    }
}
