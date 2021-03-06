using BlazorState;
using MythrasCharacterGenerator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MythrasCharacterGenerator.Features.CharacterList
{
    public partial class CharacterListState { 
    public class SetCharacterListAction : IAction
    {
            public List<Player> storedList { get; set; }
    }
    }
}
