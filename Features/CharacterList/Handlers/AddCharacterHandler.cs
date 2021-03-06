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
        public class AddCharacterHandler : ActionHandler<AddCharacterAction>
        {
            public AddCharacterHandler(IStore aStore) : base(aStore) { }

            CharacterListState CharacterListState => Store.GetState<CharacterListState>();

            public override Task<Unit> Handle(AddCharacterAction aAction, CancellationToken aCancellationToken)
            {
                var oldRecord = CharacterListState.SavedList.Where(s => s.Id == aAction.NewPlayer.Id).FirstOrDefault();
                if (oldRecord != null) CharacterListState.SavedList.Remove(oldRecord);

                aAction.NewPlayer.ModifiedDate = DateTime.UtcNow;

                CharacterListState.SavedList.Add(aAction.NewPlayer);

                return Unit.Task;
            }
        }
    }
}
