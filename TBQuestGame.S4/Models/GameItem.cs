﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TBQuestGame.Models
{
    public class GameItem
    {
        #region ENUMS

        #endregion

        #region FIELDS

        #endregion

        #region PROPERTIES

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Value { get; set; }

        #endregion

        #region CONSTRUCTORS

        public GameItem()
        {

        }

        public GameItem(int id, string name, string description, int value)
        {
            Id = id;
            Name = name;
            Description = description;
            Value = value;
        }

        #endregion

        #region METHODS


        #endregion

    }
}
