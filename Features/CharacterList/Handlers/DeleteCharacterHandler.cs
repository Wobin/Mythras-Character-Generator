using Blazored.LocalStorage;
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
            private ILocalStorageService LocalStorage;
            public DeleteCharacterHandler(IStore aStore, ILocalStorageService localStorage) : base(aStore) 
            {
                LocalStorage = localStorage;
            }

            CharacterListState CharacterListState => Store.GetState<CharacterListState>();

            public override async Task<Unit> Handle(DeleteCharacterAction aAction, CancellationToken aCancellationToken)
            {
                var oldRecord = CharacterListState.SavedList.Where(s => s.Id == aAction.PlayerId).FirstOrDefault();
                if (oldRecord != null) CharacterListState.SavedList.Remove(oldRecord);

                CharacterListState.SavedList = CharacterListState.SavedList.OrderByDescending(s => s.ModifiedDate).ToList();

                await LocalStorage.SetItemAsync("StoredCharacterSheets", CharacterListState.SavedList);
                return new Unit();
            }
        }
    }
}
