﻿using EleCho.GoCqHttpSdk.Action.Model.ResultData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EleCho.GoCqHttpSdk.Action
{
    public class CqGetUnidirectionalFriendListActionResult : CqActionResult
    {
        internal CqGetUnidirectionalFriendListActionResult() { }

        public IReadOnlyList<CqFriend> Friends { get; private set; } = new List<CqFriend>(0).AsReadOnly();

        internal override void ReadDataModel(CqActionResultDataModel? model)
        {
            if (model is not CqGetUnidirectionalFriendListActionResultDataModel m)
                throw new ArgumentException();

            Friends = m.Select(fm => new CqFriend(fm)).ToList().AsReadOnly();
        }
    }
}