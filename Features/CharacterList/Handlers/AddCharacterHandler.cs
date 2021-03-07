using Blazored.LocalStorage;
using BlazorState;
using MediatR;
using MythrasCharacterGenerator.Models;
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
            private ILocalStorageService LocalStorage;
            public AddCharacterHandler(IStore aStore, ILocalStorageService  localStorage) : base(aStore) 
            {
                LocalStorage = localStorage;
            }

            CharacterListState CharacterListState => Store.GetState<CharacterListState>();

            public override Task<Unit> Handle(AddCharacterAction aAction, CancellationToken aCancellationToken)
            {
                var oldRecord = CharacterListState.SavedList.Where(s => s.Id == aAction.NewPlayer.Id).FirstOrDefault();
                if (oldRecord != null) CharacterListState.SavedList.Remove(oldRecord);

                aAction.NewPlayer.ModifiedDate = DateTime.UtcNow;

                CharacterListState.SavedList.Add(aAction.NewPlayer);
                CharacterListState.SavedList = CharacterListState.SavedList.OrderByDescending(s => s.ModifiedDate).ToList();
                LocalStorage.SetItemAsync("StoredCharacterSheets", CharacterListState.SavedList);
                return Unit.Task;
            }
        }
    }
}
