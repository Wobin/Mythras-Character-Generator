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
        public class DeleteCharacterHandler : ActionHandler<DeleteCharacterAction>
        {
            public DeleteCharacterHandler(IStore aStore) : base(aStore) { }

            CharacterListState CharacterListState => Store.GetState<CharacterListState>();

            public override Task<Unit> Handle(DeleteCharacterAction aAction, CancellationToken aCancellationToken)
            {
                var oldRecord = CharacterListState.SavedList.Where(s => s.Id == aAction.PlayerId).FirstOrDefault();
                if (oldRecord != null) CharacterListState.SavedList.Remove(oldRecord);

                return Unit.Task;
            }
        }
    }
}
