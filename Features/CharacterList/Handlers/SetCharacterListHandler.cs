using BlazorState;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MythrasCharacterGenerator.Features.CharacterList
{
    public partial class CharacterListState
    {
        public class SetCharacterListHandler : ActionHandler<SetCharacterListAction>
        {
            public SetCharacterListHandler(IStore aStore) : base(aStore) { }

            CharacterListState CharacterListState => Store.GetState<CharacterListState>();

            public override Task<Unit> Handle(SetCharacterListAction aAction, CancellationToken aCancellationToken)
            {
                CharacterListState.SavedList = aAction.storedList;

                return Unit.Task;
            }
        }
    }
}
