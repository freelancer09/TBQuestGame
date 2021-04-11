using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace TBQuestGame.Models
{
    interface ITrade
    {
        ObservableCollection<GameItem> Inventory { get; set; }
        void AddGameItemToInventory(GameItem selectedGameItem);
        void RemoveGameItemFromInventory(GameItem selectedGameItem);

    }
}
